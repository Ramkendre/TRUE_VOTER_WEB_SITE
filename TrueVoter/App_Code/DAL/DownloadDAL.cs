using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TrueVoter.App_Code.DAL
{
    public class DownloadDAL
    {
        //private SqlCommand cmd = null;
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ToString());


        private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet data = null;
        private int Error = CommonCode.OK;
        public int isError { get { return this.Error; } }
        public DataSet Data { get { return this.data; } }

        public void downloadVoterList(string localBody, string wardno, string boothno, int count)
        {
            try
            {
                string query = "with data as(SELECT Row_Number() over (order by[FULL_NAMEEN]) as row,  [SLNOINPART],[HOUSE_NO],[fm_name_v1],[Lastname_v1]" +
                               " ,[RLN_TYPE],[RLN_FM_NM_v1],[RLN_L_NM_v1],[IDCARD_NO],[STATUSTYPE],[SEX],[AGE]" +
                               " ,[FM_NAMEEN],[LASTNAMEEN],[RLN_FM_NMEN],[RLN_L_NMEN],[VUI_CODE],[FULL_NAMEEN]" +
                               " ,[EB_No],[Allocated_Ward],[SerialNo_InWard],[Duplicate_Flag],[BoothNo]" +
                               " ,[ElectionID],[flag],[Dlt_Reason],[OLDWARD_NO]," +
                               " [SerialNo_ForFinalList],[Allocated_booth_No],Address.*" +
                               " FROM [VoterApp_Data].[dbo].[Voter_Election_Data_Master] as ElectionData" +
                               " left outer join" +
                               " [VoterApp_Data].[dbo].[Section_Master] as Address" +
                               " on Address.[SECTION_NO]=ElectionData.[SECTION_NO] and Address.[AC_NO]=ElectionData.[AC_NO] and Address.[PART_NO]=ElectionData.[PART_NO]" +
                               " where [ElectionID]=" + localBody + " and [Allocated_Ward]=" + wardno + ")select top 250 * from data where row >" + count;

                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = query;
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
        public void downloadCandiateInformation(string localBody, string wardno)
        {
            try
            {
                string query = "SELECT [Id],[Name],[PartyName],[localBody],[Address],[wardno],[Symbol] FROM [TrueVoterDB].[dbo].[CandidateInformation] where localBody='" + localBody + "' and wardno ='" + wardno + "'";
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = query;
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

        public void downloadDistrictInformation()
        {
            try
            {
                string sql = "select * from [TrueVoterDB].[dbo].[tblDistrictMapping]";
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(data);
            }
            catch (Exception)
            {
                
            }
        }

        public void downloadAssemblyInformation()
        {
            try
            {
                string sql = "SELECT [Id] AS SrNo,[Id] AS ConstituencyNo,[Name_E] AS ConstituencyName,[TrueVoterDB].[dbo].[Talukas].[DistrictId] AS DistrictCode FROM [TrueVoterDB].[dbo].[Talukas] "+
                             "WHERE [DistrictId] IN (SELECT [Id] FROM [TrueVoterDB].[dbo].[Districts] WHERE [TrueVoterDB].[dbo].[Districts].[StateId] = 12)";
                //string sql = "select * from [TrueVoterDB].[dbo].[tblAssemblyMapping]";
                data = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(data);
            }
            catch (Exception)
            {
                
            }
        }
    }
}