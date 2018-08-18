<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAddPartyRepresentative.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmAddPartyRepresentative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Add Party Representative" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <asp:HiddenField Id="hdnfieldpartytypID" runat="server"/>
                    <asp:HiddenField Id="hdnfieldpartyID" runat="server"/>
                    <asp:HiddenField Id="hdnfieldDist" runat="server"/>
                    <asp:HiddenField Id="hdnFieldLocal" runat="server"/>
                        <asp:TextBox ID="txtpid" runat="server" Visible="false" CssClass="form-control"  ></asp:TextBox>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label3" Text="Enter Mobile Number"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPartyReMoNo" AutoPostBack="true" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control" OnTextChanged="txtPartyReMoNo_TextChanged" ></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>

                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDist" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct_SelectedIndexChanged"></asp:DropDownList>--%>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalBody" Text="Local Body Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtLbName" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                    </td>
                        <td>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr> 
                    
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Party Type" ></asp:Label></td>
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
                            <asp:Label runat="server" ID="Label5" Text="Select Party"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtParty" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlParty" CssClass="form-control" runat="server"  ></asp:DropDownList>--%>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label6" Text="Select Role"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlRole" CssClass="form-control" runat="server">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                             <asp:ListItem Value="1">Main Admin</asp:ListItem>
                             <asp:ListItem Value="2">Regional Head Representative</asp:ListItem>
                             <asp:ListItem Value="3">District Head</asp:ListItem>
                             <asp:ListItem Value="4">Block Head</asp:ListItem>                  
                             <asp:ListItem Value="5">Local Body Head</asp:ListItem>                  
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
                            <asp:Label runat="server" ID="iblPrty" Text="Enter Representative Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtRepresNm" runat="server" CssClass="form-control"  ></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label4" Text="Status"></asp:Label></td>
                        </td>
                    <td>
                        <asp:RadioButtonList ID="rbtnStatus" runat="server">
                            <asp:ListItem Selected="True" Text="Active" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Deactive" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ControlToValidate="txtConPerMoNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                       <asp:Button Text="Clear" ID="btnclear" CssClass="btn btn-default" runat="server" OnClick="btnclear_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
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
                        <asp:GridView ID="gvPartyRepresData" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvPartyRepresData_PageIndexChanging">
                            <Columns>
                                <%--[ID],[MobileNo],[Rep_Name],[PartyTypeId],[PartyId],[PartyName],[HeadAddress],[RegistrationDate],[Symbols],[RoleId],[RoleName],[DistrictId],[LocalBodyId],[IsActive]--%>
                                <asp:BoundField HeaderText="ID" DataField="ID" />
                                <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" />
                                <asp:BoundField HeaderText="Name" DataField="Rep_Name" />
                                <asp:BoundField HeaderText="PartyName" DataField="PartyName" />
                                <%--<asp:BoundField HeaderText="HeadAddress" DataField="HeadAddress" />--%>
                                <asp:BoundField HeaderText="RegistrationDate" DataField="RegistrationDate" />
                                <asp:BoundField HeaderText="Symbols" DataField="Symbols" />
                                <asp:BoundField HeaderText="RoleName" DataField="RoleName" />
                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                <asp:BoundField HeaderText="LocalBodyName" DataField="ElectionName" />
                                <asp:BoundField HeaderText="Status" DataField="IsActive" />
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkbtnisActive" Text="Active" CommandArgument='<%# Eval("ID") %>' OnClick="lnkbtnisActive_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DeActive">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkbtnDeActive" Text="DeActive" CommandArgument='<%# Eval("ID") %>' OnClick="lnkbtnDeActive_Click"></asp:LinkButton>
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
                        <asp:AsyncPostBackTrigger ControlID="gvPartyRepresData" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
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
        function validateFun() {
            //debugger;

            var role = document.getElementById("<%= ddlRole.ClientID%>").value;
            if (role == '0' || role == "--Select--") {
                alert('Please Select Role');

                return false;
            }
         

            var Pernm = document.getElementById('<%= txtRepresNm.ClientID%>').value;
            if (Pernm == '') {
                alert('Please Enter Contact Person Name');

                return false;
            }
            var perMoNo = document.getElementById('<%= txtPartyReMoNo.ClientID%>').value;
            if (perMoNo == '') {
                alert('Please Enter Contact Person Mobile No');

                return false;
            }
        }
    </script>
</asp:Content>
