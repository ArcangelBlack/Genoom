using Core.Entities;
using GenoomApi.Enums;
using GenoomApi.ViewModels;
using System;

namespace GenoomApi.Extensions
{
    public static class FamilyViewModelMapper
    {
        public static FamilyVm ToViewModel(this Family entity)
        {
            return entity == null ? null : new FamilyVm
            {
                Id = entity.Id,
                SourcePersonId = entity.SourcePersonId,
                TargetPersonId = entity.TargetPersonId,
                Relation = (Relation)Enum.ToObject(typeof(Relation), entity.Relation),
            };
        }

        public static Family ToEntity(this FamilyVm viewModel)
        {
            return viewModel == null ? null : new Family
            {
                SourcePersonId = viewModel.SourcePerson.Id.Value,
                TargetPersonId = viewModel.TargetPerson.Id.Value,
                Relation = (int)viewModel.Relation
            };
        }
    }
}
