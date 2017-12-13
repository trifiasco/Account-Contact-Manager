using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using TestWebApp.Entity;
using TestWebApp.Models;

namespace TestWebApp
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      Mapper.Initialize(cfg => {
        cfg.CreateMap<Account, AccountViewModel>();
        cfg.CreateMap<Account, AccountCreateViewModel>();
        cfg.CreateMap<Account, AccountDetailsViewModel>();
        cfg.CreateMap<Account, AccountEditViewModel>();

        cfg.CreateMap<Contact, ContactViewModel>();
        cfg.CreateMap<Contact, ContactCreateViewModel>();
        cfg.CreateMap<Contact, ContactDetailsViewModel>();
        cfg.CreateMap<Contact, ContactEditViewModel>();
      });
      //Mapper.Initialize();
    }
  }
}
