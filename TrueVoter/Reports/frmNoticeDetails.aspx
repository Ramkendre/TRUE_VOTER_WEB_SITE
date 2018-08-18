<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNoticeDetails.aspx.cs" Inherits="TrueVoter.Reports.frmNoticeDetails" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:HiddenField ID="hfCanMob" runat="server" />
        <asp:HiddenField ID="hfDistId" runat="server" />
        <asp:HiddenField ID="hfLbId" runat="server" />
        <asp:HiddenField ID="hfWard" runat="server" />
        <asp:HiddenField ID="hfLbTyp" runat="server" />
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:FormView ID="FvNoticeAndDis" runat="server" CssClass="table table-hover table-bordered">
                        <ItemTemplate>
                            <table border="0" cellpadding="5" cellspacing="5">
                                <tr>
                                    <td style="color: brown">Candidate Name:
                                    </td>
                                    <td>
                                        <%# Eval("usrFullName") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Mobile No:
                                    </td>
                                    <td>
                                        <%# Eval("usrMobileNumber") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Candidate Role:
                                    </td>
                                    <td>
                                        <%# Eval("CandidateRoleName") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">PartyName:
                                    </td>
                                    <td>
                                        <%# Eval("PartyName") %>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="color: brown">Seat No:
                                    </td>
                                    <td>
                                        <%# Eval("SeatNo") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">WardNo:
                                    </td>
                                    <td>
                                        <%# Eval("WardNo") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Election Type:
                                    </td>
                                    <td>
                                        <%# Eval("ElectionType") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">LocalBody Name:
                                    </td>
                                    <td>
                                        <%# Eval("LocalBodyName") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Notice:
                                    </td>
                                    <td>
                                        <%# Eval("Notice") %>
                                        <td style="width: 45px"></td>
                                        <td style="color: brown">Status :
                                        </td>
                                        <td>
                                            <%# Eval("status") %>
                                        </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Notice Date:
                                    </td>
                                    <td>
                                        <%# Eval("Sms") %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <br />
                    <table border="0" cellpadding="5" cellspacing="5">
                        <tr>
                            <td style="color: chocolate; font-size: medium; font-weight: bold">Remark Details:
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="gvRemark" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                        PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvRemark_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Remarks" DataField="Remark" />
                            <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                            <asp:BoundField HeaderText="Full Name" DataField="Name" />
                            <asp:BoundField HeaderText="Date" DataField="CreatedDate" />
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
                    <br />

                    <div>
                        <asp:Button ID="btnstatus" runat="server" Autopostback="true" Text="Closed Status" Visible="true" OnClick="btnstatus_Click" />
                    </div>
                    <panel id="remarkInsert" runat="server" visible="false">
                    <div class="form-group">
                        <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblReamark" Text="Enter Remark"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
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
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" Text="Submit" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click" Text="Back" />
                        </td>
                </table>
                    </center>
                    </div>
                    </panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%--<div align="center">
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn" OnClick="btnback_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnsenNotice" runat="server" Text="Send Notice" CssClass="btn" OnClick="btnsenNotice_Click" />
        </div>--%>
    </div>
</asp:Content>


