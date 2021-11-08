using System.Threading.Tasks;
using Abstractions.DTOs.Customer;

namespace Abstractions.Services.Customer
{
    public interface IOrderService
    {
        // TODO userdata
        Task CreateOrder(NewOrderDto dto);
    }
}