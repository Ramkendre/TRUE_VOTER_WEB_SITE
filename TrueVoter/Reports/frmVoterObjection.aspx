<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVoterObjection.aspx.cs" Inherits="TrueVoter.Reports.frmVoterObjection" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
        <div>
            <asp:Label ID="lblHeading" runat="server" Text="Voter Objection" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
     </div> 
     <div class="form-group">
        <div align="Center">
            <table style="width:809px; text-align:left">
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label6" Text="Select District"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label3" Text="Local Body"></asp:Label>
                        &nbsp;Type</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlLocalBody" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Municiple Corporation" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Municiple Council" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Nagar Panchayat" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Zilla Parishad" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Panchayat Samiti" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label7" Text="Select Local Body ID"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlLocalBodyId" runat="server" CssClass="form-control"></asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label8" Text="Complaint"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlComplaints" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Single Objection"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Multiple Objection"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label2" Text="Enter Mobile No"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">

                        <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" PlaceHolder="e.g.9422325020" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtMobileNo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label9" Text="Enter Your Name"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtName" runat="server" PlaceHolder="e.g.Your Name" CssClass="form-control"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label4" Text="Enter Your E-mail"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtemail" runat="server" PlaceHolder="e.g.a@gmail.com" CssClass="form-control"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style5">
                        <asp:Button ID="btnGetOtp" runat="server" Text="Get OTP" ValidationGroup="sub1" OnClick="btnGetOtp_Click" CssClass="btn btn-default" />&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label runat="server" ID="Label1" Text="Enter Your OTP"></asp:Label>
                    </td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtOtp" runat="server" MaxLength="4" PlaceHolder="e.g.1234" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="**" ControlToValidate="txtOtp" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style5">
                        <asp:Button ID="btnVerify" runat="server" Text="Verify And Next" OnClick="btnVerify_Click"  CssClass="btn btn-default" />&nbsp;&nbsp;
                    </td>
                </tr>
                 <tr style="height:10px">
                                <td></td>
                             </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style5">
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-default"/>&nbsp;&nbsp;
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-default"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>        
    </div>
            </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGetOtp" />
        </Triggers>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnVerify" />
        </Triggers>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style3 {
            width: 18px;
        }
        .auto-style4 {
            width: 132px;
        }
        .auto-style5 {
            width: 626px
        }
    </style>
</asp:Content>

