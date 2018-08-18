<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVoterObjsec.aspx.cs" Inherits="TrueVoter.Reports.frmVoterObjsec" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div class="borderOuter-div-Form1">
    <div class="borderHeading-div">
        <div>
            <asp:Label ID="Label11" runat="server" Text="Voter Objection" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
      </div>
        <div class="form-group">
        <table align="center" style="width:906px;text-align:left">
            <tr>
                <td class="auto-style2">
                    <asp:Label runat="server" ID="Label5" Text="Objection Type"></asp:Label>
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlobjectionType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Name Not Found in Voter List"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Allocated To Wrong Ward"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter Assembly No
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtAssemblyNo" runat="server" MaxLength="3" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtAssemblyNo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter Part No
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtpartNo" runat="server" MaxLength="3" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtpartNo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter SR No
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtSrNo" runat="server" MaxLength="3" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtSrNo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter Voter Name
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtVoterName" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtVoterName" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter Voter Mobile No
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtVotermobileNo" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtVotermobileNo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter Expected Ward No
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtWard" runat="server" MaxLength="3" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub1" ErrorMessage="*" ControlToValidate="txtWard" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Enter Address</td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Select Address Document</td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlDocList" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Bank / Kisan / Post Office current Pass Book"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Ration Card"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Passport"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Driving License"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Income Tax Assessment Order"></asp:ListItem>
                        <asp:ListItem Value="6" Text="Latest rent agreement"></asp:ListItem>
                        <asp:ListItem Value="7" Text="Document List 1"></asp:ListItem>
                        <asp:ListItem Value="8" Text="Document List 2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>

            <tr>
                <td class="auto-style2">Upload Image
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="ufImages" runat="server" CssClass="form-control" />
                </td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2">Upload Image2
                </td>
                <td class="auto-style3">:</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="ufImage2" runat="server" CssClass="form-control"/></td>
            </tr>
            <tr style="height:10px">
               <td></td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
                <td class="auto-style1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="sub1" OnClick="btnSubmit_Click" CssClass="btn btn-default"></asp:Button>
                    &nbsp;&nbsp;
                                     <asp:Button ID="btnCancle" runat="server" Text="Cancel" OnClick="btnCancle_Click" CssClass="btn btn-default"></asp:Button>
                </td>
            </tr>
            <%-- <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="lbtnForgetpwd" runat="server" ForeColor="#ff0000" Text="Forget Daily Expense Password" OnClick="lbtnForgetpwd_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtForgetUsername" runat="server" Visible="false"></asp:TextBox>
                                    &nbsp;&nbsp;
                                     <asp:Button ID="btnGetPassword" runat="server" Text="Get Password" Visible="false" OnClick="btnGetPassword_Click"></asp:Button>
                                </td>
                            </tr>--%>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lbld1" Text="Document  List 1:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="doc1" runat="server" Text="Latest Water / Telephone / Electricity / Gas Connection Bill for that address, either in the name of the applicant or that of his / her immediate relation like parents etc."></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label1" Text="Document  List 2:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="doc2" runat="server" Text="Any post / letter / mail delivered through Indian Postal Department in the applicant’s name at the address of ordinary residence."></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvVoterObjection" runat="server" AllowPaging="True" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found...." ShowHeaderWhenEmpty="True" PageSize="20" AutoGenerateColumns="False" OnPageIndexChanging="gvVoterObjection_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvVoterObjection_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="VoterName" HeaderText="Voter Name" />
                <asp:BoundField DataField="VoterMoNo" HeaderText="Mobile No" />
                <asp:BoundField DataField="ACNo" HeaderText="AC No" />
                <asp:BoundField DataField="PARTNo" HeaderText="PART No" />
                <asp:BoundField DataField="SRNo" HeaderText="SR No" />
                <asp:BoundField DataField="DistrictId" HeaderText="District Id" />
                <asp:BoundField DataField="LocalBody" HeaderText="Local Body" />
                <asp:BoundField DataField="LocalBodyID" HeaderText="LocalBody ID" />
                <asp:BoundField DataField="ObjectionType" HeaderText="Objection Type" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="imgPhoto1" runat="server" ImageUrl='<%#"ImageHandler.ashx?imgID="+Eval("HomePhoto")+"&MobileNo="+Eval("MobileNo") %>' Height="80px" Width="80px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField></asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 476px;
        }
        .auto-style2 {
            width: 161px;
        }
        .auto-style3 {
            width: 12px;
        }
    </style>
</asp:Content>

