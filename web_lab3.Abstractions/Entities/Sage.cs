using System.Collections.Generic;

namespace Abstractions.Entities
{
    public class Sage : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}