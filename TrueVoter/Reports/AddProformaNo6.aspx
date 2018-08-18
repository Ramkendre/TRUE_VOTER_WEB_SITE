<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProformaNo6.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.AddProformaNo6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Proforma No 6" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Text="0" Visible="false"></asp:TextBox>
                    <asp:HiddenField ID="hfDistID" runat="server" />
                <asp:HiddenField ID="hfLType" runat="server" />
                <asp:HiddenField ID="hfLbNameID" runat="server" />
                    <asp:HiddenField ID="hdnfieldpartytypID" runat="server" />
                <asp:HiddenField ID="hdnfieldpartyID" runat="server" />
                     <asp:HiddenField ID="hfEletypeName" runat="server" />
                <asp:HiddenField ID="hfEletypeId" runat="server" />
                           <%--<tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label5" Text="Select LocalBody Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBodytype" CssClass="form-control" runat="server" >
                              <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Municiple Corporation" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Municiple Council" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Nagar Panchayat" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Zilla Parishad" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Panchayat Samiti" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server" ></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>--%>

                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label5" Text="LocalBody Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtLBtype" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                         
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalBody" Text="LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtLBName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server" ></asp:DropDownList>--%>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblExpenseDate" Text="Expense Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtExpenseDate"  runat="server" CssClass="form-control" PlaceHolder="Expense Date"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtElectionDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                                    <td>
                                        <asp:Label runat="server" ID="Label3" Text="Expense Head"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlExpenseHead" runat="server" OnSelectedIndexChanged="ddlExpenseHead_SelectedIndexChanged" Width="500px" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="Label6" Text="Sub Expense Head"></asp:Label>
                                    </td>
                                   
                                    <td>
                                        <asp:DropDownList ID="ddlSubExpenseHead" runat="server" Width="500px"  AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                  <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine" PlaceHolder="Description"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="rfvtxtWardNo" runat="server" ControlToValidate="txtDescription" ValidationGroup="sub" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label7" Text="Amount"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" onkeypress="return fncInputNumericValuesOnly(event);"   PlaceHolder="Amount"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="rfvtxtWardNo" runat="server" ControlToValidate="txtAmount" ValidationGroup="sub" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" OnClientClick=" return validateRequired()" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="pnlGrid" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-AddCandidte">
                <asp:GridView ID="gvPartyExpense" runat="server" AllowPaging="True" PageSize="10" CellPadding="4" DataKeyNames="Id" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvPartyExpense_PageIndexChanging" CssClass="table table-hover table-bordered" Width="100%" OnRowCommand="gvPartyExpense_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />

                        <%--<asp:BoundField HeaderText="Party Type" DataField="PartyType" />
                <asp:BoundField HeaderText="Party Name" DataField="PartyName" />--%>
                        <asp:BoundField HeaderText="DistrictName" DataField="DistrictName" />
                        <asp:BoundField HeaderText="LocalBodyType Name" DataField="LocalBodyTypeName" />
                        <asp:BoundField HeaderText="LocalBody Name" DataField="LocalBodyName" />
                        <%--<asp:BoundField HeaderText="Election Type" DataField="ElectionType" />--%>
                        <asp:BoundField HeaderText="Expense Date" DataField="ExpenseDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField HeaderText="Expense Head" DataField="ExpenseHead" />
                        <asp:BoundField HeaderText="SubExpense Head" DataField="SubExpenseHead" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow"
                                    CommandArgument='<%# Eval("Id")%>'
                                    OnClientClick="return confirm('Are You sure to Edit Selected Record?')"
                                    Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkActive" runat="server" CommandName="Active"
                                    CommandArgument='<%# Eval("Id")%>'
                                    OnClientClick="return confirm('Are You sure to Active Selected Record?')"
                                    Text="Active"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DeActive">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDeActive" runat="server" CommandName="DeActive"
                                    CommandArgument='<%# Eval("Id")%>'
                                    OnClientClick="return confirm('Are You sure to Deactive Selected Record?')"
                                    Text="DeActive"></asp:LinkButton>
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
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvPartyExpense" />
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtExpenseDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtExpenseDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
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
            function fncInputNumericValuesOnly(evt) {
                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                if (charCode < 48 || charCode > 57)
                    return false;
                return true;
            }
            function validateRequired() {
                
                var wno = document.getElementById("<%=txtExpenseDate.ClientID%>").value;
                if (wno == '') {
                    alert('Please Enter Expense Date'); return false;
                }
                var sno = document.getElementById("<%=ddlExpenseHead.ClientID%>").value;
                if (sno == '--Select--' || sno == '' || sno == '0') {
                    alert('Please Select Expense Head'); return false;
                }
                var cnm = document.getElementById("<%=ddlSubExpenseHead.ClientID%>").value;
                if (cnm == '--Select--' || cnm == '' || cnm == '0') {
                    alert('Please Select Sub Expense Head'); return false;
                }
                var wno = document.getElementById("<%=txtDescription.ClientID%>").value;
                if (wno == '') {
                    alert('Please Enter Expense Description'); return false;
                }
                var amt = document.getElementById("<%=txtAmount.ClientID%>").value;
                if (amt == '') {
                    alert('Please Enter Expense Amount'); return false;
                }
            }
        </script>
    </head>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>

