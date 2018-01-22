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
    public partial class PostProperty : System.Web.UI.Page
    {
        private String txtfileName = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.IsUserLoggedIn())
            {
                Response.Redirect("/login.aspx?returnurl=/PostProperty.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (openFileUpload.PostedFile != null)
            {
                String uploadedfileName = openFileUpload.PostedFile.FileName;
                String uploadPath = Server.MapPath("\\Images");
                openFileUpload.PostedFile.SaveAs(uploadPath + "\\" + uploadedfileName);
                txtfileName = String.Format("/Images/{0}", uploadedfileName);
                StartImport();
            }
        }
        private void StartImport()
        {
            Int32 userId = 0;
            Int32 homeId = 0;
            if (Session["currentUserId"] != null)
            {
                Int32.TryParse(Session["currentUserId"].ToString(), out userId);
            }
            else
            {
                Response.Redirect("/login.aspx?returnurl=/PostProperty.aspx");
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@home_no_of_beds", bed.Text));
            parameters.Add(new SqlParameter("@home_no_of_baths", bath.Text));
            parameters.Add(new SqlParameter("@home_occupancy", occupancy.Text));
            parameters.Add(new SqlParameter("@home_parking", parking.Checked ? 1 : 0));
            parameters.Add(new SqlParameter("@home_monthly_rent", rent.Text));
            parameters.Add(new SqlParameter("@home_Address", Address1.Text));
            parameters.Add(new SqlParameter("@home_city", City.Text));
            parameters.Add(new SqlParameter("@home_state", State.Text));
            parameters.Add(new SqlParameter("@apartment_flag", apartment.Checked ? 1 : 0));
            parameters.Add(new SqlParameter("@home_zipcode", zip.Text));
            parameters.Add(new SqlParameter("@home_image", txtfileName));
            BO.CallSQLProc("dbo.sp_AddHome", parameters.ToArray());

            DataSet ds = BO.CallSQLProcwithReturnValue("dbo.sp_GetLatestHome", new SqlParameter[0]);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ds.GetXml());
            if (doc.SelectSingleNode("NewDataSet/Table/Home_ID") != null)
            {
                Int32.TryParse(doc.SelectSingleNode("NewDataSet/Table/Home_ID").InnerText, out homeId);
            }

            List<SqlParameter> sqlparameters = new List<SqlParameter>();
            sqlparameters.Add(new SqlParameter("@manager_id", userId));
            sqlparameters.Add(new SqlParameter("@property_id", homeId));
            BO.CallSQLProc("dbo.sp_Lister_and_Property", sqlparameters.ToArray());


            Response.Redirect("/propertylisting.aspx");
        }
    }
}