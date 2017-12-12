﻿using NHibernate;
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
        public static List<Contact> GetAllContacts()
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSessionForContact())
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

        public static Contact GetOneContact(int id)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSessionForContact())
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

        public static void InsertOneContact(Contact contact)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSessionForContact())
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

        public static void DeleteOneContact(Contact contact)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSessionForContact())
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