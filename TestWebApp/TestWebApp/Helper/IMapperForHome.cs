using TestWebApp.Models;

namespace TestWebApp.Helper
{
  public interface IMapperForHome
  {
    HomeViewModel MapToHomeViewModel(int accountCreateCount, int accountUpdateCount,int contactCreatedCount,int contactUpdatedCount);
  }
}
