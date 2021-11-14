using System.Threading.Tasks;
using Abstractions.DTOs.Customer;

namespace Abstractions.Services.Customer
{
    public interface IOrderService
    {
        Task CreateOrder(NewOrderDto dto, string userId);
    }
}