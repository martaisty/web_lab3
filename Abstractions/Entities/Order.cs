using System.Collections.Generic;

namespace Abstractions.Entities
{
    public class Order: IEntity<int>
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; } = new();

        public List<OrdersBooks> OrdersDetails { get; set; } = new();
        
        public int CustomerId { get; set; }
        public User Customer { get; set; }
    }
}