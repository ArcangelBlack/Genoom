using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IFamilyRepository
    {
        IQueryable<Family> GetFamilyById(int Id);

        Task<Family> AddFamilyAsync(Family family);

        IQueryable<Family> GetTreeById(int Id);
    }
}
