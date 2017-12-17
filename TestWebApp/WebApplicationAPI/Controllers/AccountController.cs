using DomainClass.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainClass.QueryHelper;

namespace WebApplicationAPI.Controllers
{
  public class AccountController : ApiController
  {
    public IEnumerable<Account> GetAllAccounts()
    {
      AccountQueries accountQueries = new AccountQueries();
      List<Account> accounts = new List<Account>();
      accounts = accountQueries.GetAll();
      return accounts;
    }
  }
}
