using System.Threading.Tasks;
using Abstractions.DTOs;

namespace Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task<AuthDto> LoginAsync(LoginDto dto);

        Task<AuthDto> RegisterAsync(RegisterDto dto);

        Task LogoutAsync(string username);

        Task<RefreshTokenResponseDto> RefreshAsync(string refreshToken, string accessToken);
    }
}