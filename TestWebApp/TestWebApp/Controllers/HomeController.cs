using System.Web.Mvc;
using TestWebApp.Helper;

namespace TestWebApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly IAccountQueries _accountQueries;
    private readonly IMapperForHome _mapperForHome;
    private readonly IContactQueries _contactQueries;

    public HomeController(IAccountQueries accountQueries,IContactQueries contactQueries,IMapperForHome mapperForHome)
    {
      _accountQueries = accountQueries;
      _mapperForHome = mapperForHome;
      _contactQueries = contactQueries;
    }

    public ActionResult Index()
    {
      int accountCreatedCount = _accountQueries.GetCountOfCreatedInLastDays();
      int accountUpdatedCount = _accountQueries.GetCountOfUpdatedInLastDays();
      int contactCreatedCount = _contactQueries.GetAllCreatedInLastDays().Count;
      int contactUpdatedCount = _contactQueries.GetAllUpdatedInLastDays().Count;
      var viewModel = _mapperForHome.MapToHomeViewModel(accountCreatedCount,accountUpdatedCount,contactCreatedCount,contactUpdatedCount);
      return View(viewModel);
    }
  }
}