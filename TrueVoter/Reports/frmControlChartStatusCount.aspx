<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmControlChartStatusCount.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmControlChartStatusCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Report for Status Count" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Select Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" MaxLength="10" TextMode="Date"  PlaceHolder="Date"></asp:TextBox> 
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
                            <asp:Label runat="server" ID="lblMoNO" Text="AC No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtACNo" runat="server" CssClass="form-control" MaxLength="3"  PlaceHolder="AC No" onkeypress="return fncInputNumericValuesOnly(event);"></asp:TextBox> <%----%>
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
                            <asp:Label runat="server" ID="lblpart" Text="Part No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPart" runat="server" CssClass="form-control" MaxLength="5" onkeypress="return fncInputNumericValuesOnly(event);" PlaceHolder="Part No"></asp:TextBox>
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
                            <asp:Label runat="server" ID="Label3" Text="Ward Officer Mobile No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtwardOffMoNo" runat="server" CssClass="form-control" MaxLength="10"  PlaceHolder="Mobile No" onkeypress="return fncInputNumericValuesOnly(event);"></asp:TextBox> <%--onkeypress="return fncInputNumericValuesOnly(event);"--%>
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
                            <asp:Label runat="server" ID="Label2" Text="BLO Officer Mobile No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMoNo" runat="server" CssClass="form-control" MaxLength="10"  PlaceHolder="Mobile No" onkeypress="return fncInputNumericValuesOnly(event);"></asp:TextBox> <%--onkeypress="return fncInputNumericValuesOnly(event);"--%>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="rfvtxtWardNo" runat="server" ControlToValidate="txtWardNo" ValidationGroup="sub" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <%--<asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClientClick="return validateRequired()" OnClick="btnSubmit_Click" />--%>
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server"  />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                            <td class="auto-style3"></td>
                            
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text="STATUS:- 1=Present || 2=Absent ||3=Shifted || 4=Dead || 5=Deleted "></asp:Label>
                            </td>
                        </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                            <td class="auto-style3"></td>
                            
                            <td>
                                <asp:Label ID="lblRecordcnt" runat="server"></asp:Label>
                            </td>
                        </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="upnlgv" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-AddCandidte">
                <asp:GridView ID="gvControlChartData" runat="server" AllowPaging="True" PageSize="10" CellPadding="4" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvControlChartData_PageIndexChanging" CssClass="table table-hover table-bordered" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="Ward Officer No" DataField="ToUser" />
                        <asp:BoundField HeaderText="Ward Officer Name" DataField="WardofficerName" />
                        <asp:BoundField HeaderText="BLO Officer No" DataField="FromUser" />
                        <asp:BoundField HeaderText="BLO Officer Name" DataField="BLOName" />
                        <asp:BoundField HeaderText="Status" DataField="vstatus" />
                        <asp:BoundField HeaderText="Ac No" DataField="ACNO" />
                        <asp:BoundField HeaderText="PartNo" DataField="PartNo" />
                        <asp:BoundField HeaderText="Ward No" DataField="WardNo" />
                        <asp:BoundField HeaderText="TOTAL" DataField="TOTAL" />
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
            <asp:AsyncPostBackTrigger ControlID="gvControlChartData" />
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

            function validateRequired()
            {
               // debugger;
                var pt = document.getElementById("<%=txtACNo.ClientID%>").value;
                if (pt == '' || pt == '0') {
                    alert('Please Enter Ac No');
                    return false;
                }

                
            }

            $(document).ready(function () {
                $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            });
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        </script>
    </head>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>
