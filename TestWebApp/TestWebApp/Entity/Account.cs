using System;
using System.Collections.Generic;

namespace TestWebApp.Entity
{
  public class Account
  {
    public Account()
    {
      Contacts = new List<Contact>();
    }
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual DateTime DateCreated { get; set; }
    public virtual DateTime DateUpdated { get; set; }
    public virtual IList<Contact> Contacts { get; set; }
  }
}