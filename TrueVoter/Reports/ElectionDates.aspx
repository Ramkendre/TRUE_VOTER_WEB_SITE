<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectionDates.aspx.cs" Inherits="TrueVoter.Reports.ElectionDates" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
            <asp:Label ID="lblHeading" runat="server" Text="Gram panchayat Election" Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>

        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>

                <div class="form-group">
                    <div align="center">
                        <table>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Select State :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlState" AutoPostBack="true" CssClass="form-control" Width="550px" Height="30px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Select District :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlDistrict" CssClass="form-control" AutoPostBack="true" Width="550px" Height="30px" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Select Block :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlBlock" CssClass="form-control" AutoPostBack="true" Width="550px" Height="30px" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Select Village :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlVillage" CssClass="form-control" Width="550px" Height="30px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Gram panchayat Type :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlGrampanchaytType" CssClass="form-control" AutoPostBack="true" Width="550px" Height="30px" OnSelectedIndexChanged="ddlGrampanchaytType_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Selected="True" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Gat Grampanchayt"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Main Grampanchayt"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label Text="Villages Attached To Gram panchayat" Visible="false" ID="lblVillagesAttachedToGrampanchayt" runat="server" Font-Bold="true" CssClass="labelForm" />
                                </td>
                                <td>
                                    <asp:ListBox ID="lstbox1" runat="server" Visible="false" Width="202px" Height="170px" SelectionMode="Multiple"></asp:ListBox>
                                    &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRight" runat="server" Text=" >> " CssClass="btn" OnClick="btnRight_Click" Visible="false" />
                                    &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnleft" runat="server" Text=" << " CssClass="btn" OnClick="btnleft_Click" Visible="false" />
                                    <asp:ListBox ID="lstbox2" runat="server" Width="202px" Height="170px" SelectionMode="Multiple" Visible="false"></asp:ListBox>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">No. of Members in GP :</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNoofMembersinGP" placeholder="Enter The No Of Members" MaxLength="2" onkeypress="return fncInputNumericValuesOnly();" CssClass="form-control" Width="550px" Height="30px" />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Is falling under scheduled area(PESA) :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlGpType" CssClass="form-control" Width="550px" Height="30px">
                                        <asp:ListItem Value="0" Selected="True" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Type of Body :</label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlTypeofBody" CssClass="form-control" Width="550px" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="ddlTypeofBody_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Selected="True" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Newly Formed"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Dissolved"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Administrator"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Other"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Establishment of Body</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEstabilishmentofBody" placeholder="--Select Date--" CssClass="form-control" AutoPostBack="true" Width="550px" Height="30px" OnTextChanged="txtEstabilishmentofBody_TextChanged" />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Retirement of Body</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRetirementofBody" placeholder="--Select Date--" CssClass="form-control" Width="550px" Height="30px" />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <label class="labelForm">Gramsevak Mobile No</label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtGrmSvkMobNo" placeholder="eg.9422325020" CssClass="form-control" Width="550px" Height="30px" />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td>
                                    <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" runat="server" OnClientClick="return requiredField()" OnClick="btnSubmit_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-default" runat="server" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="borderOuter-div-Form1" align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvElectionDates" Width="100%" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" OnPageIndexChanging="gvElectionDates_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SId" HeaderText="Id">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Village" HeaderText="Village ID">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="GrampanchaytType" HeaderText="Gram panchayat Type 1=Gat / 2=Main Gram panchayat">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MembersInGp" HeaderText="Members in GP">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PESA" HeaderText="PESA 1=Yes / 2=No">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TypeofBody" HeaderText="Type of Body">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="EstabilishmentofBody" HeaderText="Estabilishment Date" DataFormatString="{0:yyyy-MM-dd}">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="RetirementofBody" HeaderText="Retirement Date" DataFormatString="{0:yyyy-MM-dd}">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvElectionDates" />
            </Triggers>
        </asp:UpdatePanel>
    </div>



    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtEstabilishmentofBody.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtEstabilishmentofBody.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
            });

            function fncInputNumericValuesOnly(evt) {
                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                if (charCode < 48 || charCode > 57)
                    return false;
                return true;
            }

            function requiredField() {
                var stateId = document.getElementById("<%=ddlState.ClientID%>").value;
                if (stateId == '--Select--' || stateId == '0') {
                    alert('Please Select State');
                    return false;
                }

                var distId = document.getElementById("<%=ddlDistrict.ClientID%>").value;
            if (distId == '--Select--' || distId == '0') {
                alert('Please Select District');
                return false;
            }
            var blkID = document.getElementById("<%=ddlBlock.ClientID%>").value;
            if (blkID == '--Select--' || blkID == '0') {
                alert('Please Select Block');
                return false;
            }
            var vilId = document.getElementById("<%=ddlVillage.ClientID%>").value;
            if (vilId == '--Select--' || vilId == '0') {
                alert('Please Select Village');
                return false;
            }


            var grmTyID = document.getElementById("<%=ddlGrampanchaytType.ClientID%>").value;
            if (grmTyID == '--Select--' || grmTyID == '0') {
                alert('Please Select Grampanchyat Type');
                return false;
            }
            var gpTypeID = document.getElementById("<%=ddlGpType.ClientID%>").value;
            if (gpTypeID == '--Select--' || gpTypeID == '0') {
                alert('Please Select PESA');
                return false;
            }
            var blkTy = document.getElementById("<%=ddlTypeofBody.ClientID%>").value;
            if (blkTy == '--Select--' || blkTy == '0') {
                alert('Please Select Body Type');
                return false;
            }
            var mem = document.getElementById("<%=txtNoofMembersinGP.ClientID%>").value;
            if (mem == '') {
                alert('Please Enter No of Members in GP');
                return false;
            }
            if (vilId != '2') {
                var esdt = document.getElementById("<%=txtEstabilishmentofBody.ClientID%>").value;
                if (esdt == '') {
                    alert('Please Enter Establishment of Body Date');
                    return false;
                }
                var redt = document.getElementById("<%=txtRetirementofBody.ClientID%>").value;
                if (redt == '') {
                    alert('Please Enter Retirement of Body Date');
                    return false;
                }
            }

        }
    </script>

    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtRetirementofBody.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtRetirementofBody.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>--%>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 209px;
        }
    </style>
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery.datetimepicker.js"></script>
    <script src="../js/jquery.datetimepicker.full.js"></script>
    <link href="../js/jquery.datetimepicker.min.css" rel="stylesheet" />
    <script>
        debugger;
        $('#txtEstabilishmentofBody').datetimepicker({
            formatTime: 'H:i',
            formatDate: 'd.m.Y',
            //defaultDate:'8.12.1986', // it's my birthday
            defaultDate: '+03.01.1970', // it's my birthday
            defaultTime: '10:00',
            timepickerScrollbar: false,
            disabledDates: ['2017/05/22', '2017/05/25', '2017/05/26']
        });
    </script>
</asp:Content>

