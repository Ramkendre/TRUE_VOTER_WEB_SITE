<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPushMsg.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmPushMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Send Message" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
            <table align="center">
                <tr>
                    <td>
                        <label class="form-group">Send Message To: </label>
                    </td>
                    <td>
                        <asp:CheckBoxList ID="cklRole" runat="server" >
                            <asp:ListItem Value="1" Text="Voters" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Officers"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Candidates"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                  
                </tr>


                <tr>
                    <td>
                         <label class="form-group">Select District </label>
                    
                    </td><td class="auto-style1">
                        
                        <asp:DropDownList ID="ddlDistirct1" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct1_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                         <label class="form-group">Select LocalBody</label>
                    </td><td class="auto-style1">
                    
                        <asp:DropDownList ID="ddlLocalBody1" CssClass="form-control"   runat="server" ></asp:DropDownList>
                    </td>
                </tr>



                <tr style="height: 10px">
                        <td class="auto-style1"></td>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCharRem" Text="0"></asp:Label>/1024</td>
                    </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtMsgBody" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"  onKeyUp="return CountChar()"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" CssClass="btn btn-default" Text="Send"/>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-default" Text="Clear"/>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn btn-default" Text="Back"/>
                    </td>
                </tr>
            </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        function CountChar() {
            //debugger;
            var av = document.getElementById("<%=txtMsgBody.ClientID%>").value;
            if (av.length == 1024)
            {
                alert('Message Length Must be 1024 Char');
            }
            var msg = 160 - document.getElementById("<%=txtMsgBody.ClientID%>").value.length;
            document.getElementById('<%=lblCharRem.ClientID%>').innerText = msg;
        }
    </script>
</asp:Content>
