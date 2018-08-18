<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deviation.aspx.cs" Inherits="TrueVoter.Reports.Deviation" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form1">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Deviation" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>

                <%-- <script language="javascript" type="text/javascript">
                        function validate() {
                            debugger;
                            // $('#btnsendmsg').datepicker({
                            $('#<%= txtdatepicker.ClientID %>').datepicker({
                                dateFormat: 'dd-M-yy',
                                onClose: function () {
                                    var date = new Date($(this).val());
                                    if (date) {
                                        var formattedDate = (date.getMonth() + 1) + "/" +
                                                            date.getDate() + "/" +
                                                            date.getFullYear();
                                        $('#hiddenfield').val(formattedDate);
                                    }
                                }
                            });
                }
            </script>--%>

                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                             <asp:Label ID="Label1" runat="server" Text="Select District Name"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                             <asp:Label ID="Label2" runat="server" Text="Select Local Body Name"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddllocalbodyName" runat="server"  CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <%-- <tr>
                        <td class="auto-style1">
                             <asp:Label ID="Label3" runat="server" Text="Select Report Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlReportTy[e" runat="server"  CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Candidate</asp:ListItem>
                            <asp:ListItem Value="2">Deviation</asp:ListItem>
                            <asp:ListItem Value="3">Objection</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>--%>
                    <tr>
                         <td class="auto-style1">
                            <asp:Label runat="server" ID="lbldate" Text="Select Date"></asp:Label></td>
                        </td>
                    <td>
                         <asp:TextBox ID="txtDate" runat="server"  CssClass="form-control" TextMode="Date"  PlaceHolder=""></asp:TextBox>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                             <asp:Label ID="lblreporttype" runat="server" Text="Select Report Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlreporttype" runat="server"  CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="3">Deviation</asp:ListItem>
                            <asp:ListItem Value="1">Objection</asp:ListItem>
                            <asp:ListItem Value="2">Remark</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="lblwardno" runat="server" Text="Ward No"></asp:Label>
                        </td>
                    <td>
                         <asp:TextBox ID="txtWardNo" runat="server"  CssClass="form-control"  PlaceHolder=""></asp:TextBox>
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
                            <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                          <asp:HiddenField ID="hiddenfield" runat="server" />
                    </tr>
                </table>
                    </center>
                    <div style="width: 928Px; height: 100%; overflow: scroll">
                        <asp:GridView ID="GvDeviation" Visible="False" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="True"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="8pt" AllowPaging="True" ShowFooter="True" DataKeyNames="PK_Id" OnPageIndexChanging="GvDeviation_PageIndexChanging" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="2"
                            OnSelectedIndexChanged="GvDeviation_SelectedIndexChanged1" OnRowDataBound="GvDeviation_RowDataBound1">
                            <%--OnRowDeleting="GvDeviation_RowDeleting" OnRowDataBound="GvDeviation_RowDataBound"--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Assign">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkDeviation" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UsrName" HeaderText="Candidate Name">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ReffrenceMobile" HeaderText="Mobile No">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="StandardRate" HeaderText="Standard Rate">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Qty_Size_Area" HeaderText="Quantity">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Rate" HeaderText="Rate">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalExpense" HeaderText="Total Expenses">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CountNo" HeaderText="Objection Count">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Deviation" HeaderText="Deviation" DataFormatString="{0:n2}">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PK_Id" HeaderText="Id">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ExtaExpId" HeaderText="Accepted Entry">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ObjectionMsg" HeaderText="Objection SendMsg Date">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ObjectionOnVisitedDate" HeaderText="Objection VisitedDate">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DeviationMsg" HeaderText="Deviation SendMsg Date">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DeviationOnVisitedDate" HeaderText="Deviation VisitedDate">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="RemarkMsg" HeaderText="Remark SendMsg Date">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="RemarkOnVisitedDate" HeaderText="Remark VisitedDate">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:TemplateField HeaderText="Objection">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkObjection" Text="Show" OnCommand="lnkObjection_Command" CommandArgument='<%#Eval ("PK_Id")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:CommandField ShowSelectButton="True" HeaderText="Deviation" SelectText="Display" />

                                <asp:TemplateField HeaderText="Extra Entry">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkAddDiffer" Text="Add Difference" OnCommand="lnkAddDiffer_Command" CommandArgument='<%#Eval ("PK_Id")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:CommandField DeleteText="Objection" HeaderText="show" ShowDeleteButton="True" />--%>
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
                    </div>
                </div>
              <%--  <div style="margin-left:100px">
                 <asp:Label ID="lbldatepicker" runat="server" Visible="false" Text="Select Visit Date:"></asp:Label>   <asp:TextBox ID="txtdatepicker" runat="server" Visible="false" TextMode="DateTime"></asp:TextBox>
                </div>--%>
                <div style="text-align: center">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button Text="Accepted" ID="btnaccepted" Visible="false" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnaccepted_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button Text="Message" ID="btnsendmsg" Visible="false" CssClass="btn btn-default" ValidationGroup="sub" OnClientClick="return validate()" runat="server" OnClick="btnsendmsg_Click" />
                </div>
                <asp:GridView ID="GvObjection" Visible="false" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                    AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" DataKeyNames="serverID" OnPageIndexChanging="GvObjection_PageIndexChanging"
                    PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                    OnSelectedIndexChanged="GvObjection_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="userName" HeaderText="User Name">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="objID" HeaderText="Objection ID">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="wardNo" HeaderText="Ward No">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="objectionDetails" HeaderText="Objection Details">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="userMobileNo" HeaderText="User MobileNo">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="serverID" HeaderText="Id">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                        </asp:BoundField>
                        <%--<asp:TemplateField HeaderText="Show">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Button ID="btnShow" Text="Select" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateField>--%>
                        <asp:CommandField ShowSelectButton="True" />
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

           <%--     <script src="../ScriptDate/jquery.js"></script>
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
                    var valdate = day + '/' + month + '/' + year;
                    return valdate;
                };
            </script>--%>

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="GvDeviation" />
                <asp:PostBackTrigger ControlID="GvObjection"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="GvObjection"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="GvObjection"></asp:PostBackTrigger>
            </Triggers>
            <Triggers>
                <asp:PostBackTrigger ControlID="GvObjection" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

   

    <%--<script langague="" type="text/javascript">
        $('#btnsendmsg').datepicker({
            dateFormat: 'dd-M-yy',
            onClose: function () {
                var date = new Date($(this).val());
                if (date) {
                    var formattedDate = (date.getMonth() + 1) + "/" +
                                        date.getDate() + "/" +
                                        date.getFullYear();
                    $('#hiddenfield').val(formattedDate);
                }
            }
        });
        </script>--%>

     
</asp:Content>
