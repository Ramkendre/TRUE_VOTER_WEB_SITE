<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BalanceSheet.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.BalanceSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-register">
        <div class="borderHeading-div">
            <asp:Label Text="Balance Sheet" ID="lblBalanceSheet" runat="server"  Font-Size="Medium" Font-Bold="true"/>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <label class="form-group">OrderID : </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtOrderId" CssClass="form-control" placeholder="OrderID" ReadOnly="true" Height="36px" Width="400px"/>
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
                        <label class="form-group">UserID :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserID" CssClass="form-control" placeholder="UserID" ReadOnly="true" Height="36px" Width="400px"/>
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
                        <label class="form-group">No of Sms :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNoOfSms" CssClass="form-control" placeholder="No of Sms" required="required" Height="36px" Width="400px"/>
                    </td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
                  <tr>
                    <td>
                        <label class="form-group">Sms Cost :</label>
                    </td>
                    <td>
                       <asp:TextBox runat="server" ID="txtSmsCost" CssClass="form-control" placeholder="Sms Cost" required="required" Height="36px" Width="400px"/>
                     </td>
                </tr>
                <tr style="height:10px">
                       <td></td>
                </tr>
                <tr>
                    <td>
                        <label class="form-group">Amount(Include Tax) :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" required="required" placeholder="Amount" Height="36px" Width="400px"/>
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
                        <label class="form-group">Date :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" required="required" Placeholder="Date" Height="36px" Width="400px"/>
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


     <script type="text/javascript">
         $(document).ready(function () {
             $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });          
         });
     </script>
</asp:Content>