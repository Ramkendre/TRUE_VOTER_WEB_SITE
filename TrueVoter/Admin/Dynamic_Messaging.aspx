﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dynamic_Messaging.aspx.cs" Inherits="TrueVoter.Admin.Dynamic_Messaging"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <title><%: Page.Title %>TrueVoters</title>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="borderOuter-div-Form">
            <div>
                <div class="borderHeading-div">
                    <asp:Label ID="lblHeading" runat="server" Text="Dynamic Messaging Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblmsgstatus" runat="server" Text="Message Send Successfully" ForeColor="Green" Font-Size="Medium" Visible="false"></asp:Label>
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
                        <asp:DropDownList ID="ddlLocalbodyType" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlLocalbodyType_SelectedIndexChanged">
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
                           <asp:Label ID="lblrpt" runat="server" Text="Select Form Type"></asp:Label>
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
                   <%-- <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>--%>
                    <%--<tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDateFrom" Text="Select From Date"></asp:Label></td>
                        </td>
                    <td>
                         <asp:TextBox ID="txtDateFrom" runat="server"  CssClass="form-control" TextMode="Date" PlaceHolder=""></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>--%>
                  <%--  <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                           <asp:Label runat="server" ID="lblDateTo" Text="Select To Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtDateTo" runat="server"  CssClass="form-control" TextMode="Date" PlaceHolder=""></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>--%>
                     <tr style="height: 10px"></tr>
                     <tr>
                        <td class="auto-style1">
                           <asp:Label runat="server" ID="Label1" Text="Enter ID"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtNomid" runat="server"  CssClass="form-control"  PlaceHolder=""></asp:TextBox>
                    </td>
                        <td>
                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorage" ValidationGroup="sub" runat="server" ControlToValidate="txtDateTo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>

                     <tr style="height: 10px"></tr>
                     <tr>
                        <td class="auto-style1">
                           <asp:Label runat="server" ID="Label2" Text="Enter Message"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMeassage" runat="server"  CssClass="form-control" TextMode="MultiLine"  PlaceHolder=""></asp:TextBox>
                    </td>
                        <td>
                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorage" ValidationGroup="sub" runat="server" ControlToValidate="txtDateTo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                        <%--<asp:Button Text="Export_Excel" ID="btnExportExcel" CssClass="btn btn-default" runat="server" OnClick="btnExportExcel_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <asp:Button Text="SendMsg" ID="btnsendmsg" CssClass="btn btn-default" runat="server" OnClick="btnsendmsg_Click" />
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
                        <td>
                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorage" ValidationGroup="sub" runat="server" ControlToValidate="txtDateTo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            last sent massage Id:-  <asp:Label ID="lblLastsendmsgid" Text="" Visible="false" runat="server" Font-Size="X-Large" ForeColor="OrangeRed"></asp:Label>
                        </td>
                    </tr>
                </table>
                    </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div>
            <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvSECData" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" DataKeyNames="NOMINATIONID" OnPageIndexChanging="gvSECData_PageIndexChanging"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <Columns>
                                <asp:BoundField DataField="FIRSTNAME" HeaderText="First Name">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MIDDLENAME" HeaderText="Middle Name">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="LASTNAME" HeaderText="Last Name">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CANDIDATEMOB" HeaderText="Mobile No">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMINATIONID" HeaderText="Nomination id">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DISTRICTNAME" HeaderText="District name">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FORMTTYPE" HeaderText="Formt type">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="WARDID" HeaderText="Ward id">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>

                                </asp:BoundField>
                                <asp:BoundField DataField="LOCALBODYNAME" HeaderText="Localbody name">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CREATEDDATE" HeaderText="Date">
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

                        </asp:GridView>
                    </ContentTemplate>
                    <%-- <Triggers>
                    <asp:PostBackTrigger ControlID="btnExportExcel" />
                </Triggers>--%>
                </asp:UpdatePanel>
            </div>
        </div>

        <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-1.4.1.min.js"></script>--%>

        <%-- <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>--%>
    </form>
</body>
</html>
