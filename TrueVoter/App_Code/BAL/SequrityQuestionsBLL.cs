using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;

namespace TrueVoter.App_Code.BAL
{
    public class SequrityQuestionsBLL
    {
        public string insert(string questionsString)
        {
            try
            {
                string result = string.Empty;
                string[] stringArray = questionsString.Split(new char[] { '#', '*' });
                if ((stringArray.Length % 3) == 0)
                {
                    SecurityQuestionsDAL securityQuestionsDal = new SecurityQuestionsDAL();
                    for (int i = 0; i < stringArray.Length; i += 3)
                    {
                        result += securityQuestionsDal.insert(Convert.ToInt32(stringArray[i]), stringArray[i + 1], stringArray[i + 2]) + "*";
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

        public XmlDocument getQuestions(string id, int type)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                SecurityQuestionsDAL securityQuesionsDal = new SecurityQuestionsDAL();
                securityQuesionsDal.getQuestions(id, type);
                if (securityQuesionsDal.isError == CommonCode.OK)
                {
                    if (securityQuesionsDal.QuestionsData != null && securityQuesionsDal.QuestionsData.Tables[0].Rows.Count != 0)
                    {
                        securityQuesionsDal.QuestionsData.Tables[0].TableName = "Questions";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(securityQuesionsDal.QuestionsData);
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
                return commonCode.ErrorXml(CommonCode.FAIL);
            }
        }
    }
}