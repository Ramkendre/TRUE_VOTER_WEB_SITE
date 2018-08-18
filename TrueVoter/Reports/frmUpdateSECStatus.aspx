<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUpdateSECStatus.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmUpdateSECStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Update SEC Status" Font-Bold="true" Font-Size="Medium"></asp:Label>
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
                        <asp:TextBox ID="txtMobNo" runat="server" MaxLength="10" placeholder="e.g. 9421506998" onClientClick="return ValidateMe()" onkeypress="return numbersonly(this,event)" ></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Choose Status"></asp:Label></td>
                        </td>
                    <td class="auto-style2">
                        <asp:RadioButtonList Id="rbActive" runat="server" RepeatDirection="Vertical" CssClass="radio">
                            <asp:ListItem Selected="True" Text="Active" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Deactive" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <%--<asp:Label runat="server" ID="lblMoNO" ></asp:Label>--%></td>
                        </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnChange" runat="server" Text="Change" OnClientClick="return ValidateMe()" OnClick="btnChange_Click"></asp:Button>
                        &nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btnBack" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" Text="Back" />
                    </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
                </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript" lang="javascript">
            function ConfirmMe() {
                debugger;
                var r = confirm("Are You Sure You Want to Change SEC Status?");
                if (r == true) {
                    return true;
                }
                else {
                    return false;
                }

            }

            function ValidateMe() {
                debugger;
                var mono = document.getElementById("<%= txtMobNo.ClientID %>").value;
                var l = mono.length;
                if (l == "10") {
                    return true;
                }
                else {
                    alert('Mobile No is Not Valid!!!');
                    return false;
                }
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 314px;
        }

        .auto-style2 {
            width: 270px;
        }
    </style>

</asp:Content>
