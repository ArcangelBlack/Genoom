using Core.Entities;
using Core.Repositories;
using GenoomApi.Enums;
using GenoomApi.Extensions;
using GenoomApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenoomApi.Services
{
    public class PeopleService : IPeopleService
    {
        #region Fields

        private readonly IPersonRepository personRepository;

        private readonly IFamilyRepository familyRepository;

        #endregion

        #region Constructor

        public PeopleService(IPersonRepository pRepository, IFamilyRepository fRepository)
        {
            this.personRepository = pRepository;
            this.familyRepository = fRepository;
        }

        #endregion

        public async Task<PersonVm> GetPersonById(int Id)
        {
            var response = new SingleModelResponse<PersonVm>() as ISingleModelResponse<PersonVm>;

            var entity = await personRepository.GetPersonByIdAsync(Id);
            if (entity != null)
            {
                return response.Model = entity.ToViewModel();
            }
            return null;
        }

        public async Task<IEnumerable<FamilyVm>> GetFamilyById(int Id)
        {
            var response = new ListModelResponse<FamilyVm>() as IListModelResponse<FamilyVm>;

            var familyList = await familyRepository.GetFamilyById(Id).ToListAsync();

            var listFamily = await this.GetFamilyModel(familyList);

            response.Model = listFamily;
            //response.Model = await familyRepository
            //        .GetFamilyById(Id)
            //        .Select(item => item.ToViewModel())
            //        .ToListAsync();

            return response.Model;
        }

        public async Task<int> SaveParent(PersonVm person, int Id)
        {
            var family = await this.GetFamilyById(Id);
            var result = -1;
            if (family != null)
            {
                var listFamily = family;
                if (person.Sex == Enums.Sex.Man)
                {
                    if (listFamily.Any(x => x.Relation != Enums.Relation.Fhater))
                    {
                        return await this.SaveRelation(person, Id, (int)Enums.Relation.Fhater);
                    }
                }
                else if (person.Sex == Enums.Sex.Woman)
                {
                    if (listFamily.Any(x => x.Relation != Enums.Relation.Mother))
                    {
                        return await this.SaveRelation(person, Id, (int)Enums.Relation.Mother);
                    }
                }
            }
            return result;
        }

        public async Task<int> SaveChildren(PersonVm person, int Id)
        {
            var family = this.GetFamilyById(Id);
            var result = -1;
            if (family != null)
            {
                foreach (var f in family.Result)
                {
                    if (f.Relation == Enums.Relation.Son || f.Relation == Enums.Relation.Wife)
                    {
                        var relation = person.Sex == Enums.Sex.Man ? (int)Enums.Relation.Son : (int)Enums.Relation.Wife;
                        return await this.SaveRelation(person, Id, relation);
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<FamilyVm>> GetTreeByPersonId(int Id)
        {
            var response = new ListModelResponse<FamilyVm>() as IListModelResponse<FamilyVm>;

            var tree = new List<Family>();
            tree = await familyRepository
              .GetTreeById(Id)
              .Select(item => item)
              .ToListAsync();           

            var parents2LevelIds = tree.Select(x => x.TargetPersonId);
            foreach (var p2 in parents2LevelIds)
            {
                var node2 = await familyRepository
              .GetTreeById(Id)
              .Select(item => item).ToListAsync();

                tree.AddRange(node2);
            }

            var result1Level = await this.GetFamilyModel(tree);
            var resultTree = new List<FamilyVm>();
            var resultLevels = result1Level.GroupBy(x => x.SourcePersonId).ToList();
            foreach(var r in result1Level)
            {
                
            }
            return response.Model;
        }

        #region Private Methods

        public async Task<int> SavePerson(PersonVm value)
        {
            var entity = await personRepository.AddPersonAsync(value.ToEntity());
            if (entity != -1)
            {
                return entity;
            }
            return -1;
        }

        private async Task<int> SaveRelation(PersonVm person, int Id, int relation)
        {
            var idNewPerson = await this.SavePerson(person);

            var newFamily = new Family();
            newFamily.Relation = relation;
            newFamily.SourcePersonId = Id;
            newFamily.TargetPersonId = idNewPerson;

            await familyRepository.AddFamilyAsync(newFamily);

            return idNewPerson;
        }

        private async Task<List<FamilyVm>> GetFamilyModel(List<Family> familyList)
        {
            var items = new List<FamilyVm>();

            foreach (var entity in familyList)
            {
                var item = new FamilyVm();
                item.Id = entity.Id;
                item.SourcePersonId = entity.SourcePersonId;
                item.SourcePerson = await GetPersonById(entity.SourcePersonId);
                item.TargetPersonId = entity.TargetPersonId;
                item.TargetPerson = await GetPersonById(entity.TargetPersonId);
                item.Relation = (Relation)Enum.ToObject(typeof(Relation), entity.Relation);
                items.Add(item);
            }
            return items;
        }



        #endregion
    }
}
