using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Models;

namespace TestWebApp.Helper
{
  public class MapperForHome : IMapperForHome
  {
    public HomeViewModel MapToHomeViewModel(int accountCreateCount, int accountUpdateCount,int contactCreatedCount)
    {
      var homeViewModel = new HomeViewModel();
      homeViewModel.AccountCreatedCount = accountCreateCount;
      homeViewModel.AccountUpdatedCount = accountUpdateCount;
      homeViewModel.ContactCreatedCount = contactCreatedCount;
      return homeViewModel;
    }
  }
}