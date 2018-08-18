<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBLOReport.aspx.cs" Inherits="TrueVoter.Reports.frmBLOReport" MasterPageFile="~/MasterPages/UserSite.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Officer Junior Details" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                <table style="width: 700px;text-align:left;">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lblDist" Text="Select District"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlDistirct" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistirct_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="Label5" Text="Select LocalBody Type"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBodytype" CssClass="form-control" runat="server" >
                              <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Municiple Corporation" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Municiple Council" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Nagar Panchayat" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Zilla Parishad" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Panchayat Samiti" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label runat="server" ID="lbllocalBody" Text="Select LocalBody"></asp:Label></td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlLocalBody" CssClass="form-control" runat="server"></asp:DropDownList>
                    </td>
                        <td>
                        </td>
                    </tr>
                      <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr> 
                    <tr style="height: 10px">
                        <td class="auto-style1"></td>
                    </tr>
                   
                    <tr>

                        <td class="auto-style1"></td>
                        <td style="text-align: left">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" OnClientClick="return validateFun()" Text="Submit" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnclear" runat="server" CssClass="btn btn-default" OnClick="btnclear_Click" Text="Clear" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnback" runat="server" CssClass="btn btn-default" PostBackUrl="~/Reports/frmHomeUser.aspx" Text="Back" />
                        </td>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <asp:Panel ID="pnlOne" runat="server">
            <div class="borderOuter-div-AddCandidte" style="overflow: auto">
                <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvBLOLocalBody" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvBLOLocalBody_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Designation Name" DataField="DesignationName" />
                                    <asp:BoundField HeaderText="Count" DataField="cnt" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbtnGetDetails" CommandArgument='<%#Eval("DesignationId")+","+Eval("LocalBodyId")%>' OnClick="lbtnGetDetails_Click" OnClientClick="return scrollGrid()" Text="View"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                            <asp:AsyncPostBackTrigger ControlID="gvBLOLocalBody" />
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlTwo" runat="server" Visible="true">
            <div class="borderOuter-div-AddCandidte" style="overflow: auto">
                <div id="Div1" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvOfficerReports" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvOfficerReports_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                    <asp:BoundField HeaderText="Mobile No" DataField="usrMobileNumber" />
                                    <asp:BoundField HeaderText="Designation Name" DataField="DesignationName" />
                                    <asp:BoundField HeaderText="Count" DataField="cnt" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbtnGetJrDetails" CommandArgument='<%#Eval("DesignationId")+","+Eval("LocalBodyId") +","+Eval("usrMobileNumber")%>' OnClick="lbtnGetJrDetails_Click" OnClientClick="return scrollJrGrid()" Text="View"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                            <asp:AsyncPostBackTrigger ControlID="gvOfficerReports" />
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlThree" runat="server" Visible="true">
            <div class="borderOuter-div-AddCandidte" style="overflow: auto">
                <div id="Div2" style="height: auto; width: 100%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvJrDetails" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                                PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvJrDetails_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                    <asp:BoundField HeaderText="Mobile No" DataField="UserMobile" />
                                    <asp:BoundField HeaderText="Designation Name" DataField="DesignationName" />
                                    <asp:BoundField HeaderText="LocalBody Name" DataField="LocalBodyName" />
                                    <asp:BoundField HeaderText="Status" DataField="isActive" />
                                    
                                    <%--                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate> 
                                        <asp:LinkButton runat="server" ID="lbtnGetJrDetails" CommandArgument='<%#Eval("DesignationId")+","+Eval("LocalBodyId") +","+Eval("usrMobileNumber")%>' OnClick="lbtnGetJrDetails_Click" Text="View"></asp:LinkButton>
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
                            <asp:AsyncPostBackTrigger ControlID="gvJrDetails" />
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div>
    </div>
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        function scrollGrid1() {
            //debugger;
            //$('#lbtnGetDetails').click(function ()
            //{
                $('html,body').animate
                    (
                    {
                        scrollTop: $('#Div1').offset().top
                    },
                    'slow'
                    )
            //})
        }

        function scrollJrGrid1() {
            //debugger;
            //$('#lbtnGetDetails').click(function ()
            //{
            $('html,body').animate
                (
                {
                    scrollTop: $('#Div2').offset().top
                },
                'slow'
                )
            //})
        }

        function validateFun() {

            var dis = document.getElementById("<%= ddlDistirct.ClientID%>").value;
            if (dis == '0' || dis == "--Select--") {
                alert('Please Select District');

                return false;
            }
            var lby = document.getElementById("<%= ddlLocalBodytype.ClientID%>").value;
            if (lby == '0' || lby == "--Select--") {
                alert('Please Select Local Body Type');

                return false;
            }

            var lby = document.getElementById("<%= ddlLocalBody.ClientID%>").value;
            if (lby == '0' || lby == "--Select--") {
                alert('Please Select Local Body');

                return false;
            }
        }
    </script>
</asp:Content>
