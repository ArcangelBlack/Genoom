using Core.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Mapper
{
    public class FamilyMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Family>();
            entity.ToTable("Relationships");
            entity.HasKey(p => new { p.Id });
            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
