<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmExpHeadwiseReport.aspx.cs" Inherits="TrueVoter.Reports.frmExpHeadwiseReport" EnableEventValidation="false" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">

    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Expense Report" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <div align="Center">
                        <table style="width: 809px; text-align: left">
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
                                <td class="auto-style1">
                                    <asp:Label runat="server" ID="Label2" Text="Select Ward"></asp:Label></td>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlWard" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label runat="server" ID="Label3" Text="Select Report Type"></asp:Label></td>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlReporttype" CssClass="form-control" OnSelectedIndexChanged="ddlReporttype_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Text="App Installed Report" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="App Not Installed Report" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Daily Expense Date Wise" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Head Wise Expense Report" Value="4"></asp:ListItem>
                                        <%--<asp:ListItem Text="Daily Expense Date From-To" Value="5"></asp:ListItem>--%>
                                        <%--<asp:ListItem Text="Accepted Candidate Expenses" Value="5"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <asp:Panel runat="server" ID="pnlDate" Visible="false">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label runat="server" ID="Label4" Text="Select Expense Date" ></asp:Label></td>
                                    </td>
                                <td id="Date">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date" placeholder="yyyy-MM-dd"/>
                                </td>
                                    <td></td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style1"></td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlToDate" Visible="false">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label runat="server" ID="Label7" Text="Select Expense Upto Date"></asp:Label></td>
                                    </td>
                                <td id="DateTo">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date"  placeholder="yyyy-MM-dd"></asp:TextBox>
                                </td>
                                    <td></td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style1"></td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlExpHead" Visible="false">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label runat="server" ID="Label1" Text="Select Head"></asp:Label></td>
                                    </td>
                                <td>
                                    <asp:DropDownList ID="ddlHead" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Text="नामनिर्देशन प्रक्रिया खर्च" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="प्रचार दरम्यान भाडे खर्च" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="प्रचार कार्यालयीन खर्च" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="प्रचार साहित्यावरील खर्च" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="प्रचार माध्यमावरील खर्च" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="प्रचारातील खर्च" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="खानपान" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="इतर सर्व खर्च" Value="8"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                    <td></td>
                                </tr>
                                <tr style="height: 10px">
                                    <td class="auto-style1"></td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label runat="server" ID="Label6" Text="Total Record Found"></asp:Label></td>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblRecoredTotal"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>

                            <tr>
                                <td class="auto-style1"></td>
                                <td style="text-align: left">
                                    <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" OnClientClick="return ValiRequierd()" runat="server" OnClick="btnSubmit_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button Text="Download Excel" ID="btnExcelDownload" Visible="false" CssClass="btn btn-default" runat="server" OnClick="btnExcelDownload_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="btnExcelDownload" />
                <asp:AsyncPostBackTrigger ControlID="ddlReporttype" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="borderOuter-div-AddCandidte" style="overflow: auto">
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvExpByHead" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvExpByHead" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        function ValiRequierd() {
            var disId = document.getElementById("<%=ddlDistirct.ClientID%>").value;
            if (disId == '--Select--' || disId == '' || disId == '0') {
                alert('Please Select District Name'); return false;
            }

            var lbtyp = document.getElementById("<%=ddlLocalBodytype.ClientID%>").value;
            if (lbtyp == '--Select--' || lbtyp == '' || lbtyp == '0') {
                alert('Please Select Local Body Type'); return false;
            }

            var lb = document.getElementById("<%=ddlLocalBody.ClientID%>").value;
            if (lb == '--Select--' || lb == '' || lb == '0') {
                alert('Please Select Local Body Name'); return false;
            }

            var wrd = document.getElementById("<%=ddlWard.ClientID%>").value;
            if (wrd == '--Select--' || wrd == '' || wrd == '0') {
                alert('Please Select Ward'); return false;
            }

            var hd = document.getElementById("<%=ddlHead.ClientID%>").value;
            if (hd == '--Select--' || hd == '' || hd == '0') {
                alert('Please Select Head'); return false;
            }

            var rt = document.getElementById("<%=ddlReporttype.ClientID%>").value;
            if (rt == '--Select--' || rt == '' || rt == '0') {
                alert('Please Select Report Type'); return false;
            }
        }
    </script>

    
   <%--<script type="text/javascript">
       $(document).ready(function () {
           $("#<%=.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
       var prm = Sys.WebForms.PageRequestManager.getInstance();

       prm.add_endRequest(function () {
           $("#<%=.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
