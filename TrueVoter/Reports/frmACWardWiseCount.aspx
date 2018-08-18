<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPages/UserSite.Master" CodeBehind="frmACWardWiseCount.aspx.cs" Inherits="TrueVoter.Reports.frmACWardWiseCount" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="AC No-Ward No Wise Control Chart Report" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCanName" Text="Enter AC No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtACNO" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="e.g:114" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ControlToValidate="txtACNO" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblWardNo" Text="Ward No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtWardNo" runat="server" CssClass="form-control" PlaceHolder="eg:12" MaxLength="4" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ValidationGroup="sub" ControlToValidate="txtWardNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button Text="Export Approved Data" ID="btnExportActive" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnExportActive_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button Text="Export Not Approved Data" ID="btnExportDeActive" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnExportDeActive_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
                        </td>
                    </tr>
                    <tr>
                            <td class="auto-style3"></td>
                            <td>
                                <asp:Label ID="lblCount" runat="server" Text="Total Active Record:"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblCountNo" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblCount1" runat="server" Text="Total DeActive Record Found:"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblCountNo1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="auto-style3"></td>
                        </tr>
                </table>
                    </center>
                </div>
            </div>
            <div class="borderOuter-div-AddCandidte">
                <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvBoothAdd" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" DataKeyNames="SrNo"
                                PageSize="30" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvBoothAdd_PageIndexChanging">
                                <Columns>
                                    <%--[SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[vstatus],[IsActive],[Voters],[BoothNo],[SectionNo]--%>
                                    <asp:BoundField HeaderText="SrNo" DataField="SrNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="ACNO" DataField="ACNO" ItemStyle-Width="90px" />
                                    <asp:BoundField HeaderText="PartNo" DataField="PartNo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="WardNo" DataField="WardNo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="SrNo From" DataField="SrNoFrom" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="SrNoTo" DataField="SrNoTo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="VoterList Staff MobileNo" DataField="FromUser" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Officer MobileNo" DataField="ToUser" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Status" DataField="vstatus" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="IsActive" DataField="IsActive" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="BoothNo" DataField="BoothNo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Voters" DataField="Voters" ItemStyle-Width="70px" />
                                    <%--<asp:BoundField HeaderText="SectionNo" DataField="SectionNo" ItemStyle-Width="70px" />--%>
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

                    </asp:UpdatePanel>
                </div>
            </div>
        <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
            <%--<asp:AsyncPostBackTrigger ControlID="gvBoothAdd" />
            <asp:AsyncPostBackTrigger ControlID="btnExportActive" />
            <asp:AsyncPostBackTrigger ControlID="btnExportDeActive" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>
