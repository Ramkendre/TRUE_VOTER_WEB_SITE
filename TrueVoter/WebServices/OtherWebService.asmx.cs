using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;
using TrueVoter;
using TrueVoter.App_Code.BAL;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for OtherWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OtherWebService : System.Web.Services.WebService
    {
        private SqlCommand cmd = null;
        private SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ToString());
       // private SqlCommand sqlCommand = null;
        SqlDataAdapter da = new SqlDataAdapter();
      //  private SqlDataAdapter sqlDataAdapter = null;
        TrueVoter.CommonCode commonCode = new TrueVoter.CommonCode();

        EncDecArrayClass objenc = new EncDecArrayClass();
        [WebMethod]
        public XmlDocument Districts(int state)
        {
            try
            {
                OthersBLL othersDll = new OthersBLL();
                return othersDll.getDistrict(state);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument Talukas(int district)
        {
            try
            {
                OthersBLL othersDll = new OthersBLL();
                return othersDll.getTalukas(district);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument LocalBodies(int district, int taluka, int localBodyType)
        {
            try
            {
                OthersBLL othersDll = new OthersBLL();
                return othersDll.getLocalBodies(district, taluka, localBodyType);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public int insertfeedbackform(string subject, string message, int type, string regid) //Change
        {
            insertfeedbackBll insertbll = new insertfeedbackBll();
            try
            {
                string[] uregid = regid.Split('$');
                string substr = uregid[0].Substring(0, 3);
                string ump = uregid[0].ToString();
                int len = ump.Length;
                len = len - 3;
                ump = ump.Substring(3, len);

                regid = objenc.DecryptInteger(ump, uregid[1]);
                regid = substr + regid;

                string insertiondate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                return insertbll.insertfeebackinfobll(subject, message, type, insertiondate, regid);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [WebMethod]
        public XmlDocument getVoters(string fName, string lName, string localBody)
        {
            try
            {
                OthersBLL othersDll = new OthersBLL();
                return othersDll.getVotersNames(fName, lName, localBody);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
        [WebMethod]
        public XmlDocument getVotersById(string id)
        {
            try
            {
                OthersBLL othersDll = new OthersBLL();
                return othersDll.getVotersById(id);
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        //[WebMethod]
        //public byte[] getPhoto(string photoId)
        //{
        //    OthersDAL dal = new OthersDAL();
        //    return  dal.getPhoto(photoId);
        //}



        [WebMethod]
        public string GcmDemo()
        {
            try
            {
                //return AndroidPush();
            }
            catch (Exception)
            {
                return "0"; // throw ex;
            }
            return "NO";
        }
        class PostData
        {
            public class Msg
            {
                public string message { get; set; }
                public Msg(string msg)
                { this.message = msg; }
            }


            public string ApplicationId { get; set; }
            public string senderId { get; set; }
            public Msg data { get; set; }
            public List<string> registration_ids { get; set; }
            public string collapse_key { get; set; }
            public int time_to_live { get; set; }
            public bool delay_while_idle { get; set; }


            public PostData(string applicationId, string SenderId, string Message, List<string> regids)
            {
                this.ApplicationId = applicationId;
                this.senderId = SenderId;
                this.data = new Msg(Message); ;

                this.registration_ids = regids;
            }

        }

        #region Commented Code of Ganesh
        //private string MulitipleSenders()
        //{
        //    // your RegistrationID paste here which is received from GCM server.                                                               
        //    //string regId = "APA91bHpKCrA2LLRiqsLka30zpWDntVnppWvWrXPnBwurilCt78rOispJ2rXK4fY3tynRqjh81ZYVg5YsHk2xPIhPgRcxBxeKlkXO5fieOfvxmc-rQJZglzkbyAAI5KoxQvTSksRYn_kZl90O4uyaFfpe76Wwls_u26gbBbn7uj8A8Sirb7laG4";
        //    string regId = "APA91bG1W5WbvZUFb13N2dI3_KQzOZLOrTWaINxllCER0Gk4xDuic1Pr6oD_w0hS7tJKfAUu_KiPtjnBUeqWVE9AV1ZMQMLTBiN_UCGzItQwbZfZvDjdIfLcL_H9GtID_JRw3SCgjiQ-zBMVleTsKkCe_PHrID85ug";
        //    List<string> RegList = new List<string>();
        //    RegList.Add(regId);
        //    regId = "APA91bEoS8EL_YrmaWwxT8Z1fOzEIAvXCuBy0zgb78GREvwiloKmDsQBcqllq_K02_8LzQurdkxDM1e33IGedl3FIWu551NTAeFNeQdZM5YijdXBYYwsoKoYLI-yoPQXL_Mxt1cr8ObrS11srTRAYVEKz3Ley1-85g";
        //    RegList.Add(regId);

        //    // applicationID means google Api key                                                                                                     
        //    var applicationID = "AIzaSyApgVPYik8j43hbRlDAfI1Zhnt3mM_qEY0";
        //    //var applicationID = "AIzaSyBRNNThLacZjhvY8K1SrJGaUAAYfkNi4vo";

        //    // SENDER_ID is nothing but your ProjectID (from API Console- google code)//                                          
        //    var SENDER_ID = "1003894098616";
        //    // var SENDER_ID = "490997419744";

        //    var value = "Hello Ganesh"; //message text box                                                                               

        //    PostData pdata = new PostData(applicationID, SENDER_ID, value, RegList);

        //    pdata.collapse_key = "score_update";
        //    pdata.time_to_live = 108;
        //    pdata.delay_while_idle = true;


        //    System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    string s = js.Serialize(pdata);



        //    System.Net.WebRequest tRequest;

        //    tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");

        //    tRequest.Method = "post";

        //    tRequest.ContentType = " application/json";

        //    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

        //    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

        //    //Data post to server                                                                                                                                         
        //    //string postData =     
        //    //     "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="         
        //    //      + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" +      
        //    //         regId + "";
        //    string postData =
        //                  "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.msg=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" +
        //                      regId + "";


        //    Console.WriteLine(postData);

        //    Byte[] byteArray = Encoding.UTF8.GetBytes(s);

        //    tRequest.ContentLength = byteArray.Length;

        //    Stream dataStream = tRequest.GetRequestStream();

        //    dataStream.Write(byteArray, 0, byteArray.Length);

        //    dataStream.Close();

        //    WebResponse tResponse = tRequest.GetResponse();

        //    dataStream = tResponse.GetResponseStream();

        //    StreamReader tReader = new StreamReader(dataStream);

        //    String sResponseFromServer = tReader.ReadToEnd();   //Get response from GCM server.

        //    //Assigning GCM response to Label text 

        //    tReader.Close();

        //    dataStream.Close();
        //    tResponse.Close();
        //    return sResponseFromServer;    //Assigning GCM response to Label text 
        //}                     



        ////private string SingleMessage()
        ////{
        ////    // your RegistrationID paste here which is received from GCM server.                                                               
        ////    //string regId = "APA91bHpKCrA2LLRiqsLka30zpWDntVnppWvWrXPnBwurilCt78rOispJ2rXK4fY3tynRqjh81ZYVg5YsHk2xPIhPgRcxBxeKlkXO5fieOfvxmc-rQJZglzkbyAAI5KoxQvTSksRYn_kZl90O4uyaFfpe76Wwls_u26gbBbn7uj8A8Sirb7laG4";
        ////    string regId = "APA91bG1W5WbvZUFb13N2dI3_KQzOZLOrTWaINxllCER0Gk4xDuic1Pr6oD_w0hS7tJKfAUu_KiPtjnBUeqWVE9AV1ZMQMLTBiN_UCGzItQwbZfZvDjdIfLcL_H9GtID_JRw3SCgjiQ-zBMVleTsKkCe_PHrID85ug";

        ////    // applicationID means google Api key                                                                                                     
        ////    var applicationID = "AIzaSyApgVPYik8j43hbRlDAfI1Zhnt3mM_qEY0";
        ////    //var applicationID = "AIzaSyBRNNThLacZjhvY8K1SrJGaUAAYfkNi4vo";

        ////    // SENDER_ID is nothing but your ProjectID (from API Console- google code)//                                          
        ////    var SENDER_ID = "1003894098616";
        ////   // var SENDER_ID = "490997419744";

        ////    var value = "Hello Ganesh"; //message text box                                                                               

        ////    System.Net.WebRequest tRequest;

        ////    tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");

        ////    tRequest.Method = "post";

        ////    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";

        ////    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

        ////    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

        ////    //Data post to server                                                                                                                                         
        ////    //string postData =     
        ////    //     "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="         
        ////    //      + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" +      
        ////    //         regId + "";
        ////    string postData =
        ////                  "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.msg="+value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" +
        ////                      regId + "";


        ////    Console.WriteLine(postData);

        ////    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        ////    tRequest.ContentLength = byteArray.Length;

        ////    Stream dataStream = tRequest.GetRequestStream();

        ////    dataStream.Write(byteArray, 0, byteArray.Length);

        ////    dataStream.Close();

        ////    WebResponse tResponse = tRequest.GetResponse();

        ////    dataStream = tResponse.GetResponseStream();

        ////    StreamReader tReader = new StreamReader(dataStream);

        ////    String sResponseFromServer = tReader.ReadToEnd();   //Get response from GCM server.

        ////    //Assigning GCM response to Label text 

        ////    tReader.Close();

        ////    dataStream.Close();
        ////    tResponse.Close();
        ////    return sResponseFromServer;    //Assigning GCM response to Label text 
        ////}                     

        #endregion

        [WebMethod]
        public string insertBogusVoters(string information)
        {
            try
            {
                OthersDAL otherdal = new OthersDAL();
                string[] voers = information.Split(new char[] { '*' });
                return otherdal.insertbogusvoters(voers[0], voers[1], voers[2], voers[3]);
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
        }

        //[WebMethod]
        //public string insertBoothAddress(string data)
        //{
        //    try
        //    {
        //        string[] dataArray = data.Split(new char[] { '*' });
        //        OthersDAL otherDal = new OthersDAL();
        //        for (int i = 0; i < dataArray.Length; i += 6)
        //        {
        //            try
        //            {
        //                otherDal.insertBoothAddress(dataArray[i].ToString(), dataArray[i + 1].ToString(), dataArray[i + 2].ToString(), dataArray[i + 3].ToString(), dataArray[i + 4].ToString(), dataArray[i + 5].ToString());
        //            }
        //            catch { return "0"; }
        //        }
        //        return "1";
        //    }
        //    catch
        //    {
        //        return "0";
        //    }
        //}

        #region REGION FOR INSERT AND DOWNLOAD BOOTH ADDRESS

        [WebMethod(Description = "WEB METHOD FOR INSERT BOOTH ADDRESS")]
        public string InsertBoothAddressNEW(string boothAddData)
        {
            string returnString = string.Empty;
            try
            {
                string[] str = null;
                string id = string.Empty;
                string localBody = string.Empty;
                string wardno = string.Empty;
                string boothno = string.Empty;
                string boothAddress = string.Empty;
                string lat = string.Empty;
                string log = string.Empty;
                string imei = string.Empty;
                string createdBy = string.Empty;
                string createdDate = string.Empty;
                string modifyBy = string.Empty;
                string modifyDate = string.Empty;
                string refrenceNo = string.Empty;
                string localBodyID = string.Empty;

                str = boothAddData.Split(new char[] { '#', '*' });
                for (int i = 0; i < str.Length - 1; i += 11)
                {
                    localBody = str[i].ToString().Trim();
                    wardno = str[i + 1].Trim();
                    boothno = str[i + 2].ToString().Trim();
                    boothAddress = str[i + 3].ToString().Trim();
                    lat = str[i + 4].ToString().Trim();
                    log = str[i + 5].ToString().Trim();
                    
                    createdBy = str[i + 6].ToString().Trim();
                    refrenceNo = str[i + 7].ToString().Trim();
                    imei = str[i + 8].ToString().Trim();
                    localBodyID = str[i + 9].ToString().Trim();
                    id = str[i + 10].ToString().Trim();
                    
                    createdDate = System.DateTime.Now.ToString("yyyy-MM-dd");

                    string sql = "INSERT INTO [TrueVoterDB].[dbo].[BoothAddresses] ([LocalBody],[Ward],[BoothNo],[BoothAddress],[Latitute],[Longitute],[CreatedBy],[ReffrenceMo],[IMEI],[LocalBodyId],[CreatedDate]) " +
                                            " values('" + localBody + "','" + wardno + "','" + boothno + "',N'" + boothAddress + "','" + lat + "','" + log + "','" + createdBy + "','" + refrenceNo + "','" + imei + "','" + localBodyID + "','" + createdDate + "')";

                    commonCode.ExecuteNonQuery(sql);

                    string sqlMaxId = "SELECT MAX(Id) FROM [TrueVoterDB].[dbo].[BoothAddresses](NOLOCK)";
                    string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                    returnString += id + "*" + MaxId + "#";
                }
                return returnString;
            }
            catch
            {
                return returnString = "0";
            }
        }


        [WebMethod(Description = "WEB METHOD FOR DOWNLOAD BOOTH ADDRESS")]
        public string downloadBoothAddress(string localBody, string wardNo)
        {
            string returnString = string.Empty;
            string id = string.Empty;
            string localBodyId = string.Empty;
            string ward = string.Empty;
            string boothNo = string.Empty;
            string boothAddress = string.Empty;
            string latitute = string.Empty;
            string longitute = string.Empty;
            string imei = string.Empty;
            string createdBy = string.Empty;
            string createdDate = string.Empty;
            string refrenceNo = string.Empty;
            string localBodyID = string.Empty;


            DataSet DS = new DataSet();
            try
            {
                string query = "SELECT TOP 50 [Id],[LocalBody],[Ward],[BoothNo],[BoothAddress],[Latitute],[Longitute],[LocalBodyId],[CreatedBy],[ReffrenceMo],[IMEI],[CreatedDate] FROM [TrueVoterDB].[dbo].[BoothAddresses](NOLOCK) WHERE [LocalBodyId]='" + localBody.Trim() + "' AND [Ward]='" + wardNo.Trim() + "'";
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(DS);
                int rowCount = Convert.ToInt32(DS.Tables[0].Rows.Count);
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        id = DS.Tables[0].Rows[i]["Id"].ToString().Trim();

                        if (DS.Tables[0].Rows[i]["LocalBody"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["LocalBody"].ToString().Trim() == null)
                        {
                            localBodyId = "0";
                        }
                        else
                        {
                            localBodyId = DS.Tables[0].Rows[i]["LocalBody"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["Ward"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["Ward"].ToString().Trim() == null)
                        {
                            ward = "0";
                        }
                        else
                        {
                            ward = DS.Tables[0].Rows[i]["Ward"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["BoothNo"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["BoothNo"].ToString().Trim() == null)
                        {
                            boothNo = "0";
                        }
                        else
                        {
                            boothNo = DS.Tables[0].Rows[i]["BoothNo"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["BoothAddress"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["BoothAddress"].ToString().Trim() == null)
                        {
                            boothAddress = "0";
                        }
                        else
                        {
                            boothAddress = DS.Tables[0].Rows[i]["BoothAddress"].ToString().Trim();
                        }
                        if (DS.Tables[0].Rows[i]["Latitute"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["Latitute"].ToString().Trim() == null)
                        {
                            latitute = "0";
                        }
                        else
                        {
                            latitute = DS.Tables[0].Rows[i]["Latitute"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["Longitute"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["Longitute"].ToString().Trim() == null)
                        {
                            longitute = "0";
                        }
                        else
                        {
                            longitute = DS.Tables[0].Rows[i]["Longitute"].ToString().Trim();
                        }





                        if (DS.Tables[0].Rows[i]["LocalBodyId"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["LocalBodyId"].ToString().Trim() == null)
                        {
                            localBodyID = "0";
                        }
                        else
                        {
                            localBodyID = DS.Tables[0].Rows[i]["LocalBodyId"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["CreatedBy"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["CreatedBy"].ToString().Trim() == null)
                        {
                            createdBy = "0";
                        }
                        else
                        {
                            createdBy = DS.Tables[0].Rows[i]["CreatedBy"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["ReffrenceMo"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["ReffrenceMo"].ToString().Trim() == null)
                        {
                            refrenceNo = "0";
                        }
                        else
                        {
                            refrenceNo = DS.Tables[0].Rows[i]["ReffrenceMo"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["IMEI"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["IMEI"].ToString().Trim() == null)
                        {
                            imei = "0";
                        }
                        else
                        {
                            imei = DS.Tables[0].Rows[i]["IMEI"].ToString().Trim();
                        }

                        if (DS.Tables[0].Rows[i]["CreatedDate"].ToString().Trim() == "" || DS.Tables[0].Rows[i]["CreatedDate"].ToString().Trim() == null)
                        {
                            createdDate = "0";
                        }
                        else
                        {
                            createdDate = DS.Tables[0].Rows[i]["CreatedDate"].ToString().Trim();
                        }

                        returnString += id + "*" + localBodyId + "*" + ward + "*" + boothNo + "*" + boothAddress + "*" + latitute + "*" + longitute + "*" + localBodyID + "*" + createdBy + "*" + refrenceNo + "*" + imei + "*" + createdDate + "#";
                    }
                }
                else
                {
                    return "0";
                }
                return returnString;
            }
            catch
            {
                return "0";
            }

        }
        #endregion



    }
}
