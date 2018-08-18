using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TrueVoter.App_Code.DAL;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;


namespace TrueVoter.App_Code.BAL
{
    public class FamiliesBll
    {
        public String insert(string familiesString)
        {
            try
            {
                string result = string.Empty;
                string[] stringArray = familiesString.Split(new char[] { '#', '*' });
                if ((stringArray.Length % 4) == 0)
                {
                    FamiliesDAL familiesDal = new FamiliesDAL();
                    for (int i = 0; i < stringArray.Length; i += 4)
                    {
                        result += familiesDal.insert(stringArray[i], stringArray[i + 1], Convert.ToInt32(stringArray[i + 2]), stringArray[i + 3]) + "*";
                    }
                    return result.Substring(0, result.Length - 1);
                }
                else
                    return CommonCode.WRONG_INPUT.ToString();
            }
            catch
            {
                return CommonCode.WRONG_INPUT.ToString();
            }
        }

        public XmlDocument getFamilyDetails(string regId)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                FamiliesDAL familiesDal = new FamiliesDAL();
                familiesDal.getFamilies(regId);
                if (familiesDal.isError == CommonCode.OK)
                {
                    if (familiesDal.FamilyData != null && familiesDal.FamilyData.Tables[0].Rows.Count != 0)
                    {
                        familiesDal.FamilyData.Tables[0].TableName = "FamilyDetails";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(familiesDal.FamilyData);
                        XmlElement element = xmlDataDocument.DocumentElement;
                        return xmlDataDocument;
                    }
                    else
                    {
                        CommonCode commonCode = new CommonCode();
                        return commonCode.ErrorXml(CommonCode.DATA_NOT_FOUND);
                    }
                }
                else
                {
                    CommonCode commonCode = new CommonCode();
                    return commonCode.ErrorXml(familiesDal.isError);
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
    }
}