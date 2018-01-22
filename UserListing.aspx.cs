using HousingApp.ClassFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HousingApp
{
    public partial class UserListing : System.Web.UI.Page
    {
        public bool showFav = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.IsUserLoggedIn())
            {
                Response.Redirect("/login.aspx?returnurl=/UserListing.aspx");
            }
            else
            {
                Int32 userId = 0;
                if (Session["currentUserId"] != null)
                {
                    Int32.TryParse(Session["currentUserId"].ToString(), out userId);
                    hdnUserId.Value = userId.ToString();
                }
            }
            String storedProc = "dbo.sp_GetAllHome";
            List<SqlParameter> sqlparameters = new List<SqlParameter>();
            ltrName.Text = "All Homes";
            if (Request.QueryString["type"] != null)
            {
                String homeTypeProc = Request.QueryString["type"];
                if(homeTypeProc.Equals("apt"))
                {
                    ltrName.Text = "Apartments";
                    storedProc = "dbo.sp_GetApartments";
                }
                else if (homeTypeProc.Equals("home"))
                {
                    storedProc = "dbo.sp_GetHome";
                    ltrName.Text = "Individual Homes";
                }
                else if (homeTypeProc.Equals("fav"))
                {
                    ltrName.Text = "User Favorite Homes";
                    showFav = false;
                    storedProc = "dbo.sp_GetFavorites";
                    Int32 userId = 0;
                    if (Session["currentUserId"] != null)
                    {
                        Int32.TryParse(Session["currentUserId"].ToString(), out userId);
                    }
                    sqlparameters.Add(new SqlParameter("@user_id", userId));
                }
            }
            DataSet ds = BO.CallSQLProcwithReturnValue(storedProc, sqlparameters.ToArray());
            if (ds.Tables.Count > 0)
            {
                rptHome.DataSource = ds;
                rptHome.DataBind();
            }
        }
    }
}