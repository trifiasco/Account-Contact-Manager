using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace TestWebApp.Models
{
  public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\NhibernateFolder\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var accountConfigurationFile = HttpContext.Current.Server.MapPath(@"~\NhibernateFolder\Account.hbm.xml");
            configuration.AddFile(accountConfigurationFile);
            var contactConfigurationFile = HttpContext.Current.Server.MapPath(@"~\NhibernateFolder\Contact.hbm.xml");
            configuration.AddFile(contactConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}