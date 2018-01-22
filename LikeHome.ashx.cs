using HousingApp.ClassFiles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HousingApp
{
    /// <summary>
    /// Summary description for LikeHome
    /// </summary>
    public class LikeHome : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool doesFavExist = false;
            if (context.Request.QueryString.HasKeys())
            {
                if (context.Request.QueryString["id"] != null)
                {
                    Int32 homeId = 0;
                    Int32.TryParse(context.Request.QueryString["id"].ToString(), out homeId);
                    Int32 userId = 0;
                    if (context.Request.QueryString["userId"] != null)
                    {
                        Int32.TryParse(context.Request.QueryString["userId"].ToString(), out userId);

                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@user_id", userId));
                        parameters.Add(new SqlParameter("@property_id", homeId));
                        doesFavExist = BO.CallSQLFunction("dbo.DoesFavoriteExist", parameters.ToArray());
                        if (!doesFavExist)
                        {
                            List<SqlParameter> sqlparameters = new List<SqlParameter>();
                            sqlparameters.Add(new SqlParameter("@user_id", userId));
                            sqlparameters.Add(new SqlParameter("@property_id", homeId));
                            BO.CallSQLProc("dbo.sp_Wishlist", sqlparameters.ToArray());
                        }
                    }
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(!doesFavExist ? "Favorite added succesfully" : " Favorite already exist, please select other property");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}