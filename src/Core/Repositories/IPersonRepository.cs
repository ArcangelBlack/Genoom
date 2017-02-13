using Core.Entities;
using System;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPersonRepository : IDisposable
    {

        Task<Person> GetPersonByIdAsync(int Id);


        Task<int> AddPersonAsync(Person Id);
    }
}
