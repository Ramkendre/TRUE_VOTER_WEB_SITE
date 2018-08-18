<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLOReport_AcNoWise.aspx.cs" Inherits="TrueVoter.Reports.BLOReport_AcNoWise" MasterPageFile="~/MasterPages/UserSite.Master"%>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="BLO Report" Visible="true" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div style="width: 100%;" align="center">
                    <asp:Label ID="lbldisplay" runat="server"></asp:Label>
                    &nbsp;<table cellpadding="0" cellspacing="0" width="80%" border="1">
                        <tr>
                            <td align="center">
                                <div id="div" style="width: 100%; margin-right: 7px;">
                                    <table cellpadding="0" cellspacing="0" border="0" width="70%" class="tables">
                                        <div style="width: 96%">
                                            <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                                <tr>
                                                    <td style="height: 20px;">
                                                        <table style="width: 81%; class="tables" cellspacing="2" cellpadding="2">
                                                            <tr>
                                                            </tr>
                                                            <tr align="center">
                                                                <td colspan="3">
                                                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="width: 628px; text-align: Center;">
                                                                    <asp:Label ID="lblSelectTable" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                        Font-Size="11pt" Text="Enter Ac No:"></asp:Label>
                                                                    <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                                </td>
                                                                <td style="width: 628px; text-align: center">
                                                                   <asp:TextBox ID="txtAcNo" runat="server" Visible="true" CssClass="form-control"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 10px">
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                        <center>
                                                        <table>
                                                     <tr>
                                                         <td></td>
                                                         <td>
                                                            <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" CssClass="btn" OnClick="btnExportToExcel_Click" />
                                                         &nbsp;&nbsp;&nbsp;
                                                         </td>
                                                </tr>
                                                     </table>
                                                    </center>
                                                    </td>
                                                </tr>
                                            </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div align="center" class="borderOuter-div-Form" style="height: 100%; width: 850px; overflow: auto;">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover table-bordered" EmptyDataText="Not Found Record." CellPadding="3"
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" DataKeyNames="Id" GridLines="Vertical" Width="731px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <FooterStyle BackColor=" #33adff" ForeColor="Black" />
                    <HeaderStyle BackColor=" #33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor=" #33adff" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                    <Columns>
                        <asp:TemplateField HeaderText="Choose Record">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnApproved" runat="server" Visible="true" Text="Approve" CssClass="btn" OnClick="btnApproved_Click" />
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnDeapproved" runat="server" Visible="true" Text="DisApprove" CssClass="btn" OnClick="btnDeapproved_Click" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>
