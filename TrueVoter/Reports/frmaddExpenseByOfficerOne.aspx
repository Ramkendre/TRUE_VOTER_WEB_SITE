﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmaddExpenseByOfficerOne.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmaddExpenseByOfficerOne" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Candidate Daily Expenses" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                      <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                   <%-- <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Select Local Body Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddllbtype" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddllbtype_SelectedIndexChanged">
                            <asp:ListItem  Value="0" Selected="True" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Deactive"></asp:ListItem>
                            <asp:ListItem  Value="2" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Deactive"></asp:ListItem>
                            <asp:ListItem  Value="4" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Deactive"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>--%>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblwrd" Text="Ward No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtWardNo" runat="server" CssClass="form-control" onkeypress="return numbersonly(this,event)" ></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtWardNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblSeatNo" Text="Seat No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlSeat" CssClass="form-control" runat="server">
                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                              <asp:ListItem Value="1">A</asp:ListItem>
                            <asp:ListItem Value="2">B</asp:ListItem>
                             <asp:ListItem Value="3">C</asp:ListItem>
                           <asp:ListItem Value="4">D</asp:ListItem>                  
                           <asp:ListItem Value="5">E</asp:ListItem>
                        </asp:DropDownList>
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
                            <asp:Button Text="Show Candidate List" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <div class="borderOuter-div-AddCandidte" style="overflow: auto">
            <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvcandidateList" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvcandidateList_PageIndexChanging">
                            <Columns>
                                <%--[CId],[usrFullName],[usrMobileNumber],[CandidateRoleName],[LocalBodyType],[LocalBodyName],[WardNo],[AssemblyID]--%>
                                <asp:BoundField HeaderText="CId" DataField="CId" Visible="false" />
                                <asp:BoundField HeaderText="Candidate Name" DataField="usrFullName" />
                                <asp:BoundField HeaderText="Candidate Role" DataField="CandidateRoleName" />
                                <asp:BoundField HeaderText="Local Body Name" DataField="LocalBodyName" />
                                <asp:BoundField HeaderText="WardNo" DataField="WardNo" />
                                <asp:TemplateField HeaderText="Add">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkShow" runat="server"
                                            CommandArgument='<%# Eval("usrMobileNumber")%>'
                                            OnClientClick="return confirm('You Want Add Selected Candidate Daily Expenses?')"
                                            Text="Add" OnClick="lnkShow_Click"></asp:LinkButton>
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
                        <asp:AsyncPostBackTrigger ControlID="gvcandidateList" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
