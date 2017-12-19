using DomainClass.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainClass.QueryHelper
{
  public class ContactQueries : IContactQueries
  {
    public List<Contact> GetAll()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var contacts = session.Query<Contact>().ToList();
          return contacts;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new List<Contact>(); // doubt ???
      }
    }

    public List<Contact> GetAllCreatedInLastDays()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var contacts = session.CreateSQLQuery("exec GetContactsCreatedInLastDays").AddEntity(typeof(Contact)).List<Contact>();
          return contacts.ToList();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new List<Contact>();
      }
    }

    public List<Contact> GetAllUpdatedInLastDays()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var contacts = session.CreateSQLQuery("exec GetContactsUpdatedInLastDays").AddEntity(typeof(Contact)).List<Contact>();
          return contacts.ToList();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new List<Contact>();
      }
    }

    public Contact GetOneById(int id)
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          using (ITransaction transaction = session.BeginTransaction())
          {
            var contact = session.Get<Contact>(id);
            transaction.Commit();
            return contact;
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new Contact();
      }
    }

    public void Save(Contact contact)
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          
          using (ITransaction transaction = session.BeginTransaction())
          {
            session.SaveOrUpdate(contact);
            transaction.Commit();
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return;
      }
    }

    public void Delete(Contact contact)
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          using (ITransaction transaction = session.BeginTransaction())
          {
            session.Delete(contact);
            transaction.Commit();
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return;
      }
    }

  }
}