using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace DomainClass
{
  public class NHibernateSession
  {
    public static ISession OpenSession()
    {
      var configuration = new Configuration();//.AddAssembly("DomainClass");
      //var configurationPath = HttpContext.Current.Server.MapPath(@"~\DomainClass\NHibernate\hibernate.cfg.xml");
      //configuration.Configure(configurationPath);
      configuration.Configure(@"D:\WorkSpace\TestWebApp\DomainClass\NHibernate\hibernate.cfg.xml");
      //var accountConfigurationFile = HttpContext.Current.Server.MapPath(@"~\DomainClass\NHibernate\Account.hbm.xml");
      //configuration.AddFile(accountConfigurationFile);
      configuration.AddFile(@"D:\WorkSpace\TestWebApp\DomainClass\NHibernate\Account.hbm.xml");
      //var contactConfigurationFile = HttpContext.Current.Server.MapPath(@"~\DomainClass\NHibernate\Contact.hbm.xml");
      //configuration.AddFile(contactConfigurationFile);
      configuration.AddFile(@"D:\WorkSpace\TestWebApp\DomainClass\NHibernate\Contact.hbm.xml");
      ISessionFactory sessionFactory = configuration.BuildSessionFactory();
      return sessionFactory.OpenSession();
    }
  }
}