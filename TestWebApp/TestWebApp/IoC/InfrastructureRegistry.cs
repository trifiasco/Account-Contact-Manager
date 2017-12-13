using StructureMap.Configuration.DSL;
using TestWebApp.Helper;

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
    }
  }
}