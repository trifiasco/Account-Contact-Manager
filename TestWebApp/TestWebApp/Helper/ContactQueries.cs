using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Entity;
using TestWebApp.Models;

namespace TestWebApp.Helper
{
    public static class ContactQueries
    {
        public static List<Contact> GetAll()
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

        public static Contact GetOneById(int id)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var contact = session.Get<Contact>(id);
                    return contact;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Contact();
            }
        }

        public static void Save(Contact contact)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(contact);
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

        public static void Delete(Contact contact)
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