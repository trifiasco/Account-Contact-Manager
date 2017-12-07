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
        public static List<AccountViewModel> MapToContactViewModel(List<Account> accounts)
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
    }
}