using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace ASPWithoutWAPI
{
    public partial class Register : System.Web.UI.Page
    {
        MessageDBContainer1 dbContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbContext = new MessageDBContainer1();

        }

        public void RegisterUser()
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            if (PassBox.Text == TPassBox.Text)
            {
                ASPWithoutWAPI.User newUser = new ASPWithoutWAPI.User();
                newUser.Email = EmailBox.Text;
                newUser.Nick = NickBox.Text;
                newUser.Pass = PassBox.Text;
                newUser.User_Meta.Add(new User_Meta() { Key = "RegisterTime", Value = DateTime.Now.ToString() });
                dbContext.UserSet.Add(newUser);
                dbContext.SaveChanges();
            }
        }
    }
}