<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUploadManualControlChart.aspx.cs" Inherits="TrueVoter.Reports.frmUploadManualControlChart" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">

    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Upload Control Chart BACKUP" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div align="center" class="form-group">
            <table style="width: 870px; text-align: left">
                <tr>
                    <td style="text-align: left" class="auto-style1">Enter AC NO:</td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:TextBox ID="txtAcNo" runat="server" MaxLength="3" ValidationGroup="sub1" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 94"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtAcNo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td>
                        <asp:Button ID="btnAdd0" runat="server" Text="Get Data" ValidationGroup="sub1" CssClass="btn btn-default" OnClick="btnAdd0_Click" />
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: left" class="auto-style1">Download Sample:</td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:LinkButton ID="lnkbtnSampleDownload" runat="server" Text="Download ControlChart Sample Excel" OnClick="lnkbtnSampleDownload_Click"></asp:LinkButton>
                    <td class="auto-style3">
                    </td>
                </tr>
               <%--  <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: left" class="auto-style1">Enter Higher officer No:</td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:TextBox ID="txthigoffNo" runat="server" MaxLength="10" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 9422325020"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txthigoffNo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: left" class="auto-style1">Select File:</td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:FileUpload ID="FileId" runat="server" CssClass="form-control" />
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:Button ID="btnAdd" runat="server" Text="Submit" ValidationGroup="sub" CssClass="btn btn-default" OnClick="btnAdd_Click" OnClientClick="return confirm('Please Wait...It Will Take some Time? ');" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-default" />
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">
                        <asp:Label ID="lblLoading" runat="server" Text="Please Wait...." Visible="false"></asp:Label></td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right; color: red; font-size: x-large" class="auto-style1">Note:</td>
                    <td style="text-align: left" class="auto-style2">1].xls OR .xlsx File Extention File only

                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right; color: red" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">2]Do Not Change File Name Or Sheet Name
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td style="text-align: right; color: red" class="auto-style1"></td>
                    <td style="text-align: left" class="auto-style2">3]File Name And Sheet Name Must be ManualControlChart.xlsx OR .xls 
                    </td>
                </tr>
            </table>
        &nbsp;</div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-AddCandidte">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="100" CssClass="table table-hover table-bordered" CellPadding="4" DataKeyNames="SrNo" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvUploadCC_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="SrNo" />
                        <asp:BoundField HeaderText="AC NO" DataField="ACNO" />
                        <asp:BoundField HeaderText="Part No" DataField="PartNo" />
                        <asp:BoundField HeaderText="SrNo From" DataField="SrNoFrom" />
                        <asp:BoundField HeaderText="SrNO To" DataField="SrNoTo" />
                        <asp:BoundField HeaderText="Ward No" DataField="WardNo" />
                        <asp:BoundField HeaderText="VoterList Staff MobileNo" DataField="FromUser" />
                        <asp:BoundField HeaderText="Officer MobileNo" DataField="ToUser" />
                        <asp:BoundField HeaderText="Status" DataField="vstatus" />
                        <asp:BoundField HeaderText="Latitude" DataField="Latitude" />
                        <asp:BoundField HeaderText="Longitude" DataField="Longitude" />
                        <asp:BoundField HeaderText="CreatedBy" DataField="CreatedBy" />
                        <asp:BoundField HeaderText="Uploaded" DataField="IsActive" />
                         <asp:BoundField HeaderText="Server ID" DataField="ServerID" />
                        <asp:TemplateField HeaderText="Choose Record">
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" Text="SelectAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this);" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="INSERT">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove" runat="server"
                                    CommandArgument='<%# Eval("SrNo")%>'
                                    OnClientClick="return confirm('Are You sure to Insert ?')"
                                    Text="Insert" OnClick="InsertRecord"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DELETE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemoveDeactive" runat="server"
                                    CommandArgument='<%# Eval("SrNo")%>'
                                    OnClientClick="return confirm('Are You Sure to Delete ?')"
                                    Text="Delete" OnClick="DeleteRecord"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd0" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 179px;
        }

        .auto-style2 {
            width: 570px;
        }

        .auto-style3 {
            width: 82px;
        }
    </style>
</asp:Content>


