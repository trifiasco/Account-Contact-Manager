using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;
using TestWebApp.Helper;
using NHibernate.Linq;

namespace TestWebApp.Helper
{
  public class AccountQueries : IAccountQueries
  {
    public List<Account> GetAll()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var accounts = session.Query<Account>().ToList();
          return accounts;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new List<Account>();
      }
    }

    public List<Account> GetAllCreatedInLastDays()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var accounts = session.QueryOver<Account>().Where(x => x.DateCreated >= DateTime.Today.AddDays(-1)).List<Account>();
          return accounts.ToList();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new List<Account>();
      }
    }

    public List<Account> GetAllUpdatedInLastDays()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var accounts = session.QueryOver<Account>().Where(x => x.DateUpdated >= DateTime.Today.AddDays(-1)).List<Account>();
          return accounts.ToList();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new List<Account>();
      }
    }

    public int GetCountOfUpdatedInLastDays()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var accounts = session.QueryOver<Account>().Where(x => x.DateUpdated >= DateTime.Today.AddDays(-1)).RowCount();
          return accounts;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return -1;
      }
    }

    public int GetCountOfCreatedInLastDays()
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var accounts = session.QueryOver<Account>().Where(x => x.DateUpdated >= DateTime.Today.AddDays(-1)).RowCount();
          return accounts;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return -1;
      }
    }

    public Account GetOneById(int id)
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          var accounts = session.Get<Account>(id);
          return accounts;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return new Account();
      }
    }

    public void Save(Account account)
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          using (ITransaction transaction = session.BeginTransaction())
          {
            session.SaveOrUpdate(account);
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

    public void Delete(Account account)
    {
      try
      {
        using (ISession session = NHibernateSession.OpenSession())
        {
          using (ITransaction transaction = session.BeginTransaction())
          {
            session.Delete(account);
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