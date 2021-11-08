using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Customer;

namespace Abstractions.Services.Customer
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
    }
}