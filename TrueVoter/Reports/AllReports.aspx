<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllReports.aspx.cs" Inherits="TrueVoter.Reports.AllReports" EnableEventValidation="false" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Report Page" Visible="true" Font-Bold="true" Font-Size="Medium"></asp:Label>
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
                                                        <table style="width: 81%; margin-left: 148px;" class="tables" cellspacing="2" cellpadding="2">
                                                            <tr>
                                                                <%--<td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                            <h3 style="color: Green; margin-left: 250px;">Report Page</h3>
                                                        </td>
                                                        <td></td>--%>
                                                            </tr>
                                                            <tr align="center">
                                                                <td colspan="3">
                                                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="width: 628px; text-align: Center;">
                                                                    <asp:Label ID="lblSelectTable" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                        Font-Size="11pt" Text="Select Table"></asp:Label>
                                                                    <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                                </td>
                                                                <td style="width: 628px; text-align: center">
                                                                    <asp:DropDownList ID="ddlMstTable" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlMstTable_SelectedIndexChanged" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 10px">
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 628px; text-align: Center;">
                                                                    <asp:Label ID="lblslctField" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                        Font-Size="11pt" Text="Select Field"></asp:Label>
                                                                    <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                                </td>
                                                                <td style="width: 628px; text-align: center;">
                                                                    <asp:Label ID="lblSlctoperator" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                        Font-Size="11pt" Text="Select Operator"></asp:Label>
                                                                    <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                                </td>
                                                                <td style="width: 628px; text-align: left;">&nbsp;
                                                               <asp:Label ID="lblSlctFielditem" runat="server" Font-Bold="true" Font-Names="Arial" Visible="true"
                                                                   Font-Size="11pt" Text="Select Field Item"></asp:Label>
                                                                    <asp:Label ID="lblSlctDate" runat="server" Font-Bold="true" Visible="false" Font-Names="Arial"
                                                                        Font-Size="11pt" Text="Select Date"></asp:Label>
                                                                </td>
                                                                <td style="width: 628px; text-align: left;">&nbsp;
                                                             
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 10px">
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 276px; text-align: Center;">
                                                                    <asp:DropDownList ID="ddlField" runat="server" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 200px; text-align: center;">
                                                                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">=</asp:ListItem>
                                                                        <asp:ListItem Value="2">!=</asp:ListItem>
                                                                        <asp:ListItem Value="3">></asp:ListItem>
                                                                        <asp:ListItem Value="4">>=</asp:ListItem>
                                                                        <asp:ListItem Value="5"><</asp:ListItem>
                                                                        <asp:ListItem Value="6">Search By Firstletter</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%; text-align: right;">
                                                                    <asp:DropDownList ID="ddlFieldItem" runat="server" Visible="false" AutoPostBack="true" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtSrchNumber" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                                                    <asp:TextBox ID="txtDate" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox><br />
                                                                    <asp:TextBox ID="txtSrchChar" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                                                    <%--  <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    PopupButtonID="imgFromDate" TargetControlID="txtSrchNumber">
                                                                </asp:CalendarExtender>--%>
                                                                    <%-- <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="24"
                                                                    src="../resources/images/calendarclick.gif" />--%>
                                                                </td>
                                                                <td align="left" style="width: 18%; text-align: Center;">
                                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" Width="70px" OnClick="btnAdd_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 10px">
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                                <td align="left" style="width: 37%; text-align: center">
                                                                    <asp:CheckBoxList runat="server" ID="ChkAddList" CssClass="form-control">
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr style="height: 10px">
                                                                <td></td>
                                                            </tr>
                                                            <div class="Space">
                                                            </div>
                                                            <tr>
                                                                <td style="width: 5%; text-align: center">
                                                                    <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">

                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 10px">
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <%-- <td style="width:5%; text-align:right">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">

                                                                </asp:Label>
                                                            </td>--%>
                                                                <td style="width: 15%; text-align: left">
                                                                    <asp:ListBox ID="lstbox1" runat="server" Width="200px" Height="170px" SelectionMode="Multiple"></asp:ListBox>
                                                                </td>
                                                                <td style="width: 10%; text-align: center">
                                                                    <asp:Button ID="btnRight" runat="server" Text=" >> " CssClass="btn" OnClick="btnRight_Click" /><br />
                                                                    <br />
                                                                    <asp:Button ID="btnleft" runat="server" Text=" << " CssClass="btn" OnClick="btnleft_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:ListBox ID="lstbox2" runat="server" Width="180px" Height="170px" SelectionMode="Multiple"></asp:ListBox>
                                                                </td>
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
                                                         <td>
                                                            <asp:Button ID="btdisplay" runat="server" Text="Display" CssClass="btn" OnClick="btdisplay_Click" />
                                                         &nbsp;&nbsp;&nbsp;
                                                         </td>
                                                         <%--<td>
                                                            <asp:Button ID="btnApproved" runat="server" Visible="true" Text="Approve" CssClass="btn" OnClick="btnApproved_Click" />
                                                         &nbsp;&nbsp;
                                                         </td>
                                                         <td>
                                                            <asp:Button ID="btnDeapproved" runat="server" Visible="true" Text="DisApprove" CssClass="btn" OnClick="btnDeapproved_Click" />
                                                         &nbsp;&nbsp;
                                                         </td>--%>
                                                         <td>
                                                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />
                                                        </td>
                                                </tr>
                                                     </table>
                                                    </center>
                                                        <div class="SpcBwnBtnAndGv" align="center">
                                                            <asp:Label ID="lbllableCount" runat="server" Text="Total Records :" Font-Bold="True"></asp:Label><asp:Label ID="lblCount" runat="server" Font-Bold="true" Font-Size="14pt"></asp:Label>
                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    <asp:Label ID="lblTotalUpdated" Visible="false" runat="server" Font-Bold="true" Font-Size="14pt" BorderColor="Red"></asp:Label>
                                                        </div>
                                                        <br />
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
            <asp:PostBackTrigger ControlID="btdisplay" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
    </asp:UpdatePanel>
    <%--<div>
                                                    <asp:GridView ID="GridView2" runat="server" Visible="false" ></asp:GridView>
                                                </div>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
           });
           var prm = Sys.WebForms.PageRequestManager.getInstance();

           prm.add_endRequest(function () {
               $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>
</asp:Content>
