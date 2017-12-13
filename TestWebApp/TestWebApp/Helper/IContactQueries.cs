using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Helper
{
  public interface IContactQueries
  {
    List<Contact> GetAll();
    Contact GetOneById(int id);
    void Save(Contact contact);
    void Delete(Contact contact);
  }
}
