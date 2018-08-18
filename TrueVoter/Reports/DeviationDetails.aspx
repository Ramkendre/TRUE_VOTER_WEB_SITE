<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviationDetails.aspx.cs" Inherits="TrueVoter.Reports.DeviationDetails" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">

        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Deviation Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:FormView ID="FvDeviationDetails" runat="server" CssClass="table table-hover table-bordered" AllowPaging="true">
                        <ItemTemplate>
                            <table border="0" cellpadding="5" cellspacing="5">
                                <tr>
                                    <td style="color: brown">Candidate Name:
                                    </td>
                                    <td>
                                        <%# Eval("UsrName") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Total Expenses:
                                    </td>
                                    <td>
                                        <%# Eval("TotalExpense") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">District Name:
                                    </td>
                                    <td>
                                        <%# Eval("CandidateDistrict") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Cheque No:
                                    </td>
                                    <td>
                                        <%# Eval("ChequeNo") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">LocalBody Name:
                                    </td>
                                    <td>
                                        <%# Eval("LocalBodyNameID") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Cheque Date:
                                    </td>
                                    <td>
                                        <%# Eval("ChequeDate") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Ward No:
                                    </td>
                                    <td>
                                        <%# Eval("WardNo") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Date and Time:
                                    </td>
                                    <td>
                                        <%# Eval("Date") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Party Name:
                                    </td>
                                    <td>
                                        <%# Eval("PartyName") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Firm Name:
                                    </td>
                                    <td>
                                        <%# Eval("FirmName") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Expenses Head:
                                    </td>
                                    <td>
                                        <%# Eval("ExpenseType") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Insert On Date:
                                    </td>
                                    <td>
                                        <%# Eval("InsertDate") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Sub Expenses Head:
                                    </td>
                                    <td>
                                        <%# Eval("SubExpenseType") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Source of Expense:
                                    </td>
                                    <td>
                                        <%# Eval("SourceOfExpense") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Standard Rate:
                                    </td>
                                    <td>
                                        <%# Eval("StandardRate") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Paid Amount:
                                    </td>
                                    <td>
                                        <%# Eval("PaidAmount") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Quantity:
                                    </td>
                                    <td>
                                        <%# Eval("Qty_Size_Area") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Payment Mode:
                                    </td>
                                    <td>
                                        <%# Eval("PaymentMode") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Rate:
                                    </td>
                                    <td>
                                        <%# Eval("Rate") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="color: brown">Payment Type:
                                    </td>
                                    <td>
                                        <%# Eval("PaymentType") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: coral; font-size: 17px">Deviation %:
                                    </td>
                                    <td style="font-size: 24px">
                                        <%# Eval("Deviation") %>
                                    </td>
                                    <td style="width: 45px"></td>
                                     <td style="color: brown">Candidate Mobile No:
                                    </td>
                                    <td>
                                        <%# Eval("ReffrenceMobile") %>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>Cheque No:
                                    </td>
                                    <td>
                                        <%# Eval("ChequeNo") %>
                                    </td>
                                </tr>--%>
                                <%--  <tr>
                                    <td>Cheque Date:
                                    </td>
                                    <td>
                                        <%# Eval("ChequeDate") %>
                                    </td>
                                </tr>--%>
                                <%-- <tr>
                                    <td>Date and Time:
                                    </td>
                                    <td>
                                        <%# Eval("Date") %>
                                    </td>
                                </tr>--%>
                                <%-- <tr>
                                    <td>Firm Name:
                                    </td>
                                    <td>
                                        <%# Eval("FirmName") %>
                                    </td>
                                </tr>--%>
                                <%-- <tr>
                                    <td>Insert On Date:
                                    </td>
                                    <td>
                                        <%# Eval("InsertDate") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Source of Expense:
                                    </td>
                                    <td>
                                        <%# Eval("SourceOfExpense") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Paid Amount:
                                    </td>
                                    <td>
                                        <%# Eval("PaidAmount") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Payment Mode:
                                    </td>
                                    <td>
                                        <%# Eval("PaymentMode") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Payment Type:
                                    </td>
                                    <td>
                                        <%# Eval("PaymentType") %>
                                    </td>
                                </tr>--%>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <div>
                        <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn" OnClick="btnback_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <%-- <div class="borderOuter-div-Form">--%>
        <div class="borderHeading-div" ng-app="myApp" ng-controller="myCntrl">
            <asp:Label ID="Label1" runat="server" Text="Objection Report" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-bordered" AllowSorting="false" AutoGenerateColumns="false" OnSorting="gvData_Sorting">
                    <Columns>
                        <asp:BoundField DataField="ObjID" HeaderText="ID" SortExpression="ObjID">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UserMobileNo" HeaderText="Mobile No" SortExpression="UserMobileNo">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="WardNo" HeaderText="Ward No" SortExpression="WardNo">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ObjectionDetails" HeaderText="Objection Details" SortExpression="ObjectionDetails">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <%-- <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalExpense" HeaderText="TotalExpense" SortExpression="TotalExpense">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>
                                 <asp:BoundField DataField="PaymentMode" HeaderText="PaymentMode" SortExpression="PaymentMode">
                                    <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                    <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                </asp:BoundField>--%>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- </div>--%>
    </div>
</asp:Content>
