using System.Collections.Generic;

namespace Abstractions.DTOs.Admin
{
    public class OrderDto
    {
        public int Id { get; set; }

        public List<OrderedBookDto> Books { get; set; }

        public UserDataDto Customer { get; set; }
    }

    public class OrderedBookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<SageDto> Sages { get; set; }

        public int Quantity { get; set; }
    }
}