using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TrueVoter.App_Code.BAL;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for CheclUserName
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class CheclUserName : System.Web.Services.WebService
    {
        EncDecArrayClass objenc = new EncDecArrayClass();
        
        [WebMethod]
        public string checkUserName(string username) //Change Here
        {
            try
            {
                OthersBLL other = new OthersBLL();
                string s = other.checkUserName(username);
                return s;
            }
            catch
            {
                return "0";
            }
        }
        [WebMethod]
        public string GetJunior(string mobileNo) //Change Here
        {
            try
            {
                string[] uregid = mobileNo.Split('$');
                mobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);
                OthersDAL dal = new OthersDAL();
                return dal.ImigiateJuniour(mobileNo);
            }
            catch
            {
                return "0";
            }
        }
        [WebMethod]
        public string GetResponsibility(string localBody, string wardno, string mobileno) //Change Here
        {
            try
            {
                string[] uregid = mobileno.Split('$');
                mobileno = objenc.DecryptInteger(uregid[0], uregid[1]);

                OthersBLL bll = new OthersBLL();
                return bll.GetResponsibility(localBody, wardno, mobileno);
            }
            catch
            {
                return "0";
            }
        }
    }
}
