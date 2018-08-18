<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/UserSite.Master" CodeBehind="SmsRecharge.aspx.cs" Inherits="TrueVoter.Reports.Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
             <asp:Label ID="lblSmsRecharge" runat="server" Text="SMS Recharge" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div> 
       <div>
           <table>
               <tr>
                   <td>
                       <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" Height="36px" Width="300px" Placeholder="Search" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"/>                       
                   </td>
                   <td><asp:Button ID="btnsearch" Text="Search" runat="server" CssClass="btn btn-default" Width="74px" Visible="false"/></td>
               </tr>
           </table>
       </div>
                    
                  
        
        <div align="center">
            
            <asp:GridView runat="server" ID="gvSmsRecharge" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" Width="899px">
                <Columns>

                   <%-- <asp:BoundField HeaderText="Id" DataField="Id"/>--%>
                    <asp:BoundField HeaderText="UserID" DataField="UserID"/>
                    <asp:BoundField HeaderText="TransectionID" DataField="TransectionID"/>
                    <asp:BoundField HeaderText="FName" DataField="FName" />
                    <asp:BoundField HeaderText="LName" DataField="LName"/>
                    <asp:BoundField HeaderText="MobileNo" DataField="MobileNo"/>
                   <%-- <asp:BoundField HeaderText="EmailId" DataField="EmailId"/> --%>                   
                    <%--<asp:BoundField HeaderText="IMEINo" DataField="IMEINo"/>--%>
                    <asp:BoundField HeaderText="OrderID" DataField="OrderID"/>
                    <asp:BoundField HeaderText="Amount" DataField="Amount"/>
                    <%--<asp:BoundField HeaderText="PaymentDate" DataField="PaymentDate"/>--%>
                    <asp:BoundField HeaderText="BankRefNo" DataField="BankRefNo" />
                    <%--<asp:BoundField HeaderText="TranxType" DataField="TranxType"/>   --%>                 
                    <%--<asp:BoundField HeaderText="PaymentSource" DataField="PaymentSource"/>--%>
                    <asp:BoundField HeaderText="NoOfSMS" DataField="NoOfSMS"/>                    
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkStatus" runat="server"                              
                                OnClientClick="return confirm('Are You sure to Process ?')"
                                Text="Process" OnClick="lnkStatus_Click" ForeColor="Blue" BackColor="White"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>