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
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employee = session.Get<Account>(id);
                return View(employee);
            }

        }


        [HttpPost]
        public ActionResult Edit(int id, Account account)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var accountUpdate = session.Get<Account>(id);

                    accountUpdate.Id = account.Id;
                    accountUpdate.Name = account.Name;
                    

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(accountUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}