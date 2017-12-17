﻿using TestWebApp.Models;

namespace TestWebApp.Helper
{
  public class MapperForHome : IMapperForHome
  {
    public HomeViewModel MapToHomeViewModel(int accountCreateCount, int accountUpdateCount,int contactCreatedCount, int contactUpdatedCount)
    {
      var homeViewModel = new HomeViewModel();
      homeViewModel.AccountCreatedCount = accountCreateCount;
      homeViewModel.AccountUpdatedCount = accountUpdateCount;
      homeViewModel.ContactCreatedCount = contactCreatedCount;
      homeViewModel.ContactUpdatedCount = contactUpdatedCount;
      return homeViewModel;
    }
  }
}