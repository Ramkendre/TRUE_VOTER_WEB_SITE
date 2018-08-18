<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPollingDayActivity1.aspx.cs" Inherits="TrueVoter.Reports.frmPollingDayActivity1" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language="Javascript" type="text/javascript">
        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                    return false;
                }
                return true;
            }
            catch (err) {

                alert(err.Description);
            }
        }
    </script>
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Polling Day Activity" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
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
                         <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="form-control">
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
                        <asp:DropDownList ID="ddlLocalbodyType" runat="server" AutoPostBack="true"  CssClass="form-control">
                            <asp:ListItem value="0">--Select--</asp:ListItem>
		                    <asp:ListItem value="1">Municiple Corporation</asp:ListItem>
		                    <asp:ListItem value="2">Municiple Council</asp:ListItem>
		                    <asp:ListItem value="3">Nagar Panchayat</asp:ListItem>
		                    <asp:ListItem value="4">Zilla Parishad</asp:ListItem>
		                    <asp:ListItem value="5">Panchayat Samiti</asp:ListItem>                            </asp:DropDownList>
                    </td>
                        <td>
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
                           <asp:Label ID="lblwardNo" runat="server" Text="Ward/ZP Div/PS Coll Number"></asp:Label>
                        </td>
                    <td>
                       <asp:TextBox ID="txtwardNo" runat="server" CssClass="form-control" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="txtwardNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblboothNo" Text="Enter Booth Number"></asp:Label></td>
                        </td>
                    <td>
                         <asp:TextBox ID="txtboothNo" runat="server"  CssClass="form-control" AutoPostBack="true" onkeypress="return onlyNos(event,this)" OnTextChanged="txtboothNo_TextChanged"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txtboothNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    </table>
                    <%--<table style="text-align:center">
                    <tr style="background-color:skyblue;font-size:17px;border:medium">
                       
                    </tr>
                        </table>--%>
                        <br />
                     <table border="0" cellpadding="5" cellspacing="5">
                        <tr>
                            <td style="color: brown; font-size: medium; font-weight: bold"> Enter Total Voter's To Vote  On This Booth
                            </td>
                        </tr>
                    </table>

                     <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style3">
                           <asp:Label runat="server" ID="lblmale" Text="Male"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtmale" runat="server"  CssClass="form-control" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub" ControlToValidate="txtmale" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                         <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>

                    <tr>
                        <td class="auto-style3">
                           <asp:Label runat="server" ID="lblfemale" Text="Female"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtfemale" runat="server"  CssClass="form-control" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ControlToValidate="txtfemale" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                         <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                           <asp:Label runat="server" ID="lblother" Text="Other"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtother" runat="server"  CssClass="form-control" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="sub" ControlToValidate="txtother" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style3"></td>
                    </tr>
                  
                     <tr>
                        <td class="auto-style3"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style3"></td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style3"></td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style3"></td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%--<div>
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvReport" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" DataKeyNames="NOMINATIONID" OnPageIndexChanging="gvReport_PageIndexChanging"
                        PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField DataField="FIRSTNAME" HeaderText="First Name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="MIDDLENAME" HeaderText="Middle Name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="LASTNAME" HeaderText="Last Name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CANDIDATEMOB" HeaderText="Mobile No">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="NOMINATIONID" HeaderText="Nomination id">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DISTRICTNAME" HeaderText="District name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="FORMTTYPE" HeaderText="Formt type">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="WARDID" HeaderText="Ward id">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>

                            </asp:BoundField>
                            <asp:BoundField DataField="LOCALBODYNAME" HeaderText="Localbody name">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CREATEDDATE" HeaderText="Date">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
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
                    <asp:PostBackTrigger ControlID="btnExportExcel" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>--%>
</asp:Content>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1
        {
            width: 220px;
        }

        .auto-style2
        {
            width: 211px;
        }

        .auto-style3
        {
            width: 226px;
        }
    </style>
</asp:Content>


