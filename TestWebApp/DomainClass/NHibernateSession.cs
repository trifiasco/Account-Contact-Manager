using NHibernate;
using NHibernate.Cfg;

namespace DomainClass
{
  public class NHibernateSession
  {
    private static ISessionFactory _sessionFactory;
    public static ISession OpenSession()
    {
      if(_sessionFactory==null)
      {
        var configuration = new Configuration();
        configuration.Configure(@"D:\WorkSpace\TestWebApp\DomainClass\NHibernate\hibernate.cfg.xml");
        configuration.AddFile(@"D:\WorkSpace\TestWebApp\DomainClass\NHibernate\Account.hbm.xml");
        configuration.AddFile(@"D:\WorkSpace\TestWebApp\DomainClass\NHibernate\Contact.hbm.xml");
        _sessionFactory = configuration.BuildSessionFactory();
      }
      return _sessionFactory.OpenSession();
    }
  }
}