using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrueVoter.App_Code.DAL
{
    public class Connection
    {
        public static SqlConnection GetConnectionString()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
            return con;
        }
    }
}