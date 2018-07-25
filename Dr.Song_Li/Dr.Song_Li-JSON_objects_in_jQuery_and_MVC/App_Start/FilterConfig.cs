using System.Web;
using System.Web.Mvc;

namespace Dr.Song_Li_JSON_objects_in_jQuery_and_MVC
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
