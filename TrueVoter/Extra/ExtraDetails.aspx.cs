using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class ExtraDetails : System.Web.UI.Page
    {
        string MoNo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginSession();
        }
        public string LoginSession()
        {
            if (Session["MobileNo"] != null)
            {
                MoNo = Session["MobileNo"].ToString();
            }
            else
            {
                Response.Redirect("../Home/Logout");
            }
            return MoNo;
        }
        public void ClearAll()
        {
            txtCandidateName.Text = string.Empty;
            txtMoNo.Text = string.Empty;
            txtNominationDate.Text = string.Empty;
            txtElectionDate.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtPlace.Text = string.Empty;
            txtPartyName.Text = string.Empty;
            txtSeatNo.Text = string.Empty;
            txtElectionType.Text = string.Empty;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}