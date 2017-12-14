using System.Collections.Generic;
using TestWebApp.Entity;
using TestWebApp.Models;

namespace TestWebApp.Helper
{
  public interface IMapperForContact
  {
    List<ContactViewModel> MapToContactViewModel(List<Contact> contacts);
    List<ContactCreatedInLastDaysViewModel> MapToCreatedInLastDaysViewModel(List<Contact> contacts);
    List<ContactUpdatedInLastDaysViewModel> MapToUpdatedInLastDaysViewModel(List<Contact> contacts);
    ContactCreateViewModel MapToContactCreateViewModel(Contact contact);
    ContactEditViewModel MapToContactEditViewModel(Contact contact);
    ContactDetailsViewModel MapToContactDetailsViewModel(Contact contact);
  }
}
