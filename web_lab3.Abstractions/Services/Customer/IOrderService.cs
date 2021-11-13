using System.Threading.Tasks;
using Abstractions.DTOs.Customer;
using Abstractions.Entities;

namespace Abstractions.Services.Customer
{
    public interface IOrderService
    {
        // TODO userdata
        Task CreateOrder(NewOrderDto dto, string userId);
    }
}