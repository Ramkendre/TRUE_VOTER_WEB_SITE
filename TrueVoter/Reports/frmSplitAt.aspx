<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSplitAt.aspx.cs" Inherits="TrueVoter.Reports.frmSplitAt" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Split Control Chart Entry" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <asp:Panel runat="server" ID="pnlallData" >
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCanName" Text="Enter AC No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtACNO" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="e.g:114" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="Requriedfield1" runat="server"  ValidationGroup="sub" ControlToValidate="txtACNO" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtPartNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblFromSrNo" Text="Enter From SrNo"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtFormSrNo" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="eg:12" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtFormSrNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblToSrNo" Text="Enter To SrNo"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtToSrNo" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="eg:12" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub" ControlToValidate="txtToSrNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:Button ID="btnback" runat="server" CssClass="btn btn-default" OnClick="btnback_Click" Text="Back" />
                        </td>
                        </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlbooth" runat="server" Visible="false">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblSplit" runat="server" Text="Enter SrNo Split"></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSplitNo" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return numbersonly(this,event)" PlaceHolder="eg:10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ControlToValidate="txtSplitNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="sub"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                             <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" OnClick="btnback_Click" Text="Back" />
                        </td>
                        </tr>
                        </asp:Panel>
                </table>
                    </center>
                </div>
            </div>
            <asp:Panel runat="server" ID="pnlFirstgv">
            <div class="borderOuter-div-AddCandidte">
                <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvBoothAdd" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="10pt" AllowPaging="True" ShowFooter="True" DataKeyNames="SrNo"
                                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="2" OnPageIndexChanging="gvBoothAdd_PageIndexChanging">
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
                                    <asp:TemplateField HeaderText="Split">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSubmit" runat="server"
                                                CommandArgument='<%# Eval("SrNo")%>'
                                                OnClientClick="return confirm('Are You sure to Split This Entry?')"
                                                Text="Split" OnClick="SubmitRecord"></asp:LinkButton>
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
                </asp:Panel>
            <asp:Panel runat="server" ID="pnlSecondgv">
            <div class="borderOuter-div-AddCandidte">
                <div id="Div1" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvShowData" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="10pt" AllowPaging="True" ShowFooter="True" DataKeyNames="SrNo"
                                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="2" OnPageIndexChanging="gvShowData_PageIndexChanging">
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
                                    <asp:BoundField HeaderText="SplitFrom" DataField="SplitFrom" ItemStyle-Width="70px" />
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
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

