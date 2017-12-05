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
    }
}