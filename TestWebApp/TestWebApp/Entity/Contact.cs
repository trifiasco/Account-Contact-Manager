using System;
using System.Collections.Generic;

namespace TestWebApp.Entity
{
  public class Contact
  {
    public Contact()
    {
      Accounts = new List<Account>();
    }
    public virtual int Id { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    public virtual DateTime DateCreated { get; set; }
    public virtual DateTime DateUpdated { get; set; }
    public virtual IList<Account> Accounts { get; set; }
  }
}