using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkbtnOrder1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election_Expences_Procedure.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Expences Procedure.pdf"));
            Response.End();
        }

        protected void lnkbtnOrder2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election_Expense_Order_1.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Expense Order 1.pdf"));
            Response.End();
        }

        protected void lnkbtnOrder3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Expenses_Format_Order 2.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Expenses Format Order 2.pdf"));
            Response.End();
        }

        protected void lnkbtnoffAppPro_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Officers app registration process ver 1.76.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Officers app registration process ver 1.76.pptx"));
            Response.End();
        }

        protected void lnkbtnofficerFunction_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=officer functions versions 1.47.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/officer functions versions 1.47.pptx"));
            Response.End();
        }

        protected void lnkbtnstandardrates_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Standard rates version 1.77.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Standard rates version 1.77.pptx"));
            Response.End();
        }

        protected void lnkbtnElectionActi_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election Activity_version 1.57.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Activity_version 1.57.pptx"));
            Response.End();
        }

        protected void lnkbtnElectionData_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election Data_version 1.57.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Data_version 1.57.pptx"));
            Response.End();
        }

        protected void lnkbtnEmergencyService_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Emergency services_version 1.57.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Emergency services_version 1.57.pptx"));
            Response.End();
        }

        protected void btnCandiAppRegPro_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=candidateappregistrationprocessver2/64.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/daily expens and website 2.62ppt.ppt"));
            Response.End();
        }

        protected void lnkbtnDailyExpecandi_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=GroupExpense2/64.pptx");
            Response.TransmitFile(Server.MapPath("../PDFFiles/group daily expense version 2.64.pptx"));
            Response.End();
        }
    }
}