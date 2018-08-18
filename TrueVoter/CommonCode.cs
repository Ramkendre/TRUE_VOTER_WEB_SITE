using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;

namespace TrueVoter
{
    public class CommonCode 
    {
        public static int OK = 1, INVALID_REQUEST = 9, WRONG_INPUT = 2, DATA_NOT_FOUND = 3, FAIL = 4, SQL_ERROR = 5, ERROR = 6, PRIMARY_KEY_VIOLATION = 7, USER_NAME_ALREADY_USED = 8;
        private XmlDocument xmlDocument = new XmlDocument();

        //private string smsUserName = "ezeesoft";
        //private string smsPassword = "67893";

        //private string aid = "639128";
        //private string pin = "M@h123";

        private string aid = "639250"; //NEWLY ADDED BY JITENDRA DATED ON 05.11.2016
        private string pin = "M@h123";

        private WebProxy objProxy1 = null;
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";
        private static byte[] keys = { };
        private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKeys = "!5623a#de";

        public XmlDocument ErrorXml(int errorCode)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode errrorNode = doc.CreateElement("ErrorMainNode");
            doc.AppendChild(errrorNode);

            XmlNode nameNode = doc.CreateElement("Error");
            nameNode.AppendChild(doc.CreateTextNode(errorCode.ToString()));
            errrorNode.AppendChild(nameNode);
            return doc;
        }

        public string MulitipleSenders(List<string> regIds, string message)
        {

            // applicationID means google Api key                                                                                                     
            var applicationID = "AIzaSyCm3Z-UbwmxR0P3bmRxos-cbFiNCxzm7Rg";

            // SENDER_ID is nothing but your ProjectID (from API Console- google code)//                                          
            var SENDER_ID = "273504352189";

            var value = message; //message text box                                                                               

            TrueVoter.App_Code.BAL.PostData pdata = new TrueVoter.App_Code.BAL.PostData(applicationID, SENDER_ID, value, regIds);

            pdata.collapse_key = "score_update";
            pdata.time_to_live = 108;
            pdata.delay_while_idle = true;

            string request = JsonConvert.SerializeObject(pdata);

            System.Net.WebRequest tRequest;

            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");

            tRequest.Method = "post";

            tRequest.ContentType = " application/json";

            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            //Data post to server                                                                                                                                         

            Byte[] byteArray = Encoding.UTF8.GetBytes(request);

            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            String sResponseFromServer = tReader.ReadToEnd();   //Get response from GCM server.

            //Assigning GCM response to Label text 

            tReader.Close();

            dataStream.Close();
            tResponse.Close();
            return sResponseFromServer;    //Assigning GCM response to Label text 
        }

