<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGetPassword.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmGetPassword" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Get Password" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
        <ContentTemplate>
        <div class="form-group">
            <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCanName" Text="Candidate Mobile No"></asp:Label></td>
                        </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtForgetUsername" runat="server" MaxLength="10" placeholder="e.g. 9421506998" onkeypress="return numbersonly(this,event)" required="required"></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <%--<asp:Label runat="server" ID="lblMoNO" ></asp:Label></td>--%>
                        </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnGetPassword" runat="server" Text="Get Password" OnClick="btnGetPassword_Click"></asp:Button>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                    </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
                </center>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </asp:content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 314px;
        }
        .auto-style2 {
            width: 270px;
        }
    </style>
</asp:Content>

