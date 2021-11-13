using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.DTOs;
using Abstractions.Entities;
using Abstractions.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BLL.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var signInResult = await _unitOfWork.SignInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = _unitOfWork.UserManager.Users.Single((u) => u.UserName == dto.UserName);
                return await GenerateJwtToken(user);
            }

            throw new ApplicationException("Login failed");
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = _mapper.Map<RegisterDto, User>(dto);
            var createResult = await _unitOfWork.UserManager.CreateAsync(user, dto.Password);

            if (!createResult.Succeeded)
            {
                throw new ApplicationException("RegisterFailed");
            }

            await _unitOfWork.SaveAsync();
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var jwt = _configuration.GetSection("Jwt");

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub,user.UserName),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier,user.Id)
            };
            
            var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwt["ExpireDays"]));

            var token = new JwtSecurityToken(
                jwt["Issuer"],
                jwt["Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}