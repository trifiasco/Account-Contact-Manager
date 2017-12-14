using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Helper
{
  public interface IAccountQueries
  {
    List<Account> GetAll();
    List<Account> GetAllCreatedInLastDays();
    List<Account> GetAllUpdatedInLastDays();
    int GetCountOfCreatedInLastDays();
    int GetCountOfUpdatedInLastDays();
    Account GetOneById(int id);
    void Save(Account account);
    void Delete(Account account);
  }
}
