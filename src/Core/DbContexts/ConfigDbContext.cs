using Core.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Core.DbContexts
{
    public class ConfigDbContext : DbContext
    {
        public ConfigDbContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;

            EntityMapper = entityMapper;
        }

        public String ConnectionString { get; }

        public IEntityMapper EntityMapper { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
