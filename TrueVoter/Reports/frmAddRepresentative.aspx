<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAddRepresentative.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmAddRepresentative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Add Representative" Font-Bold="true" Font-Size="Medium"></asp:Label>
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
                            <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"   ></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblMobileNo" Text="Mobile No" ></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" MaxLength="10" AutoPostBack="true" onkeypress="return numbersonly(this,event)" PlaceHolder="Enter Mobile No." OnTextChanged="txtMobileNo_TextChanged"></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblReprName" Text="Enter Representative Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtRepresntativeNm" runat="server"  CssClass="form-control" PlaceHolder="Enter Name"></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblAddress" Text="Enter Address"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"  CssClass="form-control"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtValidFrom" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Is Active"></asp:Label></td>
                        </td>
                    <td>
                        <asp:RadioButtonList ID="rbtnisactive" runat="server" CssClass="radio" >
                            <asp:ListItem  Value="1" Selected="True" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="0" Text="Deactive"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtValidFrom" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" OnClientClick="return ValidateForm()"  runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%-- <div class="borderOuter-div-Form1">
        <center>--%>
    <%--<div id="dvGrid" style="height: auto; width: 100%;" align="center">--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvRepresentativeData" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvRepresentativeData_PageIndexChanging">
                <Columns>
                    <%--[ID],[DistrictID],[DistrictName],[LocalBodyID],[LocalBodyName],[MobileNo],[RepresentativeName],[Address]--%>
                    <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="District Name" DataField="DistrictName" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="LocalBody Name" DataField="LocalBodyName" ItemStyle-Width="60px" />
                    <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Representative Name" DataField="RepresentativeName" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="70px" />
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
            <asp:AsyncPostBackTrigger ControlID="gvRepresentativeData" />
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
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

        function ValidateForm() {
            // debugger;
            var dist = document.getElementById('<%=ddlDistirct.ClientID%>').value;
                if (dist == "Select" || dist == "0") {
                    alert("Please Select District Name");
                    return false;
                }
                var localBody = document.getElementById('<%=ddlLocalBody.ClientID%>').value;
                if (localBody == "Select" || localBody == '' || localBody == "0") {
                    alert("Please Select LocalBody Name");
                    return false;
                }
                var moNo = document.getElementById('<%=txtMobileNo.ClientID%>').value;
                if (moNo == '') {
                    alert("Please Enter Mobile No");
                    return false;
                }
                var rName = document.getElementById('<%=txtRepresntativeNm.ClientID%>').value;
                if (rName == '') {
                    alert("Please Enter Representative Name");
                    return false;
                }
                var addr = document.getElementById('<%=txtAddress.ClientID%>').value;
                if (addr == '') {
                    alert("Please Enter Address");
                    return false;
                }
            }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>
