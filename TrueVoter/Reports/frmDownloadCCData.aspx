<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDownloadCCData.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmDownloadCCData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Voters Count Report" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label4" Text="Enter Officer Mobile No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtOfficerMoNo" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" AutoPostBack="false" CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit"  CssClass="btn btn-default" OnClientClick="return validateFun()" runat="server" OnClick="btnSubmit_Click" />
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
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Approved Voter Count" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                        <asp:GridView ID="gvCCDetails" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvCCDetails_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="BLO_MoNo" DataField="BLO_MoNo" />
                                <asp:BoundField HeaderText="Voter Count" DataField="ApprovedVoterCount" />
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
                        <br />
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="DisApproved Voter Count" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="BLO_MoNo" DataField="BLO_MoNo" />
                                <asp:BoundField HeaderText="Voter Count" DataField="DisApprovedVoterCount" />
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
                        <asp:AsyncPostBackTrigger ControlID="gvCCDetails" />
                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
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

            var symbol = document.getElementById('<%= txtOfficerMoNo.ClientID%>').value;
            if (symbol == '') {
                alert('Please Enter Officer Mobile No');

                return false;
            }
        }
    </script>
</asp:Content>
