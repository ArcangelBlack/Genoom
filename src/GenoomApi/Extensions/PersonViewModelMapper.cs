using Core.Entities;
using GenoomApi.ViewModels;

namespace GenoomApi.Extensions
{
    public static class PersonViewModelMapper
    {
        public static PersonVm ToViewModel(this Person entity)
        {
            return entity == null ? null : new PersonVm
            {
                Id = entity.Id,
                Name = entity.Name,
                Lastname = entity.Lastname,
                Birthdate = entity.Birthdate,
                Deathdate = entity.Deathdate,
                Sex = entity.Sex == true ? Enums.Sex.Woman : Enums.Sex.Man,
            };
        }

        public static Person ToEntity(this PersonVm viewModel)
        {
            return viewModel == null ? null : new Person
            {
                Name = viewModel.Name,
                Lastname = viewModel.Lastname,
                Birthdate = viewModel.Birthdate,
                Deathdate = viewModel.Deathdate,
                Sex = viewModel.Sex == Enums.Sex.Man ? false : true
            };
        }
    }
}
