using StructureMap;

namespace TestWebApp.IoC
{
  public class StructureMapConfiguration
  {
    public static IContainer CreateContainer()
    {
      ObjectFactory.Initialize(
        c => c.Scan(s =>
        {
          s.TheCallingAssembly();
          s.LookForRegistries();
        }));

      ObjectFactory.Configure(x =>
      {
        x.AddRegistry<InfrastructureRegistry>();
      });

      return ObjectFactory.Container;
    }
  }
}