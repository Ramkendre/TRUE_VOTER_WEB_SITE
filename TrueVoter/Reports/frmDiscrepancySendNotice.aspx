<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDiscrepancySendNotice.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmDiscrepancySendNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Send Notice" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:HiddenField ID="hfCanMob" runat="server" />
        <asp:HiddenField ID="hfLbId" runat="server" />
         <asp:HiddenField ID="hfDistId" runat="server" />
        <asp:HiddenField ID="hfWard" runat="server" />
        <asp:HiddenField ID="hfLbTyp" runat="server" />
        <div id="dvGrid" style="height: auto; width: 100%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                  <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="Enter Notice"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtNotice" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                   
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button ID="btnSend" runat="server" CssClass="btn btn-default" OnClick="btnSend_Click" Text="Send" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click" Text="Back" />
                        </td>
                </table>
                    </center>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
