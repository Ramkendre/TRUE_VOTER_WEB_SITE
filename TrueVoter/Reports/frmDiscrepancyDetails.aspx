<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDiscrepancyDetails.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmDiscrepancyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table.Custom, table.Custom.td, table.Custom.th {
            border: 1px solid #ddd;
            text-align: left;
        }

        table.Custom {
            border-collapse: collapse;
            width: 100%;
        }

        th.Custom, td.Custom {
            padding: 15px;
        }
    </style>
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Discrepancy Details Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:HiddenField ID="hfCanMob" runat="server" />
        <asp:HiddenField ID="hfDistId" runat="server" />
        <asp:HiddenField ID="hfLbId" runat="server" />
        <asp:HiddenField ID="hfWard" runat="server" />
        <asp:HiddenField ID="hfLbTyp" runat="server" />
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:FormView ID="FvDiscrepancyDetails" runat="server" CssClass="table table-hover table-bordered">
                        <ItemTemplate>
                            <table border="0" cellpadding="5" cellspacing="5">
                                <tr>
                                    <td style="color: brown">Candidate Name:
                                    </td>
                                    <td>
                                        <%# Eval("usrFullName") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Mobile No:
                                    </td>
                                    <td>
                                        <%# Eval("usrMobileNumber") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Candidate Role:
                                    </td>
                                    <td>
                                        <%# Eval("CandidateRoleName") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">PartyName:
                                    </td>
                                    <td>
                                        <%# Eval("PartyName") %>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="color: brown">Seat No:
                                    </td>
                                    <td>
                                        <%# Eval("SeatNo") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">WardNo:
                                    </td>
                                    <td>
                                        <%# Eval("WardNo") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Election Type:
                                    </td>
                                    <td>
                                        <%# Eval("ElectionType") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">LocalBody Name:
                                    </td>
                                    <td>
                                        <%# Eval("LocalBodyName") %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>

                    <table class="Custom">
                        <tr>
                            <td class="Custom">Total Expense:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblTotalExp" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom"></td>
                            <td class="Custom"></td>
                            <td class="Custom"></td>
                            <td class="Custom"></td>
                        </tr>
                        <tr>
                            <%--style="color: brown; font-size: medium"--%>
                            <td class="Custom">Total Expense By Self:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblExpSelf" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom">Total Expense By party:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblExpparty" runat="server" Font-Bold="true"></asp:Label>
                            </td>

                            <td class="Custom">Total Expense By Other:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblExpOther" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <asp:GridView ID="gvDailyExpenses" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" Visible="true" AllowPaging="True"
                        PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvDailyExpenses_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="PK_Id" ItemStyle-Width="90px" />
                            <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="90px" />
                            <asp:BoundField HeaderText="Expense Type" DataField="ExpenseType" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="SubExpense Type" DataField="SubExpenseType" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Qty" DataField="Qty_Size_Area" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Rate" DataField="Rate" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Pay Mode" DataField="PaymentMode" ItemStyle-Width="70px" />
                            <%--<asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" ItemStyle-Width="70px" />--%>
                            <%--<asp:BoundField HeaderText="Firm Name" DataField="FirmName" ItemStyle-Width="70px" />--%>
                            <%--ShowFooter="True"--%>
                            <asp:BoundField HeaderText="Deviation" DataField="Deviation" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Total Expense" DataField="TotalExpense" ItemStyle-Width="70px" />
                            <%--<asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server"
                                        CommandArgument='<%# Eval("PK_Id")%>'
                                        OnClientClick="return confirm('Are You sure to View Deviation Record?')"
                                        Text="View" OnClick="ApproveRecord"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <%--  <FooterStyle BackColor="#33adff" ForeColor="#003399" />
                        <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />--%>
                    </asp:GridView>

                    <table class="Custom">
                        <tr>
                            <td class="Custom">Total Fund:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblTotalFund" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom"></td>
                            <td class="Custom"></td>
                            <td class="Custom"></td>
                            <td class="Custom"></td>
                        </tr>
                        <tr>
                            <td class="Custom">Total Expense Self:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblSelf" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom">Total Expense Party:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblParty" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom">Total Expense Supporter:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblSupporter" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Custom">Total Expense Relative:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblRelative" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom">Total Expense Friend:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblFriend" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="Custom">Total Expense WellWisher:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblWellWisher" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="gvFundDetails" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True"
                        PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Visible="true">
                        <Columns>
                            <asp:BoundField HeaderText="FundID" DataField="FundID" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="70px" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField HeaderText="Name" DataField="ProviderName" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Relation" DataField="FromText" ItemStyle-Width="60px" />
                            <asp:BoundField HeaderText="Fund Type" DataField="FundTYpeTxt" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="PaidBy" DataField="PaidBy" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="ChequeNo" DataField="CheckNo" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Bank Name" DataField="ProviderBankName" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-Width="70px" />
                            <%--<asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="70px" />--%>
                        </Columns>
                        <%--  <FooterStyle BackColor="#33adff" ForeColor="#003399" />
                        <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />--%>
                    </asp:GridView>


                    <table class="Custom">
                        <tr>
                            <td class="Custom">Total Party Expense:
                            </td>
                            <td class="Custom">
                                <asp:Label ID="lblPartyExpe" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="Div1" style="height: auto; width: 100%;" align="center">
                <asp:GridView ID="gvPrtyExpCan" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                    AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" Visible="true"
                    PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvPrtyExpCan_PageIndexChanging" OnDataBound="gvPrtyExpCan_DataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Expense Head" DataField="ExpenseHead" />
                        <asp:BoundField HeaderText="Sub Expense" DataField="SubExpenseHead" />
                        <asp:BoundField HeaderText="Expense Date" DataField="ExpenseDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                        <asp:BoundField HeaderText="Party Officer" DataField="CreatedBy" />
                    </Columns>
                    <%--<FooterStyle BackColor="#33adff" ForeColor="#003399" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />--%>
                </asp:GridView>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn" OnClick="btnback_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnsenNotice" runat="server" Text="Send Notice" CssClass="btn" OnClick="btnsenNotice_Click" />
        </div>
    </div>
</asp:Content>

