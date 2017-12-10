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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            ViewBag.Message = "Your account page is here.";
            using (ISession session = NHibernateSession.OpenSession())
            {
                var accounts = session.Query<Account>().ToList();
                var viewModel = MapperForAccount.MapToAccountViewModel(accounts);
                return View(viewModel);
            }
        }

        public ActionResult Create()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Account account = new Account();
                using (ISession sessionGetContacts = NHibernateSession.OpenSessionForContact())
                {
                    var contacts = sessionGetContacts.Query<Contact>().ToList();
                    account.Contacts = contacts;
                }
                var viewModel = MapperForAccount.MapToAccountCreateViewModel(account);
                return View(viewModel);
            }
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(AccountCreateViewModel accountCreateViewModel)
        {
            try
            {
                Account account = new Account();
                account.Id = accountCreateViewModel.Id;
                account.Name = accountCreateViewModel.Name;

                using (ISession session = NHibernateSession.OpenSessionForContact())
                {
                    var contact = session.Get<Contact>(accountCreateViewModel.ContactSelectId);
                    account.Contacts.Add(contact);
                }

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
                var account = session.Get<Account>(id);

                using (ISession sessionGetContacts = NHibernateSession.OpenSessionForContact())
                {
                    var contacts = sessionGetContacts.Query<Contact>().ToList();
                    account.Contacts = contacts;
                }

                var viewModel = MapperForAccount.MapToAccountEditViewModel(account);
                return View(viewModel);
            }

        }


        [HttpPost]
        public ActionResult Edit(int id, AccountEditViewModel accountEditViewModel)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var accountUpdate = session.Get<Account>(id);

                    accountUpdate.Id = accountEditViewModel.Id;
                    accountUpdate.Name = accountEditViewModel.Name;

                    using (ISession sessionGetContact = NHibernateSession.OpenSessionForContact())
                    {
                        var contact = sessionGetContact.Get<Contact>(accountEditViewModel.ContactSelectId);
                        accountUpdate.Contacts.Add(contact);
                    }

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

    }
}