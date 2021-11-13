using System.Collections.Generic;

namespace Abstractions.DTOs.Customer
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<SageDto> Sages { get; set; }
    }
}