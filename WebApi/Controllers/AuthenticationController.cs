using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs;
using Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_lab3.Helpers;

namespace web_lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        private ISession Session => HttpContext.Session;

        private Dictionary<int, int> Cart
        {
            get => Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            set => Session.Set("cart", value);
        }

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            var resultDto = await _authenticationService.RegisterAsync(dto);
            Cart = null;
            return Ok(resultDto);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            try
            {
                var resultDto = await _authenticationService.LoginAsync(dto);
                Cart = null;
                return Ok(resultDto);
            }
            catch (ApplicationException)
            {
                return Unauthorized();
            }
        }
    }
}