using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Helper
{
  public interface IAccountQueries
  {
    List<Account> GetAll();
    Account GetOneById(int id);
    void Save(Account account);
    void Delete(Account account);
  }
}
