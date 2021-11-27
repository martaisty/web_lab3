using System;
using System.Threading.Tasks;
using Abstractions.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using IAuthenticationService = Abstractions.Services.IAuthenticationService;

namespace web_lab3.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resultDto = await _authenticationService.RegisterAsync(dto);
            return Ok(resultDto);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var resultDto = await _authenticationService.LoginAsync(dto);
                return Ok(resultDto);
            }
            catch (ApplicationException)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            var userName = User.Identity?.Name;
            await _authenticationService.LogoutAsync(userName);
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            try
            {
                var userName = User.Identity?.Name;

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var result = await _authenticationService.RefreshAsync(request.RefreshToken, accessToken);
                return Ok(result);
            }
            catch (SecurityTokenException e)
            {
                return
                    Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }
    }
}