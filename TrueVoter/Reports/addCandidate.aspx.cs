//using BLL;
//using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class addCandidate : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string mob = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
                BindDistrict();
            }
        }

        public DataSet GetData(SqlCommand cmd)
        {
            int i = cmd.ExecuteNonQuery();
            da.Fill(ds);
            return ds;
        }

        public void BindData()
        {
            cmd.CommandText = "SELECT [ID], [DistrictId], [DistrictName], [LocalBodyTypeId], [LocalBodyTypeName], [LocalBodyId], [LocalBodyName], [CandidateType], [WardNo], [SeatNo], [CandidateName], [PartyName], [AllocatedSymbol], [RegistrationId], [CreatedBy], [CreatedDate] FROM [TrueVoterDB].[dbo].[tblCanditateDetails] WHERE [LocalBodyId]='" + ddlLocalBodyName.SelectedValue + "' AND [DistrictId]='" + ddlDistrict.SelectedValue + "' AND [IsActive]=1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }


        private void BindDistrict()
        {
            if (!IsPostBack)
            {
                cmd.CommandText = " SELECT [Id],[Name_M],[Name_E],[StateId]  FROM [TrueVoterDB].[dbo].[Districts] WHERE StateId =12";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = contrue;
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = ds.Tables[0];
                    ddlDistrict.DataTextField = "Name_E";
                    ddlDistrict.DataValueField = "Id";
                    ddlDistrict.DataBind();

                    ddlDistrict.Items.Add("--Select--");
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
                }
            }
        }

        protected void AddNewCandidate(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedItem.Text == "--Select--" || ddlDistrict.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District')", true);
            }
            else if (ddlLocalBodyType.SelectedItem.Text == "--Select--" || ddlLocalBodyType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Local Body Type')", true);
            }
            else if (ddlcandidateType.SelectedItem.Text == "--Select--" || ddlcandidateType.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Candidate Type')", true);
            }
            else if (ddlLocalBodyName.SelectedItem.Text == "--Select--" || ddlLocalBodyName.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Local BodyName')", true);
            }
            else
            {
                string candidateName = ((TextBox)GridView1.FooterRow.FindControl("txtCandiName")).Text;
                string partyName = ((TextBox)GridView1.FooterRow.FindControl("txtPartyName")).Text;
                string allocatedSymbol = ((TextBox)GridView1.FooterRow.FindControl("txtAllocatedSymbol")).Text;
                string registrationId = ((TextBox)GridView1.FooterRow.FindControl("txtRegistrationId")).Text;

                cmd.Connection = contrue;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO [TrueVoterDB].[dbo].[tblCanditateDetails] ([DistrictId], [DistrictName], [LocalBodyTypeId], [LocalBodyTypeName], [LocalBodyId], [LocalBodyName], [CandidateType], [WardNo], [SeatNo], [CandidateName], [PartyName], [AllocatedSymbol], [RegistrationId],[CreatedBy], [CreatedDate],[Provider]) VALUES " +
                                   "(@DistrictId,@DistrictName,@LocalBodyTypeId,@LocalBodyTypeName,@LocalBodyId,@LocalBodyName,@CandidateType,@WardNo,@SeatNo,@CandidateName,@PartyName,@AllocatedSymbol,@RegistrationId,@CreatedBy,@CreatedDate,@provider)";


                cmd.Parameters.Add("@DistrictId", SqlDbType.Int).Value = Convert.ToInt32(ddlDistrict.SelectedValue);
                cmd.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = ddlDistrict.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@LocalBodyTypeId", SqlDbType.Int).Value = Convert.ToInt32(ddlLocalBodyType.SelectedValue);
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.VarChar).Value = ddlLocalBodyType.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.Int).Value = Convert.ToInt32(ddlLocalBodyName.SelectedValue);
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.VarChar).Value = ddlLocalBodyName.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@CandidateType", SqlDbType.VarChar).Value = ddlcandidateType.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@WardNo", SqlDbType.VarChar).Value = txtwardNo.Text.Trim();
                cmd.Parameters.Add("@SeatNo", SqlDbType.VarChar).Value = txtSeatNo.Text.Trim();
                cmd.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = candidateName;
                cmd.Parameters.Add("@PartyName", SqlDbType.VarChar).Value = partyName;
                cmd.Parameters.Add("@AllocatedSymbol", SqlDbType.VarChar).Value = allocatedSymbol;
                cmd.Parameters.Add("@RegistrationId", SqlDbType.VarChar).Value = registrationId;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "9422325020";
                cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@Provider", SqlDbType.VarChar).Value = "WEB";
                contrue.Open();
                cmd.ExecuteNonQuery();
                contrue.Close();
                BindData();
            }
        }

        protected void EditCandidate(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void UpdateCandidate(object sender, GridViewUpdateEventArgs e)
        {
            if (ddlDistrict.SelectedItem.Text == "--Select--" || ddlDistrict.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District')", true);
            }
            else if (ddlLocalBodyType.SelectedItem.Text == "--Select--" || ddlLocalBodyType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Local Body Type')", true);
            }
            else if (ddlcandidateType.SelectedItem.Text == "--Select--" || ddlcandidateType.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Candidate Type')", true);
            }
            else if (ddlLocalBodyName.SelectedItem.Text == "--Select--" || ddlLocalBodyName.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Local BodyName')", true);
            }
            else
            {
                string Id = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblID")).Text;
                string candidateName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCandiName")).Text;
                string partyName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPartyName")).Text;
                string allocatedSymbol = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAllocatedSymbol")).Text;
                //string registrationId = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRegistrationId")).Text;


                cmd.Connection = contrue;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblCanditateDetails] SET [DistrictId]=@DistrictId, [DistrictName]=@DistrictName, [LocalBodyTypeId]=@LocalBodyTypeId, [LocalBodyTypeName]=@LocalBodyTypeName, [LocalBodyId]=@LocalBodyId, [LocalBodyName]=@LocalBodyName, [CandidateType]=@CandidateType," +
                                  " [WardNo]=@WardNo, [SeatNo]=@SeatNo, [CandidateName]=@CandidateName, [PartyName]=@PartyName, [AllocatedSymbol]=@AllocatedSymbol, [ModifyBy]=@ModifyBy, [ModifyDate]=@ModifyDate WHERE [ID]='" + Id + "'";

                cmd.Parameters.Add("@DistrictId", SqlDbType.Int).Value = Convert.ToInt32(ddlDistrict.SelectedValue);
                cmd.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = ddlDistrict.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@LocalBodyTypeId", SqlDbType.Int).Value = Convert.ToInt32(ddlLocalBodyType.SelectedValue);
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.VarChar).Value = ddlLocalBodyType.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.Int).Value = Convert.ToInt32(ddlLocalBodyName.SelectedValue);
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.VarChar).Value = ddlLocalBodyName.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@CandidateType", SqlDbType.VarChar).Value = ddlcandidateType.SelectedItem.Text.Trim();
                cmd.Parameters.Add("@WardNo", SqlDbType.VarChar).Value = txtwardNo.Text.Trim();
                cmd.Parameters.Add("@SeatNo", SqlDbType.VarChar).Value = txtSeatNo.Text.Trim();
                cmd.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = candidateName;
                cmd.Parameters.Add("@PartyName", SqlDbType.VarChar).Value = partyName;
                cmd.Parameters.Add("@AllocatedSymbol", SqlDbType.VarChar).Value = allocatedSymbol;
                //cmd.Parameters.Add("@RegistrationId", SqlDbType.VarChar).Value = registrationId;
                cmd.Parameters.Add("@ModifyBy", SqlDbType.VarChar).Value = "9422325020";
                cmd.Parameters.Add("@ModifyDate", SqlDbType.Date).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                GridView1.EditIndex = -1;

                contrue.Open();
                cmd.ExecuteNonQuery();
                contrue.Close();
                BindData();
            }
        }

        protected void DeleteCandidate(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            cmd.Connection = contrue;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblCanditateDetails] SET  [IsActive]=0 where [ID]=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lnkRemove.CommandArgument;

            contrue.Open();
            cmd.ExecuteNonQuery();
            contrue.Close();
            BindData();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            BindData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {            
                cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType],[DistrictCode],[DistrictName],[ACNo] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE [DistrictCode]='" + ddlDistrict.SelectedValue.ToString() + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = contrue;
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlLocalBodyName.DataSource = ds.Tables[0];
                    ddlLocalBodyName.DataTextField ="ElectionName";
                    ddlLocalBodyName.DataValueField = "ElectionId";
                    ddlLocalBodyName.DataBind();

                    ddlLocalBodyName.Items.Add("--Select--");
                    ddlLocalBodyName.SelectedIndex = ddlLocalBodyName.Items.Count - 1;
                }           
        }

        protected void ddlcandidateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcandidateType.SelectedValue == "2")
            {
                pnlseattype.Visible = true;
            }
            else
            {
                pnlseattype.Visible = false;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedItem.Text == "--Select--" || ddlDistrict.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District')", true);
            }
            else if (ddlLocalBodyType.SelectedItem.Text == "--Select--" || ddlLocalBodyType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Local Body Type')", true);
            }
            else if (ddlcandidateType.SelectedItem.Text == "--Select--" || ddlcandidateType.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Candidate Type')", true);
            }
            else if (ddlLocalBodyName.SelectedItem.Text == "--Select--" || ddlLocalBodyName.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Local BodyName')", true);
            }
            else
            {
                BindData();
            }
        }

    }
}