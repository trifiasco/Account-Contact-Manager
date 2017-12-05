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
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Message = "Your Contact page is here.";
            using (ISession session = NHibernateSession.OpenSessionForContact())
            {
                var contact = session.Query<Contact>().ToList();
                return View(contact);
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
                Contact contact = new Contact();     //  Creating a new instance of the account
                contact.Id = Convert.ToInt32(collection["Id"]);
                contact.FirstName = collection["FirstName"].ToString();
                contact.LastName = collection["LastName"].ToString();
                contact.Email = collection["Email"].ToString();



                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSessionForContact())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(contact); //  Save the book in session
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

    }
}