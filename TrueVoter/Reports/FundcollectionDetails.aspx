<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FundcollectionDetails.aspx.cs" Inherits="TrueVoter.Reports.FundcollectionDetails" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Fund Collection Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                         <td class="auto-style1">
                            <asp:Label runat="server" ID="Label2" Text="Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDate" TextMode="Date" runat="server" CssClass="form-control" PlaceHolder="Date"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblFrom" Text="From"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlFrom" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlFrom_SelectedIndexChanged">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="1">self</asp:ListItem>
                            <asp:ListItem Value="2">Party</asp:ListItem>
                             <asp:ListItem Value="3">Supporter</asp:ListItem>
                           <asp:ListItem Value="4">Relative</asp:ListItem>                  
                           <asp:ListItem Value="5">Friend</asp:ListItem>
                           <asp:ListItem Value="6">Wellwisher</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMoNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblSelectFundType" Text="Select Fund Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlSelectFundType" CssClass="form-control" runat="server"  AutoPostBack="true">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="1">Donation</asp:ListItem>
                            <asp:ListItem Value="2">Gift</asp:ListItem>
                             <asp:ListItem Value="3">Loan</asp:ListItem>
                           <asp:ListItem Value="4">Other</asp:ListItem>                  
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ValidationGroup="sub" ControlToValidate="ddlSelectFundType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblAmount" Text="Amount"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" PlaceHolder="Enter amount"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtAmount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblpaidBy" Text="Paid By"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlPaidBy" CssClass="form-control" runat="server"  AutoPostBack="true">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="Cash">Cash</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                           <asp:ListItem Value="Other">Other</asp:ListItem>                  
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFath" ValidationGroup="sub" runat="server" ControlToValidate="ddlPaidBy" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblchkNoOtherDtls" Text="Check No/Other Details"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtChkDtls" runat="server"  CssClass="form-control" PlaceHolder="Check No and other details"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorage" ValidationGroup="sub" runat="server" ControlToValidate="txtChkDtls" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <asp:Panel runat="server" ID="pnlProviderBankName" Visible="false">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblproviderbankNo" Text="Provider's Bank Name" Visible="false"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtproviderbnkDtls" runat="server" CssClass="form-control" PlaceHolder="Provider's Bank Name" Visible="false"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlace" ValidationGroup="sub" runat="server" ControlToValidate="txtproviderbnkDtls" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlprovidername" Visible="false">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblprovidername" Text="Provider Name" Visible="false"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtProviderName" runat="server" CssClass="form-control" PlaceHolder="Provider Name" Visible="false"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorParty" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     </asp:Panel>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblAddress" Text="Address"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" PlaceHolder="Address"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <asp:Panel runat="server" ID="pnlMoNo" Visible="false">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblMobNo" Text="Mobile No" Visible="false"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtmobNo" runat="server" CssClass="form-control" PlaceHolder="Mobile No" Visible="false"></asp:TextBox>
                            <%--<asp:TextBox ID="txtSeatNo" runat="server" CssClass="form-control" PlaceHolder="Seat No"></asp:TextBox>--%>
                        </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorSeatNo" ValidationGroup="sub" runat="server" ControlToValidate="txtSeatNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                   </asp:Panel>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />--%>
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
                        <asp:GridView ID="gvFundDetails" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanging="gvFundDetails_SelectedIndexChanging">
                            <Columns>
                                <%--[FundID],[Date],[FromWhom],[FundType],[Amount],[PaidBy],[CheckNo],[CheckDate],[ProviderBankName],[ProviderName],[Address],[MobileNo]--%>
                                <asp:BoundField HeaderText="FundID" DataField="FundID" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="70px" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField HeaderText="FromWhom" DataField="FromWhom" ItemStyle-Width="60px" />
                                <asp:BoundField HeaderText="FundType" DataField="FundType" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="PaidBy" DataField="PaidBy" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="CheckNo" DataField="CheckNo" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Provider BankName" DataField="ProviderBankName" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Provider Name" DataField="ProviderName" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="IsActive" DataField="IsActive" ItemStyle-Width="70px" />
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSubmit" runat="server"
                                            CommandArgument='<%# Eval("FundID")%>'
                                            OnClientClick="return confirm('Are You sure to Active  Fund Details?')"
                                            Text="Active" OnClick="lnkSubmit_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deactive">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDeactive" runat="server"
                                            CommandArgument='<%# Eval("FundID")%>'
                                            OnClientClick="return confirm('Are You sure to Deactive Fund Details?')"
                                            Text="Deactive" OnClick="lnkDeactive_Click"></asp:LinkButton>
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
                        <asp:AsyncPostBackTrigger ControlID="gvFundDetails" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
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
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <head>
        <title></title>
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
    </head>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>


