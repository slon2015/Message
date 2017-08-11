using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPWithoutWAPI.App_Start;

namespace ASPWithoutWAPI.Controllers
{
    public class UserController : Controller
    {
        static MessageDBContainer1 dbContext = new MessageDBContainer1();
        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

            [HttpPost]
        public string LogIn(string Email, string Password)
        {
            if (dbContext.UserSet.FirstOrDefault(u => MD5Crypto.getHashOfString(u.Email) == Email && u.Pass == Password) != null)
                return "LogIn success";
            else
                return "Login failed";
        }
    }
}