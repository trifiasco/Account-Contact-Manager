using DomainClass.Entity;
using DomainClass.QueryHelper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPIV_2.Models;

namespace WebApplicationAPIV_2.Controllers
{
  [RoutePrefix("api/accounts")]
  public class AccountApiController : ApiController
  {

    [Route("")]
    [HttpGet]
    public IHttpActionResult Get()
    {
      List<Account> accounts = new List<Account>();
      AccountQueries _accountQueries = new AccountQueries();
      accounts = _accountQueries.GetAll();
      List<AccountModel> accountModels = new List<AccountModel>();
      foreach (var account in accounts)
      {
        AccountModel accountModel = new AccountModel();
        accountModel.Id = account.Id;
        accountModel.Name = account.Name;
        foreach(var contact in account.Contacts)
        {
          ContactDetails contactDetails = new ContactDetails();
          contactDetails.Id = contact.Id;
          contactDetails.FirstName = contact.FirstName;
          contactDetails.LastName = contact.LastName;
          contactDetails.Email = contact.Email;

          accountModel.Contacts.Add(contactDetails);
        }
        accountModels.Add(accountModel);
      }
      return Ok(accountModels);
    }

    // GET api/accounts/5
    [Route("{id:int}")]
    public IHttpActionResult Get(int id)
    {
      AccountQueries _accountQueries = new AccountQueries();
      var account = _accountQueries.GetOneById(id);
      AccountModel accountModel = new AccountModel();
      accountModel.Id = account.Id;
      accountModel.Name = account.Name;

      foreach (var contact in account.Contacts)
      {
        ContactDetails contactDetails = new ContactDetails();
        contactDetails.Id = contact.Id;
        contactDetails.FirstName = contact.FirstName;
        contactDetails.LastName = contact.LastName;
        contactDetails.Email = contact.Email;

        accountModel.Contacts.Add(contactDetails);
      }

      return Ok(accountModel);
    }

    [Route("")]
    [HttpPost]
    public IHttpActionResult Post([FromBody]AccountModel accountModel)
    {
      if (ModelState.IsValid)
      {
        Account account = new Account();
        account.Id = accountModel.Id;
        account.Name = accountModel.Name;
        account.DateCreated = DateTime.Now;
        account.DateUpdated = DateTime.Now;
        foreach (var contactDetails in accountModel.Contacts)
        {
          Contact contact = new Contact();
          contact.Id = contactDetails.Id;
          contact.FirstName = contactDetails.FirstName;
          contact.LastName = contactDetails.LastName;
          contact.Email = contactDetails.Email;

          account.Contacts.Add(contact);
        }
        AccountQueries _accountQueries = new AccountQueries();
        _accountQueries.Save(account);
      }
      return Ok();
    }

    // PUT api/accounts/5
    [Route("{id:int}")]
    public IHttpActionResult Put(int id, [FromBody]AccountModel accountModel)
    {
      if (ModelState.IsValid)
      {
        AccountQueries _accountQueries = new AccountQueries();
        Account account = _accountQueries.GetOneById(id);
        account.Name = accountModel.Name;
        account.DateUpdated = DateTime.Now;
        foreach (var contactDetails in accountModel.Contacts)
        {
          Contact contact = new Contact();
          contact.Id = contactDetails.Id;
          contact.FirstName = contactDetails.FirstName;
          contact.LastName = contactDetails.LastName;
          contact.Email = contactDetails.Email;

          account.Contacts.Add(contact);
        }
        
        _accountQueries.Save(account);
      }
      return Ok();
    }

    // DELETE api/accounts/5
    [Route("{id:int}")]
    public IHttpActionResult Delete(int id)
    {
      AccountQueries _accountQueries = new AccountQueries();
      Account account = _accountQueries.GetOneById(id);
      _accountQueries.Delete(account);
      return Ok();
    }

  }
}
