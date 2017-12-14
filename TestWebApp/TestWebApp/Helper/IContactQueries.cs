using System.Collections.Generic;
using TestWebApp.Entity;

namespace TestWebApp.Helper
{
  public interface IContactQueries
  {
    List<Contact> GetAll();
    List<Contact> GetAllCreatedInLastDays();
    List<Contact> GetAllUpdatedInLastDays();
    Contact GetOneById(int id);
    void Save(Contact contact);
    void Delete(Contact contact);
  }
}
