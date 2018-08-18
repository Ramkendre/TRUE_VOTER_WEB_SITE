using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmAboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotalCount.Text = Application["TotalNoOfVisitors"].ToString();
            lblCount.Text = Application["NoOfVisitors"].ToString();
        }
    }
}