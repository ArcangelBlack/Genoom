using Core.Configurations;
using System.Collections.Generic;

namespace Core.Mapper
{
    public class PersonEntityMapper : EntityMapper
    {
        public PersonEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new PersonMap() as IEntityMap,
                new FamilyMap() as IEntityMap
            };
        }
    }
}
