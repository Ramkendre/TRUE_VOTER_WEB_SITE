<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDownloadSRate.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" EnableEventValidation="false" Inherits="TrueVoter.Reports.frmDownloadSRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Download Standard Rates" Font-Bold="true" Font-Size="Medium"></asp:Label>
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
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server" ></asp:DropDownList>
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
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" runat="server" OnClientClick="return validateControl()" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Excel Download" ID="btnExcelDown" CssClass="btn btn-default" runat="server" OnClientClick="return validateControl()" OnClick="btnExcelDown_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="btnExcelDown" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="borderOuter-div-AddCandidte">
        <asp:GridView ID="gvStandardRates" runat="server" AllowPaging="True" PageSize="30" CellPadding="4" DataKeyNames="Id" ShowHeaderWhenEmpty="true"
            EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvStandardRates_PageIndexChanging" CssClass="table table-hover table-bordered" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Expense Type Id" DataField="ExpenseType" />
                <asp:BoundField HeaderText="Expense Head" DataField="ExpenseHead" />
                <asp:BoundField HeaderText="Sub Expense Type Id" DataField="SubExpenseType" />
                <asp:BoundField HeaderText="Sub Expense Head" DataField="SubExpenseHead" />
                <asp:BoundField HeaderText="Election Name" DataField="ElectionName" />
                <asp:BoundField HeaderText="Election Id" DataField="LocalBodyId" />
                <asp:BoundField HeaderText="Standard Rate" DataField="StandardRate" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:BoundField HeaderText="InsertBy" DataField="InsertBy" />
            </Columns>

            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function validateControl() {
            var ddlDist = document.getElementById("<%= ddlDistirct.ClientID%>").value;
            if (ddlDist == '0' || ddlDist == "--Select--") {
                alert('Please Select District');

                return false;
            }
            var ddlLb = document.getElementById("<%= ddlLocalBody.ClientID%>").value;
            if (ddlLb == '0' || ddlLb == "--Select--") {
                alert('Please Select Local Body Name');

                return false;
            }
        }
    </script>
</asp:Content>
