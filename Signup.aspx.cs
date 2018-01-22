using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using HousingApp.ClassFiles;
using System.Data.SqlClient;
using System.Xml;
using System.Data;

namespace HousingApp
{
    public partial class Signup : System.Web.UI.Page
    {
        StringBuilder sbErrors = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void registerButton_Click(object sender, EventArgs e)
        {
            bool isPageValid = true;
            if (Page.IsValid)
            {
                if (!Utilities.IsValidInput(username.Text))
                {
                    sbErrors.Append("The username is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(txtPassword.Text))
                {
                    sbErrors.Append("The username password is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(first_name.Text))
                {
                    sbErrors.Append("The first is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(last_name.Text))
                {
                    sbErrors.Append("The lastname is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsEmailValidInput(email.Text))
                {
                    sbErrors.Append("The email is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(phone.Text))
                {
                    sbErrors.Append("The Phone is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(fax.Text))
                {
                    sbErrors.Append("The Fax is invalid!<br/>");
                    isPageValid = false;
                }
                if (!Utilities.IsValidInput(vcu.Text))
                {
                    sbErrors.Append("The VCU number is invalid!<br/>");
                    isPageValid = false;
                }
                if (isPageValid)
                {
                    if (!radioList.SelectedItem.Text.Equals("Property Manager"))
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@student_id", vcu.Text));
                        parameters.Add(new SqlParameter("@student_email", email.Text));
                        bool isUserValid = BO.CallSQLFunction("dbo.IsValidVCUMember", parameters.ToArray());
                        if (!isUserValid)
                        {
                            sbErrors.Append("The VCU number is invalid!<br/>");
                            isPageValid = false;
                        }
                    }
                }
                if(isPageValid)
                {
                    //create user account
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    if (radioList.SelectedItem.Text.Equals("Student"))
                    {
                        parameters.Add(new SqlParameter("@student_id", vcu.Text));
                        parameters.Add(new SqlParameter("@student_password", txtPassword.Text));
                        parameters.Add(new SqlParameter("@student_username", username.Text));
                        parameters.Add(new SqlParameter("@student_lastname", last_name.Text));
                        parameters.Add(new SqlParameter("@student_firstname", first_name.Text));
                        parameters.Add(new SqlParameter("@student_MobilePhoneNumber", phone.Text));
                        parameters.Add(new SqlParameter("@student_gradeLevel", fax.Text));
                        parameters.Add(new SqlParameter("@student_email", email.Text));
                        parameters.Add(new SqlParameter("@student_Gender", referencedfrom.SelectedItem.Text.Equals("Please Select") ? "" : referencedfrom.SelectedItem.Text));
                        BO.CallSQLProc("dbo.sp_AddStudent", parameters.ToArray());
                    }
                    else if (radioList.SelectedItem.Text.Equals("Faculty"))
                    {
                        parameters.Add(new SqlParameter("@faculty_vcu_vNumber", vcu.Text));
                        parameters.Add(new SqlParameter("@faculty_Password", txtPassword.Text));
                        parameters.Add(new SqlParameter("@faculty_Username", username.Text));
                        parameters.Add(new SqlParameter("@faculty_lastName", last_name.Text));
                        parameters.Add(new SqlParameter("@faculty_firstName", first_name.Text));
                        parameters.Add(new SqlParameter("@faculty_MobilePhoneNumber", phone.Text));
                        parameters.Add(new SqlParameter("@faculty_Gender", referencedfrom.SelectedItem.Text.Equals("Please Select") ? "" : referencedfrom.SelectedItem.Text));
                        parameters.Add(new SqlParameter("@faculty_email", email.Text));
                        BO.CallSQLProc("dbo.sp_AddFaculty", parameters.ToArray());
                    }
                    else
                    {
                        parameters.Add(new SqlParameter("@propertyLister_password", txtPassword.Text));
                        parameters.Add(new SqlParameter("@propertyLister_username", username.Text));
                        parameters.Add(new SqlParameter("@propertyLister_lastname", last_name.Text));
                        parameters.Add(new SqlParameter("@propertyLister_firstname", first_name.Text));
                        parameters.Add(new SqlParameter("@propertyLister_MobilePhoneNumber", phone.Text));
                        parameters.Add(new SqlParameter("@propertyLister_email", email.Text));
                        BO.CallSQLProc("dbo.sp_AddPropertyLister", parameters.ToArray());
                    }
                    Session["UserLoggedIn"] = "true";
                    Session["CurrentUser"] = username.Text.Trim();
                    Session["currentUserType"] = radioList.SelectedItem.Text.Trim();
                    String sqlProc = String.Empty;
                    String property = String.Empty;
                    String currentUserId = String.Empty;
                    //get user id and put in session
                    if (radioList.SelectedItem.Text.Equals("Student"))
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
                ltrError.Text = sbErrors.ToString();
            }
        }
    }
}