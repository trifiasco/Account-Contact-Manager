using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
    public class ContactEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AccountOnSelect { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}