using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
  public class ContactCreatedInLastDaysViewModel
  {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public string DisplayName
      {
        get
        {
          return LastName + ", " + FirstName;
        }
      }
      public IList<Account> Accounts { get; set; }
  }
}