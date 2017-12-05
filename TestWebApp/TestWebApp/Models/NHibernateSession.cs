﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using TestWebApp.Entity;

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
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();

            //NHibernate.Bytecode.IProxyFactoryFactory;
            //NHibernate.Bytecode
            
        }
    }
}