        #region MHSEC MSG
        public string SendSMS(string Mobile_Number, string Message)
        {
            Mobile_Number = "91" + Mobile_Number;
           // System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";
            System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;
                //objWebRequest = (HttpWebRequest)WebRequest.Create(" http://otp.zone:7501/failsafe/HttpLink?aid=639128&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MAHSEC");
                //objWebRequest = (HttpWebRequest)WebRequest.Create("  http://otp.zone:7501/failsafe/HttpLink?aid=639250&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MGAGEX");
              
                objWebRequest = (HttpWebRequest)WebRequest.Create("http://otp.zone:7501/failsafe/HttpLink?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }


        public string SMS(string Mobile_Number, string Message)
        {
            Mobile_Number = "91" + Mobile_Number;
            //System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";
            System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;
                //objWebRequest = (HttpWebRequest)WebRequest.Create(" http://otp.zone:7501/failsafe/HttpLink?aid=639128&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MAHSEC");
                //objWebRequest = (HttpWebRequest)WebRequest.Create("  http://otp.zone:7501/failsafe/HttpLink?aid=639250&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MGAGEX");
               
                objWebRequest = (HttpWebRequest)WebRequest.Create("http://otp.zone:7501/failsafe/HttpLink?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }
        #endregion

        #region myctsms
        //protected string SendSMS(string Mobile_Number, string Message)
        //{

        //    Mobile_Number = "91" + Mobile_Number;
        //    System.Object stringpost = "User=" + smsUserName + "&passwd=" + smsPassword + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&mtype=N&DR=Y";

        //    //string functionReturnValue = null;
        //    //functionReturnValue = "";

        //    HttpWebRequest objWebRequest = null;
        //    HttpWebResponse objWebResponse = null;
        //    StreamWriter objStreamWriter = null;
        //    StreamReader objStreamReader = null;

        //    try
        //    {
        //        string stringResult = null;
        //        //http://api.smscountry.com/SMSCwebservice_bulk.aspx
        //        objWebRequest = (HttpWebRequest)WebRequest.Create("http://api.smscountry.com/SMSCwebservice_bulk.aspx?");
        //        objWebRequest.Method = "POST";

        //        if ((objProxy1 != null))
        //        {
        //            objWebRequest.Proxy = objProxy1;
        //        }

        //        // Use below code if you want to SETUP PROXY.
        //        //Parameters to pass: 1. ProxyAddress 2. Port
        //        //You can find both the parameters in Connection settings of your internet explorer.

        //        //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
        //        //myProxy.BypassProxyOnLocal = true;
        //        //wrGETURL.Proxy = myProxy;

        //        objWebRequest.ContentType = "application/x-www-form-urlencoded";

        //        objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
        //        objStreamWriter.Write(stringpost);
        //        objStreamWriter.Flush();
        //        objStreamWriter.Close();

        //        objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
        //        objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
        //        stringResult = objStreamReader.ReadToEnd();

        //        objStreamReader.Close();
        //        return (stringResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (ex.Message);
        //    }
        //    finally
        //    {

        //        if ((objStreamWriter != null))
        //        {
        //            objStreamWriter.Close();
        //        }
        //        if ((objStreamReader != null))
        //        {
        //            objStreamReader.Close();
        //        }
        //        objWebRequest = null;
        //        objWebResponse = null;
        //        objProxy1 = null;
        //    }
        //}
        //public string SMS(string Mobile_Number, string Message)
        //{

        //    Mobile_Number = "91" + Mobile_Number;
        //    Message += " www.myct.in";
        //    System.Object stringpost = "User=" + smsUserName + "&passwd=" + smsPassword + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&mtype=N&DR=Y";

        //    //string functionReturnValue = null;
        //    //functionReturnValue = "";

        //    HttpWebRequest objWebRequest = null;
        //    HttpWebResponse objWebResponse = null;
        //    StreamWriter objStreamWriter = null;
        //    StreamReader objStreamReader = null;

        //    try
        //    {
        //        string stringResult = null;
        //        //http://api.smscountry.com/SMSCwebservice_bulk.aspx
        //        objWebRequest = (HttpWebRequest)WebRequest.Create("http://api.smscountry.com/SMSCwebservice_bulk.aspx?");
        //        objWebRequest.Method = "POST";

        //        if ((objProxy1 != null))
        //        {
        //            objWebRequest.Proxy = objProxy1;
        //        }

        //        // Use below code if you want to SETUP PROXY.
        //        //Parameters to pass: 1. ProxyAddress 2. Port
        //        //You can find both the parameters in Connection settings of your internet explorer.

        //        //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
        //        //myProxy.BypassProxyOnLocal = true;
        //        //wrGETURL.Proxy = myProxy;

        //        objWebRequest.ContentType = "application/x-www-form-urlencoded";

        //        objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
        //        objStreamWriter.Write(stringpost);
        //        objStreamWriter.Flush();
        //        objStreamWriter.Close();

        //        objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
        //        objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
        //        stringResult = objStreamReader.ReadToEnd();

        //        objStreamReader.Close();
        //        return (stringResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (ex.Message);
        //    }
        //    finally
        //    {

        //        if ((objStreamWriter != null))
        //        {
        //            objStreamWriter.Close();
        //        }
        //        if ((objStreamReader != null))
        //        {
        //            objStreamReader.Close();
        //        }
        //        objWebRequest = null;
        //        objWebResponse = null;
        //        objProxy1 = null;
        //    }
        //}

        #endregion

        protected void sendMail(string message, string emailId)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("ezeesoftindia@gmail.com", "abhi_chk");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(emailId);
            mailMessage.From = new MailAddress("ezeesoftindia@gmail.com");
            mailMessage.Subject = "Scrach Code for android App";
            mailMessage.Body = message;

            smtpClient.Send(mailMessage);
        }
        protected void StreamReader(Stream stream)
        {
            throw new NotImplementedException();
        }
        public string Encrypt(string sInput)
        {
            try
            {
                keys = System.Text.Encoding.UTF8.GetBytes
                (EncryptionKeys.Substring(0, 8));
                DESCryptoServiceProvider description = new DESCryptoServiceProvider();
                Byte[] inputArray = Encoding.UTF8.GetBytes(sInput);
                MemoryStream mstream = new MemoryStream();
                CryptoStream cstream = new CryptoStream
                (mstream, description.CreateEncryptor(keys, IVs), CryptoStreamMode.Write);
                cstream.Write(inputArray, 0, inputArray.Length);
                cstream.FlushFinalBlock();
                return Convert.ToBase64String(mstream.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Decryption(string sInput)
        {
            Byte[] inputArray = new Byte[sInput.Length];
            try
            {
                keys = System.Text.Encoding.UTF8.GetBytes(EncryptionKeys.Substring(0, 8));
                DESCryptoServiceProvider description = new DESCryptoServiceProvider();
                inputArray = Convert.FromBase64String(sInput);
                MemoryStream mstream = new MemoryStream();
                CryptoStream cstream = new CryptoStream
                (mstream, description.CreateDecryptor(keys, IVs), CryptoStreamMode.Write);
                cstream.Write(inputArray, 0, inputArray.Length);
                cstream.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(mstream.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);

                stringToDecrypt = stringToDecrypt.Replace(" ", "+");

                int len = stringToDecrypt.Length;
                inputByteArray = Convert.FromBase64String(stringToDecrypt);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Encrypt the normal string with the DES to Encrypted string 
        /// </summary>
        /// <param name="stringToEncrypt">Normal String  to Encrypt</param>
        /// <returns></returns>
        public string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }
        public static System.Data.DataSet ErrorDs(string error)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Error", typeof(string));
            dt.Rows.Add(error);
            ds.Tables.Add(dt);
            return ds;

        }

        public DataSet ExecuteDataset(string Sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                try
                {
                    ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return ds;
        }

        public string ExecuteScalar(string Sql)
        {
            string Data = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                try
                {
                    Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return Data;
        }

        public int ExecuteNonQuery(string Sql)
        {
            int flag = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {

                try
                {
                    flag = SqlHelper.ExecuteNonQuery(con, CommandType.Text, Sql);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return flag;
        }
    }
}