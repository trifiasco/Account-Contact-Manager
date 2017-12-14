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
    private readonly IAccountQueries _accountQueries;
    private readonly IContactQueries _contactQueries;
    private readonly IMapperForAccount _mapperForAccount;
    private readonly IMapperForContact _mapperForContact;

    public ContactController(IAccountQueries accountQueries, IContactQueries contactQueries, IMapperForAccount mapperForAccount, IMapperForContact mapperForContact)
    {
      _accountQueries = accountQueries;
      _contactQueries = contactQueries;
      _mapperForAccount = mapperForAccount;
      _mapperForContact = mapperForContact;
    }
    // GET: Contact
    public ActionResult Index()
    {
      var contact = _contactQueries.GetAll();
      var viewModel = _mapperForContact.MapToContactViewModel(contact);
      return View(viewModel);

    }

    public ActionResult Create()
    {
      // changes for associating dropdownlist- final

      Contact contact = new Contact();

      var accounts = _accountQueries.GetAll();
      contact.Accounts = accounts;

      var viewModel = _mapperForContact.MapToContactCreateViewModel(contact);
      return View(viewModel);
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
        contact.DateCreated = DateTime.Now;
        contact.DateUpdated = DateTime.Now;

        var account = _accountQueries.GetOneById(contactCreateViewModel.AccountOnSelect);
        contact.Accounts.Add(account);

        _contactQueries.Save(contact);

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
      var contact = _contactQueries.GetOneById(id);
      var accounts = _accountQueries.GetAll();
      contact.Accounts = accounts;

      var viewModel = _mapperForContact.MapToContactEditViewModel(contact);
      return View(viewModel);

    }

    [HttpPost]
    public ActionResult Edit(int id, ContactEditViewModel contactEditViewModel)
    {
      try
      {

        var contactUpdate = _contactQueries.GetOneById(id);

        contactUpdate.Id = contactEditViewModel.Id;
        contactUpdate.FirstName = contactEditViewModel.FirstName;
        contactUpdate.LastName = contactEditViewModel.LastName;
        contactUpdate.Email = contactEditViewModel.Email;
        contactUpdate.DateUpdated = DateTime.Now;

        var account = _accountQueries.GetOneById(contactEditViewModel.AccountOnSelect);
        contactUpdate.Accounts.Add(account);


        _contactQueries.Save(contactUpdate);
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
      var contact = _contactQueries.GetOneById(id);
      var viewModel = _mapperForContact.MapToContactDetailsViewModel(contact);
      return View(viewModel);
    }


    //GET: Contact/Delete

    public ActionResult Delete(int id)
    {

      var contact = _contactQueries.GetOneById(id);
      return View(contact);
    }


    [HttpPost]
    public ActionResult Delete(int id, Contact contact)
    {
      try
      {
        _contactQueries.Delete(contact);
        return RedirectToAction("Index");
      }
      catch (Exception exception)
      {
        return View();
      }
    }

  }
}