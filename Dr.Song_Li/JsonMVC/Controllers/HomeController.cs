using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonMVC.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      NameValueCollection appSettings = ConfigurationManager.AppSettings;
      ViewData["ApplicationTitle"] = appSettings["ApplicationTitle"];
      return View();
    }

    //public ActionResult About()
    //{
    //  ViewBag.Message = "Your application description page.";

    //  return View();
    //}

    //public ActionResult Contact()
    //{
    //  ViewBag.Message = "Your contact page.";

    //  return View();
    //}
  }
}