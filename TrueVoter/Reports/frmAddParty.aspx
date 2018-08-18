<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAddParty.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmAddParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Add Party" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                        <asp:TextBox ID="txtpid" runat="server" Visible="false" CssClass="form-control"  ></asp:TextBox>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label4" Text="Enter Contact Person Mobile No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtConPerMoNo" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtConPerMoNo_TextChanged" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ControlToValidate="txtConPerMoNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Select Party Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlPartyType" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPartyType_SelectedIndexChanged" AutoPostBack="true">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="1">National Parties</asp:ListItem>
                            <asp:ListItem Value="2">State Parties in Maharashtra</asp:ListItem>
                             <asp:ListItem Value="3">State Parties in other States</asp:ListItem>
                           <asp:ListItem Value="4">other Parties</asp:ListItem>  
                            <asp:ListItem Value="5">Independent</asp:ListItem>                 
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
                            <asp:Label runat="server" ID="iblPrty" Text="Enter Party Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPartyNm" runat="server" CssClass="form-control"  ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtPartyNm" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblRda" Text="Select Registration Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtRegiDate" runat="server" CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtRegiDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblSym" Text="Enter Symbol Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtSymbolnm" runat="server" CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtSymbolnm" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label2" Text="Enter Party Head Office Address"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtAddress" Rows="5" TextMode="MultiLine" runat="server" CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label3" Text="Enter Contact Person Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtConperNm" runat="server" CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ControlToValidate="txtSymbolnm" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" OnClientClick="return validateFun()" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button Text="Download To Excel" ID="btnExcel" CssClass="btn btn-default" runat="server" OnClick="btnExcel_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button Text="Clear" ID="btnclear" CssClass="btn btn-default" runat="server" OnClick="btnclear_Click" />
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
                        <asp:GridView ID="gvParty" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvParty_PageIndexChanging">
                            <Columns>
                                <%-- [PID],[PartyName],[RegistrationDate],[Symbols]--%>
                                <asp:BoundField HeaderText="ID" DataField="PID" />
                                <asp:BoundField HeaderText="Party Name" DataField="PartyName" />
                                <asp:BoundField HeaderText="Registration Date" DataField="RegistrationDate" />
                                <%--<asp:BoundField HeaderText="Local Body Name" DataField="LocalBodyName" />--%>
                                <asp:BoundField HeaderText="Symbols" DataField="Symbols" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" ID="btnEdit"  CommandArgument='<%# Eval("PID") %>' CssClass="form-control" OnClick="btnEdit_Click" runat="server" />
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
                        <asp:AsyncPostBackTrigger ControlID="gvParty" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                        <asp:PostBackTrigger ControlID="btnExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div> 
    </div>
    <script type="text/javascript">
        function numbersonly(evt) {
            //debugger;
            var charCode = (evt.fwhich) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        $(document).ready(function () {
            $("#<%=txtRegiDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtRegiDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });

        function validateFun() {
            //debugger;
            //var perMoNo = document.getElementById('<%= txtConPerMoNo.ClientID%>').value;            if (perMoNo == '') {                alert('Please Enter Contact Person Mobile No');                return false;            }

            var ddparty = document.getElementById("<%= ddlPartyType.ClientID%>").value;
            if (ddparty == '0' || ddparty == "--Select--")
            {
                alert('Please Select Party Type');

                return false;
            }
            var prtynm = document.getElementById("<%= txtPartyNm.ClientID%>").value;
            if (prtynm == '')
            {
                alert('Please Enter Party Name');

                return false;
            }
            var regidt = document.getElementById("<%= txtRegiDate.ClientID%>").value;
            if (regidt == '') {
                alert('Please Select Registration Date');

                return false;
            }
            //var symbol = document.getElementById('<%= txtSymbolnm.ClientID%>').value;            if (symbol == '') {             alert('Please Enter Symbol Name');             return false;            }
            //var addr = document.getElementById('<%= txtAddress.ClientID%>').value;            if (addr == '') {                alert('Please Enter Head Office Address');                return false;            }
            //var Pernm = document.getElementById('<%= txtConperNm.ClientID%>').value;            if (Pernm == '') {                alert('Please Enter Contact Person Name');                return false;            }
           
        }
    </script>
</asp:Content>
