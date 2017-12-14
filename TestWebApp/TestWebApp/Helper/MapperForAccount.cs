using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;
using AutoMapper;

namespace TestWebApp.Helper
{
  public class MapperForAccount : IMapperForAccount
  {
    public List<AccountViewModel> MapToAccountViewModel(List<Account> accounts)
    {
      var viewModelList = Mapper.Map<List<AccountViewModel>>(accounts);
      return viewModelList;
    }
    public List<AccountCreatedInLastDaysViewModel> MapToCreatedInLastDaysViewModel(List<Account> accounts)
    {
      var viewModelList = Mapper.Map<List<AccountCreatedInLastDaysViewModel>>(accounts.ToList());
      return viewModelList;
    }

    public List<AccountUpdatedInLastDaysViewModel> MapToUpdatedInLastDaysViewModel(List<Account> accounts)
    {
      var viewModelList = Mapper.Map<List<AccountUpdatedInLastDaysViewModel>>(accounts.ToList());
      return viewModelList;
    }

    public AccountCreateViewModel MapToAccountCreateViewModel(Account account)
    {
      var accountViewModel = Mapper.Map<AccountCreateViewModel>(account);
      return accountViewModel;
    }

    public AccountEditViewModel MapToAccountEditViewModel(Account account, List<int> contactSelectIds)
    {
      var accountViewModel = Mapper.Map<AccountEditViewModel>(account);
      accountViewModel.ContactSelectId = contactSelectIds;
      return accountViewModel;
    }

    public AccountDetailsViewModel MapToAccountDetailsViewModel(Account account)
    {
      var accountViewModel = Mapper.Map<AccountDetailsViewModel>(account);
      return accountViewModel;
    }
  }
}