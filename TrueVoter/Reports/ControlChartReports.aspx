<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlChartReports.aspx.cs" Inherits="TrueVoter.Reports.ControlChartReports" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Control Chart Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>

                <script type="text/javascript">
                    var markers = [
                    <asp:Repeater ID="rptMarkers" runat="server">
                    <ItemTemplate>
                                {
                                    "ACNO": '<%# Eval("ACNO") %>',
                                "PartNo": '<%# Eval("PartNo") %>',
                                "lat": '<%# Eval("Latitude") %>',
                                "lng": '<%# Eval("Longitude") %>',
                                "SrNoFrom": '<%# Eval("SrNoFrom") %>',
                                "SrNoTo": '<%# Eval("SrNoTo") %>'
                            }
                            </ItemTemplate><SeparatorTemplate>,</SeparatorTemplate></asp:Repeater>
                ];
                </script>
                <div align="center" class="form-group">
                    <table style="width: 1049px; margin-left: 77px;" cellpadding="7" cellspacing="7">
                        <tr>
                            <td class="auto-style3">Search By
                            </td>
                            <td>:</td>
                            <td>
                                <asp:RadioButtonList ID="rbtnFirst" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical" AutoPostBack="true" OnSelectedIndexChanged="rbtnFirst_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">Mobile No</asp:ListItem>
                                    <asp:ListItem Value="1">AC/PART</asp:ListItem>
                                    <asp:ListItem Value="2">Date Wise</asp:ListItem>
                                    <asp:ListItem Value="3">ID Wise</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style3"></td>
                        </tr>
                        <asp:Panel ID="pnlMobileNo" runat="server">
                            <tr>
                                <td>Search By
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                                        <asp:ListItem Value="0" Selected="True">Officer No</asp:ListItem>
                                        <asp:ListItem Value="1">VoterList Staff</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>Mobile No
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtMobileNo2" runat="server" Width="500px" MaxLength="10" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtMobileNo2" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnldateWise" runat="server" Visible="false">
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>Enter Date
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" MaxLength="10" placeholder="yyyy-MM-dd" Width="500px" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtdate" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>AC No
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtacNoDate" runat="server" Width="500px" MaxLength="4" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtacNoDate" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlAcWiseDetails" runat="server" Visible="false">
                            <tr>
                                <td>AC No
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtAcNo" runat="server" Width="500px" MaxLength="4" PlaceHolder="e.g. 25" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtAcNo" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>Part No
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtPartNo" runat="server" Width="500px" MaxLength="4" PlaceHolder="e.g. 2" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="sub" ControlToValidate="txtPartNo" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>Search By
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:RadioButtonList ID="rbtnSearchBy" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                                        <asp:ListItem Value="0" Selected="True">Officer No</asp:ListItem>
                                        <asp:ListItem Value="1">VoterList Staff</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>Mobile No
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtUserNo" runat="server" MaxLength="10" Width="500px" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="sub" ControlToValidate="txtUserNo" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlIDWise" runat="server" Visible="false">
                            <tr>
                                <td>Enter ID
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtSRNOID" runat="server" Width="500px" MaxLength="10" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtSRNOID" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                        </asp:Panel>
                        <tr style="height: 10px">
                            <td class="auto-style3"></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnGetData" runat="server" ValidationGroup="sub" CssClass="btn btn-default" Text="Get Details" OnClick="btnGetData_Click" Width="116px" />&nbsp;&nbsp;
                            <asp:Button ID="btnExportToExcel" runat="server" Text="Export Approved Data" CssClass="btn btn-default" OnClick="btnExportToExcel_Click" Visible="false" OnClientClick="return confirm('Do you want to Download Your Valid Approved Data ? ');" Width="185px" />&nbsp;&nbsp;
                             <asp:Button ID="btnUnformatedData" runat="server" Text="Export Unformated Data" CssClass="btn btn-default" OnClick="btnUnformatedData_Click" OnClientClick="return confirm('Do you want to Download Unapproved Rought Data ? ');" Visible="false" Width="229px" />&nbsp;&nbsp;
                            <br />
                                <br />
                                <asp:Button ID="btnMap" runat="server" Text="Show on Map" OnClick="btnMap_Click" CssClass="btn btn-default" Width="140px" />&nbsp;&nbsp;
                            <asp:Button ID="btnShowlatlong" runat="server" Text="Display Map" OnClick="btnShowlatlong_Click" CssClass="btn btn-default" />&nbsp;&nbsp;
                            <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="btn btn-default" OnClick="btnBack_Click" />

                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style3"></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"></td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblCount" runat="server" Text="Total Active Record:"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblCountNo" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblCount1" runat="server" Text="Total Record Found:"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblCountNo1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style3"></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"></td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text="STATUS:- 1=Present || 2=Absent ||3=Shifted || 4=Dead || 5=Deleted "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGetData" />
            <asp:PostBackTrigger ControlID="btnShowlatlong" />
            <asp:PostBackTrigger ControlID="btnMap"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnExportToExcel"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnUnformatedData"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnMap"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnExportToExcel"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnUnformatedData"></asp:PostBackTrigger>
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnMap" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUnformatedData" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnShowlatlong" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="borderOuter-div-AddCandidte" style="overflow: auto">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewControlChart" runat="server">
                <div style="height: 100%; width: 100%; overflow: auto;" align="center;">
                    <asp:GridView ID="gvControlChart" runat="server" AllowPaging="True" CssClass="table table-hover table-bordered" PageSize="20" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="true" OnPageIndexChanging="gvControlChart_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="SrNo" />
                            <asp:BoundField HeaderText="ACNO" DataField="ACNO" />
                            <asp:BoundField HeaderText="PartNo" DataField="PartNo" />
                            <asp:BoundField HeaderText="FromSrNo" DataField="FromSrNo" />
                            <asp:BoundField HeaderText="ToSrNo" DataField="ToSrNo" />
                            <asp:BoundField HeaderText="WardNo" DataField="WardNo" />
                            <asp:BoundField HeaderText="VoterList Staff MobileNo" DataField="VoterListStaff" />
                            <asp:BoundField HeaderText="Officer MobileNo" DataField="Officer" />
                            <asp:BoundField HeaderText="Status" DataField="Status" />
                            <asp:BoundField HeaderText="Approved" DataField="IsActive" />
                        </Columns>

                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="viewMap" runat="server">
                <table>
                    <tr>
                        <td>
                            <div style="height: 100%; width: 750px; overflow: auto;" align="center">
                                <asp:GridView ID="gvMapData" runat="server" AllowPaging="True" CssClass="table table-hover table-bordered" PageSize="15" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvMapData_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Check">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="ACNO" DataField="ACNO" />
                                        <asp:BoundField HeaderText="PartNo" DataField="PartNo" />
                                        <asp:BoundField HeaderText="FromSrNo" DataField="FromSrNo" />
                                        <asp:BoundField HeaderText="ToSrNo" DataField="ToSrNo" />
                                        <asp:BoundField HeaderText="WardNo" DataField="WardNo" />
                                        <asp:BoundField HeaderText="VoterList Staff MobileNo" DataField="VoterListStaff" />
                                        <asp:BoundField HeaderText="Officer MobileNo" DataField="Officer" />
                                        <asp:BoundField HeaderText="Latitude" DataField="Latitude" />
                                        <asp:BoundField HeaderText="Longitude" DataField="Longitude" />
                                        <%--<asp:BoundField HeaderText="Status" DataField="Status" />--%>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>
                        </td>

                        <td>
                            <div id="dvMap1" style="width: 500px; height: 460px; align-content: center"></div>
                        </td>
                    </tr>
                </table>

            </asp:View>
        </asp:MultiView>


        <asp:Panel ID="pnlvisiblefalse" runat="server" Visible="false">
            <div>
                <asp:GridView ID="gvvisiblefalse" runat="server" AllowPaging="True" CssClass="table table-hover table-bordered" PageSize="20" OnPageIndexChanging="gvControlChart_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="SrNo" />
                        <asp:BoundField HeaderText="ACNO" DataField="ACNO" />
                        <asp:BoundField HeaderText="PartNo" DataField="PartNo" />
                        <asp:BoundField HeaderText="FromSrNo" DataField="FromSrNo" />
                        <asp:BoundField HeaderText="ToSrNo" DataField="ToSrNo" />
                        <asp:BoundField HeaderText="WardNo" DataField="WardNo" />
                        <asp:BoundField HeaderText="VoterList Staff MobileNo" DataField="VoterListStaff" />
                        <asp:BoundField HeaderText="Officer MobileNo" DataField="Officer" />
                        <asp:BoundField HeaderText="Status" DataField="Status" />
                        <asp:BoundField HeaderText="Approved" DataField="IsActive" />
                    </Columns>

                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtdate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });           
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtdate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 95px;
        }

        .auto-style3 {
            width: 71px;
        }
    </style>
</asp:Content>
