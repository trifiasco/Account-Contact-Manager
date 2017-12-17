using System.Collections.Generic;
using DomainClass.Entity;

namespace DomainClass.QueryHelper
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
