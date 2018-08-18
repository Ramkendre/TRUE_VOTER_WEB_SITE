<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeReport.aspx.cs" Inherits="TrueVoter.Reports.TreeReport" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
        <ContentTemplate>
    <div class="borderOuter-div-Form1">
        <div class="borderHeading-div">
    <div>
        <asp:Label ID="lblHeading" runat="server" Text="Tree Report" Font-Bold="true" Font-Size="Medium"></asp:Label>
    </div>
            </div>
    <div>
        <asp:TreeView ID="TreeView1" ExpandDepth="0" Style="text-align: left;" NodeIndent="100" NodeStyle-ImageUrl="~/Content/Images/3.png" ShowLines="True" runat="server"
            OnTreeNodePopulate="TreeView1_TreeNodePopulate" HoverNodeStyle-BorderColor="#ff0000" ParentNodeStyle-ForeColor="#000099" ParentNodeStyle-Font-Size="18px" RootNodeStyle-Font-Size="20px" RootNodeStyle-ForeColor="#000000" LineImagesFolder="~/TreeLineImages">

            <NodeStyle ImageUrl="~/Content/Images/3.png"></NodeStyle>

            <ParentNodeStyle Font-Size="18px"></ParentNodeStyle>

            <RootNodeStyle Font-Size="20px" ForeColor="Black"></RootNodeStyle>
        </asp:TreeView>
    </div>
        </div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
