using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.App_Code.DAL
{
    public class frmDownloadSRateDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);


        public DataSet BindDistrictDAL()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindDistrict";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }


        public DataSet BindLocalBodyDAL(frmDownloadSRateBAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindLocalBodyDistrictWise";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@distID", SqlDbType.Int).Value = objBAL.DistID;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindStandardRates(frmDownloadSRateBAL objBAL)
        {
             DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspDownloadStandardRatesByLocalBody";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@LocalBodyID", SqlDbType.Int).Value = objBAL.LocalBodyId;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
        }
    }
}