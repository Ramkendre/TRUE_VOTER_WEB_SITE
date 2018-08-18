using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TrueVoter.App_Code.DAL;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;

namespace TrueVoter.App_Code.BAL
{
    public class DownloadBLL
    {
        public XmlDocument getdataByWardNo(string localBody,string wardno,string boothNo,int count)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                DownloadDAL downloadDal = new DownloadDAL();
                downloadDal.downloadVoterList(localBody, wardno, boothNo, count);
                if (downloadDal.isError == CommonCode.OK)
                {
                    if (downloadDal.Data != null && downloadDal.Data.Tables[0].Rows.Count != 0)
                    {
                        downloadDal.Data.Tables[0].TableName = "VotersInformation";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(downloadDal.Data);
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
                    return commonCode.ErrorXml(downloadDal.isError);
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        public XmlDocument downloadCandidateInforamation(string localBody, string wardno)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                DownloadDAL downloadDal = new DownloadDAL();
                downloadDal.downloadCandiateInformation(localBody, wardno);
                if (downloadDal.isError == CommonCode.OK)
                {
                    if (downloadDal.Data != null && downloadDal.Data.Tables[0].Rows.Count != 0)
                    {
                        downloadDal.Data.Tables[0].TableName = "CandidateInformation";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(downloadDal.Data);
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
                    return commonCode.ErrorXml(downloadDal.isError);
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        public XmlDocument downloadDistrictInfo()
        {
            try
            {

                XmlDocument xmlDocument = new XmlDocument();
                DownloadDAL downloadDal = new DownloadDAL();
                downloadDal.downloadDistrictInformation();
                downloadDal.Data.Tables[0].TableName = "tblDistrictMapping";
                XmlDataDocument xmlDataDocument = new XmlDataDocument(downloadDal.Data);
                XmlElement element = xmlDataDocument.DocumentElement;
                return xmlDataDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        public XmlDocument downloadAssemblyInfo()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                DownloadDAL downloadDal = new DownloadDAL();
                downloadDal.downloadAssemblyInformation();
                downloadDal.Data.Tables[0].TableName = "tblAssemblyMapping";
                XmlDataDocument xmlDataDocument = new XmlDataDocument(downloadDal.Data);
                XmlElement element = xmlDataDocument.DocumentElement;
                return xmlDataDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
    }
}