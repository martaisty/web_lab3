using Abstractions.Entities;

namespace Abstractions.Repositories
{
    public interface IBookRepository : IBaseRepository<Book, int> { }
}