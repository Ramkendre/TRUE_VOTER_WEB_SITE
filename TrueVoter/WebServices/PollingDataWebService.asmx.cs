using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using TrueVoter.App_Code.BAL;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for PollingDataWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PollingDataWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string Insert(string pollingData) // Chnage
        {
            try
            {
                PollindDataBLL pollingDataBll = new PollindDataBLL();
                return pollingDataBll.insert(pollingData);
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }
        [WebMethod]
        public string AssignResponsibity(string data) //Change if need
        {
            try
            {
                PollindDataBLL pollingBll = new PollindDataBLL();
                return pollingBll.Responsibility(data);
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }
        [WebMethod]
        public string UserStatus(string data) //Change if need
        {
            try
            {
                PollindDataBLL pollingBll = new PollindDataBLL();
                return pollingBll.UserStatus(data);
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }
        [WebMethod]
        public string GetUserStatus(string userNo, string Ward, string localbody, string booth = null) //Change if need
        {
            try
            {
                PollindDataBLL bll = new PollindDataBLL();

                EncDecArrayClass objenc = new EncDecArrayClass();
                string[] uregid = userNo.Split('$');
                userNo = objenc.DecryptInteger(uregid[0], uregid[1]);

                return bll.GetUserStatus(localbody, Ward, userNo, booth);
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }

            #region Comment
            //XmlDocument xmlDocument = new XmlDocument();
            //try
            //{
            //    PollingDataDAL pollingDal = new PollingDataDAL();
            //    DataSet ds = pollingDal.GetUserStatus(userNo, Ward, booth,localbody);
            //    if (ds.Tables[0].Rows.Count != 0)
            //    {
            //        XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);
            //        XmlElement element = xmlDataDocument.DocumentElement;
            //        return xmlDataDocument;
            //    }
            //    else
            //    {
            //        ds=CommonCode.ErrorDs(CommonCode.DATA_NOT_FOUND.ToString());
            //        ds.Tables[0].TableName = "ErrorTable";
            //        XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);
            //        XmlElement element = xmlDataDocument.DocumentElement;
            //        return xmlDataDocument;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XmlWriter writer = xmlDocument.CreateNavigator().AppendChild();
            //    writer.WriteStartDocument(true);
            //    writer.WriteStartElement("Error");
            //    writer.WriteString(Convert.ToString(ex.Message));
            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //    writer.Close();
            //}
            //return xmlDocument;
            #endregion

        }
    }
}
