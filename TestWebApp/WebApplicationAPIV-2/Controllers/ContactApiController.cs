using DomainClass.Entity;
using DomainClass.QueryHelper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPIV_2.Models;

namespace WebApplicationAPIV_2.Controllers
{
  [RoutePrefix("api/contacts")]
  public class ContactApiController : ApiController
  {
    
    [Route("")]
    [HttpGet]
    public IHttpActionResult Get()
    {
      List<Contact> contacts = new List<Contact>();

      ContactQueries _contactQueries = new ContactQueries();
      contacts = _contactQueries.GetAll();
      List<ContactModel> contactModels = new List<ContactModel>();

      foreach (var contact in contacts)
      {
        ContactModel contactModel = new ContactModel();
        contactModel.Id = contact.Id;
        contactModel.FirstName = contact.FirstName;
        contactModel.LastName = contact.LastName;
        contactModel.Email = contact.Email;

        foreach (var account in contact.Accounts)
        {
          AccountDetails accountDetails = new AccountDetails();
          accountDetails.Id = account.Id;
          accountDetails.Name = account.Name;

          contactModel.Accounts.Add(accountDetails);
        }
        contactModels.Add(contactModel);
      }
      return Ok(contactModels);
    }

    // GET api/contacts/5
    [Route("{id:int}")]
    public IHttpActionResult Get(int id)
    {
      Contact contact = new Contact();
      ContactQueries _contactQueries = new ContactQueries();
      contact = _contactQueries.GetOneById(id);

      ContactModel contactModel = new ContactModel();
      contactModel.Id = contact.Id;
      contactModel.FirstName = contact.FirstName;
      contactModel.LastName = contact.LastName;
      contactModel.Email = contact.Email;

      foreach (var account in contact.Accounts)
      {
        AccountDetails accountDetails = new AccountDetails();
        accountDetails.Id = account.Id;
        accountDetails.Name = account.Name;

        contactModel.Accounts.Add(accountDetails);
      }
      return Ok(contactModel);
    }

    [Route("")]
    [HttpPost]
    public IHttpActionResult Post([FromBody]ContactModel contactModel)
    {
      if (ModelState.IsValid)
      {
        Contact contact = new Contact();
        contact.Id = 0;// contactModel.Id;
        contact.FirstName = contactModel.FirstName;
        contact.LastName = contactModel.LastName;
        contact.Email = contactModel.Email;
        contact.DateCreated = DateTime.Now;
        contact.DateUpdated = DateTime.Now;

        foreach (var accountDetails in contactModel.Accounts)
        {

          Account account = new Account();
          account.Id = accountDetails.Id;
          account.Name = accountDetails.Name;

          contact.Accounts.Add(account);
        }
        ContactQueries _contactQueries = new ContactQueries();
        _contactQueries.Save(contact);
      }
      return Ok();
    }

    // PUT api/contacts/5
    [Route("{id:int}")]
    [HttpPut]
    public IHttpActionResult Put(int id,[FromBody]ContactModel contactModel)
    {
      if (ModelState.IsValid)
      {
        ContactQueries _contactQueries = new ContactQueries();
        Contact contact = _contactQueries.GetOneById(id);
        contact.FirstName = contactModel.FirstName;
        contact.LastName = contactModel.LastName;
        contact.Email = contactModel.Email;
        contact.DateUpdated = DateTime.Now;

        foreach (var accountDetails in contactModel.Accounts)
        {

          Account account = new Account();
          account.Id = accountDetails.Id;
          account.Name = accountDetails.Name;

          contact.Accounts.Add(account);
        }
        
        _contactQueries.Save(contact);
      }
      return Ok();
    }

    // DELETE api/contacts/5
    [Route("{id:int}")]
    public IHttpActionResult Delete(int id)
    {
      ContactQueries _contactQueries = new ContactQueries();
      Contact contact = _contactQueries.GetOneById(id);
      _contactQueries.Delete(contact);
      return Ok();
    }


  }
}
