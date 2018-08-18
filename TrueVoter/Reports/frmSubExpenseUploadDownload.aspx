<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSubExpenseUploadDownload.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmSubExpenseUploadDownload" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">

    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Upload/Download SubExpense" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div align="center" class="form-group">
            <table style="width: 870px; text-align: left">
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label runat="server" ID="Label5" Text="Select LocalBody Type"></asp:Label></td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBodytype" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Municiple Corporation" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Municiple Council" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Nagar Panchayat" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Zilla Parishad" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Panchayat Samiti" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
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
                    <td></td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:Button ID="btnDownloadSubExpen" runat="server" Text="Download" CssClass="btn btn-default" OnClientClick="return validateRequired()" OnClick="btnDownloadSubExpen_Click" />
                    </td>
                </tr>
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
                        <asp:LinkButton ID="lnkbtnSampleDownload" runat="server" Text="Download Sub Expense Sample Excel" OnClick="lnkbtnSampleDownload_Click"></asp:LinkButton>
                    <td class="auto-style3"></td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:Button ID="btnAdd" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnAdd_Click" OnClientClick="return validateRequired()" />
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
                <asp:GridView ID="gvSubExpense" runat="server" AllowPaging="True" PageSize="20" CssClass="table table-hover table-bordered" CellPadding="4" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvSubExpense_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="SEID" DataField="SEID" />
                        <asp:BoundField HeaderText="Sub Expense Type" DataField="SubExpenseType" />
                        <asp:BoundField HeaderText="EID" DataField="EID" />
                        <asp:BoundField HeaderText="DistId" DataField="DistId" />
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
            <asp:PostBackTrigger ControlID="btnDownloadSubExpen" />
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
    <script type="text/javascript">
        function validateRequired() {

            var dt = document.getElementById("<%=ddlDistirct.ClientID%>").value;
                    if (dt == '--Select--' || dt == '' || dt == '0') {
                        alert('Please Select District'); return false;
                    }

                    
                     alert('Please Wait...It Will Take some Time?');
                }
    </script>
</asp:Content>
