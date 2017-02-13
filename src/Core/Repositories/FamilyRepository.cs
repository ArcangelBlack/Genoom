using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.DbContexts;

namespace Core.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly ConfigDbContext DbContext;

        private Boolean Disposed;

        #region Constructor and Destructor

        public FamilyRepository(ConfigDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                    Disposed = true;
                }
            }
        }

        #endregion

        public async Task<Family> AddFamilyAsync(Family entity)
        {
            DbContext.Set<Family>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public IQueryable<Family> GetFamilyById(int Id)
        {
            var query = DbContext.Set<Family>().Skip((1 - 1) * 100).Take(100);
            query = query.Where(item => item.SourcePersonId == Id);
            return query;
        }

        public IQueryable<Family> GetTreeById(int Id)
        {
            var query = DbContext.Set<Family>().Skip((1 - 1) * 100).Take(100);
            query = query.Where(item => item.SourcePersonId == Id && (item.Relation == 1 && item.Relation == 2));
            return query;
        }

    }
}
