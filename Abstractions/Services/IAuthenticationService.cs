using System.Threading.Tasks;
using Abstractions.DTOs;

namespace Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto dto);

        Task RegisterAsync(RegisterDto dto);
    }
}