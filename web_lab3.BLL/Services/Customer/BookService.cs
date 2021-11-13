using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.DTOs.Customer;
using Abstractions.Entities;
using Abstractions.Services.Customer;
using AutoMapper;

namespace BLL.Services.Customer
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
    }
}