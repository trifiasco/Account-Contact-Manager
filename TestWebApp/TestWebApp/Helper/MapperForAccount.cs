using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;
using AutoMapper;

namespace TestWebApp.Helper
{
  public class MapperForAccount
  {
    public static List<AccountViewModel> MapToAccountViewModel(List<Account> accounts)
    {
      var viewModelList = Mapper.Map<List<AccountViewModel>>(accounts);
      return viewModelList;
    }
    public static AccountCreateViewModel MapToAccountCreateViewModel(Account account)
    {
      var accountViewModel = Mapper.Map<AccountCreateViewModel>(account);
      return accountViewModel;
    }

    public static AccountEditViewModel MapToAccountEditViewModel(Account account, List<int> contactSelectIds)
    {
      var accountViewModel = Mapper.Map<AccountEditViewModel>(account);
      accountViewModel.ContactSelectId = contactSelectIds;
      return accountViewModel;
    }

    public static AccountDetailsViewModel MapToAccountDetailsViewModel(Account account)
    {
      var accountViewModel = Mapper.Map<AccountDetailsViewModel>(account);
      return accountViewModel;
    }
  }
}