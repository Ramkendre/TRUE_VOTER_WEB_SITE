<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCreateBooth.aspx.cs" Inherits="TrueVoter.Reports.frmCreateBooth" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Create Booth" Font-Bold="true" Font-Size="Medium"></asp:Label>
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
                            <asp:Label runat="server" ID="lblPart" Text="Enter Part No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPartNo" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="eg:12" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:Panel runat="server" ID="pnlbooth" Visible="false">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblBooth" Text="Enter Assign Booth No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtBoothNo"  runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="eg:12" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtBoothNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </asp:Panel>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                        </td>
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
                                PageSize="50" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                <Columns>
                                    <%--SrNo, ACNO, PartNo, SrNoFrom, SrNoTo, WardNo, FromUser, ToUser, roletype, CreateDate, CreatedBy, ModifiedDate, ModifiedBy, Latitude, Longitude, vstatus, IsActive, NewLat, NewLong, Voters, BoothNo, SplitFrom, UpdatedBy--%>
                                    <asp:BoundField HeaderText="SrNo" DataField="SrNo" />
                                    <asp:BoundField HeaderText="ACNO" DataField="ACNO" ItemStyle-Width="90px" />
                                    <asp:BoundField HeaderText="PartNo" DataField="PartNo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="SrNo From" DataField="SrNoFrom" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="SrNoTo" DataField="SrNoTo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="WardNo" DataField="WardNo" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="From User" DataField="FromUser" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="ToUser" DataField="ToUser" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="vstatus" DataField="vstatus" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="IsActive" DataField="IsActive" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Voters" DataField="Voters" ItemStyle-Width="70px" />
                                    <asp:BoundField HeaderText="BoothNo" DataField="BoothNo" ItemStyle-Width="70px" />
                                    <asp:TemplateField HeaderText="Choose Record">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="checkAll" runat="server" Text="Select All" AutoPostBack="true" onclick="checkAll(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this);" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Submit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSubmit" runat="server"
                                                CommandArgument='<%# Eval("SrNo")%>'
                                                OnClientClick="return confirm('Are You sure to Assign Booth To This Entrys?')"
                                                Text="Submit" OnClick="SubmitRecord"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvBoothAdd" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
