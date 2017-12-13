using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;
using AutoMapper;

namespace TestWebApp.Helper
{
  public class MapperForContact : IMapperForContact
  {
    public List<ContactViewModel> MapToContactViewModel(List<Contact> contacts)
    {
      var viewModelList = Mapper.Map<List<ContactViewModel>>(contacts);
      return viewModelList;
    }

    public ContactCreateViewModel MapToContactCreateViewModel(Contact contact)
    {
      var contactCreateViewModel = Mapper.Map<ContactCreateViewModel>(contact);
      return contactCreateViewModel;


    }
    public ContactEditViewModel MapToContactEditViewModel(Contact contact)
    {
      var contactEditViewModel = Mapper.Map<ContactEditViewModel>(contact);
      return contactEditViewModel;
    }
    public ContactDetailsViewModel MapToContactDetailsViewModel(Contact contact)
    {
      var contactDetailsViewModel = Mapper.Map<ContactDetailsViewModel>(contact);
      return contactDetailsViewModel;
    }

  }
}