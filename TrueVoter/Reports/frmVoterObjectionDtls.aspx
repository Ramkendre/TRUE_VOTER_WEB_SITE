<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVoterObjectionDtls.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" EnableEventValidation="true" Inherits="TrueVoter.Reports.frmVoterObjectionDtls" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="BodyContent">
    <script type="text/javascript">
        function DisplayImage(ctrl)
        {
            document.getElementById('imgLargeImage').src = ctrl.src;

            $("#ImageDialog").dialog(
                {
                    title: "Document Photo",
                    buttons:
                        {
                            Ok: function ()
                            {
                                $(this).dialog('close');
                            }
                        },
                    modal: true
                });
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="borderOuter-div-Form">
                <div class="borderHeading-div">
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="VoterList Objection Control Chart" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblCanName" Text="Enter AC No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtACNO" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="e.g:114" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ControlToValidate="txtACNO" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblPart" Text="Enter Part No"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtPartNo" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="eg:12" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                     <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label1" Text="Enter Expected Ward"></asp:Label></td>
                        </td>
                    <td>
                        <asp:TextBox ID="txtExpectedWard" runat="server" CssClass="form-control" MaxLength="4" PlaceHolder="eg:12" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                    </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPartNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Export To Excel" ID="btnExcel" CssClass="btn btn-default" runat="server" Visible="false" OnClick="btnExcel_Click" />
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                        </td>
                    </tr>
                    
                </table>
                    </center>
                </div>
            </div>
            <%--Popup dialog to display large image--%>
            <div id="ImageDialog" style="display: none">
                <img height="700" width="500" id="imgLargeImage" />
            </div>
            <div class="borderOuter-div-AddCandidte" style="overflow: auto">
                <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvVoterObjection" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" DataKeyNames="ID"
                                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvVoterObjection_PageIndexChanging" OnRowDataBound="gvVoterObjection_RowDataBound">
                                <Columns>
                                    <%--[ID],[MobileNo],[Name],[LocalBodyID],[ACNo],[PARTNo],[SRNo],[ExpectedWard],[VoterName],[VoterMoNo],[ObjectionType],[Remark],[Latitude],[Longitude],[IsCorrect],[IsCorrectedBy],[IsCorrectedDate],[IsApprove],[IsApproveBy],[IsApproveDate],[CreatedDate]--%>
                                    <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Local Body" DataField="LocalBodyID" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="AC No" DataField="ACNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="PART No" DataField="PARTNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="SR No" DataField="SRNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Expected Ward" DataField="ExpectedWard" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Voter Name" DataField="VoterName" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Voter MoNo" DataField="VoterMoNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Objection Type" DataField="ObjectionType" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Address" DataField="Remark" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Is Correct" DataField="IsCorrect" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Corrected By" DataField="CorrectedBy" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Is Approved" DataField="IsApproved" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Approved By" DataField="ApprovedBy" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Objection Date" DataField="ObjectionDate" ItemStyle-Width="50px" DataFormatString="{0:yyyy-MM-dd}" />
                                     <%--<asp:TemplateField HeaderText="Doc Photos">
                                        <ItemTemplate>
                                            <img src='<%# "data:image/gif;base64," + Eval("DocumentPhoto")  %>' onclick="DisplayImage(this)" height="25" width="25" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Home Photos">
                                        <ItemTemplate>
                                            <img src='<%# "data:image/gif;base64," + Eval("HomePhoto")  %>' onclick="DisplayImage(this)" height="25" width="25" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="Doc Photos">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDoc" runat="server"
                                                CommandArgument='<%# Eval("ID")%>'
                                                OnClientClick="return confirm('Are You sure View Doc Photo ?')"
                                                Text="Doc.Photo" OnClick="lnkDoc_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Home Photos">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkHome" runat="server"
                                                CommandArgument='<%# Eval("ID")%>'
                                                OnClientClick="return confirm('Are You sure View Home Photo ?')"
                                                Text="Home Photo" OnClick="lnkHome_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <FooterStyle BackColor="#33adff" ForeColor="#003399" />
                                <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />

                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvVoterObjection" />
                            <asp:PostBackTrigger ControlID="btnExcel" />
                            <asp:PostBackTrigger ControlID="btnExcel" />
                        </Triggers>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExcel" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
