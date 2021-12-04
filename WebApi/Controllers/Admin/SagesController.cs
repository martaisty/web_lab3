using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Admin;
using Abstractions.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web_lab3.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class SagesController : ControllerBase
    {
        private readonly ISageService _sageService;

        public SagesController(ISageService sageService)
        {
            _sageService = sageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SageDto>>> GetAll()
        {
            return await _sageService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SageDto>> Get(int id)
        {
            return await _sageService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<SageDto>> Insert([FromBody] CreateSageDto dto)
        {
            try
            {
                var sage = await _sageService.InsertAsync(dto);
                return StatusCode(200, sage);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSageDto dto)
        {
            try
            {
                var sage = await _sageService.UpdateAsync(dto);
                return StatusCode(200, sage);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Sage with id {dto.Id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sageService.DeleteAsync(id);
                return StatusCode(200);
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Sage with id {id} not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.InnerException);
            }
        }
    }
}