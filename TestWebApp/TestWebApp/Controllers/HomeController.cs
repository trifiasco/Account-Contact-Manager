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

        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Account account = new Account();     //  Creating a new instance of the account
                account.Id = Convert.ToInt32(collection["Id"]);
                account.Name = collection["Name"].ToString();
                

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(account); //  Save the book in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //ViewBag.Message = e.Message;
                //e.Message;
                return View();
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

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employee = session.Get<Account>(id);
                return View(employee);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var account = session.Get<Account>(id);
                return View(account);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Account account)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(account);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
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