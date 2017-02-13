using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Configurations
{
    public interface IEntityMapper
    {
        IEnumerable<IEntityMap> Mappings { get; }

        void MapEntities(ModelBuilder modelBuilder);
    }
}
