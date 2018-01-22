using HousingApp.ClassFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace HousingApp
{
    public partial class PropertyDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString.HasKeys())
                {
                    if (Request.QueryString["id"] != null)
                    {
                        Int32 propertyId = 0;
                        Int32.TryParse(Request.QueryString["id"], out propertyId);
                        List<SqlParameter> sqlparameters = new List<SqlParameter>();
                        sqlparameters.Add(new SqlParameter("@property_id", propertyId));
                        DataSet ds = BO.CallSQLProcwithReturnValue("dbo.sp_GetProperty", sqlparameters.ToArray());
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(ds.GetXml());

                        ltrImage.Text = String.Format("<img src=\"{0}\"  style=\"width:100%\"/>", doc.SelectSingleNode("NewDataSet/Table/Home_image").InnerText);


                        ltrPrice.Text = "$" + doc.SelectSingleNode("NewDataSet/Table/Home_MonthlyRent").InnerText;

                        ltrBeds.Text = doc.SelectSingleNode("NewDataSet/Table/Home_No_Of_Beds").InnerText + " beds";

                        lrBath.Text = doc.SelectSingleNode("NewDataSet/Table/Home_No_Of_Baths").InnerText + " baths";

                        ltroccu.Text = doc.SelectSingleNode("NewDataSet/Table/Home_Occupancy").InnerText;

                        ltrparking.Text = doc.SelectSingleNode("NewDataSet/Table/Home_Parking").InnerText.Equals("1") ? "Yes" : "No";

                        ltraddress.Text = doc.SelectSingleNode("NewDataSet/Table/Home_Address").InnerText + " " + doc.SelectSingleNode("NewDataSet/Table/Home_City").InnerText + " " +
                            doc.SelectSingleNode("NewDataSet/Table/Home_State").InnerText + " " + doc.SelectSingleNode("NewDataSet/Table/Home_Zipcode").InnerText;
                    }
                }
                else
                {
                    Response.Redirect("/propertylisting.aspx");
                }
            }
            catch (Exception)
            {


            }
        }
    }
}