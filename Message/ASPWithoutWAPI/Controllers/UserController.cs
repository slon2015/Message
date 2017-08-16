using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPWithoutWAPI.App_Start;
using Newtonsoft.Json;

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
            ASPWithoutWAPI.User user = dbContext.UserSet.FirstOrDefault(u => u.Email == Email && u.Pass == Password);
            if (user != null)
            {
                AccessToken token = dbContext.AccessTokenSet.Create();

                string hash;
                Random rand = new Random();
                do
                {
                    hash = MD5Crypto.getHashOfString(rand.Next().ToString());
                } while (dbContext.AccessTokenSet.FirstOrDefault(to => to.Token == hash) != null);
                user.AccessToken.Add(new AccessToken()
                {
                    Token = hash,
                    CreationTime = DateTime.Now,
                    DeadTime = DateTime.Now.AddDays(1)
                });

                dbContext.SaveChanges();
                AccessToken t = user.AccessToken.Last();
                return JsonConvert.SerializeObject(new {UserID = t.UserID, Token = t.Token, CreationTime = t.CreationTime ,DeadTime = t.DeadTime});
            }
            else
                return "Login failed";
        }
    }
}