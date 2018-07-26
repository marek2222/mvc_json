using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonResultDemo.Controllers;
using System.Web.Mvc;

namespace WebApplication1.Tests.Controllers
{
  [TestClass]
  public class JsonDemoControllerTest
  {
    [TestMethod]
    public void WelcomeNote()
    {
      JsonDemoController controller = new JsonDemoController();

      JsonResult result = controller.WelcomeNote();
      string msg = Convert.ToString(result.Data);
      // Assert   
      Assert.AreEqual("Welcome to the User", msg);
    }

  }
}
