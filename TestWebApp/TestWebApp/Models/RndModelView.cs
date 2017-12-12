using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
    public class RndModelView
    {
        public RndModelView()
        {
            AlreadySelctedContacts = new List<Contact>();
            NewContacts = new List<Contact>();
            ContactSelectId = new List<int>();
            ContactDiselectId = new List<int>();
            ContactDummy1 = new List<Contact>();
            ContactDummy2 = new List<Contact>();


        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ContactSelectId { get; set; }
        public List<int> ContactDiselectId { get; set; }
        public IList<Contact> AlreadySelctedContacts { get; set; }
        public IList<Contact> NewContacts { get; set; }
        public IList<Contact> ContactDummy1 { get; set; }
        public IList<Contact> ContactDummy2 { get; set; }
    }
}