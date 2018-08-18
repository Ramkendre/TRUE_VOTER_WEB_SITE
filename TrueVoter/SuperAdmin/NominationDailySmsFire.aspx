<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NominationDailySmsFire.aspx.cs" Inherits="TrueVoter.SuperAdmin.NominationDailySmsFire" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <title><%: Page.Title %>TrueVoters</title>
    <link rel="stylesheet" href="../Content/new-css-transport.css" type="text/css" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/new-Jscript.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&libraries=places&sensor=false"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="borderOuter-div-Form">
            <div>
                <div class="borderHeading-div">
                    <asp:Label ID="lblHeading" runat="server" Text="SEC Report Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                         <td class="auto-style1">
                            <asp:Label runat="server" ID="lbldistrict" Text="Select district Name"></asp:Label></td>
                        </td>
                    <td>
                         <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="ddlDistrict" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                             <asp:Label ID="lbllocalbodytype" runat="server" Text="Select LocalBody Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalbodyType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalbodyType_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="5">Municipal Corporation</asp:ListItem>
                            <asp:ListItem Value="2">Zilla Parishad</asp:ListItem>
                            <asp:ListItem Value="3">Panchayat Samiti</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocalbodyType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="lbllocalbodyname" runat="server" Text="Select LocalBody Name"></asp:Label>
                        </td>
                    <td>
                         <asp:DropDownList ID="ddlLocalbodyName" runat="server" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ValidationGroup="sub" ControlToValidate="ddlLocalbodyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                           <asp:Label ID="lblrpt" runat="server" Text="Select Report Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlreport" runat="server" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="AL">All</asp:ListItem>
                            <asp:ListItem Value="P">Submitted</asp:ListItem>
                            <asp:ListItem Value="F">Final</asp:ListItem>
                              <asp:ListItem Value="WY">Withdrawal Status</asp:ListItem>
                            <asp:ListItem Value="R">Rejected</asp:ListItem>
                            <asp:ListItem Value="RO">Ro Check</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="ddlreport" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                           <asp:Label ID="Label1" runat="server" Text="Select Message Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlmsgStatus" runat="server"  CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">TrueVoter Install msg</asp:ListItem>
                            <asp:ListItem Value="2">Daily Expense msg</asp:ListItem>
                            <asp:ListItem Value="3">Print Out msg</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="ddlmsgStatus" ErrorMessage="Please Select At least one value" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDateFrom" Text="Enter message"></asp:Label></td>
                        </td>
                    <td>
                         <asp:TextBox ID="txtmsg" runat="server"  CssClass="form-control" PlaceHolder=""></asp:TextBox>
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
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button Text="SendSms" ID="btnSendSms" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSendSms_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click"/>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                           <asp:Label runat="server" ID="lbltotalCount" Text="Total Count:" BorderStyle="Solid" ForeColor="SkyBlue" Font-Size="Large"></asp:Label> &nbsp;&nbsp;
                        <asp:Label ID="lblCount" runat="server" Visible="false" Font-Size="X-Large" ForeColor="OrangeRed"></asp:Label>
                        </td>
                    <td>
                    </td>
                        <%--<td>
                            last sent massage Id:-  <asp:Label ID="lblLastsendmsgid" Text="" Visible="false" runat="server" Font-Size="X-Large" ForeColor="OrangeRed"></asp:Label>
                        </td>--%>
                    </tr>
                </table>
                    </center>
                    </div>

                    </div>

        <div>
            <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                <%--<asp:GridView ID="gvReport" runat="server" AllowPaging="True" CssClass="table table-hover table-bordered" EmptyDataText="Not Found Record." CellPadding="3"
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
                 </asp:GridView>--%>

                <%--<asp:GridView ID="EMPGRIDDATA" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"  OnPageIndexChanging="EMPGRIDDATA_PageIndexChanging"
                        PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="NOMINATIONID">
                        <Columns>
                             <asp:BoundField DataField="CANDIDATEMOB" HeaderText="Candidate Mob">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="FIRSTNAME" HeaderText="First Name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="LASTNAME" HeaderText="Last Name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                             <asp:BoundField DataField="LOCALBODYNAME" HeaderText="Localbody name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="NOMINATIONID" HeaderText="Nomination id">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
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
                    </asp:GridView>--%>

                <asp:GridView ID="EMPGRIDDATA" runat="server"  CssClass="table table-hover table-bordered" BackColor="White" BorderColor="#E7E7FF" OnPageIndexChanging="EMPGRIDDATA_PageIndexChanging"
                    BorderStyle="None" BorderWidth="1px" CellPadding="5" Font-Names="Calibri"  DataKeyNames="NOMINATIONID"  Font-Size="11pt"
                    GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
                <%--<Triggers>
                    <asp:PostBackTrigger ControlID="btnExportExcel" />
                </Triggers>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
