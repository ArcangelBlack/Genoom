using Core.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Mapper
{
    public class PersonMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Person>();
            entity.ToTable("Person");
            entity.HasKey(p => new { p.Id });
            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
