﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUploadBoothAddress.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmUploadBoothAddress" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">

    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Upload Booth Address" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <div align="Center">
                        <table style="width: 809px; text-align: left">
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
                                </td>
                    <td>
                        <asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                                <td></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label runat="server" ID="Label5" Text="Select LocalBody Type"></asp:Label></td>
                                </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBodytype" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Municiple Corporation" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Municiple Council" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Nagar Panchayat" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Zilla Parishad" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Panchayat Samiti" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                                <td></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"></asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>

                            <tr>
                                <td style="text-align: left" class="auto-style2">Select File:</td>
                                <td style="text-align: left" class="auto-style1">
                                    <asp:FileUpload ID="FileId" runat="server" CssClass="form-control" />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td style="text-align: left" class="auto-style1">Download Sample:</td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:LinkButton ID="lnkbtnSampleDownload" runat="server" Text="Download BoothAdd Sample Excel File" OnClick="lnkbtnSampleDownload_Click"></asp:LinkButton>
                                <td class="auto-style3"></td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td style="text-align: left">
                                    <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" OnClientClick="return ValiRequierd()" runat="server" OnClick="btnSubmit_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" PostBackUrl="~/Reports/frmHomeUser.aspx" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="lnkbtnSampleDownload" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="borderOuter-div-AddCandidte" style="overflow: auto">
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvBoothAddress" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" ShowFooter="True"
                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="Ward No" DataField="Ward" />
                            <asp:BoundField HeaderText="Booth No" DataField="BoothNo" />
                            <asp:BoundField HeaderText="Address" DataField="BoothAddress" />
                            <asp:BoundField HeaderText="LocalBodyName" DataField="LocalBodyName" />
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
                    <asp:AsyncPostBackTrigger ControlID="gvBoothAddress" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        function ValiRequierd() {
            var disId = document.getElementById("<%=ddlDistirct.ClientID%>").value;
            if (disId == '--Select--' || disId == '' || disId == '0') {
                alert('Please Select District Name'); return false;
            }

            var lbtyp = document.getElementById("<%=ddlLocalBodytype.ClientID%>").value;
            if (lbtyp == '--Select--' || lbtyp == '' || lbtyp == '0') {
                alert('Please Select Local Body Type'); return false;
            }

            var lb = document.getElementById("<%=ddlLocalBody.ClientID%>").value;
            if (lb == '--Select--' || lb == '' || lb == '0') {
                alert('Please Select Local Body Name'); return false;
            }
        }
    </script>
</asp:Content>