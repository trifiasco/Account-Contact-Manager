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

                var accounts = AccountQueries.GetAllAccounts();
                var viewModel = MapperForAccount.MapToAccountViewModel(accounts);
                return View(viewModel);
        }

        public ActionResult Create()
        {
            Account account = new Account();
            var contacts = ContactQueries.GetAllContacts();
            account.Contacts = contacts;
            var viewModel = MapperForAccount.MapToAccountCreateViewModel(account);
            return View(viewModel);
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
                foreach (var contactSelectedId in accountCreateViewModel.ContactSelectId)
                {
                    var contact = ContactQueries.GetOneContact(contactSelectedId);
                    account.Contacts.Add(contact);
                }
                
                AccountQueries.InsertOneAccount(account);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }



        public ActionResult Edit(int id)
        {
                var account = AccountQueries.GetOneAccount(id);
                var contactSelectIds = new List<int>();
                foreach(var contact in account.Contacts)
                {
                    contactSelectIds.Add(contact.Id);
                }
                
                var contacts = ContactQueries.GetAllContacts();
                account.Contacts = contacts;
                var viewModel = MapperForAccount.MapToAccountEditViewModel(account,contactSelectIds);
                return View(viewModel);

        }


        [HttpPost]
        public ActionResult Edit(int id, AccountEditViewModel accountEditViewModel)
        {
            try
            {

                var accountUpdate = AccountQueries.GetOneAccount(id);

                accountUpdate.Id = accountEditViewModel.Id;
                accountUpdate.Name = accountEditViewModel.Name;
                //check if one old contact id is not in the new selected contact id, then remove it
                for (int i = 0; i < accountUpdate.Contacts.Count; i++)
                {
                    var contact = accountUpdate.Contacts[i];
                    if (!accountEditViewModel.ContactSelectId.Contains(contact.Id))
                    {
                        accountUpdate.Contacts.Remove(contact);
                    }
                }

                //check if one new contact is not in the old contact list, then add it
                foreach (var contactId in accountEditViewModel.ContactSelectId)
                {   
                    var contact = ContactQueries.GetOneContact(contactId);
                    if (accountUpdate.Contacts.Where(x=>x.Id==contact.Id).ToList().Count==0)
                    {
                        accountUpdate.Contacts.Add(contact);
                    }
                }

                AccountQueries.InsertOneAccount(accountUpdate);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Details(int id)
        {

            var account = AccountQueries.GetOneAccount(id);
            var viewModel = MapperForAccount.MapToAccountDetailsViewModel(account);
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
                var account = AccountQueries.GetOneAccount(id);
                return View(account);
        }


        [HttpPost]
        public ActionResult Delete(int id, Account account)
        {
            try
            {
                AccountQueries.DeleteOneAccount(account);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

    }
}