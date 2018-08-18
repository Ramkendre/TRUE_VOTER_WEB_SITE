using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using TrueVoter.App_Code.BAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for DownloadVoterInformation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DownloadVoterInformation : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

       
        [WebMethod]
        public XmlDocument downloadfromWard(string localBody, string wardno, string boothNo, int count)
        {
            try
            {
                DownloadBLL downloadBll = new DownloadBLL();
                return downloadBll.getdataByWardNo(localBody, wardno, boothNo, count);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        [WebMethod]
        public XmlDocument downloadCandiateInformation(string localBody, string wardno)
        {
            try
            {
                DownloadBLL downloadBll = new DownloadBLL();
                return downloadBll.downloadCandidateInforamation(localBody, wardno);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument downloadAssembly() //Download Taluka Call When True voter App Start
        {
            try
            {
                DownloadBLL downloadBll = new DownloadBLL();
                return downloadBll.downloadAssemblyInfo();
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument downloadDistrict() //Download District Basic Details Call When True voter App Start
        {
            try
            {
                DownloadBLL downloadBll = new DownloadBLL();
                return downloadBll.downloadDistrictInfo();
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }        
    }
}
