﻿using System;
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

        public static ContactCreateViewModel MapToContactCreateViewModel(Contact contact)
        {
            var contactCreateViewModel = new ContactCreateViewModel();
            contactCreateViewModel.Id = contact.Id;
            contactCreateViewModel.FirstName = contact.FirstName;
            contactCreateViewModel.LastName = contact.LastName;
            contactCreateViewModel.Email = contact.Email;

            contactCreateViewModel.Accounts = contact.Accounts;

            return contactCreateViewModel;


        }
        public static ContactEditViewModel MapToContactEditViewModel(Contact contact)
        {
            var contactEditViewModel = new ContactEditViewModel();
            contactEditViewModel.Id = contact.Id;
            contactEditViewModel.FirstName = contact.FirstName;
            contactEditViewModel.LastName = contact.LastName;
            contactEditViewModel.Email = contact.Email;

            contactEditViewModel.Accounts = contact.Accounts;

            return contactEditViewModel;


        }
        public static ContactDetailsViewModel MapToContactDetailsViewModel(Contact contact)
        {
            var contactDetailsViewModel = new ContactDetailsViewModel();
            contactDetailsViewModel.Id = contact.Id;
            contactDetailsViewModel.FirstName = contact.FirstName;
            contactDetailsViewModel.LastName = contact.LastName;
            contactDetailsViewModel.Email = contact.Email;

            contactDetailsViewModel.Accounts = contact.Accounts;

            return contactDetailsViewModel;


        }

    }
}