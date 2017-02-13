
using Core.DbContexts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ConfigDbContext DbContext;

        private Boolean Disposed;

        #region Constructor and Destructor

        public PersonRepository(ConfigDbContext dbContext)
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

        public Task<Person> GetPersonByIdAsync(int Id)
        {
            return DbContext.Set<Person>().FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<int> AddPersonAsync(Person entity)
        {
            DbContext.Set<Person>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity.Id.Value;
        }

    }
}
