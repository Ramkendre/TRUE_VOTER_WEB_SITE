<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration_Sms.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.Registration_Sms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-register">
        <div class="borderHeading-div">
            <asp:Label Text="User Registration" ID="lblRegistration" runat="server"  Font-Size="Medium" Font-Bold="true"/>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <label class="form-group">User ID : </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control" placeholder="User ID" required="required" Height="36px" Width="400px"/>
                    </td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
                <%--<tr>
                    <td>
                        <label class="form-group">TransactionsID :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTransactionsID" CssClass="form-control" ReadOnly="true" placeholder="TransactionsID" Height="36px" Width="400px"/>
                    </td>
                </tr>--%>
                <tr style="height:10px">
                       <td></td>
                </tr>
                <tr>
                    <td>
                        <label class="form-group">User Name :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="User Name" required="required" Height="36px" Width="400px"/>
                    </td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
               <%-- <tr>
                    <td>
                        <label class="form-group">Mobile No :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" ReadOnly="true" placeholder="Mobile No" Height="36px" Width="400px"/>
                    </td>
                </tr>--%>
                 <tr style="height:10px">
                       <td></td>
                </tr>
               <%-- <tr>
                    <td>
                        <label class="form-group">Payment :</label>
                    </td>
                    <td>
                       <asp:TextBox runat="server" ID="txtPayment" CssClass="form-control" placeholder="Payment" Height="36px" Width="400px"/>
                     </td>
                </tr>--%>
                <tr style="height:10px">
                       <td></td>
                </tr>
                <tr>
                    <td>
                        <label class="form-group">Password :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Password" required="required" Height="36px" Width="400px"/>
                    </td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
                  <tr>
                    <td>
                        <label class="form-group">Order ID :</label>
                    </td>
                    <td>
                       <asp:TextBox runat="server" ID="txtOrderId" CssClass="form-control" placeholder="Order ID" required="required" Height="36px" Width="400px"/>
                     </td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
                <tr>
                    <td>
                        <label class="form-group">Mobile No :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Mobile No" required="required" Height="36px" Width="400px"/>
                    </td>
                </tr>
                 <tr style="height:10px">
                       <td></td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
                <tr>
                    <td>
                        <label class="form-group">No Of Sms :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNoofSms" CssClass="form-control" Placeholder="No Of Sms" required="required" Height="36px" Width="400px"/>
                    </td>
                </tr>
                 <tr style="height:10px">
                       <td></td>
                </tr>
                <tr style="height:10px">
                   <td></td>
                </tr>
                <%--<tr>
                    <td>
                        <label class="labelForm"></label>
                    </td>
                </tr>--%>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button Text="Submit" ID="btnSubmit" runat="server" CssClass="btn btn-default" Width="99px" OnClick="btnSubmit_Click"/>
                    </td>
                </tr>
                
            </table>
        </div>
    </div>
</asp:Content>