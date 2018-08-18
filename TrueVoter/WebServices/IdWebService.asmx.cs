using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using TrueVoter;
using TrueVoter.App_Code.DAL;

namespace TrueVoter
{
    /// <summary>
    /// Summary description for IdWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IdWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public XmlDocument Get()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                IdDAL idDal = new IdDAL();

                idDal.Get();
                if (idDal.isError == CommonCode.OK)
                {
                    if (idDal.idsTable != null && idDal.idsTable.Tables[0].Rows.Count != 0)
                    {
                        idDal.idsTable.Tables[0].TableName = "Ids";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(idDal.idsTable);
                        XmlElement element = xmlDataDocument.DocumentElement;
                        return xmlDataDocument;
                    }
                }
                else
                {
                    XmlWriter writer = xmlDocument.CreateNavigator().AppendChild();
                    writer.WriteStartDocument(true);
                    writer.WriteStartElement("Error");
                    writer.WriteString(Convert.ToString(idDal.isError));
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                return xmlDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument GetSubId()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                IdDAL idDal = new IdDAL();

                idDal.GetSubId();
                if (idDal.isError == CommonCode.OK)
                {
                    if (idDal.idsTable != null && idDal.idsTable.Tables[0].Rows.Count != 0)
                    {
                        idDal.idsTable.Tables[0].TableName = "SubIds";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(idDal.idsTable);
                        XmlElement element = xmlDataDocument.DocumentElement;
                        return xmlDataDocument;
                    }
                }
                else
                {
                    XmlWriter writer = xmlDocument.CreateNavigator().AppendChild();
                    writer.WriteStartDocument(true);
                    writer.WriteStartElement("Error");
                    writer.WriteString(Convert.ToString(idDal.isError));
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                return xmlDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public string GetLocalbody()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                IdDAL idDal = new IdDAL();
                string data = "";
                idDal.getLocalBody();
                if (idDal.idsTable != null && idDal.idsTable.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < idDal.idsTable.Tables[0].Rows.Count; i++)
                    {
                        data += "*" + idDal.idsTable.Tables[0].Rows[i][0].ToString() + "*" + idDal.idsTable.Tables[0].Rows[i][1].ToString();
                    }
                }
                if (data != "")
                    return data.Substring(1, data.Length - 1);
                return "0";
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }
    }
}
