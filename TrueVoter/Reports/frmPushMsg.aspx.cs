using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;
namespace TrueVoter.Reports
{
    public partial class frmPushMsg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        frmDownloadSRateBAL objBAL = new frmDownloadSRateBAL();
        string SERVER_API_KEY = "AAAAMv7ilQ0:APA91bFAhj19ZYuEjgYxY9v_kHaePTycpsQUVLHEDJ_u0vYA0mDlKq5aQymBKmSXATAq9QCZ8rpWFots6Ry5DwxONHSXenMkQgTTZJWSfAZZSJ4IO7e50nUeqa30vlhAbr8cTlNZXUYC";
        string SENDER_ID = "219024626957";

        string mob = string.Empty;
        string name = string.Empty;
        string role = string.Empty;
        string dist = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["MobileNo"] != null)
            {
                mob = Convert.ToString(Session["MobileNo"]);
                name = Convert.ToString(Session["Name"]);
                role = Convert.ToString(Session["MainRole"]);
                dist = Convert.ToString(Session["District"]);

            }
            else
            {
                Response.Redirect("~/Reports/frmHomeUser.aspx");
            }
            if (!IsPostBack)
            {
                BindDistrict();
            }

        }

        protected void btnSendOld_Click(object sender, EventArgs e)
        {
            string UserTypes = ListItemSelected();
            string Message = txtMsgBody.Text + "  (" + mob + "-" + name + ")";

            //if (mob == "9422325020" || mob == "8087371027" || mob == "9619460202")
            //{
            //    string query = "SELECT [Regid],[userType],[WardNo] FROM [TrueVoterDB].[dbo].[GCMRegistrations] WHERE [userType] IN(" + UserTypes + ") AND [MobileNo]='9112019919'";
            //    ds.Clear();
            //    ds = cc.ExecuteDataset(query);
            //}
            //else if (role == "5")
            //{
            //    string query = "SELECT [Regid],[userType],[WardNo] FROM [TrueVoterDB].[dbo].[GCMRegistrations] WHERE [userType] IN(" + UserTypes + ") AND [DistictID]='" + dist + "' AND [MobileNo]='9112019919'";
            //    ds.Clear();
            //    ds = cc.ExecuteDataset(query);
            //}
            //else
            //{
            //    string query = "SELECT [Regid],[userType],[WardNo] FROM [TrueVoterDB].[dbo].[GCMRegistrations] WHERE [userType] IN(" + UserTypes + ") AND [MobileNo]='9112019919'";
            //    ds.Clear();
            //    ds = cc.ExecuteDataset(query);
            //}

            //string qry = "INSERT INTO [TrueVoterDB].[dbo].[tblFCMMsgDetails] ([MobileNo],[Name],[MessageBody],[LocalBodyType],[LocalBodyId],[WardNo],[InsertDate]) VALUES ('" + mob + "','" + Session["NAME"].ToString() + "',N'" + Message + "','" + UserTypes.Replace("'", "").Replace("'", "") + "','0','0','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
            //cc.ExecuteNonQuery(qry);

            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@mob", mob);
            par[1] = new SqlParameter("@UserTypes", UserTypes);
            par[2] = new SqlParameter("@dist", dist);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspFCMSMSSendOne", par);

            SqlParameter[] par1 = new SqlParameter[10];
            par1[0] = new SqlParameter("@mob", mob);
            par1[1] = new SqlParameter("@name", Session["NAME"].ToString());
            par1[2] = new SqlParameter("@Message", Message);
            par1[3] = new SqlParameter("@UserTypes", UserTypes.Replace("'", "").Replace("'", ""));
            par1[4] = new SqlParameter("@LocalBodyId", "0");
            par1[5] = new SqlParameter("@WardNo", "0");
            par1[6] = new SqlParameter("@InsertDate", System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            ds.Clear();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspFCMSMSSendTwo", par1);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string chk = SendNotification_FCM(Convert.ToString(ds.Tables[0].Rows[i][0]), Message);
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Messages Send Successfully...')", true);
            clear();
        }

        public string ListItemSelected()
        {
            string selectedItem = string.Empty;
            foreach (ListItem item in cklRole.Items)
            {
                if (item.Selected)
                {
                    selectedItem += "'" + item.Value + "',";
                }
            }
            selectedItem = selectedItem.Substring(0, selectedItem.Length - 1);
            return selectedItem;
        }

        public string SendNotification_FCM(string DeviRegId, string Msg)
        {
            string str = string.Empty;
            try
            {
                //string deviceId = "cbZioNLbd3Q:APA91bEtsLrqrWVsn4VbCQdRKKJe-y7cSVWxwgkBQlkzmwNfgZ7rRNGGMyHq0kniyFglit3niTxWeBWmunUYpGu3j4rBgUAyOwqAF0OXfL56nltaxmUmRZU1-l-hRrkPFjFxNOKXRC41";
                string deviceId = DeviRegId;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = Msg,
                        title = "True Voters",
                        sound = "Hi",
                        click_action = "FcmNotifier"
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                tRequest.ContentLength = byteArray.Length;
                #region add
                tRequest.UseDefaultCredentials = true;
                tRequest.PreAuthenticate = true;
                tRequest.Credentials = CredentialCache.DefaultCredentials;
                #endregion

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())//
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                str = sResponseFromServer;
                            }
                        }
                    }
                }
                str = "SUCCESS:" + str;
            }
            catch (Exception ex)
            {
                str = "ERROR:" + ex.Message;
            }
            return str;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            cklRole.SelectedIndex = 0;
            txtMsgBody.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }
        public void BindDistrict()
        {
            DataSet ds = new DataSet();
            ds = objBAL.BindDistrictBAL();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistirct1.DataSource = ds.Tables[0];
                ddlDistirct1.DataTextField = "DistrictName";
                ddlDistirct1.DataValueField = "DistrictCode";
                ddlDistirct1.DataBind();
                ddlDistirct1.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlDistirct1.SelectedIndex = 0;
            }
            else
            {
            }
        }
        protected void ddlDistirct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            objBAL.DistID = Convert.ToInt32(ddlDistirct1.SelectedValue);
            ds = objBAL.BindLocalBodyBAL(objBAL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody1.DataSource = ds.Tables[0];
                ddlLocalBody1.DataTextField = "ElectionName";
                ddlLocalBody1.DataValueField = "ElectionId";
                ddlLocalBody1.DataBind();
                ddlLocalBody1.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLocalBody1.SelectedIndex = 0;
            }
            else
            {

            }
        }


        ///Comment or Remove This code AND [MobileNo]='9421506998' other wise Notification send This Number Only
        /// <summary>
        /// Send Fcm Notification all Voter,Officier,Candidate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string UserTypes = ListItemSelected();
            string Message = txtMsgBody.Text + "  (" + mob + "-" + name + ")";
            DataSet dsDetails = new DataSet();

            //string query1 = "SELECT [Regid],[userType],[WardNo],[localBody] FROM [TrueVoterDB].[dbo].[GCMRegistrations] WHERE [userType] IN(" + UserTypes + ") AND [localBody]='" + ddlLocalBody1.SelectedValue + "' AND [localBody]='" + ddlLocalBody1.SelectedValue + "' AND [MobileNo]='8087371027'";
            //dsDetails.Clear();
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@UserTypes", UserTypes);
            par[1] = new SqlParameter("@lbdy", ddlLocalBody1.SelectedValue.ToString());
            dsDetails.Clear();
            dsDetails = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspFCMSMSSendOne", par);


            //dsDetails = cc.ExecuteDataset(query1);
            if (dsDetails.Tables[0].Rows.Count > 0)
            {
                //string qry = "INSERT INTO [TrueVoterDB].[dbo].[tblFCMMsgDetails] ([MobileNo],[Name],[MessageBody],[LocalBodyType],[LocalBodyId],[WardNo],[InsertDate]) VALUES ('" + mob + "','" + Session["NAME"].ToString() + "',N'" + Message + "','" + UserTypes.Replace("'", "").Replace("'", "") + "','" + ddlLocalBody1.SelectedValue + "','0','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                //cc.ExecuteNonQuery(qry);

                SqlParameter[] par1 = new SqlParameter[10];
                par1[0] = new SqlParameter("@mob", mob);
                par1[1] = new SqlParameter("@name", Session["NAME"].ToString());
                par1[2] = new SqlParameter("@Message", Message);
                par1[3] = new SqlParameter("@UserTypes", UserTypes.Replace("'", "").Replace("'", ""));
                par1[4] = new SqlParameter("@LocalBodyId", ddlLocalBody1.SelectedValue.ToString());
                par1[5] = new SqlParameter("@WardNo", "0");
                par1[6] = new SqlParameter("@InsertDate", System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                ds.Clear();
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspFCMSMSSendTwo", par1);

                for (int i = 0; i < dsDetails.Tables[0].Rows.Count; i++)
                {
                    string chk = SendNotification_FCM(Convert.ToString(dsDetails.Tables[0].Rows[i][0]), Message);
                }
            }
        }
    }
}