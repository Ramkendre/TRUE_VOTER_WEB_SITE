<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtraDetails.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.ExtraDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Extra Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCanName" Text="Candidate Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtCandidateName" runat="server" CssClass="form-control" PlaceHolder="Candidate Name" ReadOnly="true"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ControlToValidate="txtCandidateName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblMoNO" Text="Mobile No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMoNo" runat="server" CssClass="form-control" MaxLength="12" PlaceHolder="Mobile No" ReadOnly="true"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMoNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblNominationDate" Text="Nomination Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtNominationDate" TextMode="Date" runat="server" CssClass="form-control" PlaceHolder="Nomination Date"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ValidationGroup="sub" ControlToValidate="txtNominationDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblElectionDate" Text="Election Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtElectionDate" TextMode="Date" runat="server" CssClass="form-control" PlaceHolder="Election Date"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtElectionDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblFatherName" Text="Father/Husband Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" PlaceHolder="Father Name"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFath" ValidationGroup="sub" runat="server" ControlToValidate="txtFatherName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblAge" Text="Age"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server" onkeypress="return numbersonly(this,event)" CssClass="form-control" PlaceHolder="Age"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorage" ValidationGroup="sub" runat="server" ControlToValidate="txtAge" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblPlace" Text="Place"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control" PlaceHolder="Place"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlace" ValidationGroup="sub" runat="server" ControlToValidate="txtPlace" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblPartyName" Text="Party Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlPartytype" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPartytype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorParty" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label3" Text="Party Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlPartyName"  CssClass="form-control" runat="server"></asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartyName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblSeatNo" Text="Seat No."></asp:Label></td>

                        <td>
                            <asp:DropDownList ID="ddlSeatNo" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="--" Value="6" ></asp:ListItem>
                            <asp:ListItem Text="A" Value="1"></asp:ListItem>
                            <asp:ListItem Text="B" Value="2"></asp:ListItem>
                            <asp:ListItem Text="C" Value="3"></asp:ListItem>
                            <asp:ListItem Text="D" Value="4"></asp:ListItem>
                            <asp:ListItem Text="E" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                            <%--<asp:TextBox ID="txtSeatNo" runat="server" CssClass="form-control" PlaceHolder="Seat No"></asp:TextBox>--%>
                        </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorSeatNo" ValidationGroup="sub" runat="server" ControlToValidate="txtSeatNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblElectionType" Text="Election Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlElectionType" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="सार्वत्रिक निवडणूक" Value="1"></asp:ListItem>
                            <asp:ListItem Text="पोट निवडणूक" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorElectionType" runat="server" ControlToValidate="txtElectionType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Result Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtResultDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtResultdate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                        <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label4" Text="Bank Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtResultdate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label2" Text="Bank Account No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtBankAccNo" runat="server" CssClass="form-control"  onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtResultdate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <%--<tr style="height: 10px">
                        <td class="auto-style2"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label runat="server" ID="Label2" Text="Order NO"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtResultdate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtNominationDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=txtElectionDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=txtResultDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            //$("#<%=txtNominationDate.ClientID %>").addEventListener("click", fucntionToExecuteName, false).datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtNominationDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=txtElectionDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=txtResultDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <head>
        <title></title>
        <script type="text/javascript">
            function numbersonly(evt) {
                //debugger;
                var charCode = (evt.fwhich) ? evt.which : event.keyCode;
                if (charCode != 46 && charCode > 31
                        && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }
        </script>
    </head>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>

