using System.Web;
using System.Web.Mvc;

namespace WebApplicationAPIV_2
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
