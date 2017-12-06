using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;

namespace TestWebApp.Helper
{
    public static class Mapper
    {
        public static List<ContactViewModel> MapToContactViewModel(List<Contact> contacts)
        {
            var viewModelList = new List<ContactViewModel>();
            foreach(var contact in contacts)
            {
                viewModelList.Add(new ContactViewModel {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Accounts = contact.Accounts
                });

            }

            return viewModelList;
        }
    }
}