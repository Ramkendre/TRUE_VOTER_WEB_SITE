<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficerSms.aspx.cs" Inherits="TrueVoter.Admin.OfficerSms" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>

    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Dynamic Messaging Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div class="loading" align="center">
            Loading. Please wait.<br />
            <br />
            <%-- <img src="Loading-Bar-PSD.gif" alt="" />--%>
            <img src="../loader.gif" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                         <td class="auto-style1">
                            <asp:Label runat="server" ID="lbldistrict" Text="Select district Name"></asp:Label></td>
                        </td>
                    <td>
                         <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="ddlDistrict" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                             <asp:Label ID="lbllocalbodytype" runat="server" Text="Select LocalBody Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalbodyType" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlLocalbodyType_SelectedIndexChanged">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="5">Municipal Corporation</asp:ListItem>
                            <asp:ListItem Value="2">Zilla Parishad</asp:ListItem>
                            <asp:ListItem Value="3">Panchayat Samiti</asp:ListItem>
                            <asp:ListItem Value="4">Municipal Council</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocalbodyType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="lbllocalbodyname" runat="server" Text="Select LocalBody Name"></asp:Label>
                        </td>
                    <td>
                         <asp:DropDownList ID="ddlLocalbodyName" runat="server" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ValidationGroup="sub" ControlToValidate="ddlLocalbodyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                           <asp:Label ID="lblrpt" runat="server" Text="Select Form Type"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlreport" runat="server" AutoPostBack="true"  CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <%--<asp:ListItem Value="1">Demo</asp:ListItem>--%>
                            <asp:ListItem Value="2">Officer</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="ddlreport" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                           <asp:Label runat="server" ID="Label2" Text="Mobile No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMoNo" runat="server"  CssClass="form-control" Rows="5" TextMode="MultiLine" ReadOnly="false"  PlaceHolder=""></asp:TextBox>
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
                            <%--<asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <%--<asp:Button Text="Export_Excel" ID="btnExportExcel" CssClass="btn btn-default" runat="server" OnClick="btnExportExcel_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <asp:Button Text="SendMsg" ID="btnsendmsg" CssClass="btn btn-default" runat="server" OnClick="btnsendmsg_Click" />
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <%--<tr>
                        <td class="auto-style1">
                           <asp:Label runat="server" ID="lbltotalCount" Text="Total Count:" BorderStyle="Solid" ForeColor="SkyBlue" Font-Size="Large"></asp:Label> &nbsp;&nbsp;
                        <asp:Label ID="lblCount" runat="server" Visible="false" Font-Size="X-Large" ForeColor="OrangeRed"></asp:Label>
                        </td>
                    <td>
                    </td>
                        <td>
                            last sent massage Id:-  <asp:Label ID="lblLastsendmsgid" Text="" Visible="false" runat="server" Font-Size="X-Large" ForeColor="OrangeRed"></asp:Label>
                        </td>
                    </tr>--%>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
