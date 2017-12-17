using System.Collections.Generic;
using DomainClass.Entity;
using TestWebApp.Models;

namespace TestWebApp.Helper
{
  public interface IMapperForAccount
  {
    List<AccountViewModel> MapToAccountViewModel(List<Account> accounts);
    List<AccountCreatedInLastDaysViewModel> MapToCreatedInLastDaysViewModel(List<Account> accounts);
    List<AccountUpdatedInLastDaysViewModel> MapToUpdatedInLastDaysViewModel(List<Account> accounts);
    AccountCreateViewModel MapToAccountCreateViewModel(Account account);
    AccountEditViewModel MapToAccountEditViewModel(Account account, List<int> contactSelectIds);
    AccountDetailsViewModel MapToAccountDetailsViewModel(Account account);
  }
}
