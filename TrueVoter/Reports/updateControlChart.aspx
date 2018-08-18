<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="updateControlChart.aspx.cs" Inherits="TrueVoter.Reports.updateControlChart" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Update Control Chart" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div align="center" class="form-group">
                    <table style="width: auto; text-align: center">
                        <tr>
                            <td style="text-align: left">
                                <asp:Label runat="server" ID="lblSerchBy" Text="Search By:"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:RadioButtonList ID="rbtnSerchBy" runat="server" RepeatDirection="Vertical" Style="margin-left: 0px" AutoPostBack="true" OnSelectedIndexChanged="rbtnSerchBy_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="1">AC NO/PART NO</asp:ListItem>
                                    <asp:ListItem Value="2">Mobile No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>

                        <asp:Panel runat="server" ID="pnlACPART">
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>

                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblwardl" Text="AC NO"></asp:Label></td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtAcno" runat="server" MaxLength="4" Width="500px" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 1"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtAcNo" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblpartNo" Text="Part No"></asp:Label></td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtSeatNo" runat="server" MaxLength="4" Width="500px" CssClass="form-control" PlaceHolder="e.g. 1"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtSeatNo" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblOfficer" Text="You are Working as:"></asp:Label></td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="rbofficer" runat="server" RepeatDirection="Vertical" Style="margin-left: 0px">
                                        <asp:ListItem Selected="True" Value="1">TeamLead officer</asp:ListItem>
                                        <asp:ListItem Value="2">VoterList Staff</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblMobNo" Text="Your Mobile No:"></asp:Label></td>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblMobileNo"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlMobileNo" runat="server" Visible="false">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lbla" Text="You are Working as:"></asp:Label></td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="rbtnmobileno" runat="server" RepeatDirection="Vertical" Style="margin-left: 0px">
                                        <asp:ListItem Selected="True" Value="1">TeamLead officer</asp:ListItem>
                                        <asp:ListItem Value="2">VoterList Staff</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblMoNo" Text="Your Mobile No:"></asp:Label></td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Width="500px" CssClass="form-control" PlaceHolder="e.g. 9422325020" ReadOnly="true" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr style="height: 10px">
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style1" style="text-align: right"></td>
                            <td style="text-align: left">
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnsubmit" runat="server" ValidationGroup="sub" Text="Submit" OnClick="btnsubmit_Click" CssClass="btn btn-default" />&nbsp;&nbsp;
                        <asp:Button ID="btnduplicate" runat="server" ValidationGroup="sub" Text=" Find Duplicate" OnClick="btnduplicate_Click" CssClass="btn btn-default" />&nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                    <b>Total Approved Records : </b>
                    <asp:Label ID="lblActiveCount" runat="server"></asp:Label>
                </div>
                <div>
                    <b>Total Not Approved Records : </b>
                    <asp:Label ID="lblDectiveCount" runat="server"></asp:Label>
                </div>
                <div>
                    <b>Total Approved Voters : </b>
                    <asp:Label ID="lblAppVoterCount" runat="server"></asp:Label>
                </div>
                <div>
                    <b>Total Not Approved Voters : </b>
                    <asp:Label ID="lblNotAppVoterCount" runat="server"></asp:Label>
                </div>
                <br />
                <asp:Label ID="lblResult" Text="" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsubmit" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnduplicate" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel102" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-AddCandidte">
                <div id="dvGrid" style="height: auto; width: 100%; overflow-x: auto; overflow-y: auto;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" Height="550px" Width="550px" CssClass="table table-hover table-bordered"
                                AutoGenerateColumns="False" Font-Names="Arial"
                                Font-Size="11pt" 
                                AllowPaging="True" ShowFooter="True" DataKeyNames="SrNo" OnRowDataBound="GridView1_RowDataBound"
                                OnPageIndexChanging="OnPaging" OnRowEditing="EditCandidate"
                                OnRowUpdating="UpdateCandidate" OnRowCancelingEdit="CancelEdit" PageSize="50" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNo" runat="server" Width="50px"
                                                Text='<%# Eval("SrNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="AC NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblACNO" runat="server" Width="50px"
                                                Text='<%# Eval("ACNO")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtACNO" runat="server" Width="50px"
                                                Text='<%# Eval("ACNO")%>'></asp:TextBox>
                                        </EditItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPartNo" runat="server" Width="50px"
                                                Text='<%# Eval("PartNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPartNo" runat="server" Width="50px"
                                                Text='<%# Eval("PartNo")%>'></asp:TextBox>
                                        </EditItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="From SrNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNoFrom" runat="server" Width="50px"
                                                Text='<%# Eval("SrNoFrom")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To SrNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNoTo" runat="server" Width="50px"
                                                Text='<%# Eval("SrNoTo")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ward No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWardNo" runat="server" Width="50px"
                                                Text='<%# Eval("WardNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtWardNo" runat="server" Width="50px"
                                                Text='<%# Eval("WardNo")%>'></asp:TextBox>
                                        </EditItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Voter Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvstatus" runat="server" Width="50px"
                                                Text='<%# Eval("vstatus")%>'></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlstatus" runat="server">
                                                <%--<asp:ListItem Value="0" Text="--Select--"></asp:ListItem>--%>
                                                <asp:ListItem Value="1" Text="Present"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Absent"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Shifted"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Dead"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Deleted"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Double/Dubar"></asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>

                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Sect ion No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSectionNo" runat="server" Width="50px"
                                                Text='<%# Eval("SectionNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSectionNo" runat="server" Width="50px"
                                                Text='<%# Eval("SectionNo")%>'></asp:TextBox>
                                        </EditItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Voter List Staff Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromUser" runat="server" Width="100px"
                                                Text='<%# Eval("FromUser")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Officer Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToUser" runat="server" Width="100px"
                                                Text='<%# Eval("ToUser")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Latitude">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLatitude" runat="server" Width="100px"
                                                Text='<%# Eval("Latitude")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Longitude">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLongitude" runat="server" Width="100px"
                                                Text='<%# Eval("Longitude")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Create Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDate" runat="server" Width="100px"
                                                Text='<%# Eval("CreateDate")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="App rove">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemove" runat="server"
                                                CommandArgument='<%# Eval("SrNo")%>'
                                                OnClientClick="return confirm('Are You sure to active ?')"
                                                Text="Approve" OnClick="ActiveCandidate"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Dis Approve">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemoveDeactive" runat="server"
                                                CommandArgument='<%# Eval("SrNo")%>'
                                                OnClientClick="return confirm('Are You Sure to Deactive ?')"
                                                Text="DisApprove" OnClick="DeactiveCandidate"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Choose Record">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="checkAll" runat="server" Text="Select All" onclick="checkAll(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Is Appr oved">
                                        <ItemTemplate>
                                            <center>
                                        <asp:Label ID="lblActDeAct" runat="server" Text='<%# Eval("IsActive")%>' Font-Bold="true"></asp:Label></center>
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
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
