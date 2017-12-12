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
    public static class AccountQueries
    {
        public static List<Account> GetAllAccounts()
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var accounts = session.Query<Account>().ToList();
                    return accounts;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Account>(); // doubt ???
            }
        }

        public static Account GetOneAccount(int id)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var accounts = session.Get<Account>(id);
                    return accounts;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new Account();
            }
        }

        public static void InsertOneAccount(Account account)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(account);
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

        public static void DeleteOneAccount(Account account)
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