<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact Us.aspx.cs" Inherits="TrueVoter.Reports.Contact_Us" MasterPageFile="~/MasterPages/UserSite.Master" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="Contact Us" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <center>
        <div class="form-group">
            <table>
                <tr>
                    <td>
                        <label>First Name :</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFirstName" required="required" CssClass="form-control" placeholder="First Name"  Width="350px"/><br />

                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Last Name :</label>
                    </td>
                    <td>
                        <asp:textbox runat="server"  ID="txtLastName" required="required" CssClass="form-control" placeholder="Last Name"  Width="350px"/><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Email-ID :</label>
                    </td>
                    <td>
                        <asp:textbox runat="server" ID="txtEmailId" required="required" CssClass="form-control" placeholder="Email-ID"  Width="350px"/> <br /> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Mobile No. :</label>
                    </td>
                    <td>
                        <asp:textbox runat="server" ID="txtMobileNo" required="required" CssClass="form-control" placeholder="Mobile Number"  Width="350px"/><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Company Name :</label>
                    </td>
                    <td>
                        <asp:textbox runat="server" ID="txtCompanyName" required="required" CssClass="form-control" placeholder="Comapny Name" Width="350px" /><br>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Subject :</label>
                    </td>
                    <td>
                        <asp:textbox runat="server"  ID="txtSubject" required="required" CssClass="form-control" placeholder="Subject"  Width="350px"/><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Comment :</label>
                    </td>
                    <td>
                       <asp:textbox runat="server"  ID="txtComment" required="required" CssClass="form-control" placeholder="Comment" style="overflow:auto"  Width="350px" Height="100px" TextMode="MultiLine"/><br />
                   </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:button text="Submit" ID="btnSubmit" CssClass="btn btn-default" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
            </center>
        </div>
</asp:Content>
