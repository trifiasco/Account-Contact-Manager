using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;

namespace TestWebApp.Helper
{
    public class MapperForAccount
    {
        public static List<AccountViewModel> MapToAccountViewModel(List<Account> accounts)
        {
            var viewModelList = new List<AccountViewModel>();
            foreach (var account in accounts)
            {
                viewModelList.Add(new AccountViewModel
                {
                    Id = account.Id,
                    Name = account.Name,
                    Contacts = account.Contacts
                });

            }

            return viewModelList;
        }
        public static AccountCreateViewModel MapToAccountCreateViewModel(Account account)
        {
            var accountViewModel = new AccountCreateViewModel();
            accountViewModel.Id = account.Id;
            accountViewModel.Name = account.Name;
            accountViewModel.Contacts = account.Contacts;
            return accountViewModel;
        }

        public static AccountEditViewModel MapToAccountEditViewModel(Account account)
        {
            var accountViewModel = new AccountEditViewModel();
            accountViewModel.Id = account.Id;
            accountViewModel.Name = account.Name;
            accountViewModel.Contacts = account.Contacts;
            return accountViewModel;
        }
    }
}