<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrueVoter.Admin.Login" MasterPageFile="~/MasterPages/Site.Master" Title="Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="borderOuter-div-login">
        <div class="borderHeading-div">
            <div>
                <span class="label lblHeading">LOGIN</span>
            </div>
        </div>
        <div id="fail" class="message-div-fail" runat="server" visible="false">
            <label>LOGIN FAILED..!!!</label>
        </div>
        <div id="Warn" class="message-div-fail" runat="server" visible="false">
            <label>NOT REGISTERED IN SEC..!!!</label>
        </div>
        <div class="form-group">
            <label class="labelForm">Enter User Name </label>
            <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="10" placeholder="e.g. 9421506998" onkeypress="return numbersonly(this,event)" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="labelForm">Enter Password *</label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="labelForm">Select Role *</label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                <asp:ListItem Value="2" Text="Officer"></asp:ListItem>
                <asp:ListItem Value="3" Text="Candidate"></asp:ListItem>
                <asp:ListItem Value="4" Text="Party Officer"></asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="login" />
        </div>
        <div class="form-group">
            <asp:LinkButton ID="lnkbtnForgotp" runat="server" Text="Forgot Password?" OnClick="lnkbtnForgotp_Click" OnClientClick="return confirm('Do you want to resend password to your Registered Mobile?')"></asp:LinkButton>&nbsp;
            <%--<asp:LinkButton ID="lnkbtnNewReg" runat="server" Text="New Registration" PostBackUrl="~/User/Registration.aspx"></asp:LinkButton>--%>
        </div>
    </div>
</asp:Content>

