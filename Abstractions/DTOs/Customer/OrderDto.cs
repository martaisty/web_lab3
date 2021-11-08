using System.Collections.Generic;

namespace Abstractions.DTOs.Customer
{
    public class NewOrderDto
    {
        private List<NewOrderDto> Books { get; set; }
    }

    public class NewOrderBookDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}