using Microsoft.EntityFrameworkCore;

namespace Core.Configurations
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
