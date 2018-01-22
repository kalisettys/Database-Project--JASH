using HousingApp.ClassFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HousingApp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Utilities.IsUserLoggedIn())
            {
                pnlLogin.Visible = false;
                pnlSignup.Visible = false;
                pnlLogout.Visible = true;
            }
            else
            {
                pnlLogin.Visible = true;
                pnlSignup.Visible = true;
                pnlLogout.Visible = false;

            }
        }
    }
}