<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDailyExpDetails.aspx.cs" Inherits="TrueVoter.Admin.ReportDailyExpDetails" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Daily Expense Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDate" Text="Select Date"></asp:Label></td>
                                <td>:</td>
                                <td class="auto-style4" id="Date">
                                    <asp:TextBox ID="txtDate" TextMode="Date" Width="300px" Height="34px"  runat="server" ValidationGroup="sub"  placeholder="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="Enter ten digit Number" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label2" Text="Select Role"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList runat="server" ID="rbtnConditon" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="DailyExpense Filled Candidates"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="DailyExpense Not Filled Candidates"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                                                 <tr>
                                    <td class="auto-style12"></td>
                                    <td class="auto-style5"></td>
                                    <td class="auto-style4">
                                        <asp:Button ID="btnSubmit1" runat="server" ValidationGroup="sub" Text="Submit"  CssClass="btn btn-default" OnClick="btnSubmit1_Click" />&nbsp;&nbsp; <%--OnClientClick="return Validate()"--%>
                                        <asp:Button ID="btnClear" runat="server" Text="Clear"  CssClass="btn btn-default" />&nbsp;&nbsp;
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </table>
                        <div>
                            <asp:GridView ID="gvDailyExpense" runat="server" ShowHeaderWhenEmpty="True"  ShowFooter="True" AllowPaging="True" PageSize="10" CssClass="table table-hover table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
