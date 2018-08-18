<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dynamic_code_generate.aspx.cs" Inherits="TrueVoter.Admin.Dynamic_code_generate"  MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Generate Coupon Codes" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                         <td class="auto-style1">
                            <asp:Label runat="server" ID="lblFirstnoOfSeries" Text="First no. of Series"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtseries" runat="server" PlaceHolder="e.g: 50100001" TextMode="Number" CssClass="txtclass"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtseries" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                             <asp:Label ID="lblTotalnoOfcodestobegenerated" runat="server" Text="Total no. of codes to be generated"></asp:Label>
                        </td>
                    <td>
                       <asp:TextBox ID="txttotacodes" runat="server" PlaceHolder="e.g: 1000" TextMode="Number" CssClass="txtclass"></asp:TextBox>
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
                            <asp:Label ID="lblScratchcodelength" runat="server" Text="Scratch code length"></asp:Label>
                        </td>
                    <td>
                         <asp:TextBox ID="txtscratchcode" runat="server" PlaceHolder="e.g: 5" CssClass="txtclass"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ValidationGroup="sub" ControlToValidate="txtscratchcode" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                           <asp:Label ID="lblAlphaNumeric" runat="server" Text="Alpha-Numeric"></asp:Label>
                        </td>
                    <td>
                       <asp:RadioButtonList ID="rdobtnYesNo" runat="server" RepeatDirection="Vertical">
                            <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEleDate" runat="server" ValidationGroup="sub" ControlToValidate="rdobtnYesNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDategeneration" Text="Date of Code Generation"></asp:Label></td>
                        </td>
                    <td>
                          <asp:TextBox ID="txtDate" runat="server" ReadOnly="True" CssClass="txtclass"></asp:TextBox>
                    </td>
                        <td>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorFath" ValidationGroup="sub" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                   
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblAssigntoMktperson" Text="Enter Mobile No"></asp:Label></td>
                        </td>
                    <td>
                          <asp:TextBox ID="txtAssigntoMktperson" runat="server"  PlaceHolder="Enter Mobile No" MaxLength="10" CssClass="txtclass"></asp:TextBox>
                    </td>
                        <td>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorFath" ValidationGroup="sub" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                   
                    
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                  
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <%-- <asp:Button Text="Export_Excel" ID="btnExportExcel" CssClass="btn btn-default" runat="server" OnClick="btnExportExcel_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                       <%-- <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />--%>
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
                        
                        </td>
                    </tr>--%>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <div>
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvcodelist" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                        AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" OnPageIndexChanging="gvcodelist_PageIndexChanging"
                        PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="2">
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Scratchcode" HeaderText="Scratch code">
                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                            </asp:BoundField>
                        </Columns>
                       <%-- <FooterStyle BackColor="#33adff" ForeColor="#003399" />--%>
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
                <%--<Triggers>
                    <asp:PostBackTrigger ControlID="btnExportExcel" />
                </Triggers>--%>
            </asp:UpdatePanel>
        </div>
    </div>
  
</asp:Content>

