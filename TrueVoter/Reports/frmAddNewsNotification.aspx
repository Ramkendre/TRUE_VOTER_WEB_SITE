<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAddNewsNotification.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmAddNewsNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Add News" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Text="0" Visible="false"></asp:TextBox>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Select News For"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlNewsFor" CssClass="form-control" runat="server" >
                              <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Officers" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Candidates" Value="3"></asp:ListItem>
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
                            <asp:Label runat="server" ID="Label2" Text="Select LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:RadioButtonList ID="rbtnlocalBodywise" runat="server" AutoPostBack="true" CssClass="dl-horizontal" OnSelectedIndexChanged="rbtnlocalBodywise_SelectedIndexChanged">
                            <asp:ListItem Text="All" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Single" Value="2" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <asp:Panel runat="server" ID="pnlDislocal" Visible="false">
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
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </asp:Panel>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="iblNewsHead" Text="Heading"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtHeading"  runat="server" MaxLength="150" CssClass="form-control" PlaceHolder="Heading" required="*"></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                   
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                  <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" MaxLength="3000" Rows="5" required="*" TextMode="MultiLine" PlaceHolder="Description"></asp:TextBox>
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
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" OnClientClick=" return validateRequired()" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" formnovalidate="true" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" formnovalidate="true"/>
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-AddCandidte">
                <asp:GridView ID="gvNews" runat="server" AllowPaging="True" PageSize="10" CellPadding="4" DataKeyNames="Id" ShowHeaderWhenEmpty="true" OnPageIndexChanging="gvNews_PageIndexChanging"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CssClass="table table-hover table-bordered" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="News Scope" DataField="NewsScopeName" />
                        <asp:BoundField HeaderText="District" DataField="DistrictName" />
                        <asp:BoundField HeaderText="LocalBody Name" DataField="ElectionName" />
                        <asp:BoundField HeaderText="Title" DataField="Header" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
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
            <asp:AsyncPostBackTrigger ControlID="gvNews"/>
            <asp:PostBackTrigger ControlID="btnSubmit"/>
        </Triggers>
    </asp:UpdatePanel>
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
                var scp = document.getElementById("<%=ddlNewsFor.ClientID%>").value;
                if (scp == '--Select--' || scp == '0' || scp == '') {
                    alert('Please Select News To');
                    return false;
                }

                var dt = document.getElementById("<%=ddlDistirct.ClientID%>").value;
                if (dt == '--Select--' || dt == '' || dt == '0') {
                    alert('Please Select District'); return false;
                }
                if (cnm == '--Select--' || cnm == '' || cnm == '0') {
                    alert('Please Select Sub Expense Head'); return false;
                }
                var wno = document.getElementById("<%=txtDescription.ClientID%>").value;
                if (wno == '') {
                    alert('Please Enter Expense Description'); return false;
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
