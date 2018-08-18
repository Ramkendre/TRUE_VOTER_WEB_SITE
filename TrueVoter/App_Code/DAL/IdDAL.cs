using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Caching;


namespace TrueVoter.App_Code.DAL
{
    public class IdDAL
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        //private Id id;
       // private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet data = null;
        private string getQuery = "[TrueVoterDB].[dbo].[uspGetIds]";
        private string getSubIdQuery = "[TrueVoterDB].[dbo].[uspGetSubids]";
        private int Error = CommonCode.OK;
        public int isError { get { return this.Error; } }
        public DataSet idsTable { get { return this.data; } }
        //public IdDAL(Id idClass)
        //{
        //    this.id = idClass;
        //}
        public IdDAL()
        {
        }
        //public bool isValid()
        //{
        //    return (this.id.id != 0 && this.id.Name != null && id.Name != " ") ? true : false;
        //}
        public void Get()
        {
            try
            {
                DataSet Idds = HttpRuntime.Cache["ID"] as DataSet;
                
                if (Idds == null)
                {
                    data = new DataSet();
                    sqlDataAdapter = new SqlDataAdapter(getQuery, sqlConnection);
                    sqlDataAdapter.Fill(data);
                    HttpRuntime.Cache.Insert("Id",data, null, DateTime.Now.AddHours(2), Cache.NoSlidingExpiration);	
                }
                else
                {
                    this.data = HttpRuntime.Cache["ID"] as DataSet;
                }
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
        public void GetSubId()
        {
            try
            {
                DataSet Idds = HttpRuntime.Cache["ID"] as DataSet;
                if (Idds == null)
                {
                    data = new DataSet();
                    sqlDataAdapter = new SqlDataAdapter(getSubIdQuery, sqlConnection);
                    sqlDataAdapter.Fill(data);
                }
                else
                {
                    this.data = HttpRuntime.Cache["ID"] as DataSet;
                }
            }
            catch (SqlException)
            {
                Error = CommonCode.SQL_ERROR;
            }
        }
        public void getLocalBody() 
        {
            try
            {  
                    data = new DataSet();
                    sqlDataAdapter = new SqlDataAdapter(" select [ElectionID],[ElectionName] FROM [VoterApp_Data].[dbo].[Election_Master]", sqlConnection);
                    sqlDataAdapter.Fill(data);
                    HttpRuntime.Cache.Insert("Id", data, null, DateTime.Now.AddHours(2), Cache.NoSlidingExpiration);
                
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