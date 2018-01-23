using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HousingApp
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLoggedIn"] != null)
                {
                    Session.Remove("UserLoggedIn");
                }
                    if (Request.Cookies["currentUser"] != null)
                {
                    Response.Cookies["currentUser"].Expires = DateTime.Now.AddDays(-1);
                }
                if (Request.Cookies["currentUserType"] != null)
                {
                    Response.Cookies["currentUserType"].Expires = DateTime.Now.AddDays(-1);
                }
                Session.RemoveAll();
                Response.Cookies.Clear();
                Response.Redirect("/");
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }
        }
    }
}
