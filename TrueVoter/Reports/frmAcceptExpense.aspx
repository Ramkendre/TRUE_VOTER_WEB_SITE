<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAcceptExpense.aspx.cs" Inherits="TrueVoter.Reports.frmAcceptExpense" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Accept Expenses" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                   <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtDistrict" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalby" Text="Local Body Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtLocalBody" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtLocalBody" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblwrd" Text="Ward No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtWardNo" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" ></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtWardNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblSeatNo" Text="Seat No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlSeat" CssClass="form-control" runat="server">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="1">A</asp:ListItem>
                            <asp:ListItem Value="2">B</asp:ListItem>
                             <asp:ListItem Value="3">C</asp:ListItem>
                           <asp:ListItem Value="4">D</asp:ListItem>                  
                           <asp:ListItem Value="5">E</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Show Candidate List" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <div class="borderOuter-div-AddCandidte" style="overflow: auto">
            <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvcandidateList" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvcandidateList_PageIndexChanging">
                            <Columns>
                                <%--[CId],[usrFullName],[usrMobileNumber],[CandidateRoleName],[LocalBodyType],[LocalBodyName],[WardNo],[AssemblyID]--%>
                                <asp:BoundField HeaderText="CId" DataField="CId" Visible="false" />
                                <asp:BoundField HeaderText="Candidate Name" DataField="usrFullName" />
                                <asp:BoundField HeaderText="Candidate Role" DataField="CandidateRoleName" />
                                <asp:BoundField HeaderText="Local Body Name" DataField="LocalBodyName" />
                                <asp:BoundField HeaderText="WardNo" DataField="WardNo" />
                                <asp:TemplateField HeaderText="Show">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkShow" runat="server" 
                                            CommandArgument='<%# Eval("usrMobileNumber")%>'
                                            OnClientClick="return confirm('Show Selected Candidate Details?')"
                                            Text="Show" OnClick="lnkShow_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#33adff" ForeColor="#003399" />
                            <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvcandidateList" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div>
        <%--<div class="borderOuter-div-AddCandidte">
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
                            <asp:BoundField HeaderText="SubExpense Type" DataField="SubExpenseType"/>
                            <asp:BoundField HeaderText="Qty" DataField="Qty_Size_Area"/>
                            <asp:BoundField HeaderText="Rate" DataField="Rate" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Total Expense" DataField="TotalExpense"/>
                            <asp:BoundField HeaderText="Pay Mode" DataField="PaymentMode"/>
                            <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount"/>
                            <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo"/>
                            <asp:BoundField HeaderText="Firm Name" DataField="FirmName"/>
                            <asp:BoundField HeaderText="Expense By" DataField="SourceOfExpense"/>
                            <asp:BoundField HeaderText="Status" DataField="OFFStatus"/>
                            <%--<asp:TemplateField HeaderText="Choose Record">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" Text="Select All" AutoPostBack="true" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this);" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Accept">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAccept" runat="server"
                                        CommandArgument='<%# Eval("PK_Id")%>'
                                        OnClientClick="return confirm('Are You sure to Accept Candidate Daily Expense?')"
                                        Text="Accept" OnClick="lnkAccept_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reject">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReject" runat="server"
                                        CommandArgument='<%# Eval("PK_Id")%>'
                                        OnClientClick="return confirm('Are You sure to Reject Candidate Daily Expense?')"
                                        Text="Reject" OnClick="lnkReject_Click"></asp:LinkButton>
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
                    <asp:AsyncPostBackTrigger ControlID="gvcandidateList" />
                    <asp:PostBackTrigger ControlID="btnSubmit" />
                </Triggers>
            </asp:UpdatePanel>
        </div>--%>
    </div>
</asp:Content>

