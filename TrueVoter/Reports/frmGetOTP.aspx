<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGetOTP.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmGetOTP" %>
<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Get OTP" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
        <ContentTemplate>
        <div class="form-group">
            <center>
                <table style="width: 574px; text-align:left; margin-left: 6px;">
                    <tr>
                        <td class="auto-style7">
                            <asp:Label runat="server" ID="lblCanName" Text="Candidate Mobile No."></asp:Label></td>
                        </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtGetOPT" runat="server" CssClass="form-control" MaxLength="10" placeholder="e.g. 9421506998" Width="350px" onkeypress="return numbersonly(this,event)" required="required"></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
                    <tr>
                        <%--<td class="auto-style1">
                            <asp:Label runat="server" ID="lblMoNO" Text="Mobile No"></asp:Label></td>
                        </td>--%>
                        <td class="auto-style7"></td>
                    <td class="auto-style2">
                        <asp:Button ID="btnGetPassword" runat="server" Text="Get OTP" CssClass="btn btn-default" OnClick="btnGetPassword_Click"></asp:Button>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default"/>
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
        .auto-style2 {
            width: 270px;
        }
        .auto-style6 {
            width: 234px
        }
        .auto-style7 {
            width: 155px
        }
    </style>
</asp:Content>
