using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
    public class AccountEditViewModel
    {
        public AccountEditViewModel()
        {
            Contacts = new List<Contact>();
            ContactSelectId = new List<int>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ContactSelectId { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}