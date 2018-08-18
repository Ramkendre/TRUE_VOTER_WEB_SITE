<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upDateDailyExpenses.aspx.cs" Inherits="TrueVoter.Reports.upDateDailyExpenses" MasterPageFile="~/MasterPages/UserSite.Master" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel runat="server" ID="updateDailyExpense">
        <ContentTemplate>
            <div class="borderOuter-div-Form1">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Approve Disapprove Daily Expenses" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="borderOuter-div-AddCandidte">
                <asp:GridView ID="gvMyDailyExpense" runat="server" AllowPaging="True" PageSize="10" CellPadding="4" DataKeyNames="PK_Id" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvMyDailyExpense_PageIndexChanging" CssClass="table table-hover table-bordered" Width="962px" OnRowDataBound="gvMyDailyExpense_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="PK_Id" />
                        <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="90px" />
                        <asp:BoundField HeaderText="Expense Type" DataField="ExpenseType" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="SubExpense Type" DataField="SubExpenseType" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Qty" DataField="Qty_Size_Area" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Rate" DataField="Rate" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Total Expense" DataField="TotalExpense" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Pay Mode" DataField="PaymentMode" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Firm Name" DataField="FirmName" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Expense By" DataField="SourceOfExpense" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Entry By (Candidate(2)/ Represen- tative(3))" DataField="CandidateRole" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Reffrence" DataField="ReffrenceMobile" Visible="false" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Candidate has (Verified(1)/ Rejected(0))" DataField="IsApproved" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Publish(1) / Discard(0)" DataField="IsActive" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Printed" DataField="Printed" ItemStyle-Width="70px" />
                        <asp:TemplateField HeaderText="Choose Record">
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" Text="Select All" AutoPostBack="true" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this);" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Publish">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove" runat="server"
                                    CommandArgument='<%# Eval("PK_Id")%>'
                                    OnClientClick="return confirm('Are You sure to Print and Publish this Record?')"
                                    Text="Publish" OnClick="ApproveRecord"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Discard">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemoveDeactive" runat="server"
                                    CommandArgument='<%# Eval("PK_Id")%>'
                                    OnClientClick="return confirm('Are You Sure to Discard this Entry in Printing. This Entry Will Not be Published and Will not be Submitted to RO?')"
                                    Text="Discard" OnClick="DisApproveRecord"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkApproves" runat="server"
                                    CommandArgument='<%# Eval("PK_Id")%>'
                                    OnClientClick="return confirm('Are You sure to Verify the Entry Added By Your Representative/Worker ?')"
                                    Text="Verify" OnClick="ApproveRecordNew"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reject">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDisApprove" runat="server"
                                    CommandArgument='<%# Eval("PK_Id")%>'
                                    OnClientClick="return confirm('Are You Sure to Reject The Entry Added By Your Representative?')"
                                    Text="Reject" OnClick="DisApproveRecordNew"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Officer Status" DataField="OFFStatus" />
                        <asp:BoundField HeaderText="ID" DataField="PK_Id" />
                    </Columns>

                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>

            <div style="height: 30px">
                <asp:Label runat="server" ID="lblTotalCount" Text="Total Expense:" style="font-size:large;font-weight:bold"></asp:Label><asp:Label runat="server" ID="lblTotal"></asp:Label>
            </div>
            <div style="height: 30px">
                <asp:Label runat="server" ID="Label1" Text="Total Approved Expense:" style="font-size:large;font-weight:bold"></asp:Label><asp:Label runat="server" ID="lblTotalApp"></asp:Label>
            </div>
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Reports/frmHomeUser.aspx" CssClass="btn btn-default" />

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
