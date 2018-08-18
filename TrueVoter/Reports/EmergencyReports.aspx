<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmergencyReports.aspx.cs" Inherits="TrueVoter.Reports.EmergencyReports" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="borderOuter-div-Form">
    <div class="borderHeading-div">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Add Candidate Name" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>        
    </div>
    <div align="center" class="form-group">
        <table style="width: 62%">
            <tr>
                <td style="text-align: left" class="auto-style1">Select District:</td>
                <td style="text-align: left" class="auto-style2">
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
             <tr style="height:10px">
                <td class="auto-style1"></td>
             </tr>
            <tr>
                <td class="auto-style1" style="text-align: left">Select Local Body Type:</td>
                <td style="text-align: left" class="auto-style2">
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
                <td class="auto-style1"></td>
             </tr>
            <tr>
                <td class="auto-style1" style="text-align: left">Local Body Name:</td>
                <td style="text-align: left" class="auto-style2">
                    <asp:DropDownList ID="ddlLocalBodyName" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr style="height:10px">
                <td class="auto-style1"></td>
             </tr>
            <tr>
                <td class="auto-style1" style="text-align: left">Emergency Service:</td>
                <td style="text-align: left" class="auto-style2">
                    <asp:DropDownList ID="ddlEmergencyService" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlEmergencyService_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="3"></asp:ListItem>
                        <asp:ListItem Value="4"></asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel  ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    <div class="borderOuter-div-Form">
    <%--<div style="color: white; background: #33adff; width: 96%; height: 35px;" align="center">
        <asp:Label ID="lblHeading" runat="server" Text="Emergency Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
    </div>
    <br />--%>
   
    <div>
        <center>
                 <asp:GridView runat="server" ID="gvEmergencyReports" AllowPaging="True" PageSize="25" CssClass="table table-hover table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvEmergencyReports_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </center>
    </div>
    <br />
    <div align="center" class="form-group">
        <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" OnClick="btnExcel_Click" CssClass="btn btn-default" />
    </div>
        </div>
            </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 211px
        }
        .auto-style2 {
            width: 457px;
        }
    </style>
</asp:Content>

