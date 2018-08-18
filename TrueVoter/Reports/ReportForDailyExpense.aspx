<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportForDailyExpense.aspx.cs" Inherits="TrueVoter.Reports.ReportForDailyExpense" MasterPageFile="~/MasterPages/UserSite.Master" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form1">
                <div>
                    <div class="borderHeading-div">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="Expense Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="form-group" style="overflow: auto" align="center">
                        <div class="form-group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblReportType" Text="REPORT TYPE"></asp:Label></td>
                                    <td>:</td>
                                    <td>
                                        <asp:RadioButtonList ID="rblReporttype" AutoPostBack="true" runat="server"  OnSelectedIndexChanged="rblReporttype_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True" Text="Daily Expense Filled"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Daily Expense Not Filled"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="District Wise"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td></td>
                                </tr>
                                <asp:Panel runat="server" ID="pnlDist" Visible="false">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblDistName" Text="Select District"></asp:Label></td>
                                        <td>:</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlDistName" Width="500px" CssClass="form-control"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblCount" Text="COUNT"></asp:Label></td>
                                    <td>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label runat="server" ID="lblCounttotal"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnGetDetails" Text="Get Details" OnClick="btnGetDetails_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button runat="server" ID="btnExport" Text="Export" OnClick="btnExport_Click" Visible="false" />
                                    </td>
                                </tr>
                            </table>

                            <asp:GridView ID="gvCandidateList" runat="server" PageSize="100" AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvCandidateList_PageIndexChanging">
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
                    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
            <asp:PostBackTrigger ControlID="btnGetDetails" />
            <asp:PostBackTrigger ControlID="rblReporttype" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>--%>
</asp:Content>
