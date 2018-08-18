using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using System.Data;

namespace TrueVoter.App_Code.BAL 
{
    public class OthersBLL
    {
        public XmlDocument getDistrict(int stateId)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                OthersDAL othersDal = new OthersDAL();
                othersDal.getDistrict(stateId);
                if (othersDal.isError == CommonCode.OK)
                {
                    if (othersDal.Data != null && othersDal.Data.Tables[0].Rows.Count != 0)
                    {
                        othersDal.Data.Tables[0].TableName = "District";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(othersDal.Data);
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
                    return commonCode.ErrorXml(CommonCode.FAIL);
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        public XmlDocument getTalukas(int districtId)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                OthersDAL othersDal = new OthersDAL();
                othersDal.getTaluka(districtId);
                if (othersDal.isError == CommonCode.OK)
                {
                    if (othersDal.Data != null && othersDal.Data.Tables[0].Rows.Count != 0)
                    {
                        othersDal.Data.Tables[0].TableName = "Talukas";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(othersDal.Data);
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
                    return commonCode.ErrorXml(CommonCode.FAIL);
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        public XmlDocument getLocalBodies(int district, int taluka, int localBodyType)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                OthersDAL othersDal = new OthersDAL();
                othersDal.getLocalBody(taluka, district, localBodyType);
                if (othersDal.isError == CommonCode.OK)
                {
                    if (othersDal.Data != null && othersDal.Data.Tables[0].Rows.Count != 0)
                    {
                        othersDal.Data.Tables[0].TableName = "LocalBodies";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(othersDal.Data);
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
                    return commonCode.ErrorXml(CommonCode.FAIL);
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        public XmlDocument getVotersById(string id)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                App_Code.DAL.OthersDAL othersDal = new App_Code.DAL.OthersDAL();
                System.Data.DataSet ds = othersDal.getVotersById(id);
                XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);
                XmlElement element = xmlDataDocument.DocumentElement;
                return xmlDataDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        public XmlDocument getVotersNames(string fName, string lName, string localBody)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                App_Code.DAL.OthersDAL othersDal = new App_Code.DAL.OthersDAL();
                System.Data.DataSet ds = othersDal.getVoters(fName, lName, localBody);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement element = xmldata.DocumentElement;
                return xmldata;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        public string checkUserName(string userName) //Chag
        {
            App_Code.DAL.OthersDAL otherDal = new App_Code.DAL.OthersDAL();
            return otherDal.checkuserName(userName);
        }
        public string GetResponsibility(string localBody, string wardno, string mobileno)
        {
            try
            {
                OthersDAL dal = new OthersDAL();
                DataSet ds = dal.GetJuniiours(mobileno);
                string juniours = "";
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        juniours += ",'" + ds.Tables[0].Rows[i][1].ToString() + "'";
                    juniours = juniours.Substring(1, juniours.Length - 1);


                    DataSet ds1 = dal.GetResponsibility(juniours, localBody, wardno);
                    juniours = "";
                    if (ds1.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            juniours += "*" + ds1.Tables[0].Rows[i][1].ToString() + "*" + ds1.Tables[0].Rows[i][4].ToString() + "*" + (ds.Tables[0].AsEnumerable().Where(a => a.Field<string>("USER_MOBILE") == ds1.Tables[0].Rows[i][1].ToString()).Select(r => r.Field<string>("Name")).First<string>());
                        juniours= juniours.Substring(1, juniours.Length - 1);
                    }
                    else
                        juniours += "" + CommonCode.DATA_NOT_FOUND.ToString();
                }
                else
                    juniours += ""+CommonCode.DATA_NOT_FOUND;
                return juniours;
            }
            catch (Exception)
            {
                return "" + CommonCode.ERROR;
            }
        }
    }
}