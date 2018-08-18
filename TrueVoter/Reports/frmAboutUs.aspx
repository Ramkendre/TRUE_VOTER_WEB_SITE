<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAboutUs.aspx.cs" Inherits="TrueVoter.Reports.frmAboutUs" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="borderOuter-div-Form">
            <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="About Us" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
          </div>
        <div style="text-align:center">
            <asp:Label ID="lblAboutus" runat="server" Text="About us Coming Soon..."></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Total No Of Visitors" Font-Bold="true"></asp:Label>:<asp:Label ID="lblTotalCount" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="No Of Visitors" Font-Bold="true"></asp:Label>:<asp:Label ID="lblCount" runat="server"></asp:Label>
        </div>
  </div>
</asp:Content>
