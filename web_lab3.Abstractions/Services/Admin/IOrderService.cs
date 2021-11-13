using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Admin;

namespace Abstractions.Services.Admin
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();

        Task<OrderDto> GetAsync(int id);
    }
}