<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProformaNo5.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.AddProformaNo5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Proforma No 5" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdnfieldpartytypID" runat="server" />
                <asp:HiddenField ID="hdnfieldpartyID" runat="server" />
                <asp:HiddenField ID="hfDistID" runat="server" />
                <asp:HiddenField ID="hfLType" runat="server" />
                <asp:HiddenField ID="hfLbNameID" runat="server" />
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Text="0" Visible="false"></asp:TextBox>
                   <%-- <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblPartyName" Text="Party Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlPartytype" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPartytype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorParty" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label3" Text="Party Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlPartyName"  CssClass="form-control" runat="server"></asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>  --%>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label3" Text="Party Type" ></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPartyType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlPartyType" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType_SelectedIndexChanged1">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="1">National Parties</asp:ListItem>
                            <asp:ListItem Value="2">State Parties in Maharashtra</asp:ListItem>
                             <asp:ListItem Value="3">State Parties in other States</asp:ListItem>
                           <asp:ListItem Value="4">other Parties</asp:ListItem>                  
                        </asp:DropDownList>--%>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label7" Text="Select Party"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtParty" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
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
                            <asp:Label runat="server" ID="Label5" Text="Select LocalBody Type"></asp:Label></td>
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
                            <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
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
                            <asp:Label runat="server" ID="Label6" Text="Election Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlElectionType" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="सार्वत्रिक निवडणूक" Value="1"></asp:ListItem>
                            <asp:ListItem Text="पोट निवडणूक" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorElectionType" runat="server" ControlToValidate="txtElectionType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>

                  <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblMoNO" Text="Ward No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtWardNo" runat="server" CssClass="form-control" MaxLength="5" onkeypress="return fncInputNumericValuesOnly(event);" PlaceHolder="Ward No"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="rfvtxtWardNo" runat="server" ControlToValidate="txtWardNo" ValidationGroup="sub" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>

                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblSeatNo" Text="Seat No."></asp:Label></td>

                        <td>
                            <asp:DropDownList ID="ddlSeatNo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSeatNo_SelectedIndexChanged">
                            <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="A" Value="1"></asp:ListItem>
                            <asp:ListItem Text="B" Value="2"></asp:ListItem>
                            <asp:ListItem Text="C" Value="3"></asp:ListItem>
                            <asp:ListItem Text="D" Value="4"></asp:ListItem>
                            <asp:ListItem Text="E" Value="5"></asp:ListItem>
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
                            <asp:Label runat="server" ID="lblCanName" Text="Select Candidate Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlCandList" CssClass="form-control" runat="server" ></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                       <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblElectionDate" Text="Election Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtElectionDate"  runat="server" CssClass="form-control" PlaceHolder="Election Date"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtElectionDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                        <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Verification Status"></asp:Label></td>
                        </td>
                    <td>
                        <asp:RadioButtonList  ID="rbtnVerificationSuccess"  runat="server" CssClass="radio">
                            <asp:ListItem Selected="True" Text="Verified" Value="1"></asp:ListItem>
                            <asp:ListItem  Text="Not Verified" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                        <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label2" Text="Nomination Withdraw"></asp:Label></td>
                        </td>
                    <td>
                        <asp:RadioButtonList  ID="rbtnWithdeowalYes"  runat="server" CssClass="radio">
                            <asp:ListItem  Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                         <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label4" Text="Election Result Status"></asp:Label></td>
                        </td>
                    <td>
                        <asp:RadioButtonList  ID="rbtnElectionWon"  runat="server" CssClass="radio">
                            <asp:ListItem Selected="True" Text="Won" Value="1"></asp:ListItem>
                            <asp:ListItem  Text="Loss" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
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
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClientClick="return validateRequired()" OnClick="btnSubmit_Click" />
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
                <asp:GridView ID="gvCandidateList" runat="server" AllowPaging="True" PageSize="10" CellPadding="4" DataKeyNames="Id" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvCandidateList_PageIndexChanging" CssClass="table table-hover table-bordered" Width="962px" OnRowCommand="gvCandidateList_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="PartyType" DataField="PartyType" />
                        <asp:BoundField HeaderText="PartyName" DataField="PartyName" />
                        <asp:BoundField HeaderText="DistrictName" DataField="DistrictName" />
                        <asp:BoundField HeaderText="LocalBodyTypeName" DataField="LocalBodyTypeName" />
                        <asp:BoundField HeaderText="LocalBodyName" DataField="LocalBodyName" />
                        <asp:BoundField HeaderText="ElectionType" DataField="ElectionType" />
                        <asp:BoundField HeaderText="ElectionDate" DataField="ElectionDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField HeaderText="CandidateName" DataField="CandidateName" />
                        <asp:BoundField HeaderText="WardNo" DataField="WardNo" />
                        <asp:BoundField HeaderText="SeatNo" DataField="SeatNo" />
                        <asp:BoundField HeaderText="Verified" DataField="Verified" />
                        <asp:BoundField HeaderText="NomiWithdraw" DataField="NomiWithdraw" />
                        <asp:BoundField HeaderText="ElectionResult" DataField="ElectionResult" />
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
            <asp:AsyncPostBackTrigger ControlID="gvCandidateList" />
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtElectionDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtElectionDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
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
                //                debugger;

                var et = document.getElementById("<%=ddlElectionType.ClientID%>").value;
                if (et == '--Select--' || et == '' || et == '0') {
                    alert('Please Select Election Type'); return false;
                }
               
                var sno = document.getElementById("<%=ddlSeatNo.ClientID%>").value;
                if (sno == '--Select--' || sno == '' || sno == '0') {
                    alert('Please Select Seat No'); return false;
                }
                var cnm = document.getElementById("<%=ddlCandList.ClientID%>").value;
                if (cnm == '--Select--' || cnm == '' || cnm == '0') {
                    alert('Please Select Candidate'); return false;
                }
                var wno = document.getElementById("<%=txtWardNo.ClientID%>").value;
                if (wno == '') {
                    alert('Please Enter Ward No'); return false;
                }
                var wno = document.getElementById("<%=txtElectionDate.ClientID%>").value;
                if (wno == '') {
                    alert('Please Enter Election Date'); return false;
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
