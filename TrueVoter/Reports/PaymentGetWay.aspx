<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentGetWay.aspx.cs" Inherits="TrueVoter.Reports.PaymentGetWay" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
                <div>
                <asp:Label ID="lblHeading" runat="server" Text="Payment Get Way" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </div>
            </div> 
    <center>
        <div id="frmError" runat="server">
         
        <span style="color: red">Please fill all mandatory fields.</span>
        <br />
    <table style="width:657px; text-align:left">
        <tr><td class="auto-style1"></td>
            <td><b>Mandatory Parameters</b></td>
        </tr>
        <tr>
            <td class="auto-style1">Amount: </td>
            <td>
                <asp:TextBox ID="amount" runat="server" Width="200px" CssClass="form-control"/></td>
           <td class="auto-style3">.</td>
            <td class="auto-style2">First Name: </td>
            <td>
                <asp:TextBox ID="firstname" runat="server" Width="200px" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Email: </td>
            <td>
                <asp:TextBox ID="email" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">Phone: </td>
            <td>
                <asp:TextBox ID="phone" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Product Info: </td>
            <td>
                <asp:TextBox ID="productinfo" runat="server" CssClass="form-control"/></td> 
            <td class="auto-style3">.</td>           
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Success URI: </td>
            <td>
                <asp:TextBox ID="surl" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Failure URI: </td>
            <td>
                <asp:TextBox ID="furl" runat="server" CssClass="form-control"/></td>
             <td class="auto-style3">.</td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr><td class="auto-style1"></td>
            <td><b>Optional Parameters</b></td>
        </tr>
        <tr>
            <td class="auto-style1">Last Name: </td>
            <td>
                <asp:TextBox ID="lastname" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">Cancel URI: </td>
            <td>
                <asp:TextBox ID="curl" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Address1: </td>
            <td>
                <asp:TextBox ID="address1" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">Address2: </td>
            <td>
                <asp:TextBox ID="address2" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">City: </td>
            <td>
                <asp:TextBox ID="city" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">State: </td>
            <td>
                <asp:TextBox ID="state" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Country: </td>
            <td>
                <asp:TextBox ID="country" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">Zipcode: </td>
            <td>
                <asp:TextBox ID="zipcode" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">UDF1: </td>
            <td>
                <asp:TextBox ID="udf1" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">UDF2: </td>
            <td>
                <asp:TextBox ID="udf2" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">UDF3: </td>
            <td>
                <asp:TextBox ID="udf3" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">UDF4: </td>
            <td>
                <asp:TextBox ID="udf4" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">UDF5: </td>
            <td>
                <asp:TextBox ID="udf5" runat="server" CssClass="form-control"/></td>
            <td class="auto-style3">.</td>
            <td class="auto-style2">PG: </td>
            <td>
                <asp:TextBox ID="pg" runat="server" CssClass="form-control"/></td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">Service Provider: </td>
            <td>
                <asp:TextBox ID="service_provider" runat="server" CssClass="form-control" /></td>
             <td class="auto-style3">.</td>
        </tr>
        <tr style="height:10px">
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
    <tr><td class="auto-style1"></td><td>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="submit" Text="submit" CssClass="btn btn-default" runat="server" OnClick="Button1_Click" />
        </td></tr>
         </table>
        <br />
    </div>
    <input type="hidden" runat="server" id="key" name="key" />
    <input type="hidden" runat="server" id="hash" name="hash" />
    <input type="hidden" runat="server" id="txnid" name="txnid" />
   <div class="form-group">
       </div>
        </center>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
        .auto-style2 {
            width: 147px;
        }
        .auto-style3 {
            width: 142px;
        }
    </style>
</asp:Content>

