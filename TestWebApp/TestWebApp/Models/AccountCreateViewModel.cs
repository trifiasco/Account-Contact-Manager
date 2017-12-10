using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
    public class AccountCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactSelectId { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}