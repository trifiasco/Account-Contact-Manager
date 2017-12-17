using System.Collections.Generic;
using DomainClass.Entity;

namespace TestWebApp.Models
{
  public class ContactUpdatedInLastDaysViewModel
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