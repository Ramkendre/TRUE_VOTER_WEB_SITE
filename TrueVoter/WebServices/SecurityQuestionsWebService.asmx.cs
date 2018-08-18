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
    /// Summary description for SecurityQuestionsWebService
    /// </summary>
    /// 

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SecurityQuestionsWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string InsertSecurityQuestions(string questiionsString) //Change
        {
            try
            {
                SequrityQuestionsBLL securityQuestionsBll = new SequrityQuestionsBLL();
                return securityQuestionsBll.insert(questiionsString);
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }

        [WebMethod]
        public XmlDocument getQuestiions(string id, int type)
        {
            try
            {
                SequrityQuestionsBLL securityQuesionsBll = new SequrityQuestionsBLL();
                return securityQuesionsBll.getQuestions(id, type);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
    }
}
