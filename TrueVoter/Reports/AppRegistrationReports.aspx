<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppRegistrationReports.aspx.cs" Inherits="TrueVoter.Reports.AppRegistrationReports" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form1">
                <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Application Registration Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
            <br />
            <br />
        <div class="form-group">
        <div>
            <table style="width: 582px; margin-left: 172px;">
                <tr>
                    <td style="text-align: left" class="auto-style1">SELECT ROLE:</td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlRole" runat="server" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Voter" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Officer" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Candidate" Value="3"></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </div>

        <br />
        <br />
        <div>
            <center>
                 <asp:GridView runat="server" ID="gvAppRegistrationReports" AllowPaging="True" EmptyDateText="Data Not Found" CssClass="table table-hover table-bordered" PageSize="25" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvAppRegistrationReports_PageIndexChanging" Width="505px">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </center>
        </div>
        <br />
        <div align="center">
            <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" OnClick="btnExcel_Click" CssClass="btn btn-default" />
        </div>
            </div>
    </div>
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-family: Tahoma;
            font-size: small;
            width: 117px;
        }
    </style>
</asp:Content>
