using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Text;
using HousingApp.ClassFiles;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace HousingApp
{
    public partial class Login : System.Web.UI.Page
    {
        StringBuilder sbErrors = new StringBuilder();
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isPageValid = true;
            if (Page.IsValid)
            {
                if (!Utilities.IsValidInput(username.Text.Trim()))
                {
                    sbErrors.Append("The username is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(password.Text.Trim()))
                {
                    sbErrors.Append("The username password is invalid!<br/>");
                    isPageValid = false;
                }
                if (isPageValid)
                {
                    String sqlFunctionName = String.Empty;
                    if(radioList.SelectedItem.Value != String.Empty)
                    {
                        sqlFunctionName = radioList.SelectedItem.Value;
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@student_pass", password.Text.Trim()));
                        parameters.Add(new SqlParameter("@student_username", username.Text.Trim()));
                        bool isUserValidLogin = BO.CallSQLFunction(sqlFunctionName, parameters.ToArray());
                        if(isUserValidLogin)
                        {
                            Session["UserLoggedIn"] = "true";
                            Session["CurrentUser"] = username.Text.Trim();
                            Session["currentUserType"] = radioList.SelectedItem.Text.Trim();
                            String sqlProc = String.Empty;
                            String property = String.Empty;
                            String currentUserId = String.Empty;
                            //get user id and put in session
                            if(radioList.SelectedItem.Text.Equals("Student"))
                            {
                                sqlProc = "dbo.sp_GetStudent";
                                property = "student_vcu_vNumber";
                            }
                            else if (radioList.SelectedItem.Text.Equals("Faculty"))
                            {
                                sqlProc = "dbo.sp_GetFaculty";
                                property = "faculty_vcu_vNumber";
                            }
                            else
                            {
                                sqlProc = "dbo.sp_GetPropertyLister";
                                property = "property_lister_ID";
                            }
                            List<SqlParameter> sqlparameters = new List<SqlParameter>();
                            sqlparameters.Add(new SqlParameter("@student_Username", username.Text.Trim()));
                            DataSet ds = BO.CallSQLProcwithReturnValue(sqlProc, sqlparameters.ToArray());
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(ds.GetXml());
                            if (doc.SelectSingleNode("NewDataSet/Table/" + property) != null)
                            {
                                currentUserId = doc.SelectSingleNode("NewDataSet/Table/" + property).InnerText;
                                Session["currentUserId"] = currentUserId;
                            }
                                
                            if (Request.QueryString["returnurl"] != null)
                            {
                                Response.Redirect(Request.QueryString["returnurl"]);
                            }
                            if (radioList.SelectedItem.Text.Equals("Property Manager"))
                            {
                                Response.Redirect("/PropertyListing.aspx");
                            }
                            else
                            {
                                Response.Redirect("/UserListing.aspx");
                            }
                        }
                        else
                        {
                            sbErrors.Append("please check the username and password!<br/>");
                        }
                    }
                    else
                    {
                        sbErrors.Append("please select the user type to login!<br/>");
                    }
                    
                }
            }
            ltrErrors.Text = sbErrors.ToString();
        }
    }
}