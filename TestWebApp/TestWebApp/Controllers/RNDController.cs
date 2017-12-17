using System.Collections.Generic;
using System.Web.Mvc;
using DomainClass.Entity;
using TestWebApp.Models;
using DomainClass;

namespace TestWebApp.Controllers
{
  public class RNDController : Controller
  {
    // GET: RND
    public ActionResult Index()
    {
      List<Contact> Contacts = new List<Contact>();
      Contacts.Add(new Contact() { Id = 1, FirstName = "one", LastName = "one", Email = "one@one" });
      Contacts.Add(new Contact() { Id = 2, FirstName = "two", LastName = "two", Email = "two@two" });
      Contacts.Add(new Contact() { Id = 3, FirstName = "three", LastName = "three", Email = "three@three" });
      Contacts.Add(new Contact() { Id = 4, FirstName = "four", LastName = "four", Email = "four@four" });

      var rndModelView = new RndModelView();
      rndModelView.Id = 21;
      rndModelView.Name = "AccountName";
      rndModelView.ContactSelectId.Add(2);
      rndModelView.ContactSelectId.Add(3);
      rndModelView.NewContacts = Contacts; //newContacts=AllContacts

      return View(rndModelView);
    }
  }
}