using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for FamiliesWebService
    /// </summary>
    /// 

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FamiliesWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string InsertFamilies(string FamiliesString) //change here
        {
            try
            {
                FamiliesBll familiesbll = new FamiliesBll();
                return familiesbll.insert(FamiliesString);
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }

        [WebMethod]
        public XmlDocument getFamilies(string regid) //change here
        {
            try
            {
                FamiliesBll familiesBll = new FamiliesBll();
                return familiesBll.getFamilyDetails(regid);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
    }
}
