using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Configurations
{
    public class EntityMapper : IEntityMapper
    {
        public IEnumerable<IEntityMap> Mappings { get; protected set; }

        public void MapEntities(ModelBuilder modelBuilder)
        {
            foreach (var item in Mappings)
            {
                item.Map(modelBuilder);
            }
        }
    }
}
