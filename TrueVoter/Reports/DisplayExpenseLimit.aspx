<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayExpenseLimit.aspx.cs" Inherits="TrueVoter.Reports.DisplayExpenseLimit" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Expense Limit Details" Visible="true" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div style="width: 100%;margin-top:-50px" align="center">
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
                                                        <table style="width: 81%;" class="tables" cellspacing="2" cellpadding="2">
                                                            <tr>
                                                            </tr>
                                                            <tr align="center">
                                                                <td colspan="3">
                                                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="width: 628px; text-align: Center;">
                                                                    <asp:Label ID="lblElectionType" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                        Font-Size="11pt" Text="Select Election Type:"></asp:Label>
                                                                    <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                                </td>
                                                                <td style="width: 628px; text-align: center">
                                                                    <asp:DropDownList ID="ddlElectionType" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Municipal Corporation</asp:ListItem>
                                                                        <asp:ListItem Value="2">Zilla Parishad</asp:ListItem>
                                                                        <asp:ListItem Value="3">Panchayat Samiti</asp:ListItem>
                                                                        <asp:ListItem Value="4">Gram Panchayat</asp:ListItem>
                                                                        <asp:ListItem Value="5">Nagar Parishad</asp:ListItem>
                                                                        <asp:ListItem Value="6">Municipal Council</asp:ListItem>
                                                                    </asp:DropDownList>
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
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
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
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div align="center" class="borderOuter-div-Form" style="height: 100%; width: 850px; overflow: auto;">
                <asp:GridView ID="GvExpenseLimit" runat="server" AllowPaging="True" CssClass="table table-hover table-bordered" EmptyDataText="Not Found Record." CellPadding="3"
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"  GridLines="Vertical" Width="731px">
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
                    <%--<Columns>
                        <asp:BoundField DataField="ElectionTypeName" HeaderText="Election Type">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CityTypeName" HeaderText="Members">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MaxExpenseLimit" HeaderText="Expense Limit">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                    </Columns>--%>
                </asp:GridView>
            </div>
        </ContentTemplate>
       <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>

