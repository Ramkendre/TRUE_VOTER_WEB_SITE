using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using TrueVoter;
using TrueVoter.App_Code.BAL;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for SearchWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchWebService : System.Web.Services.WebService
    {
        EncDecArrayClass objenc = new EncDecArrayClass();
        [WebMethod]
        public XmlDocument SearchUserByMobile(string mobileNo)
        {
            try
            {
                string[] uregid = mobileNo.Split('$');
                mobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);

                XmlDocument xmlDocument = new XmlDocument();
                SearchBAL searchBal = new SearchBAL(mobileNo);
                if (searchBal.isValid())
                {
                    SearchDAL searchDal = new SearchDAL();
                    searchDal.SearchUserByMobile(mobileNo);
                    if (searchDal.isError == CommonCode.OK)
                    {
                        if (searchDal.userData != null && searchDal.userData.Tables[0].Rows.Count != 0)
                        {
                            searchDal.userData.Tables[0].TableName = "FamilyDetails";
                            XmlDataDocument xmlDataDocument = new XmlDataDocument(searchDal.userData);
                            XmlElement element = xmlDataDocument.DocumentElement;
                            return xmlDataDocument;
                        }
                        else if (searchDal.userData.Tables[0].Rows.Count == 0)
                        {

                            XmlDocument doc = new XmlDocument();
                            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                            doc.AppendChild(docNode);

                            XmlNode errrorNode = doc.CreateElement("ErrorMainNode");
                            doc.AppendChild(errrorNode);

                            XmlNode nameNode = doc.CreateElement("Error");
                            nameNode.AppendChild(doc.CreateTextNode(CommonCode.DATA_NOT_FOUND.ToString()));
                            errrorNode.AppendChild(nameNode);
                            return doc;
                        }
                    }
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);

                        XmlNode errrorNode = doc.CreateElement("ErrorMainNode");
                        doc.AppendChild(errrorNode);

                        XmlNode nameNode = doc.CreateElement("Error");
                        nameNode.AppendChild(doc.CreateTextNode(Convert.ToString(searchDal.isError)));
                        errrorNode.AppendChild(nameNode);
                    }
                }
                else
                {

                    XmlDocument doc = new XmlDocument();
                    XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(docNode);

                    XmlNode errrorNode = doc.CreateElement("ErrorMainNode");
                    doc.AppendChild(errrorNode);

                    XmlNode nameNode = doc.CreateElement("Error");
                    nameNode.AppendChild(doc.CreateTextNode(Convert.ToString(CommonCode.WRONG_INPUT)));
                    errrorNode.AppendChild(nameNode);
                }
                return xmlDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
    }
}
