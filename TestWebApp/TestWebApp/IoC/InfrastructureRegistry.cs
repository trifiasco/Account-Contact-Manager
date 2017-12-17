using StructureMap.Configuration.DSL;
using TestWebApp.Helper;
using DomainClass.QueryHelper;

namespace TestWebApp.IoC
{
  public class InfrastructureRegistry : Registry
  {
    public InfrastructureRegistry()
    {
      For<IAccountQueries>().Use<AccountQueries>();
      For<IContactQueries>().Use<ContactQueries>();
      For<IMapperForAccount>().Use<MapperForAccount>();
      For<IMapperForContact>().Use<MapperForContact>();
      For<IMapperForHome>().Use<MapperForHome>();
    }
  }
}