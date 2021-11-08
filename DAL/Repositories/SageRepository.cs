using System.Linq;
using Abstractions.Entities;
using Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class SageRepository : BaseRepository<Sage, int>, ISageRepository
    {
        public SageRepository(DatabaseContext context) : base(context)
        {
        }

        protected override IQueryable<Sage> ComplexEntities =>
            Context.Sages
                .Include(s => s.Books)
                .AsTracking();
    }
}