﻿using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Models
{
  public class AccountDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactSelectId { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}