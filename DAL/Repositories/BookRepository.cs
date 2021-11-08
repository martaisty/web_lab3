using System.Linq;
using Abstractions.Entities;
using Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        public BookRepository(DatabaseContext context) : base(context)
        {
        }

        protected override IQueryable<Book> ComplexEntities =>
            Context.Books
                .Include(b => b.Sages)
                .Include(b => b.Orders)
                .Include(b => b.OrdersDetails)
                .AsTracking();
    }
}