using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class DisplayExpenseLimit : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        ExpenseLimit expenselimit = new ExpenseLimit();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // LoadExpenseLimit();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlElectionType.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Election Type...')", true);
                }
                else
                {
                    switch (ddlElectionType.SelectedValue)
                    {
                        case "1":
                            dt = expenselimit.CreateMcList();
                            break;
                        case "2":
                            dt = expenselimit.CreateZpList();
                            break;
                        case "3":
                            dt = expenselimit.CreatePsList();
                            break;
                        case "4":
                            dt = expenselimit.CreateGpList();
                            break;
                        //case "5":
                        //    listExpenseLimit = expenselimit.CreateNpList();
                        //    break;
                        //default :
                        //     listExpenseLimit = expenselimit.CreateMCouncilList();
                        //    break;
                    }
                    GvExpenseLimit.DataSource = dt;
                    GvExpenseLimit.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}