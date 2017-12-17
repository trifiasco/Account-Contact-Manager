using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
  public class ContactDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public IList<Account> Accounts { get; set; }
    }
}