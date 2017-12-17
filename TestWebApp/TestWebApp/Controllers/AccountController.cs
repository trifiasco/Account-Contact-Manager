using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DomainClass.Entity;
using TestWebApp.Helper;
using TestWebApp.Models;
using DomainClass.QueryHelper;

namespace TestWebApp.Controllers
{
  public class AccountController : Controller
  {
    private readonly IAccountQueries _accountQueries;
    private readonly IContactQueries _contactQueries;
    private readonly IMapperForAccount _mapperForAccount;
    private readonly IMapperForContact _mapperForContact;

    public AccountController(IAccountQueries accountQueries, IContactQueries contactQueries,IMapperForAccount mapperForAccount,IMapperForContact mapperForContact)
    {
      _accountQueries = accountQueries;
      _contactQueries = contactQueries;
      _mapperForAccount = mapperForAccount;
      _mapperForContact = mapperForContact;
    }
    // GET: Account
    public ActionResult Index()
    {
      var accounts = _accountQueries.GetAll();
      var viewModel = _mapperForAccount.MapToAccountViewModel(accounts);
      return View(viewModel);
    }
    public ActionResult Create()
    {
      Account account = new Account();
      var contacts = _contactQueries.GetAll();
      account.Contacts = contacts;
      var viewModel = _mapperForAccount.MapToAccountCreateViewModel(account);
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
        account.DateCreated = DateTime.Now;
        account.DateUpdated = DateTime.Now;
        foreach (var contactSelectedId in accountCreateViewModel.ContactSelectId)
        {
          var contact = _contactQueries.GetOneById(contactSelectedId);
          account.Contacts.Add(contact);
        }

        _accountQueries.Save(account);
        return RedirectToAction("Index");
      }
      catch (Exception e)
      {
        return View();
      }
    }
    public ActionResult Edit(int id)
    {
      var account = _accountQueries.GetOneById(id);
      var contactSelectIds = new List<int>();
      foreach (var contact in account.Contacts)
      {
        contactSelectIds.Add(contact.Id);
      }

      var contacts = _contactQueries.GetAll();
      account.Contacts = contacts;
      var viewModel = _mapperForAccount.MapToAccountEditViewModel(account, contactSelectIds);
      return View(viewModel);
    }
    [HttpPost]
    public ActionResult Edit(int id, AccountEditViewModel accountEditViewModel)
    {
      try
      {
        var accountUpdate = _accountQueries.GetOneById(id);

        accountUpdate.Id = accountEditViewModel.Id;
        accountUpdate.Name = accountEditViewModel.Name;
        accountUpdate.DateUpdated = DateTime.Now;
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
          var contact = _contactQueries.GetOneById(contactId);
          if (accountUpdate.Contacts.Where(x => x.Id == contact.Id).ToList().Count == 0)
          {
            accountUpdate.Contacts.Add(contact);
          }
        }

        _accountQueries.Save(accountUpdate);

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
    public ActionResult Details(int id)
    {

      var account = _accountQueries.GetOneById(id);
      var viewModel = _mapperForAccount.MapToAccountDetailsViewModel(account);
      return View(viewModel);
    }
    public ActionResult Delete(int id)
    {
      var account = _accountQueries.GetOneById(id);
      return View(account);
    }
    [HttpPost]
    public ActionResult Delete(int id, Account account)
    {
      try
      {
        _accountQueries.Delete(account);
        return RedirectToAction("Index");
      }
      catch (Exception)
      {
        return View();
      }
    }
    public ActionResult IndexForCreatedInLastDays()
    {
      var accounts = _accountQueries.GetAllCreatedInLastDays();
      var viewModel = _mapperForAccount.MapToCreatedInLastDaysViewModel(accounts);
      return View(viewModel);
    }
    public ActionResult IndexForUpdatedInLastDays()
    {
      var accounts = _accountQueries.GetAllUpdatedInLastDays();
      var viewModel = _mapperForAccount.MapToUpdatedInLastDaysViewModel(accounts);
      return View(viewModel);
    }
  }
}