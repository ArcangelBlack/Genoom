using GenoomApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenoomApi.Services
{
    public interface IPeopleService
    {
        Task<PersonVm> GetPersonById(int Id);

        Task<IEnumerable<FamilyVm>> GetFamilyById(int Id);

        Task<int> SaveParent(PersonVm value, int Id);

        Task<int> SaveChildren(PersonVm value, int Id);

        Task<IEnumerable<FamilyVm>> GetTreeByPersonId(int Id);
    }
}
