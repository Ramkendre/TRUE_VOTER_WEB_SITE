<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtraDetails.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.ExtraDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
            <asp:Label ID="lblHeading" runat="server" Text="Extra Basic Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
        <div class="form-group">
            <center>
            <table style="width:700px; margin-left: 8px;">
                <tr>
                    <td class="auto-style2">
                          <asp:Label runat="server" ID="lblCanName" Text="Candidate Name"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCandidateName" runat="server" CssClass="form-control"  PlaceHolder="Candidate Name"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ControlToValidate="txtCandidateName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblMoNO" Text="Mobile No"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoNo" runat="server" CssClass="form-control" MaxLength="12" PlaceHolder="Mobile No"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMoNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblNominationDate" Text="Nomination Date"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNominationDate" TextMode="Date" runat="server" CssClass="form-control" PlaceHolder="Nomination Date"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ControlToValidate="txtNominationDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblElectionDate" Text="Election Date"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtElectionDate" TextMode="Date" runat="server" CssClass="form-control" PlaceHolder="Election Date"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ControlToValidate="txtElectionDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblFatherName" Text="Father Name"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" PlaceHolder="Father Name"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFath" runat="server" ControlToValidate="txtFatherName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                 <tr>
                    <td class="auto-style2">
                          <asp:Label runat="server" ID="lblAge" Text="Age"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server" onkeypress="return numbersonly(this,event)" CssClass="form-control" PlaceHolder="Age"></asp:TextBox>
                    </td>
                      <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorage" runat="server" ControlToValidate="txtAge" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblPlace" Text="Place"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control" PlaceHolder="Place"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlace" runat="server" ControlToValidate="txtPlace" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblPartyName" Text="PartyName"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPartyName" runat="server" CssClass="form-control" PlaceHolder="Party Name"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorParty" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblSeatNo" Text="Seat No."></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSeatNo"  runat="server" CssClass="form-control" PlaceHolder="Seat No"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSeatNo" runat="server" ControlToValidate="txtSeatNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="lblElectionType" Text="Election Type"></asp:Label></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtElectionType" runat="server" CssClass="form-control" PlaceHolder="Election Type"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorElectionType" runat="server" ControlToValidate="txtElectionType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr style="height:10px">
                        <td class="auto-style2"></td>
                    </tr>
                <tr>
                    <td class="auto-style2">
                    </td>
                    <td style="text-align:left">
                        <asp:button text="Submit" ID="btnSubmit" CssClass="btn btn-default" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:button text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                    </td>
                </tr>
                </center>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 120px;
        }
    </style>
</asp:Content>
