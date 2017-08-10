using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPWithoutWAPI.Models;
using Newtonsoft.Json;
using System.IO;

namespace ASPWithoutWAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Default");
        }
        
        [HttpPost]
        public string RegisterAcc(string Login,string Pass,string Email)
        {
            Account acc = new Account();
            acc.Login = Login;
            acc.Password = Pass;
            acc.Email = Email;
            acc.CreateToken();
            
            
            List<Account> accs = JsonConvert.DeserializeObject<List<Account>>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Accounts.json")));
            accs.Add(acc);
            System.IO.File.WriteAllText(Server.MapPath("~/App_Data/Accounts.json"), JsonConvert.SerializeObject(accs));
            return JsonConvert.SerializeObject(acc);
        }
        [HttpGet]
        public string getAccount(int id)
        {
            try
            {
                List<Account> accs = JsonConvert.DeserializeObject<List<Account>>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Accounts.json")));
                Account ret = accs.ElementAt(id);
                return JsonConvert.SerializeObject(ret);
            }
            catch(Exception e)
            {
                return JsonConvert.SerializeObject(e);
            }
        }
    }
}