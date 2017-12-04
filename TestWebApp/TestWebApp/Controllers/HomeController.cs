using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using TestWebApp.Models;
using TestWebApp.Entity;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            
            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Your account page is here.";
            using (ISession session = NHibernateSession.OpenSession())
            {
                var accounts = session.Query<Account>().ToList();
                return View(accounts);
            }
            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}