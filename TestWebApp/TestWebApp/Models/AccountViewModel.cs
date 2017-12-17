using System.Collections.Generic;
using DomainClass.Entity;

namespace TestWebApp.Models
{
  public class AccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Contact> Contacts { get; set; }
    }
}