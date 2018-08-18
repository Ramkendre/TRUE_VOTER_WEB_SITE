using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TrueVoter.App_Code.BAL;
using TrueVoter;

namespace TrueVoter.App_Code.DAL
{
    public class OthersDAL
    {
       // private SqlCommand cmd = null;
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ToString());
        SqlConnection myctcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myctConnectionString"].ToString());
        private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet data = null;
        private int Error = CommonCode.OK;
        public int isError { get { return this.Error; } }
        public DataSet Data { get { return this.data; } }
        EncDecArrayClass objenc = new EncDecArrayClass();

        public void getDistrict(int state)
        {
            try
            {
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetDistricts]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@stateid", state);
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
        public void getTaluka(int district)
        {
            try
            {
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetTalukas]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@districtId", district);
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
        public void getLocalBody(int taluka, int district, int localBodytype)
        {
            try
            {
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetLocalBodies]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@localBodyType", localBodytype);
                sqlCommand.Parameters.AddWithValue("@district", district);
                sqlCommand.Parameters.AddWithValue("@taluka", taluka);
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
        public DataSet getVoters(string fName, string lName, string localBody)
        {
           
            DataSet ds = new DataSet();
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "SELECT [SLNOINPART],[HOUSE_NO],[fm_name_v1],[Lastname_v1] " +
          ",[RLN_TYPE],[RLN_FM_NM_v1],[RLN_L_NM_v1],[IDCARD_NO],[STATUSTYPE],[SEX],[AGE] " +
          ",[FM_NAMEEN],[LASTNAMEEN],[RLN_FM_NMEN],[RLN_L_NMEN],[FULL_NAMEEN] ,VUI_CODE " +
          ",[EB_No],[Allocated_Ward],[SerialNo_InWard],[Duplicate_Flag],[BoothNo] " +
          ",[ElectionID],[flag],[Dlt_Reason],[OLDWARD_NO], " +
          "[SerialNo_ForFinalList],Address.* " +
      "FROM [VoterApp_Data].[dbo].[Voter_Election_Data_Master] as ElectionData  left outer join " +
      "[VoterApp_Data].[dbo].[Section_Master] as Address " +
      "on Address.[SECTION_NO]=ElectionData.[SECTION_NO] and Address.[AC_NO]=ElectionData.[AC_NO] and Address.[PART_NO]=ElectionData.[PART_NO] " +
      "where [FM_NAMEEN] like '" + fName + "%' and [LASTNAMEEN] like '" + lName + "%' and [ElectionID]=" + localBody;
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }

        }
        public DataSet getVotersById(string Id)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "SELECT [SLNOINPART],[HOUSE_NO],[fm_name_v1],[Lastname_v1] " +
           ",[RLN_TYPE],[RLN_FM_NM_v1],[RLN_L_NM_v1],[IDCARD_NO],[STATUSTYPE],[SEX],[AGE] " +
           ",[FM_NAMEEN],[LASTNAMEEN],[RLN_FM_NMEN],[RLN_L_NMEN],[FULL_NAMEEN],(SELECT [jpgimage] FROM [VoterApp_Data].[dbo].[Citizen_Image_Master] where [VUI_CODE]=ElectionData.[VUI_CODE]) as VUI_CODE " +
           ",[EB_No],[Allocated_Ward],[SerialNo_InWard],[Duplicate_Flag],[BoothNo] " +
           ",[ElectionID],[flag],[Dlt_Reason],[OLDWARD_NO], " +
           "[SerialNo_ForFinalList],Address.* " +
           "FROM [VoterApp_Data].[dbo].[Voter_Election_Data_Master] as ElectionData  left outer join " +
           "[VoterApp_Data].[dbo].[Section_Master] as Address " +
           "on Address.[SECTION_NO]=ElectionData.[SECTION_NO] and Address.[AC_NO]=ElectionData.[AC_NO] and Address.[PART_NO]=ElectionData.[PART_NO] " +
           "  where [IDCARD_NO]='" + Id + "'";
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
        }
        public string checkuserName(string userName)
        {
            try
            {
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select count(*) FROM [TrueVoterDB].[dbo].[Logins] where [UserName]='" + userName + "'";
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(data);
                return data.Tables[0].Rows[0][0].ToString();
            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR.ToString();
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
        }

        /// <summary>
        /// Comment for ERROR SOLVING
        /// </summary>
        /// <param name="photid"></param>
        /// <returns></returns>
        //public Photo getPhoto(string photid)
        //{
        //    try
        //    {
        //        data = new DataSet();
        //        sqlCommand = new SqlCommand();
        //        sqlCommand.Connection = con;
        //        sqlCommand.CommandText = "select [jpgimage]  FROM [VoterApp_Data].[dbo].[Citizen_Image_Master] where [VUI_CODE]='" + photid + "'";
        //        if (sqlCommand.Connection.State == ConnectionState.Closed)
        //            sqlCommand.Connection.Open();
        //        byte[] b = sqlCommand.ExecuteScalar() as byte[];
        //        if (b == null)
        //        {
        //            return new Photo { status = 0, data = null };
        //        }
        //        else
        //        {
        //            return new Photo { status = 1, data = b };
        //        }

        //    }
        //    catch (SqlException)
        //    {

        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
        //    return null;
        //}
        public string insertbogusvoters(string regid, string wardno, string serialno, string type) // Want to change here
        {
            try
            {
                string[] uregid = regid.Split('$');
                string substr = uregid[0].Substring(0, 3);
                string ump = uregid[0].ToString();
                int len = ump.Length;
                len = len - 3;
                ump = ump.Substring(3, len);

                regid = objenc.DecryptInteger(ump, uregid[1]);
                regid = substr + regid;

                string query = "insert into [TrueVoterDB].[dbo].[BogusVoters] ([RegId],[WardNO],[SerialNo],[Type]) values('" + regid + "','" + wardno + "','" + serialno + "'," + type + ")";
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = query;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                return CommonCode.OK.ToString();
            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR.ToString();
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
        }
        public void insertBoothAddress(string localBody, string wardno, string boothno, string boothAddress, string lat, string log)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlCommand.CommandText = "insert into [TrueVoterDB].[dbo].[BoothAddresses] ([LocalBody],[Ward],[BoothNo],[BoothAddress],[Latitute],[Longitute]) " +
                                         " values('" + localBody + "','" + wardno + "','" + boothno + "',N'" + boothAddress + "','" + lat + "','" + log + "')";
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception) { }
        }
        public string ImigiateJuniour(string mobileNo)
        {
            try
            {
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = myctcon;
                sqlCommand.CommandText = "SELECT [Mobile_No],[Name] FROM [Come2myCityDB].[dbo].[tbl_TreeDemo] where [SMobile_No]='" + mobileNo + "' and [Keyword]='TRUEVOTER'";
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                string returnData = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnData += "*" + reader.GetString(0) + "*" + reader.GetString(1);
                    }
                    returnData = returnData.Substring(1, returnData.Length - 1);
                }
                else
                { returnData = CommonCode.DATA_NOT_FOUND.ToString(); }
                reader.Close();
                return returnData;
            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR.ToString();
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }

        }
        public DataSet GetJuniiours(string mobileno)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = myctcon;
                sqlCommand.CommandText = "[Come2myCityDB].[come2mycity].[uspGetTreeTrueVoters]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@mobileNo", mobileno);
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
        }
        public DataSet GetResponsibility(string data, string localbody, string wardno)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "SELECT [Id],[User],[WardNo],[BoothNo],[SNO],[Voted] FROM [TrueVoterDB].[dbo].[Responsibility] where [LocalBody]=" + localbody + " and [WardNo]='" + wardno + "' and [User] in(" + data + ")";
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
        }
    }
}