using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Admin;

namespace Abstractions.Services.Admin
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();

        Task<BookDto> GetAsync(int id);

        Task<BookDto> InsertAsync(CreateBookDto dto);

        Task<BookDto> UpdateAsync(UpdateBookDto dto);

        Task DeleteAsync(int id);
    }
}