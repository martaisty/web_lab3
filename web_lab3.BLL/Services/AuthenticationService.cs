using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Auth;
using Abstractions.DTOs;
using Abstractions.Entities;
using Abstractions.Services;
using AutoMapper;

namespace BLL.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthDto> LoginAsync(LoginDto dto)
        {
            var user = await _unitOfWork.UserManager.FindByNameAsync(dto.UserName);
            if (user == null || !await _unitOfWork.UserManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new ApplicationException("Login failed");
            }

            var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
            var jwtResult = GenerateJwtToken(user, roles);
            var userDto = _mapper.Map<User, AuthorizedUserDto>(user);
            userDto.Roles = roles.ToList();
            return new AuthDto
            {
                User = userDto,
                AccessToken = jwtResult.AccessToken,
            };
        }

        public async Task<AuthDto> RegisterAsync(RegisterDto dto)
        {
            var user = _mapper.Map<RegisterDto, User>(dto);
            var createResult = await _unitOfWork.UserManager.CreateAsync(user, dto.Password);

            if (!createResult.Succeeded)
            {
                throw new ApplicationException("RegisterFailed");
            }

            await _unitOfWork.UserManager.AddToRoleAsync(user, "CUSTOMER");

            await _unitOfWork.SaveAsync();
            return await LoginAsync(new LoginDto {UserName = dto.UserName, Password = dto.Password});
        }

        private JwtAuthResult GenerateJwtToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.NameIdentifier, user.Id)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return _unitOfWork.JwtAuthManager.GenerateTokens(user.UserName, claims, DateTime.Now);
        }
    }
}