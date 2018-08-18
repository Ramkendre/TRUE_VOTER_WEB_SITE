using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for PayUDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PayUDetails : System.Web.Services.WebService
    {
        #region INSERT PAYMENT DETAILS (JSON_PARSING)
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        [WebMethod(Description = "Web Method INSERT PAYMENT DETAILS ")]
        public string InsertpayUDetails(string transData)
        {
            JObject o = JObject.Parse(transData);
            cmd.CommandText = "uspInsertPaymentDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            string returnString = string.Empty;

            string Id = string.Empty;
            try { Id = (string)o["id"].ToString(); }
            catch { Id = "0"; }

            string mode = string.Empty;
            try { mode = (string)o["mode"].ToString(); }
            catch { mode = "0"; }

            string status = string.Empty;
            try { status = (string)o["status"].ToString(); }
            catch { status = "0"; }

            string unmappedstatus = string.Empty;
            try { unmappedstatus = (string)o["unmappedstatus"].ToString(); }
            catch { unmappedstatus = "0"; }

            string key = string.Empty;
            try { key = (string)o["key"].ToString(); }
            catch { key = "0"; }

            string txnid = string.Empty;
            try { txnid = (string)o["txnid"].ToString(); }
            catch { txnid = "0"; }

            string transaction_fee = string.Empty;
            try { transaction_fee = (string)o["transaction_fee"].ToString(); }
            catch { transaction_fee = "0"; }

            string amount = string.Empty;
            try { amount = (string)o["amount"].ToString(); }
            catch { amount = "0"; }

            string cardCategory = string.Empty;
            try { cardCategory = (string)o["cardCategory"].ToString(); }
            catch { cardCategory = "0"; }

            string discount = string.Empty;
            try { discount = (string)o["discount"].ToString(); }
            catch { discount = "0"; }

            string additional_charges = string.Empty;
            try { additional_charges = (string)o["additional_charges"].ToString(); }
            catch { additional_charges = "0"; }

            string addedon = string.Empty;
            try { addedon = (string)o["addedon"].ToString(); }
            catch { addedon = "0"; }

            string productinfo = string.Empty;
            try { productinfo = (string)o["productinfo"].ToString(); }
            catch { productinfo = "0"; }

            string firstname = string.Empty;
            try { firstname = (string)o["firstname"].ToString(); }
            catch { firstname = "0"; }

            string email = string.Empty;
            try { email = (string)o["email"].ToString(); }
            catch { email = "0"; }

            string udf1 = string.Empty;
            try { udf1 = (string)o["udf1"].ToString(); }
            catch { udf1 = "0"; }

            string udf2 = string.Empty;
            try { udf2 = (string)o["udf2"].ToString(); }
            catch { udf2 = "0"; }

            string udf3 = string.Empty;
            try { udf3 = (string)o["udf3"].ToString(); }
            catch { udf3 = "0"; }

            string udf4 = string.Empty;
            try { udf4 = (string)o["udf4"].ToString(); }
            catch { udf4 = "0"; }

            string udf5 = string.Empty;
            try { udf5 = (string)o["udf5"].ToString(); }
            catch { udf5 = "0"; }

            string hash = string.Empty;
            try { hash = (string)o["hash"].ToString(); }
            catch { hash = "0"; }

            string field1 = string.Empty;
            try { field1 = (string)o["field1"].ToString(); }
            catch { field1 = "0"; }

            string field2 = string.Empty;
            try { field2 = (string)o["field2"].ToString(); }
            catch { field2 = "0"; }

            string field3 = string.Empty;
            try { field3 = (string)o["field3"].ToString(); }
            catch { field3 = "0"; }

            string field4 = string.Empty;
            try { field4 = (string)o["field4"].ToString(); }
            catch { field4 = "0"; }

            string field5 = string.Empty;
            try { field5 = (string)o["field5"].ToString(); }
            catch { field5 = "0"; }

            string field6 = string.Empty;
            try { field6 = (string)o["field6"].ToString(); }
            catch { field6 = "0"; }

            string field7 = string.Empty;
            try { field7 = (string)o["field7"].ToString(); }
            catch { field7 = "0"; }

            string field8 = string.Empty;
            try { field8 = (string)o["field8"].ToString(); }
            catch { field8 = "0"; }

            string field9 = string.Empty;
            try { field9 = (string)o["field9"].ToString(); }
            catch { field9 = "0"; }

            string payment_source = string.Empty;
            try { payment_source = (string)o["payment_source"].ToString(); }
            catch { payment_source = "0"; }

            string PG_TYPE = string.Empty;
            try { PG_TYPE = (string)o["PG_TYPE"].ToString(); }
            catch { PG_TYPE = "0"; }

            string bank_ref_no = string.Empty;
            try { bank_ref_no = (string)o["bank_ref_no"].ToString(); }
            catch { bank_ref_no = "0"; }

            string ibibo_code = string.Empty;
            try { ibibo_code = (string)o["ibibo_code"].ToString(); }
            catch { ibibo_code = "0"; }

            string error_code = string.Empty;
            try { error_code = (string)o["error_code"].ToString(); }
            catch { error_code = "0"; }

            string Error_Message = string.Empty;
            try { Error_Message = (string)o["Error_Message"].ToString(); }
            catch { Error_Message = "0"; }

            string name_on_card = string.Empty;
            try { name_on_card = (string)o["name_on_card"].ToString(); }
            catch { name_on_card = "0"; }

            string card_no = string.Empty;
            try { card_no = (string)o["card_no"].ToString(); }
            catch { card_no = "0"; }

            string is_seamless = string.Empty;
            try { is_seamless = (string)o["is_seamless"].ToString(); }
            catch { is_seamless = "0"; }

            string surl = string.Empty;
            try { surl = (string)o["surl"].ToString(); }
            catch { surl = "0"; }

            string furl = string.Empty;
            try { furl = (string)o["furl"].ToString(); }
            catch { furl = "0"; }

            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = Id;
            cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 30).Value = mode;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar, 30).Value = status;
            cmd.Parameters.Add("@unmappedstatus", SqlDbType.NVarChar, 30).Value = unmappedstatus;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar, 30).Value = key;
            cmd.Parameters.Add("@txnid", SqlDbType.NVarChar, 50).Value = txnid;
            cmd.Parameters.Add("@transaction_fee", SqlDbType.NVarChar, 30).Value = transaction_fee;
            cmd.Parameters.Add("@amount", SqlDbType.NVarChar, 30).Value = amount;
            cmd.Parameters.Add("@cardCategory", SqlDbType.NVarChar, 30).Value = cardCategory;
            cmd.Parameters.Add("@discount", SqlDbType.NVarChar, 30).Value = discount;
            cmd.Parameters.Add("@additional_charges", SqlDbType.NVarChar, 30).Value = additional_charges;
            cmd.Parameters.Add("@addedon", SqlDbType.NVarChar, 30).Value = addedon;
            cmd.Parameters.Add("@productinfo", SqlDbType.NVarChar, 100).Value = productinfo;
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar, 100).Value = firstname;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
            cmd.Parameters.Add("@udf1", SqlDbType.NVarChar, 50).Value = udf1;
            cmd.Parameters.Add("@udf2", SqlDbType.NVarChar, 50).Value = udf2;
            cmd.Parameters.Add("@udf3", SqlDbType.NVarChar, 50).Value = udf3;
            cmd.Parameters.Add("@udf4", SqlDbType.NVarChar, 50).Value = udf4;
            cmd.Parameters.Add("@udf5", SqlDbType.NVarChar, 50).Value = udf5;
            cmd.Parameters.Add("@hash", SqlDbType.NVarChar).Value = hash;
            cmd.Parameters.Add("@field1", SqlDbType.NVarChar, 50).Value = field1;
            cmd.Parameters.Add("@field2", SqlDbType.NVarChar, 50).Value = field2;
            cmd.Parameters.Add("@field3", SqlDbType.NVarChar, 50).Value = field3;
            cmd.Parameters.Add("@field4", SqlDbType.NVarChar, 50).Value = field4;
            cmd.Parameters.Add("@field5", SqlDbType.NVarChar, 50).Value = field5;
            cmd.Parameters.Add("@field6", SqlDbType.NVarChar, 50).Value = field6;
            cmd.Parameters.Add("@field7", SqlDbType.NVarChar, 50).Value = field7;
            cmd.Parameters.Add("@field8", SqlDbType.NVarChar, 50).Value = field8;
            cmd.Parameters.Add("@field9", SqlDbType.NVarChar).Value = field9;
            cmd.Parameters.Add("@payment_source", SqlDbType.NVarChar, 100).Value = payment_source;
            cmd.Parameters.Add("@PG_TYPE", SqlDbType.NVarChar, 100).Value = PG_TYPE;
            cmd.Parameters.Add("@bank_ref_no", SqlDbType.NVarChar, 100).Value = bank_ref_no;
            cmd.Parameters.Add("@ibibo_code", SqlDbType.NVarChar, 100).Value = ibibo_code;
            cmd.Parameters.Add("@error_code", SqlDbType.NVarChar, 100).Value = error_code;
            cmd.Parameters.Add("@Error_Messages", SqlDbType.NVarChar, 100).Value = Error_Message;
            cmd.Parameters.Add("@name_on_card", SqlDbType.NVarChar, 100).Value = name_on_card;
            cmd.Parameters.Add("@card_no", SqlDbType.NVarChar, 100).Value = card_no;
            cmd.Parameters.Add("@is_seamless", SqlDbType.NVarChar, 100).Value = is_seamless;
            cmd.Parameters.Add("@surl", SqlDbType.NVarChar, 100).Value = surl;
            cmd.Parameters.Add("@furl", SqlDbType.NVarChar, 100).Value = furl;

            cmd.Parameters.Add("@maxID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            string MaxId = cmd.Parameters["@maxID"].Value.ToString();
            returnString += Id + "*" + MaxId + "#";

            //string postData = "txnid=" + txnid + "&key=" + key + "&form=2";//&hash=" + hash + "&amount=" + amount + "&id=" + Id + "&productinfo=" + productinfo + "&form=2";  //Id + " " + status + " " + mode + " " + unmappedstatus + " " + key + " " + txnid + " " + transaction_fee + " " + amount + " " + cardCategory + " " + discount + " " + additional_charges + " " + addedon + " " + productinfo + " " + firstname + " " + email + " " + udf1 + " " + hash + " " + field1 + " " + field2 + " " + field3 + " " + field4 + " " + field5 + " " + field6 + " " + field7 + " " + field8 + " " + field9;
            //string postData = "&txnid=|" + txnid;

            //string valn = VerifyPayment(postData);

            return returnString;

            //string ss = "&txnid=" + txnid + "&key=" + key + "&hash=" + hash + "&amount=" + amount + "&transaction_fee=" + transaction_fee + "&id=" + Id + "&mode=" + mode + "&status=" + status + "&unmappedstatus=" + unmappedstatus + "&cardCategory=" + cardCategory + "&discount=" + discount + "&productinfo=" + productinfo + "&addedon=" + addedon + "&firstname=" + firstname + "&email=" + email + "&udf1=" + udf1 + "&additional_charges=" + additional_charges + "";  //Id + " " + status + " " + mode + " " + unmappedstatus + " " + key + " " + txnid + " " + transaction_fee + " " + amount + " " + cardCategory + " " + discount + " " + additional_charges + " " + addedon + " " + productinfo + " " + firstname + " " + email + " " + udf1 + " " + hash + " " + field1 + " " + field2 + " " + field3 + " " + field4 + " " + field5 + " " + field6 + " " + field7 + " " + field8 + " " + field9;
            //string postData = "&txnid=" + txnid + "&key=" + key + "&hash=" + hash + "&amount=" + amount + "&id=" + Id + "&productinfo=" + productinfo + "";  //Id + " " + status + " " + mode + " " + unmappedstatus + " " + key + " " + txnid + " " + transaction_fee + " " + amount + " " + cardCategory + " " + discount + " " + additional_charges + " " + addedon + " " + productinfo + " " + firstname + " " + email + " " + udf1 + " " + hash + " " + field1 + " " + field2 + " " + field3 + " " + field4 + " " + field5 + " " + field6 + " " + field7 + " " + field8 + " " + field9;
            //return VerifyPayment(postData);
        }

        #endregion

        private WebProxy objProxy1 = null;

        public string VerifyPayment(string postString)//public string VerifyPayment(string postString)
        {
            System.Object stringpost = postString;

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;
                objWebRequest = (HttpWebRequest)WebRequest.Create("https://info.payu.in/merchant/postservice.php?");
                //objWebRequest = (HttpWebRequest)WebRequest.Create("https://test.payu.in/merchant/postservice.php?form=2");//TEST URL
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

                //PARSE JSON DATA
                JObject o = JObject.Parse(stringResult);
                string status = string.Empty;
                try { status = (string)o["status"].ToString(); }
                catch { status = "0"; }

                string mode = string.Empty;
                try { mode = (string)o["mode"].ToString(); }
                catch { mode = "0"; }

                string msg = string.Empty;
                try { msg = (string)o["msg"].ToString(); }
                catch { msg = "0"; }

                string transaction_details = string.Empty;
                try { transaction_details = (string)o["transaction_details"].ToString(); }
                catch { transaction_details = "0"; }

                string mihpayid = string.Empty;
                try { mihpayid = (string)o["mihpayid"].ToString(); }
                catch { mihpayid = "0"; }

                string amt = string.Empty;
                try { amt = (string)o["amt"].ToString(); }
                catch { amt = "0"; }

                string bank_ref_num = string.Empty;
                try { bank_ref_num = (string)o["bank_ref_num"].ToString(); }
                catch { bank_ref_num = "0"; }

                string ss = status + " " + mode + " " + msg + " " + transaction_details + " " + mihpayid + " " + amt + " " + bank_ref_num;
                objStreamReader.Close();
                return ss;
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


        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }

        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }

            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
    }
}
