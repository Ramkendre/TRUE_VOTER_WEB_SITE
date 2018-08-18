<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUploadVoterAnalysisData.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmUploadVoterAnalysisData" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">

    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Upload Voter Analysis" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div align="center" class="form-group">
            <table style="width: 870px; text-align: left">

                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: left" class="auto-style1">Select File:</td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:FileUpload ID="FileId" runat="server" />
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: left" class="auto-style1">Download Sample:</td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:LinkButton ID="lnkbtnSampleDownload" runat="server" Text="Download Voter Analysis Sample Excel" OnClick="lnkbtnSampleDownload_Click"></asp:LinkButton>
                    <td class="auto-style3"></td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:Button ID="btnAdd" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnAdd_Click" OnClientClick="return confirm('Please Wait...It Will Take some Time? ');" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Reports/frmHomeUser.aspx" CssClass="btn btn-default" />
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:Label ID="lblLoading" runat="server" Text="Please Wait...." Visible="false"></asp:Label></td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right; color: red; font-size: x-large" class="auto-style1">Note:</td>
                    <td style="text-align: left" class="auto-style2">1].xls OR .xlsx File Extention File only

                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right; color: red" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">2]Do Not Change File Name Or Sheet Name
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form1" style="width: 100%; height: 100%; overflow: scroll">
                <asp:GridView ID="gvVoterDetails" runat="server" AllowPaging="True" PageSize="20" CssClass="table table-hover table-bordered" CellPadding="4" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvVoterDetails_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="ACNO" DataField="ACNO" />
                        <asp:BoundField HeaderText="IdCard No" DataField="IdCard" />
                        <asp:BoundField HeaderText=" Mobile No" DataField="VoterMobileNo" />
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
            <asp:PostBackTrigger ControlID="btnAdd" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 179px;
        }

        .auto-style2 {
            width: 570px;
        }

        .auto-style3 {
            width: 82px;
        }
    </style>
</asp:Content>
