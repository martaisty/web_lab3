using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.DTOs.Admin;
using Abstractions.Entities;
using Abstractions.Services.Admin;
using AutoMapper;

namespace BLL.Services.Admin
{
    internal class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public BookService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<BookDto>> GetAllAsync() =>
            (await _uow.BookRepository.GetAllAsync())
            .Select(it => _mapper.Map<Book, BookDto>(it))
            .ToList();


        public async Task<BookDto> GetAsync(int id) =>
            _mapper.Map<Book, BookDto>(await _uow.BookRepository.GetByIdAsync(id));


        public async Task<BookDto> InsertAsync(CreateBookDto dto)
        {
            var book = _mapper.Map<CreateBookDto, Book>(dto);
            var sages = await _uow.SageRepository.GetAllAsync(s => dto.Sages.Contains(s.Id));
            book.Sages.AddRange(sages);
            await _uow.BookRepository.InsertAsync(book);
            await _uow.SaveAsync();
            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task<BookDto> UpdateAsync(UpdateBookDto dto)
        {
            var existing = await _uow.BookRepository.GetByIdAsync(dto.Id);
            var book = _mapper.Map(dto, existing);
            await UpdateBookSages(dto.Sages, book);
            await _uow.BookRepository.UpdateAsync(book);
            await _uow.SaveAsync();
            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _uow.BookRepository.DeleteAsync(id);
            await _uow.SaveAsync();
        }

        private async Task UpdateBookSages(List<int> selectedSages, Book book)
        {
            var selectedSagesHs = new HashSet<int>(selectedSages);
            var booksSages = book.Sages.Select(s => s.Id).ToHashSet();
            var sages = await _uow.SageRepository.GetAllAsync();
            foreach (var sage in sages)
            {
                if (selectedSagesHs.Contains(sage.Id))
                {
                    if (!booksSages.Contains(sage.Id))
                    {
                        book.Sages.Add(sage);
                    }
                }
                else if (booksSages.Contains(sage.Id))
                {
                    book.Sages.Remove(sage);
                }
            }
        }
    }
}