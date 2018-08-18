<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUploadControl.aspx.cs" Inherits="TrueVoter.Reports.frmUploadControl" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">   
    <div class="borderOuter-div-Form">
      <div class="borderHeading-div">
        <div>
            <asp:Label ID="lblHeading" runat="server" Text="Upload Control Chart Data" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>      
    </div>
    <div align="center" class="form-group">
        <table style="width:816px">
            <tr>
                <td style="text-align: left" class="auto-style2">Enter VoterList Staff No:</td>
                <td style="text-align: left" class="auto-style1">
                    <asp:TextBox ID="txtvoterstaffNo" runat="server" MaxLength="10" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 9422325020"></asp:TextBox></td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtvoterstaffNo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr style="height:10px">
               <td class="auto-style2"></td>
            </tr>
             <tr style="height:10px">
               <td class="auto-style2"></td>
            </tr>
            <tr>
                <td style="text-align: left" class="auto-style2">Enter Higher officer No:</td>
                <td style="text-align: left" class="auto-style1">
                    <asp:TextBox ID="txthigoffNo" runat="server" MaxLength="10" CssClass="form-control" onkeypress="return numbersonly(this,event)" PlaceHolder="e.g. 9422325020"></asp:TextBox></td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txthigoffNo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr style="height:10px">
               <td class="auto-style2"></td>
            </tr>
            <tr>
                <td style="text-align: left" class="auto-style2">Select File:</td>
                <td style="text-align: left" class="auto-style1">
                    <asp:FileUpload ID="FileId" runat="server" CssClass="form-control"/>
                </td>
            </tr>
             <tr style="height:10px">
               <td class="auto-style2"></td>
            </tr>
             <tr style="height:10px">
               <td class="auto-style2"></td>
            </tr>
            <tr>
                <td style="text-align: left" class="auto-style2"></td>
                <td style="text-align: left" class="auto-style1">
                    <asp:Button ID="btnAdd" runat="server" Text="Submit" CssClass="btn btn-default" ValidationGroup="sub" OnClick="btnAdd_Click" />

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default" PostBackUrl="~/Admin/Home" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; color: red; font-size: x-large" class="auto-style2">Note:</td>
                <td style="text-align: left" class="auto-style1">1].xls OR .xlsx File Extention File only

                </td>
            </tr>
            <tr>
                <td style="text-align: right; color: red" class="auto-style2"></td>
                <td style="text-align: left" class="auto-style1">2]Do Not Change File Name Or Sheet Name
                </td>
            </tr>
        </table>   
           </div>
       </div>     
        <div class="borderOuter-div-AddCandidte">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="100" CellPadding="4" DataKeyNames="SrNo"
                EmptyDataText="No Data Found..." ForeColor="#333333" GridLines="None" CssClass="table table-hover table-bordered" AutoGenerateColumns="False" OnPageIndexChanging="gvUploadCC_PageIndexChanging">
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
                    <asp:BoundField HeaderText="VoterList Staff" DataField="FromUser" />
                    <asp:BoundField HeaderText="Officer" DataField="ToUser" />
                    <asp:BoundField HeaderText="Status" DataField="vstatus" />
                    <asp:BoundField HeaderText="Latitude" DataField="Latitude" />
                    <asp:BoundField HeaderText="Longitude" DataField="Longitude" />
                    <asp:BoundField HeaderText="CreatedBy" DataField="CreatedBy" />
                    <asp:BoundField HeaderText="Uploaded" DataField="IsActive" />
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
 
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 363px;
        }
        .auto-style2 {
            width: 112px;
        }
        .auto-style3 {
            width: 38px;
        }
    </style>
</asp:Content>

