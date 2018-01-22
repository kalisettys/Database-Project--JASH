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
    public partial class PropertyListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utilities.IsUserLoggedIn())
                {
                    pnl.Visible = true;
                    Int32 userId = 0;
                    if (Session["currentUserId"] != null)
                    {
                        Int32.TryParse(Session["currentUserId"].ToString(), out userId);
                        hdnUserId.Value = userId.ToString();
                    }
                }
                List<SqlParameter> sqlparameters = new List<SqlParameter>();
                DataSet ds = BO.CallSQLProcwithReturnValue("dbo.sp_GetAllHome", sqlparameters.ToArray());
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(ds.GetXml());
                if(ds.Tables.Count > 0)
                {
                    rptHome.DataSource = ds;
                    rptHome.DataBind();
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}