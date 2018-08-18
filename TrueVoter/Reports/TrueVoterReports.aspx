<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrueVoterReports.aspx.cs" Inherits="TrueVoter.Reports.TrueVoterReports" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div class="borderOuter-div-Form">
    <div class="borderHeading-div">
        <div>
            <asp:Label ID="lblHeading" runat="server" Text="Register Officers Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
    </div>
        <div align="center">
            <div class="form-group">
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            <table style="width:789px;text-align:left">
                <tr>
                    <td class="auto-style1">
                        <asp:Label runat="server" ID="lblRole" Text="Select Designation"></asp:Label></td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">SEC</asp:ListItem>
                            <asp:ListItem Value="2">Divisional Commisioner</asp:ListItem>
                            <asp:ListItem Value="3">MC,Controller,CO,TAH</asp:ListItem>
                            <asp:ListItem Value="4">RO</asp:ListItem>
                            <asp:ListItem Value="5">Zonal</asp:ListItem>
                            <asp:ListItem Value="6">PRO</asp:ListItem>
                            <asp:ListItem Value="7">Office Bearer/Staff</asp:ListItem>
                            <asp:ListItem Value="8">Staff for Control Chart</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <%--<td>
                        <%--<asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddlRole" ErrorMessage="plz select role" Font-Size="Smaller" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>--%>
                </tr>
                <tr style="height:10px">
               <td></td>
            </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label runat="server" ID="lblDistrict" Text="Select District"></asp:Label></td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height:10px">
               <td></td>
            </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label runat="server" ID="lblRefNumber" Text="Enter Reference Number"></asp:Label></td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:TextBox ID="txtRefMbNo" runat="server" MaxLength="10" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 9422492827"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height:10px">
               <td></td>
            </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2"></td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  CssClass="btn btn-default"/>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnExportExcel" runat="server" Visible="false" Text="Export To Excel" CssClass="btn btn-default" OnClick="btnExportExcel_Click" />
                        &nbsp;&nbsp;
                            <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Admin/Home" CssClass="btn btn-default"/>
                    </td>
                </tr>
            </table>
                </div>
        </div>
         </div>
  
    <div class="borderOuter-div-Form1">
        <center>
                 <asp:GridView runat="server" ID="gvTReports" AllowPaging="True" PageSize="10" CssClass="table table-hover table-bordered" OnPageIndexChanging="gvTReports_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
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
       
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 163px;
        }
        .auto-style2 {
            width: 11px;
        }
    </style>
</asp:Content>

