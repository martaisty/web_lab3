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
    internal class SageService : ISageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SageService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<SageDto>> GetAllAsync() =>
            (await _uow.SageRepository.GetAllAsync())
            .Select(it => _mapper.Map<Sage, SageDto>(it))
            .ToList();


        public async Task<SageDto> GetAsync(int id) =>
            _mapper.Map<Sage, SageDto>(await _uow.SageRepository.GetByIdAsync(id));


        public async Task<SageDto> InsertAsync(CreateSageDto dto)
        {
            var sage = _mapper.Map<CreateSageDto, Sage>(dto);
            var books = await _uow.BookRepository.GetAllAsync(it => dto.Books.Contains(it.Id));
            sage.Books.AddRange(books);
            await _uow.SageRepository.InsertAsync(sage);
            await _uow.SaveAsync();
            return _mapper.Map<Sage, SageDto>(sage);
        }

        public async Task<SageDto> UpdateAsync(UpdateSageDto dto)
        {
            var existing = await _uow.SageRepository.GetByIdAsync(dto.Id);
            var sage = _mapper.Map(dto, existing);
            await UpdateSageBooks(dto.Books, sage);
            await _uow.SageRepository.UpdateAsync(sage);
            await _uow.SaveAsync();
            return _mapper.Map<Sage, SageDto>(sage);
        }

        public async Task DeleteAsync(int id)
        {
            await _uow.SageRepository.DeleteAsync(id);
            await _uow.SaveAsync();
        }

        private async Task UpdateSageBooks(List<int> selected, Sage sage)
        {
            var selectedHs = new HashSet<int>(selected);
            var existing = sage.Books.Select(s => s.Id).ToHashSet();
            var books = await _uow.BookRepository.GetAllAsync();
            foreach (var book in books)
            {
                if (selectedHs.Contains(sage.Id))
                {
                    if (!existing.Contains(sage.Id))
                    {
                        sage.Books.Add(book);
                    }
                }
                else if (existing.Contains(sage.Id))
                {
                    sage.Books.Remove(book);
                }
            }
        }
    }
}