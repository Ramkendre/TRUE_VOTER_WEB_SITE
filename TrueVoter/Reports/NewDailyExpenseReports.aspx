<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDailyExpenseReports.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.NewDailyExpenseReports" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form1">
                <div class="borderHeading-div">
                    <asp:Label ID="lblHeading" runat="server" Text="Expense Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </div>
                <br />

                <div class="form-group" style="overflow: auto" align="center">
                    <table>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Label ID="lblTotalNomination" runat="server" Text="Nomination Candidate Count"></asp:Label></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                            <asp:LinkButton ID="lbtnAnsTotalNomicandi" runat="server" OnClick="lbtnAnsTotalNomicandi_Click"></asp:LinkButton></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" Text="Symbol Alloted Candidate List"></asp:Label></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:LinkButton ID="lbtnSymbolAttotedcadilist" runat="server" OnClick="lbtnSymbolAttotedcadilist_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblInstaledCount" runat="server" Text="True Voter Installed Candidate Count"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDEInstalled" runat="server" Text="Daily Expense Filled Candidates Count"></asp:Label></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbbtnRegisteredCand" runat="server" OnClick="btnRegisteredCand_Click"></asp:LinkButton>
                            <td>
                                <asp:LinkButton ID="lbbtnDailyExpenseFilled" runat="server" OnClick="btnDailyExpenseFilled_Click"></asp:LinkButton>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNotistCand" runat="server" Text="True Voter Not Installed Candidate Count"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDENotFlled" runat="server" Text="Daily Expense Not Installed Candidate Count"></asp:Label></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbbtnNotRegiCandidate" runat="server" OnClick="btnNotRegiCandidate_Click"></asp:LinkButton>
                            <td>
                                <asp:LinkButton ID="lbbtnDailyExpenseNotFilled" runat="server" OnClick="btnDailyExpenseNotFilled_Click"></asp:LinkButton>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnNominiLoginUpdate" runat="server" Text="Nomination-Login Update" OnClick="btnNominiLoginUpdate_Click" /></td>
                            <td>
                                <asp:Button ID="btnCheckDailyExpe" runat="server" Text="Daily Expense Update" OnClick="btnCheckDailyExpe_Click" /></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                    </table>
                    <%--<table>
                        <%-- <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnInsertNomini" runat="server" Text="Add Nomination Details" OnClick="btnInsertNomini_Click" /></td>
                        </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnUpdateNomini" runat="server" Text="Update Nomination Details" OnClick="btnUpdateNomini_Click" /></td>
                    </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Button ID="btnNominiLoginUpdate" runat="server" Text="Nomination-Login Update" OnClick="btnNominiLoginUpdate_Click" /></td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Button ID="btnCheckDailyExpe" runat="server" Text="Daily Expense Update" OnClick="btnCheckDailyExpe_Click" /></td>

                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Button ID="btnRegisteredCand" runat="server" Text="Show TV Regi Candidate" OnClick="btnRegisteredCand_Click" /></td>

                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Button ID="btnNotRegiCandidate" runat="server" Text="Show TV Not Regi Candidate" OnClick="btnNotRegiCandidate_Click" /></td>

                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Button ID="btnDailyExpenseFilled" runat="server" Text="Show DailyExpenseFilled" OnClick="btnDailyExpenseFilled_Click" /></td>

                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style12"></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Button ID="btnDailyExpenseNotFilled" runat="server" Text="Show DailyExpense Not Filled" OnClick="btnDailyExpenseNotFilled_Click" /></td>

                        </tr>
                    </table>--%>
                </div>
            </div>
            <div style="height: 100%; width: 100%; overflow: auto;" align="center;">
                <asp:GridView runat="server" ID="gvReports" AllowPaging="True" PageSize="100" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="gvReports_SelectedIndexChanging">
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lbtnAnsTotalNomicandi" />
            <asp:PostBackTrigger ControlID="lbtnSymbolAttotedcadilist" />
            <asp:PostBackTrigger ControlID="btnNominiLoginUpdate" />
            <asp:PostBackTrigger ControlID="btnCheckDailyExpe" />
            <asp:PostBackTrigger ControlID="lbbtnRegisteredCand" />
            <asp:PostBackTrigger ControlID="lbbtnNotRegiCandidate" />
            <asp:PostBackTrigger ControlID="lbbtnDailyExpenseFilled" />
            <asp:PostBackTrigger ControlID="lbbtnDailyExpenseNotFilled" />
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
