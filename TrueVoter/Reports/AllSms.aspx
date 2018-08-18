<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllSms.aspx.cs" Inherits="TrueVoter.Reports.AllSms" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Message Sending" Visible="true" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div style="width: 100%; margin-top: -50px" align="center">
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
                                                                        Font-Size="11pt" Text="Select Visite Date and Time:"></asp:Label>
                                                                    <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                                </td>
                                                                <td style="width: 628px; text-align: center">
                                                                    <asp:TextBox ID="txtdatepicker" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                            <asp:Button ID="btnSmsSend" runat="server" Text="SendMsg" CssClass="btn" OnClick="btnSmsSend_Click" />
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

            <script src="../ScriptDate/jquery.js"></script>
            <link href="../ScriptDate/jquery.datetimepicker.min.css" rel="stylesheet" />
            <script src="../ScriptDate/jquery.datetimepicker.full.js"></script>
             <script>
                 $.datetimepicker.setLocale('en');

                 $('#<%= txtdatepicker.ClientID %>').datetimepicker(({
                     format: 'd/m/Y H:i',
                     lang: 'en',
                     formatTime: 'H:i',
                     dayOfWeekStart: 1,
                     startDate: '05/01/2015',
                     minDate: STdate(),
                     scrollMonth: false,
                     yearStart: logic(),

                     step: 5
                 }));

                 function logic() {
                     var today = new Date();
                     var dateObj = new Date();
                     var month = dateObj.getUTCMonth() + 1;
                     var day = dateObj.getUTCDate();
                     var year = dateObj.getUTCFullYear();
                     return year;
                 };

                 function STdate() {
                     var today = new Date();
                     var dateObj = new Date();
                     var month = dateObj.getUTCMonth() + 1;
                     var day = dateObj.getUTCDate();
                     var year = dateObj.getUTCFullYear();
                     var valdate = year + '/' + month + '/' + day;            //day + '/' + month + '/' + year;
                     return valdate;
                 };
    </script>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSmsSend" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
