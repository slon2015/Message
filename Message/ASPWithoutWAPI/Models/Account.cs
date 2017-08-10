using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWithoutWAPI.Models
{
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        string _Token;
        public string AccessToken { get { return _Token; } }
        public void CreateToken()
        {
            if (_Token == null) _Token = new Random().Next().GetHashCode().ToString();
        }
    }
}