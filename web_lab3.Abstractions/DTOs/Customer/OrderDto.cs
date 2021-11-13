using System.Collections.Generic;

namespace Abstractions.DTOs.Customer
{
    public class NewOrderDto
    {
        public List<NewOrderBookDto> Books { get; set; }
    }

    public class NewOrderBookDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}