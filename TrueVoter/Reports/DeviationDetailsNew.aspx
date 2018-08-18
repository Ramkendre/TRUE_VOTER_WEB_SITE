<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviationDetailsNew.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.DeviationDetailsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
            <div class="borderHeading-div" ng-app="myApp"  ng-controller="myCntrl">
                <asp:Label ID="lblHeading" runat="server" Text="Objection Report" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
    </div>
</asp:Content>
     