using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.App_Code.DAL
{
    public class FamiliesDAL
    {
        private SqlCommand cmd = null;
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ToString());


        private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet data = null;
        private int Error = CommonCode.OK;
        public int isError { get { return this.Error; } }
        public DataSet FamilyData { get { return this.data; } }
        EncDecArrayClass objenc = new EncDecArrayClass();

        public int insert(string mobileNo, string name, int relation, string regId)
        {
            try
            {
                string[] uregid = regId.Split('$');
                string substr = uregid[0].Substring(0, 3);
                string ump = uregid[0].ToString();
                int len = ump.Length;
                len = len - 3;
                ump = ump.Substring(3, len);

                regId = objenc.DecryptInteger(ump, uregid[1]);
                regId = substr + regId;

                string[] ump1 = mobileNo.Split('$');
                mobileNo = objenc.DecryptInteger(ump1[0], ump1[1]);


                cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
                cmd.Parameters.Add(new SqlParameter("@Name", name));
                cmd.Parameters.Add(new SqlParameter("@Relation", relation));
                cmd.Parameters.Add(new SqlParameter("@RegId", regId));
                SqlParameter retrunParameter = cmd.CreateParameter();
                retrunParameter.Direction = ParameterDirection.ReturnValue;
                retrunParameter.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(retrunParameter);

                cmd.Connection = con;
                cmd.CommandText = "[TrueVoterDB].[dbo].[uspInsertFamilies]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (Convert.ToString(retrunParameter.Value) == "1")
                    {
                        return CommonCode.OK;
                    }
                    else
                        return CommonCode.FAIL;
                }
                catch (SqlException)
                {
                    return CommonCode.ERROR;
                }
                finally { cmd.Connection.Close(); cmd.Dispose(); }
            }
            catch
            {
                return CommonCode.ERROR;
            }
        }
        public void getFamilies(string regId)
        {
            try
            {
                string[] uregid = regId.Split('$');
                string substr = uregid[0].Substring(0, 3);
                string ump = uregid[0].ToString();
                int len = ump.Length;
                len = len - 3;
                ump = ump.Substring(3, len);

                regId = objenc.DecryptInteger(ump, uregid[1]);
                regId = substr + regId;

                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetFamilyDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@regId", regId);
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(data);
            }
            catch (SqlException)
            {
                Error = CommonCode.SQL_ERROR;
            }
            catch (Exception)
            {
                Error = CommonCode.ERROR;
            }
        }
    }
}