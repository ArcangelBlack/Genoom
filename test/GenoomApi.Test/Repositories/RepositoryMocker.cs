using Core.Configurations;
using Core.DbContexts;
using Core.Mapper;
using Core.Repositories;
using GenoomApi.Services;
using Microsoft.Extensions.Options;

namespace GenoomApi.Test.Repositories
{
    public static class RepositoryMocker
    {
        public static IPersonRepository PersonRepository
        {
            get
            {
                var appSettings = Options.Create(new AppSettings
                {
                    ConnectionString = "Server=tcp:skj.database.windows.net,1433;Initial Catalog=genoomdb;Persist Security Info=False;User ID=kayl;Password=T3mp0r4L26.;integrated security=yes;"
                });

                var entityMapper = new PersonEntityMapper() as IEntityMapper;

                return new PersonRepository(new ConfigDbContext(appSettings, entityMapper)) as IPersonRepository;
            }
        }

        public static IFamilyRepository FamilyRepository
        {
            get
            {
                var appSettings = Options.Create(new AppSettings
                {
                    ConnectionString = "Server=tcp:skj.database.windows.net,1433;Initial Catalog=genoomdb;Persist Security Info=False;User ID=kayl;Password=T3mp0r4L26.;integrated security=yes;"
                });

                var entityMapper = new PersonEntityMapper() as IEntityMapper;

                return new FamilyRepository(new ConfigDbContext(appSettings, entityMapper)) as IFamilyRepository;
            }
        }

        public static IPeopleService  PeopleService
        {
            get
            {
                return new PeopleService(PersonRepository, FamilyRepository);
            }
        }
    }
}
