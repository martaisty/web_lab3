using System;
using System.Threading.Tasks;
using Abstractions.DTOs;
using Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace web_lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            await _authenticationService.RegisterAsync(dto);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            try
            {
                var token = await _authenticationService.LoginAsync(dto);
                return Ok(new {token});
            }
            catch (ApplicationException)
            {
                return Unauthorized();
            }
        }
    }
}