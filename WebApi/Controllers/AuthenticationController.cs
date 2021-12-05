using System;
using System.Threading.Tasks;
using Abstractions.DTOs;
using Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_lab3.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        private ISession Session => HttpContext.Session;

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
        public ActionResult Logout()
        {
            Session.Remove("cart");
            return Ok();
        }
    }
}