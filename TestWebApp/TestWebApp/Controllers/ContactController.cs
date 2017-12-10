using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using TestWebApp.Models;
using TestWebApp.Entity;
using TestWebApp.Helper;

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
                var viewModel = Mapper.MapToContactViewModel(contact);
                return View(viewModel);
            }
        }

        public ActionResult Create()
        {
            // changes for associating dropdownlist- final
            using (ISession session = NHibernateSession.OpenSessionForContact())
            {
                Contact contact = new Contact();
                using (ISession sessionGetAccounts = NHibernateSession.OpenSession())
                {
                    var accounts = sessionGetAccounts.Query<Account>().ToList();
                    
                    contact.Accounts = accounts;
                }
                var viewModel = Mapper.MapToContactCreateViewModel(contact);
                return View(viewModel);
            }
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactCreateViewModel contactCreateViewModel)
        {
            try
            {
                Contact contact = new Contact();
                contact.Id = contactCreateViewModel.Id;
                contact.FirstName = contactCreateViewModel.FirstName;
                contact.LastName = contactCreateViewModel.LastName;
                contact.Email = contactCreateViewModel.Email;
                
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var account = session.Get<Account>(contactCreateViewModel.AccountOnSelect);
                    contact.Accounts.Add(account);
                }
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
                ViewBag.Message = "Contact Creation Failed. Try another Email.";
                //e.Message;
                return View();
            }
        }

        // GET: Contact/Edit
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateSession.OpenSessionForContact())
            {
                var contact = session.Get<Contact>(id);
                using (ISession sessionGetAccounts = NHibernateSession.OpenSession())
                {
                    var accounts = sessionGetAccounts.Query<Account>().ToList();

                    contact.Accounts = accounts;
                }
                var viewModel = Mapper.MapToContactEditViewModel(contact);
                return View(viewModel);
            }

        }

        [HttpPost]
        public ActionResult Edit(int id, ContactEditViewModel contactEditViewModel)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSessionForContact())
                {
                    var contactUpdate = session.Get<Contact>(id);

                    contactUpdate.Id = contactEditViewModel.Id;
                    contactUpdate.FirstName = contactEditViewModel.FirstName;
                    contactUpdate.LastName = contactEditViewModel.LastName;
                    contactUpdate.Email = contactEditViewModel.Email;

                    using (ISession sessionGetAccount = NHibernateSession.OpenSession())
                    {
                        var account = sessionGetAccount.Get<Account>(contactEditViewModel.AccountOnSelect);
                        contactUpdate.Accounts.Add(account);
                    }

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(contactUpdate);
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

        // GET: Contact/Details
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateSession.OpenSessionForContact())
            {
                var contact = session.Get<Contact>(id);
                var viewModel = Mapper.MapToContactDetailsViewModel(contact);
                return View(viewModel);
            }
        }


        //GET: Contact/Delete

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateSession.OpenSessionForContact())
            {
                var contact = session.Get<Contact>(id);
                return View(contact);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSessionForContact())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(contact);
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

    }
}