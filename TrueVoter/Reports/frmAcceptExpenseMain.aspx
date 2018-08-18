<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAcceptExpenseMain.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmAcceptExpenseMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
            <asp:Label ID="lblHeading" runat="server" Text="Accept Expenses" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                   <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCanName" Text="Candidate Name"></asp:Label>:</td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtCandidateName" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtLocalBody" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalby" Text="Local Body Name"></asp:Label>:</td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtLocalBody" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtLocalBody" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Candidate Mobile No"></asp:Label>:</td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtLocalBody" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;Note:- Status: 1=Accept || 2=Reject
                        </td>
                    <td>
                        
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtLocalBody" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="borderOuter-div-AddCandidte">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvCandidateDailyEx" runat="server" AllowPaging="True" PageSize="10" CellPadding="4" DataKeyNames="PK_Id" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvCandidateDailyEx_PageIndexChanging" CssClass="table table-hover table-bordered" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />

                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="PK_Id" />
                        <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField HeaderText="Expense Type" DataField="ExpenseType" />
                        <asp:BoundField HeaderText="SubExpense Type" DataField="SubExpenseType" />
                        <asp:BoundField HeaderText="Qty" DataField="Qty_Size_Area" />
                        <asp:BoundField HeaderText="Rate" DataField="Rate" ItemStyle-Width="70px" />
                        <asp:BoundField HeaderText="Total Expense" DataField="TotalExpense" />
                        <asp:BoundField HeaderText="Pay Mode" DataField="PaymentMode" />
                        <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount" />
                        <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" Visible="false" ItemStyle-Width="50px" />
                        <asp:BoundField HeaderText="Firm Name" DataField="FirmName" />
                        <%--<asp:BoundField HeaderText="Expense By" DataField="SourceOfExpense" />--%>
                        <asp:BoundField HeaderText="Status 1-Accept 2-Reject" DataField="OFFStatus" />
                        <%--<asp:TemplateField HeaderText="Choose Record">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" Text="Select All" AutoPostBack="true" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this);" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="Accept">
                            <ItemTemplate>
                                <asp:Button ID="btnAccRej" runat="server" CommandArgument='<%# Eval("PK_Id") %>' OnClientClick="return confirm('Are U Sure Change Status of Expense?')"
                                    Text='<%# Eval("BTNTEXT") %>' OnClick="btnAccRej_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Accept">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAccept" runat="server"
                                    CommandArgument='<%# Eval("PK_Id")%>'
                                    OnClientClick="return confirm('Are You sure to Accept Candidate Daily Expense?')"
                                    Text="Accept" OnClick="lnkAccept_Click" ForeColor="#00cc00"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reject">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkReject" runat="server"
                                    CommandArgument='<%# Eval("PK_Id")%>'
                                    OnClientClick="return confirm('Are You sure to Reject Candidate Daily Expense?')"
                                    Text="Reject" OnClick="lnkReject_Click" ForeColor="Red"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvCandidateDailyEx" />
                <%--<asp:PostBackTrigger ControlID="lnkAccept" />--%>
            </Triggers>
        </asp:UpdatePanel>
        <div align="center">
            <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
        </div>
    </div>
</asp:Content>
