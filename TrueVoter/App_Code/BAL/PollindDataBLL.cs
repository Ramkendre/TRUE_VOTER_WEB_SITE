using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;
using TrueVoter.App_Code.BAL;
using System.Data;

namespace TrueVoter.App_Code.BAL
{
    public class PollindDataBLL
    {
        public String insert(string pollingData)
        {
            try
            {
                string result = string.Empty;
                string[] pollingDataArray = pollingData.Split(new char[] { '#', '*' });
                if ((pollingDataArray.Length % 10) == 0)
                {
                    PollingDataDAL pollingDataDal = new PollingDataDAL();
                    for (int i = 0; i < pollingDataArray.Length; i += 10)
                    {
                        PollingData pollingDataClass = new PollingData();
                        pollingDataClass.userName = pollingDataArray[i];
                        pollingDataClass.wardNo = Convert.ToInt32(pollingDataArray[i + 1]);
                        pollingDataClass.boothNo = pollingDataArray[i + 2] != "" ? Convert.ToInt32(pollingDataArray[i + 2]) : 0;
                        pollingDataClass.noOfVoting = Convert.ToInt32(pollingDataArray[i + 3]);
                        pollingDataClass.voters = pollingDataArray[i + 4];
                        pollingDataClass.localBody = Convert.ToInt32(pollingDataArray[i + 5]);
                        pollingDataClass.imeino = pollingDataArray[i + 6];
                        pollingDataClass.userType = pollingDataArray[i + 7];
                        pollingDataClass.date = pollingDataArray[i + 8];
                        pollingDataClass.refMobileNo = pollingDataArray[i + 9];

                        result += pollingDataDal.insert(pollingDataClass) + "*";
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
        public string Responsibility(string data)
        {
            try
            {
                string result = string.Empty;
                string[] pollingDataArray = data.Split(new char[] { '#', '*' });
                if ((pollingDataArray.Length % 5) == 0)
                {
                    PollingDataDAL pollingDataDal = new PollingDataDAL();
                    for (int i = 0; i < pollingDataArray.Length; i += 5)
                    {
                        result += pollingDataDal.Responsibility(pollingDataArray[i], pollingDataArray[i + 1], pollingDataArray[i + 2], pollingDataArray[i + 3], pollingDataArray[i + 4]) + "*";
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
        public string UserStatus(string data)
        {
            try
            {
                string result = string.Empty;
                string[] pollingDataArray = data.Split(new char[] { '#', '*' });
                if ((pollingDataArray.Length % 6) == 0)
                {
                    PollingDataDAL pollingDataDal = new PollingDataDAL();
                    for (int i = 0; i < pollingDataArray.Length; i += 6)
                    {
                        result += pollingDataDal.UserStatus(pollingDataArray[i], pollingDataArray[i + 1], pollingDataArray[i + 2], pollingDataArray[i + 3], pollingDataArray[i + 4], pollingDataArray[i + 5]) + "*";
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
        public string GetUserStatus(string localBody, string wardno, string mobileno, string boothno)
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

                    PollingDataDAL podal = new PollingDataDAL();
                    DataSet ds1 = podal.GetUserStatus(juniours, wardno, boothno, localBody);
                    juniours = "";
                    if (ds1.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            juniours += "*" + ds1.Tables[0].Rows[i][3].ToString() + "*" + ds1.Tables[0].Rows[i][4].ToString();
                        juniours = juniours.Substring(1, juniours.Length - 1);
                    }
                    else
                        juniours += "" + CommonCode.DATA_NOT_FOUND.ToString();
                }
                else
                    juniours += "" + CommonCode.DATA_NOT_FOUND;
                return juniours;
            }
            catch (Exception)
            {
                return "" + CommonCode.ERROR;
            }
        }
    }
}