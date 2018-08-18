<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmaddExpenseByOfficerTwo.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmaddExpenseByOfficerTwo" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form1">
                <div>
                    <div class="borderHeading-div">
                        <div>
                            <%--style="color: white; background: #33adff; width: 100%; height: 35px;" align="center">--%>
                            <asp:Label ID="lblHeading" runat="server" Text="Candidate Daily Expenses" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div align="left">
                            <table style="width: 911px; margin-left: 103px; margin-right: 38px; margin-top: 14px; margin-bottom: 15px;">
                                 <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label1" Text="Candidate Name"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtName"  runat="server" Width="500px"  CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">.</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                 <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label21" Text="Candidate local Body" ></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtCandidateLocalBody" Width="500px"   runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">.</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                 <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label22" Text="Candidate Mobile No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtCandidateMoNo" Width="500px"   runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">.</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="lblDateHead" Text="Date"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtDate" Width="250px" runat="server" CssClass="form-control" PlaceHolder="Date"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">.</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label2" Text="Expense Head"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="ddlExpenseHead" runat="server" OnSelectedIndexChanged="ddlExpenseHead_SelectedIndexChanged" Width="500px" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label3" Text="Sub Expense Head"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="ddlSubExpenseHead" runat="server" Width="500px" OnSelectedIndexChanged="ddlSubExpenseHead_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label4" Text="Standard Rate"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:Label runat="server" ID="lblStandardRate"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label5" Text="Unit"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:Label runat="server" ID="lblUnit"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label6" Text="Area/Size/Quantity"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtArea" runat="server" PlaceHolder="e.g. 25" Width="500px" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtArea" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label7" Text="Your Rate"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtYourRate" runat="server" PlaceHolder="e.g. 250" Width="500px" onkeypress="return numbersonly(this,event)" AutoPostBack="true" OnTextChanged="txtYourRate_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtYourRate" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label8" Text="Total"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtTotal" runat="server" onkeypress="return numbersonly(this,event)" Width="500px" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtYourRate" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label9" Text="Payment Type"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList ID="rbtnPaymentType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="0" Selected="True">Full Payment</asp:ListItem>
                                            <asp:ListItem Value="1">Partial Payment</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label10" Text="Payment Mode"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList ID="rbPaymentMode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True">Cash</asp:ListItem>
                                            <asp:ListItem Value="1">Cheque</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label11" Text="Amount"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtAmount" runat="server" PlaceHolder="e.g. 2500" Width="500px" onkeypress="return numbersonly(this,event)" MaxLength="10" OnTextChanged="txtAmount_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox></td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtAmount" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <asp:Panel runat="server" ID="pnlChequeNo" Visible="false">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label12" Text="Cheque No"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtChequeNo" runat="server" PlaceHolder="e.g. 526898" Width="500px" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label13" Text="Balance Payment"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtBalpayment" runat="server" ReadOnly="true" Width="500px" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label14" Text="Vender/Service Provider Name"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtVenderName" runat="server" Width="500px" PlaceHolder="e.g.AISPL,Pune" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtBalpayment" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label15" Text="Vender/Service Provider Mobile No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtVenderMobNo" runat="server" Width="500px" PlaceHolder="e.g.9421506998" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtBalpayment" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label20" Text="Bill No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtBillNo" runat="server" PlaceHolder="e.g.94223" Width="500px" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtBalpayment" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label16" Text="Sources Of Expense"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList ID="rbtnSourceExpense" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True">Self</asp:ListItem>
                                            <asp:ListItem Value="1">By Party</asp:ListItem>
                                            <asp:ListItem Value="2">By Other</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label17" Text="Party/OtherPerson Name"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtPartyotherName" runat="server" PlaceHolder="e.g.Party Name" Width="500px" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label18" Text="Party/OtherPerson Mobile No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtPartyotherMobNo" runat="server" MaxLength="10" Width="500px" PlaceHolder="e.g.9421506998" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <asp:Panel runat="server" ID="Panel1" Visible="false">
                                    <tr style="height: 10px">
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label19" Text="Reffrence Mobile No"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtReffrenceNo" runat="server" Width="500px" MaxLength="10" PlaceHolder="e.g.9422325020" Text="0" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12"></td>
                                    <td class="auto-style5"></td>
                                    <td class="auto-style4">
                                        <asp:Button ID="btnSubmit1" runat="server" ValidationGroup="sub" Text="Submit" OnClientClick="return confirm('Daily Expense Entry Added From Computer Can Not be updated, be careful. Add accurate details.Are You Sure Save it?')" OnClick="btnSubmit_Click" CssClass="btn btn-default" />&nbsp;&nbsp; <%--OnClientClick="return Validate()"--%>
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-default" />&nbsp;&nbsp;
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="overflow: auto">
                            <asp:GridView ID="gvDaillyExpenses" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" ShowFooter="True" CssClass="table table-hover table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvDaillyExpenses_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="अ.क्र" DataField="PK_Id" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="खर्चाचा दिनांक" DataField="Date" ItemStyle-Width="5%" DataFormatString="{0:yyyy-MM-dd}">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="खर्चाची मुख्य बाब" DataField="ExpenseType" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="खर्चाची आंतर बाब" DataField="SubExpenseType" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="संख्या/ क्षेत्रफळ/ दिवस" DataField="Qty_Size_Area" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="प्रति दर" DataField="Rate" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="चेक/ रोखीने" DataField="PaymentMode" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="पावती" DataField="InvoiceNo" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" DataField="SourceOfExpense" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="पक्षाचा की/ इतर व्यक्तीचा नाव" DataField="PartyName" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="पक्षाचा केलेल्या खर्चाच्या बाबत मोबाईल" DataField="PartyNo" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="एकूण खर्च" DataField="TotalExpense" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
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
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit1" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 17px;
        }

        .auto-style3 {
            width: 489px;
        }

        .auto-style4 {
            width: 568px;
        }

        .auto-style5 {
            width: 15px;
        }

        .auto-style7 {
            width: 48px;
        }

        .auto-style11 {
            width: 285px;
        }

        .auto-style12 {
            width: 242px;
        }
    </style>
    <script type="text/javascript">
        function numbersonly(evt) {
            //debugger;
            var charCode = (evt.fwhich) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
