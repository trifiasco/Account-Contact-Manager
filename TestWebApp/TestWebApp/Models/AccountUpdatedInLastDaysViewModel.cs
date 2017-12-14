using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
  public class AccountUpdatedInLastDaysViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<Contact> Contacts { get; set; }
  }
}