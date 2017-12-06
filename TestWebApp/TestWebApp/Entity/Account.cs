using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp.Entity
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
    }
}