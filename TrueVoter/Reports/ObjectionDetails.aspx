<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectionDetails.aspx.cs" Inherits="TrueVoter.Reports.ObjectionDetails" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Objection Reports" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:FormView ID="FvObjectionDetails" runat="server" CssClass="table table-hover table-bordered" AllowPaging="true" OnPageIndexChanging="FvDeviationDetails_PageIndexChanging">
                        <ItemTemplate>
                            <table border="0" cellpadding="5" cellspacing="5">
                                <tr>
                                    <td style="color: brown">User Name:
                                    </td>
                                    <td>
                                        <%# Eval("userName") %>
                                    </td>
                                   <%-- <td style="width: 45px"></td>
                                    <td style="color: brown">Objection ID:
                                    </td>
                                    <td>
                                        <%# Eval("objID") %>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td style="color: brown">Ward No:
                                    </td>
                                    <td>
                                        <%# Eval("wardNo") %>
                                    </td>
                                   <%-- <td style="width: 45px"></td>
                                    <td style="color: brown">Objection Details:
                                    </td>
                                    <td>
                                        <%# Eval("objectionDetails") %>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td style="color: brown">User MobileNo:
                                    </td>
                                    <td>
                                        <%# Eval("userMobileNo") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Objection ID:
                                    </td>
                                    <td>
                                        <%# Eval("objID") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: brown">Objection Details:
                                    </td>
                                    <td>
                                        <%# Eval("objectionDetails") %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <div>
                        <%--<asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn" OnClick="btnback_Click" />--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    
</asp:Content>
