<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHomeUser.aspx.cs" Inherits="TrueVoter.Reports.frmHomeUser" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Home" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Officer Help" Font-Bold="true" Font-Size="Small"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnoffAppPro" runat="server" Text="Tutorial Presentation for Officer App registration Process" ForeColor="Blue" OnClick="lnkbtnoffAppPro_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnofficerFunction" runat="server" Text="Tutorial Presentation For Functions for Officers" ForeColor="Blue" OnClick="lnkbtnofficerFunction_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnstandardrates" runat="server" Text="Tutorial Presentation For filling Standard Rates for Officers" ForeColor="Blue" OnClick="lnkbtnstandardrates_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnElectionActi" runat="server" Text="Tutorial Presentation for Officer Election Activity Process" ForeColor="Blue" OnClick="lnkbtnElectionActi_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnElectionData" runat="server" Text="Tutorial Presentation for Officer Election Data Process" ForeColor="Blue" OnClick="lnkbtnElectionData_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnEmergencyService" runat="server" Text="Tutorial Presentation for Officer Emergency Service" ForeColor="Blue" OnClick="lnkbtnEmergencyService_Click"></asp:LinkButton>
            <br />
            <br />
        </div>
        <div style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="Candidate Help" Font-Bold="true" Font-Size="Small"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="btnCandiAppRegPro" runat="server" Text="Tutorial Presentation for Candidate App Registration & Fill DailyExpenses" ForeColor="Blue" OnClick="btnCandiAppRegPro_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnDailyExpecandi" runat="server" Text="Tutorial Presentation for Filling Candidate Group Daily Expense" ForeColor="Blue" OnClick="lnkbtnDailyExpecandi_Click"></asp:LinkButton>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
