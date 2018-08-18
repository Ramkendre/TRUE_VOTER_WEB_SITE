using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for insertfeedbackDLL
/// </summary>
public class insertfeedbackDLL
{    
	public insertfeedbackDLL()
	{
		//
		// TODO: Add constructor logic here
		//        
	}
    public int insertfeedbackinfo(string subject, string message, int type, string insertiondate, string regid)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "uspinsertfeedbackform";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@message", message);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@insertiondate", insertiondate);
            cmd.Parameters.AddWithValue("@regid", regid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return 1;
    }
}