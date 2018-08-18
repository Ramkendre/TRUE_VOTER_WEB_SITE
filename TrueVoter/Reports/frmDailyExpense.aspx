<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="frmDailyExpense.aspx.cs" Inherits="TrueVoter.Reports.frmDailyExpense" MasterPageFile="~/MasterPages/UserSite.Master" %>

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
                        <div align="center">
                            <%--<table style="width: 750px; margin-left: 103px; margin-right: 38px; margin-top: 14px; margin-bottom: 15px;">
                                <tr>
                                    <td style="font-size: large">*Note:- As per instructions from SEC, Maharashtra, The &quot;Add Daily Expence&quot; Menu will be disabled from Website after 13th May 2017 (18:00 Hrs). All Candidates have to fill their Daily Expenses using True Voter Mobile Application ONLY. Approval and Printing of proforma will be same as it is.
                                        <br />
                                        एसईसी महाराष्ट्रच्या  निर्देशांनुसार,
                                        13 मे 2017 (18:00 तास) नंतर वेबसाइटवरील "Add Daily Expence" मेनू अक्षम केला जाईल.
                                        सर्व उमेदवारांना फक्त ट्रू वोटर मोबाईल अँप्लिकेशन वापरूनच त्यांच्या दैनिक खर्च भरावा लागणार आहे.
                                        प्रोफार्माची मंजूरी आणि छपाई त्याचप्रमाणेच असेल.
                                        
                                    </td>
                                </tr>
                            </table>
                            <br />--%>
                            <%--<br />--%>
                            <table style="width: 911px; margin-left: 103px; margin-right: 38px; margin-top: 14px; margin-bottom: 15px;">
                                <%--<marquee onmouseover="stop();" onmouseout="start();" class="marqueestyle" scrollamount="7" scrolldelay="100" direction="side" width="100%"  height="25" style="margin-top: 0px"></marquee>--%>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="lblDateHead" runat="server" Text="Date"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" PlaceHolder="Date" TextMode="Date" Width="250px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">.</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label2" runat="server" Text="Expense Head"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="ddlExpenseHead" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlExpenseHead_SelectedIndexChanged" Width="500px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label3" runat="server" Text="Sub Expense Head"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="ddlSubExpenseHead" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlSubExpenseHead_SelectedIndexChanged" Width="500px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label4" runat="server" Text="Standard Rate"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblStandardRate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label5" runat="server" Text="Unit"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblUnit" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label6" runat="server" Text="Area/Size/Quantity"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 25" Width="500px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtArea" ErrorMessage="*" ForeColor="Red" ValidationGroup="sub"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label7" runat="server" Text="Your Rate"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtYourRate" runat="server" AutoPostBack="true" CssClass="form-control" onkeypress="return numbersonly(this,event)" OnTextChanged="txtYourRate_TextChanged" PlaceHolder="e.g. 250" Width="500px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtYourRate" ErrorMessage="*" ForeColor="Red" ValidationGroup="sub"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label8" runat="server" Text="Total"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" ReadOnly="true" Width="500px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtYourRate" ErrorMessage="*" ForeColor="Red" ValidationGroup="sub"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label9" runat="server" Text="Payment Type"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList ID="rbtnPaymentType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="0">Full Payment</asp:ListItem>
                                            <asp:ListItem Value="1">Partial Payment</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label10" runat="server" Text="Payment Mode"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList ID="rbPaymentMode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="0">Cash</asp:ListItem>
                                            <asp:ListItem Value="1">Cheque</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label11" runat="server" Text="Amount"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" OnTextChanged="txtAmount_TextChanged" PlaceHolder="e.g. 2500" Width="500px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" ForeColor="Red" ValidationGroup="sub"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <asp:Panel ID="pnlChequeNo" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="Cheque No"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtChequeNo" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 526898" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label13" runat="server" Text="Balance Payment"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtBalpayment" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" ReadOnly="true" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label14" runat="server" Text="Vender/Service Provider Name"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtVenderName" runat="server" CssClass="form-control" PlaceHolder="e.g.AISPL,Pune" Width="500px"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtBalpayment" ForeColor="Red"></asp:RequiredFieldValidator>--%></td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label15" runat="server" Text="Vender/Service Provider Mobile No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtVenderMobNo" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.9421506998" Width="500px"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtBalpayment" ForeColor="Red"></asp:RequiredFieldValidator>--%></td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label20" runat="server" Text="Bill No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.94223" Width="500px"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtBalpayment" ForeColor="Red"></asp:RequiredFieldValidator>--%></td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label16" runat="server" Text="Sources Of Expense"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:RadioButtonList ID="rbtnSourceExpense" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="0">Self</asp:ListItem>
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
                                        <asp:Label ID="Label17" runat="server" Text="Party/OtherPerson Name"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtPartyotherName" runat="server" CssClass="form-control" PlaceHolder="e.g.Party Name" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="Label18" runat="server" Text="Party/OtherPerson Mobile No"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtPartyotherMobNo" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.9421506998" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <tr style="height: 10px">
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Text="Reffrence Mobile No"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtReffrenceNo" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.9422325020" Text="0" Width="500px"></asp:TextBox>
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
                                        <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" OnClientClick="return confirm('Daily Expense Entry Added From Computer Can Not be updated, be careful. Add accurate details.Are You Sure Save it?')" Text="Submit" ValidationGroup="sub" />
                                        &nbsp;&nbsp; <%--OnClientClick="return Validate()"--%>
                                        <asp:Button ID="btnClear" runat="server" CssClass="btn btn-default" OnClick="btnClear_Click" Text="Clear" />
                                        &nbsp;&nbsp;
                                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click" Text="Back" />
                                    </td>
                                </tr>
                                </caption>
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
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .marqueestyle {
            font-size: 18px;
            font-family: Arial;
            color: red;
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

        .auto-style12 {
            width: 242px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>
</asp:Content>

