<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAddLocalBody.aspx.cs"  MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmAddLocalBody" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Add Local Body" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                        
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server"  AutoPostBack="true" ></asp:DropDownList>
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
                            <asp:Label runat="server" ID="Label3" Text="Enter Local Body ID"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtLocalBodyId" runat="server" CssClass="form-control"  ></asp:TextBox>
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
                            <asp:Label runat="server" ID="iblPrty" Text="Enter Local Body Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtlocalbodynm" runat="server" CssClass="form-control"  ></asp:TextBox>
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
                            <asp:Label runat="server" ID="Label1" Text="Enter AC No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtACNo" runat="server" CssClass="form-control"  ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtPartyNm" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                   <%-- <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label2" Text="Enter No of Members"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtNoofMem" runat="server" CssClass="form-control"  ></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtPartyNm" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>--%>
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
                        <asp:GridView ID="gvLocalBodys" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvLocalBodys_PageIndexChanging">
                            <Columns>
                                <%-- [ElectionId],[ElectionName],[LocalBodyType],[DistrictCode],[DistrictName],[ACNo]--%>
                                <asp:BoundField HeaderText="ID" DataField="ElectionId" />
                                <asp:BoundField HeaderText="Election Name" DataField="ElectionName" />
                                <asp:BoundField HeaderText="DistrictName" DataField="DistrictName" />
                                <asp:BoundField HeaderText="AC No" DataField="ACNo" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" ID="btnEdit"  CommandArgument='<%# Eval("ElectionId") %>' CssClass="form-control" OnClick="btnEdit_Click" runat="server" />
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
                        <asp:AsyncPostBackTrigger ControlID="gvLocalBodys" />
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
            var regidt = document.getElementById("<%= txtLocalBodyId.ClientID%>").value;
            if (regidt == '') {
                alert('Please Enter Local Body ID');

                return false;
            }
            var ddparty = document.getElementById("<%= ddlDistirct.ClientID%>").value;
            if (ddparty == '0' || ddparty == "--Select--") {
                alert('Please Select District');

                return false;
            }
            var prtynm = document.getElementById("<%= ddlLocalBodytype.ClientID%>").value;
            if (prtynm == '') {
                alert('Please Select Local Body Type');

                return false;
            }
            var regidt = document.getElementById("<%= txtlocalbodynm.ClientID%>").value;
            if (regidt == '') {
                alert('Please Enter Local Body Name');

                return false;
            }
            
            var symbol = document.getElementById('<%= txtACNo.ClientID%>').value;
            if (symbol == '') {
                alert('Please Enter AC No');

                return false;
            }
          
        }
    </script>
</asp:Content>
