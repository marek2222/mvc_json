using JsonResultDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JsonResultDemo.Controllers
{
  public class JsonDemoController : Controller
  {

    /// <summary>   
    /// Welcome Note Message   
    /// </summary>   
    /// <returns>In a Json Format</returns>   
    public JsonResult WelcomeNote()
    {
      bool isAdmin = false;
      //TODO: Check the user if it is admin or normal user, (true-Admin, false- Normal user)   
      string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";

      return Json(output, JsonRequestBehavior.AllowGet);
    }

    /// <summary>   
    /// Get the Users   
    /// </summary>   
    /// <returns></returns>   
    private List<UserModel> GetUsers()
    {
      var usersList = new List<UserModel> {
                new UserModel { UserId = 1, UserName = "Ram",   Company = "Mindfire Solutions"  },
                new UserModel { UserId = 1, UserName = "chand", Company = "Mindfire Solutions"},
                new UserModel { UserId = 1, UserName = "Abc",   Company = "Abc Solutions"}
            };
      return usersList;
    }


    public JsonResult GetUsersData()
    {
      var users = GetUsers();
      return Json(users, JsonRequestBehavior.AllowGet);
    }


    // Scenario 3 : Create JSON data at the client side and send content to the controller
    public ActionResult Sample()
    {
      return View();
    }

    [HttpPost]
    public JsonResult UpdateUserDetail(string usersJson)
    {
      var js = new JavaScriptSerializer();
      UserModel[] user = js.Deserialize<UserModel[]>(usersJson);
      return Json("User Details are updated");
    }



    /// Scenario 4: How to handle huge amount of JSON Data
    private List<UserModel> GetUsersHugeData()
    {
      var userList = new List<UserModel>();
      UserModel user;
      for (int i = 1; i < 51000; i++)
      {
        user = new UserModel
        {
          UserId = i,
          UserName = "User-" + i.ToString(),
          Company = "Company-" + i.ToString()
        };
        userList.Add(user);
      }
      return userList;
    }


    public JsonResult GetUsersHugeList()
    {
      // Default JsonData depth is 100.
      // Then appears a error screen because count of data is mere then 100
      var users = GetUsersHugeData();
      return Json(users, JsonRequestBehavior.AllowGet);
    }

    /// <summary>   
    /// Override the JSON Result with Max integer JSON lenght   
    /// </summary>   
    /// <param name="data">Data</param>   
    /// <param name="contentType">Content Type</param>   
    /// <param name="contentEncoding">Content Encoding</param>   
    /// <param name="behavior">Behavior</param>   
    /// <returns>As JsonResult</returns>   
    protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
    {
      return new JsonResult()
      {
        Data                = data,
        ContentType         = contentType,
        ContentEncoding     = contentEncoding,
        JsonRequestBehavior = behavior,
        MaxJsonLength       = Int32.MaxValue
      };
    }


  }
}