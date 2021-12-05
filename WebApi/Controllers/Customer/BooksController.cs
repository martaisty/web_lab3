using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Customer;
using Abstractions.Services.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web_lab3.Helpers;

namespace web_lab3.Controllers.Customer
{
    [Route("api/customer/[controller]")]
    [ApiController]
    [Authorize(Roles = "CUSTOMER")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private ISession Session => HttpContext.Session;

        private Dictionary<int, int> Cart
        {
            get => Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            set => Session.Set("cart", value);
        }

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            return await _bookService.GetAllAsync();
        }

        [HttpGet]
        [Route("/api/customer/cart")]
        public async Task<ActionResult<string>> GetCart()
        {
            return await Task.Run(() => JsonConvert.SerializeObject(Cart));
        }

        [HttpPost]
        [Route("/api/customer/cart/{id}")]
        public async Task<ActionResult<string>> AddToCart(int id)
        {
            var cart = Cart;
            var quantity = cart.ContainsKey(id) ? cart[id] : 0;
            cart[id] = ++quantity;
            Cart = cart;
            return await Task.Run(() => JsonConvert.SerializeObject(Cart));
        }

        [HttpDelete]
        [Route("/api/customer/cart/{id}")]
        public async Task<ActionResult<string>> RemoveCart(int id)
        {
            var cart = Cart;
            if (!cart.ContainsKey(id))
            {
                return Ok();
            }

            cart[id]--;
            if (cart[id] <= 0)
            {
                cart.Remove(id);
            }

            Cart = cart;
            return await Task.Run(() => JsonConvert.SerializeObject(Cart));
        }
    }
}