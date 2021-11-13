using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Admin;
using Abstractions.Services.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web_lab3.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IBookService _bookService;

        public DoctorController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            return await _bookService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            return await _bookService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Insert([FromBody] CreateBookDto dto)
        {
            try
            {
                var book = await _bookService.InsertAsync(dto);
                return StatusCode(200, book);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto dto)
        {
            try
            {
                var book = await _bookService.UpdateAsync(dto);
                return StatusCode(200, book);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Doctor with id {dto.Id} not found");
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
                await _bookService.DeleteAsync(id);
                return StatusCode(200, "OK");
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Doctor with id {id} not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.InnerException);
            }
        }
    }
}