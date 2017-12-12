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
      var contact = ContactQueries.GetAll();
      var viewModel = Mapper.MapToContactViewModel(contact);
      return View(viewModel);

    }

    public ActionResult Create()
    {
      // changes for associating dropdownlist- final

      Contact contact = new Contact();

      var accounts = AccountQueries.GetAll();
      contact.Accounts = accounts;

      var viewModel = Mapper.MapToContactCreateViewModel(contact);
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


        var account = AccountQueries.GetOneById(contactCreateViewModel.AccountOnSelect);
        contact.Accounts.Add(account);

        ContactQueries.Save(contact);

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
      var contact = ContactQueries.GetOneById(id);
      var accounts = AccountQueries.GetAll();
      contact.Accounts = accounts;

      var viewModel = Mapper.MapToContactEditViewModel(contact);
      return View(viewModel);

    }

    [HttpPost]
    public ActionResult Edit(int id, ContactEditViewModel contactEditViewModel)
    {
      try
      {

        var contactUpdate = ContactQueries.GetOneById(id);

        contactUpdate.Id = contactEditViewModel.Id;
        contactUpdate.FirstName = contactEditViewModel.FirstName;
        contactUpdate.LastName = contactEditViewModel.LastName;
        contactUpdate.Email = contactEditViewModel.Email;


        var account = AccountQueries.GetOneById(contactEditViewModel.AccountOnSelect);
        contactUpdate.Accounts.Add(account);


        ContactQueries.Save(contactUpdate);
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
      var contact = ContactQueries.GetOneById(id);
      var viewModel = Mapper.MapToContactDetailsViewModel(contact);
      return View(viewModel);
    }


    //GET: Contact/Delete

    public ActionResult Delete(int id)
    {

      var contact = ContactQueries.GetOneById(id);
      return View(contact);
    }


    [HttpPost]
    public ActionResult Delete(int id, Contact contact)
    {
      try
      {
        ContactQueries.Delete(contact);
        return RedirectToAction("Index");
      }
      catch (Exception exception)
      {
        return View();
      }
    }

  }
}