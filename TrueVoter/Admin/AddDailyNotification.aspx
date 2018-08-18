<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDailyNotification.aspx.cs" Inherits="TrueVoter.Admin.AddDailyNotification" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Add Daily Notification" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDate" Text="Select Date"></asp:Label></td>
                                <td>:</td>
                                <td class="auto-style4" id="Date">
                                    <asp:TextBox ID="txtDate" TextMode="Date" Width="300px" Height="34px"  runat="server" ValidationGroup="sub"  placeholder="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="Enter ten digit Number" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                                    <td class="auto-style12">
                                        <asp:Label runat="server" ID="Label2" Text="Select Role"></asp:Label>
                                    </td>
                                    <td class="auto-style5">:</td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="ddlRole" runat="server"  Width="500px" AutoPostBack="true" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Voter"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Officer"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Candidate"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Representative"></asp:ListItem>

                                        </asp:DropDownList>
                                    </td>
                                </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNotification" Text="Notification"></asp:Label></td>
                                <td>:</td>
                                <td class="auto-style4" id="Td1">
                                    <asp:TextBox ID="txtNotification"  Width="300px" Height="34px"  runat="server" ValidationGroup="sub"  TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="Enter ten digit Number" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                                    <td class="auto-style12"></td>
                                    <td class="auto-style5"></td>
                                    <td class="auto-style4">
                                        <asp:Button ID="btnSubmit1" runat="server" ValidationGroup="sub" Text="Submit" OnClick="btnSubmit1_Click" CssClass="btn btn-default" />&nbsp;&nbsp; <%--OnClientClick="return Validate()"--%>
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-default" />&nbsp;&nbsp;
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </table>
                        <div>
                            <asp:GridView ID="gvTodaysNotification" runat="server" ShowHeaderWhenEmpty="True"  ShowFooter="True" AllowPaging="True" PageSize="10" CssClass="table table-hover table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvTodaysNotification_PageIndexChanging">
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
                        </div>
                </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 314px;
        }

        .auto-style2 {
            width: 270px;
        }
    </style>
</asp:Content>
