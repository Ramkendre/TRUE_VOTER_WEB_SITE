<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewChangeExpense.aspx.cs" Inherits="TrueVoter.Reports.NewChangeExpense" MasterPageFile="~/MasterPages/UserSite.Master" EnableEventValidation="false"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form1">
                <div>
                    <div class="borderHeading-div">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="Change Expenses" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div align="center">
                            <table style="width: 911px; margin-left: 103px; margin-right: 38px; margin-top: 14px; margin-bottom: 15px;">
                                <tr>
                                    <td style="width:145px">
                                        <asp:Label ID="Label1" runat="server"  Text="Enter Expense Id"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td style="width:45px">
                                        <asp:TextBox ID="txtExpenseOldId" runat="server" CssClass="form-control" ReadOnly="true" PlaceHolder="E.g 2147"  Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:10px">

                                </tr>
                                <tr>
                                    <td class="auto-style12">
                                        <asp:Label ID="lblDateHead" runat="server"  Text="Date"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="true" CssClass="form-control" PlaceHolder="Date" Width="250px"></asp:TextBox>
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
                                        <asp:DropDownList ID="ddlExpenseHead" runat="server" CssClass="form-control"  Width="500px">
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
                                        <asp:DropDownList ID="ddlSubExpenseHead" runat="server"  CssClass="form-control" Width="500px">
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
                                        <asp:TextBox ID="txtArea" runat="server" ReadOnly="true" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 25" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtYourRate" runat="server" AutoPostBack="true" ReadOnly="true"  CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 250" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"  onkeypress="return numbersonly(this,event)" ReadOnly="true" Width="500px"></asp:TextBox>
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
                                       <%-- <asp:RadioButtonList ID="rbtnPaymentType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="0">Full Payment</asp:ListItem>
                                            <asp:ListItem Value="1">Partial Payment</asp:ListItem>
                                        </asp:RadioButtonList>--%>
                                       <asp:TextBox ID="txtPaymentType" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" ReadOnly="true" Width="500px"></asp:TextBox>
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
                                        <%--<asp:RadioButtonList ID="rbPaymentMode" runat="server" AutoPostBack="true"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="0">Cash</asp:ListItem>
                                            <asp:ListItem Value="1">Cheque</asp:ListItem>
                                        </asp:RadioButtonList>--%>
                                        <asp:TextBox ID="txtPaymentMode" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" ReadOnly="true" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" ReadOnly="true" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)"  PlaceHolder="e.g. 2500" Width="500px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" ForeColor="Red" ValidationGroup="sub"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <asp:Panel ID="pnlChequeNo" runat="server" Visible="true">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="Cheque No"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtChequeNo" runat="server" CssClass="form-control" ReadOnly="true" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 526898" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtVenderName" runat="server" ReadOnly="true" CssClass="form-control" PlaceHolder="e.g.AISPL,Pune" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtVenderMobNo" runat="server" CssClass="form-control" ReadOnly="true" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.9421506998" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" ReadOnly="true" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.94223" Width="500px"></asp:TextBox>
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
                                        <%--<asp:RadioButtonList ID="rbtnSourceExpense" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="0">Self</asp:ListItem>
                                            <asp:ListItem Value="1">By Party</asp:ListItem>
                                            <asp:ListItem Value="2">By Other</asp:ListItem>
                                        </asp:RadioButtonList>--%>
                                         <asp:TextBox ID="txtSourceExpense" runat="server" CssClass="form-control" ReadOnly="true" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.94223" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtPartyotherName" runat="server" ReadOnly="true" CssClass="form-control" PlaceHolder="e.g.Party Name" Width="500px"></asp:TextBox>
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
                                        <asp:TextBox ID="txtPartyotherMobNo" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.9421506998" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>

                                <asp:Panel ID="Panel1" runat="server" Visible="true">
                                    <tr style="height: 10px">
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Text="Reffrence Mobile No"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtReffrenceNo" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g.9422325020" Text="0" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                 <tr style="height: 10px">
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Text="Difference Amount"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtdifferamount" runat="server"  CssClass="form-control" MaxLength="10" onkeypress="return numbersonly(this,event)" PlaceHolder="" Text="0" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                 <tr style="height: 10px">
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Text="Decision/Remark"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtdecisionRemark" runat="server"  CssClass="form-control"  TextMode="MultiLine" PlaceHolder="" Text="0" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style12"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style12"></td>
                                    <td class="auto-style5"></td>
                                    <td class="auto-style4">
                                        <asp:Button ID="btnAddDiffer" runat="server" CssClass="btn btn-default" OnClick="btnAddDiffer_Click" OnClientClick="return confirm('Daily Expense Entry Added From Computer Can Not be updated, be careful. Add accurate details.Are You Sure Save it Deviation?')" Text="Add Difference" ValidationGroup="sub" />
                                        &nbsp;&nbsp; <%--OnClientClick="return Validate()"--%>
                                       
                                       <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click" Text="Back" />
                                    </td>
                                </tr>
                                </caption>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddDiffer" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
