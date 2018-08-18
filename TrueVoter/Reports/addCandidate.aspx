<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCandidate.aspx.cs" Inherits="TrueVoter.Reports.addCandidate" MasterPageFile="~/MasterPages/UserSite.Master" %>
<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel101" runat="server">
        <ContentTemplate>
        <div class="borderOuter-div-Form">
            <div class="borderHeading-div">
                <div>
                <asp:Label ID="lblHeading" runat="server" Text="Add Candidate Name" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </div>
            </div>            
             <div class="form-group">   
        <div align="center">
            <table style="width: 100%">
                <tr>
                    <td style="text-align: left" class="auto-style1" >Select District:</td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" CssClass="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td></td>
                    </tr>
                <tr>
                    <td class="auto-style2" style="text-align: left">Select Local Body Type:</td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:DropDownList ID="ddlLocalBodyType" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Municipal Corporation</asp:ListItem>
                            <asp:ListItem Value="2">Municipal Council</asp:ListItem>
                            <asp:ListItem Value="3">Nagar Panchayat</asp:ListItem>
                            <asp:ListItem Value="4">Zilla Parishad</asp:ListItem>
                            <asp:ListItem Value="5">Panchayat Samiti</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td></td>
                    </tr>
                <tr>
                    <td class="auto-style2" style="text-align: left">Local Body Name:</td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:DropDownList ID="ddlLocalBodyName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td></td>
                    </tr>
                <tr>
                    <td class="auto-style2" style="text-align: left">Candidate Type</td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:DropDownList ID="ddlcandidateType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlcandidateType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">President</asp:ListItem>
                            <asp:ListItem Value="2">Ward-Member</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td></td>
                    </tr>
                <asp:Panel ID="pnlseattype" runat="server">
                    <tr>
                        <td style="text-align: left">
                            <asp:Label runat="server" ID="lblwardl" Text="Ward No"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtwardNo" runat="server" MaxLength="3" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 1" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr style="height:10px">
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label runat="server" ID="lblSeatNo" Text="Seat No"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtSeatNo" runat="server" MaxLength="1" PlaceHolder="e.g. 1" style="text-transform:capitalize;" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
                 <tr style="height:10px">
                        <td></td>
                    </tr>
                <tr>
                    <td class="auto-style2" style="text-align: right"></td>
                    <td style="text-align: left">
                        <br />
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-default"  ValidationGroup="sub" Text="Submit" OnClick="btnsubmit_Click" />&nbsp;&nbsp;

                    </td>
                </tr>
            </table>
        </div>
                 </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel102" runat="server">
        <ContentTemplate>
        <div align="center" class="borderOuter-div-AddCandidte">
            <div id="dvGrid" style="width: 100%" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Width="550px"
                            AutoGenerateColumns="False" Font-Names="Arial"
                            Font-Size="11pt" CssClass="table table-hover table-bordered"
                            AllowPaging="True" ShowFooter="True"
                            OnPageIndexChanging="OnPaging" OnRowEditing="EditCandidate"
                            OnRowUpdating="UpdateCandidate" OnRowCancelingEdit="CancelEdit" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server"
                                            Text='<%# Eval("ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                                        <asp:TextBox ID="txtID" Width="40px" 
                                            MaxLength="5" runat="server"></asp:TextBox>
                                    </FooterTemplate>--%>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>


                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Candidate Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandiName" runat="server"
                                            Text='<%# Eval("CandidateName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCandiName" runat="server"
                                            Text='<%# Eval("CandidateName")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtCandiName" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Party Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartyName" runat="server"
                                            Text='<%# Eval("PartyName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPartyName" runat="server"
                                            Text='<%# Eval("PartyName")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPartyName" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>


                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Allocated Symbol">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAllocatedSymbol" runat="server"
                                            Text='<%# Eval("AllocatedSymbol")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAllocatedSymbol" runat="server"
                                            Text='<%# Eval("AllocatedSymbol")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAllocatedSymbol" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Registration Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegistrationId" runat="server"
                                            Text='<%# Eval("RegistrationId")%>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <asp:TextBox ID="txtRegistrationId" runat="server"
                                            Text='<%# Eval("RegistrationId")%>'></asp:TextBox>
                                    </EditItemTemplate>--%>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtRegistrationId" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRemove" runat="server"
                                            CommandArgument='<%# Eval("ID")%>'
                                            OnClientClick="return confirm('This Name Now Will Not Be Shown in List?')"
                                            Text="ACTIVE" OnClick="DeleteCandidate"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Button ID="btnAdd" runat="server" Text="Add"
                                            OnClick="AddNewCandidate" />
                                    </FooterTemplate>
                                </asp:TemplateField>


                                <asp:CommandField ShowEditButton="True" />
                            </Columns>
                            <FooterStyle BackColor=" #33adff" ForeColor="#003399" />
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-family: Tahoma;
            font-size: small;
            width: 165px;
        }
        .auto-style2 {
            width: 165px;
        }
    </style>
</asp:Content>

