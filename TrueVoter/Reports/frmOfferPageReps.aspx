<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOfferPageReps.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmOfferPageReps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Offers" Font-Bold="true" Font-Size="Medium"></asp:Label>
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
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"   ></asp:DropDownList>
                    </td>
                        <td>
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
                        <asp:DropDownList ID="ddlPartyName"  CssClass="form-control" runat="server" ></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblOfferOn" Text="Offer On"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlOfferOn" CssClass="form-control" runat="server"  >
                            <asp:ListItem Selected="True" Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Representative Registration" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Voter Analysis" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Vision And Mission" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Manifesto" Value="4"></asp:ListItem>
                            <asp:ListItem Text="SMS FirstPayment" Value="5"></asp:ListItem>
                            <asp:ListItem Text="SMS Gatway Recharge" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblofferHead" Text="Offer Name"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtofferHead" runat="server" CssClass="form-control" MaxLength="100" PlaceHolder="Offer Name"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorFath"  runat="server" ControlToValidate="txtofferHead" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCode" Text="Offer Code"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control" PlaceHolder="Code"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorage"  runat="server" ControlToValidate="txtCode" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblOfferStart" Text="Offer Valid From Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtValidFrom" runat="server"   CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtValidFrom" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label2" Text="Offer Valid To Date"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtValidTo" runat="server"  CssClass="form-control" ></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="txtValidTo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default"  runat="server" OnClick="btnSubmit_Click" OnClientClick="return ValidateForm()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%-- <div class="borderOuter-div-Form1">
        <center>--%>
    <%--<div id="dvGrid" style="height: auto; width: 100%;" align="center">--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvOfferDetails" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvOfferDetails_PageIndexChanging">
                <Columns>
                    <%--[OfferID],[DistrictID],[District],[LocalBodyID],[LocalBodyName],[PartyID],[PartyName],[OfferNo],[OfferName],[OfferHeading],[OfferCode],[OfferStartDate],[OfferEndDate]--%>
                    <asp:BoundField HeaderText="OfferID" DataField="OfferID" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="District" DataField="District" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="LocalBody Name" DataField="LocalBodyName" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Party Name" DataField="PartyName" ItemStyle-Width="60px" />
                    <asp:BoundField HeaderText="Offer Name" DataField="OfferName" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Offer Heading" DataField="OfferHeading" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Offer Code" DataField="OfferCode" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Offer Start Date" DataField="OfferStartDate" ItemStyle-Width="70px" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="Offer End Date" DataField="OfferEndDate" ItemStyle-Width="70px" DataFormatString="{0:yyyy-MM-dd}" />
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
            <script>
                $(document).ready(function ()
                               {
                    $("#<%=txtValidFrom.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                    $("#<%=txtValidTo.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                               });

                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function ()
                    {
                    $("#<%=txtValidFrom.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                    $("#<%=txtValidTo.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                    });
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvOfferDetails" />
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    <%--</div>--%>
    <%-- </center>
    </div>--%>
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

            function ValidateForm() {
                debugger;
                var dist = document.getElementById('<%=ddlDistirct.ClientID%>').value;
                if (dist == "Select" || dist == "0") {
                    alert("Please Select District Name");
                    return false;
                }
                var localBody = document.getElementById('<%=ddlLocalBody.ClientID%>').value;
                if (localBody == "Select" || localBody == '' || localBody == "0") {
                    alert("Please Select LocalBody Name");
                    return false;
                }
                var partyType = document.getElementById('<%=ddlPartytype.ClientID%>').value;
                if (partyType == "Select" || partyType == '' || partyType == "0") {
                    alert("Please Select Party Type Name");
                    return false;
                }
                var partyName = document.getElementById('<%=ddlPartyName.ClientID%>').value;
                if (partyName == "Select" || partyName == '' || partyName == "0") {
                    alert("Please Select Party Name");
                    return false;
                }
                var offeron = document.getElementById('<%=ddlOfferOn.ClientID%>').value;
                if (offeron == "Select" || offeron == '' || offeron == "0") {
                    alert("Please Select Offer Name");
                    return false;
                }
                var offerhead = document.getElementById('<%=txtofferHead.ClientID%>').value;
            if (offerhead == '') {
                alert("Please Enter Offer Name");
                return false;
            }
            var code = document.getElementById('<%=txtCode.ClientID%>').value;
                if (code == '') {
                    alert("Please Enter Code No");
                    return false;
                }

                var validFrom = document.getElementById('<%=txtValidFrom.ClientID%>').value;
                if (validFrom == '') {
                    alert("Please Enter Valid from Date");
                    return false;
                }
                var validTo = document.getElementById('<%=txtValidTo.ClientID%>').value;
                if (validTo == '') {
                    alert("Please Enter Valid To Date");
                    return false;
                }
            }


        </script>
        <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
        <link href="../css/style.css" rel="stylesheet" />
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            $(function Date() {
                $("#txtValidFrom").datepicker();
                $("#txtValidTo").datepicker();
            });
        </script>
    </head>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>
