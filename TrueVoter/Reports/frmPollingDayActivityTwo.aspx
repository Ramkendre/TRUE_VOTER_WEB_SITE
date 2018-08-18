<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPollingDayActivityTwo.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.frmPollingDayActivityTwo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form">
        <div>
            <div class="borderHeading-div">
                <asp:Label ID="lblHeading" runat="server" Text="Polling Day Activity" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel101" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <center>
                        <asp:HiddenField ID="hfDistId" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfLbType" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfLbId" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfMaleCnt" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfFemaleCnt" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfOtherCnt" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hfTotal" runat="server"></asp:HiddenField>
                <table style="width: 700px;text-align:left;">
                    <tr>
                         <td class="auto-style8">
                            <asp:Label runat="server" ID="Label2" Text="Local Body Type:"></asp:Label></td>
                        </td>
                    <td>
                        <asp:Label runat="server" ID="lbllbtype" ></asp:Label></td>
                    </td>
                        <td>
                        </td>
                    </tr>

                    <tr style="height: 10px">
                        <td class="auto-style8"></td>
                    </tr>
                                      <tr>
                        <td class="auto-style8">
                            <asp:Label runat="server" ID="lblAmount" Text="Local Body Name:"></asp:Label></td>
                        </td>
                    <td>
                        <asp:Label runat="server" ID="lblLbName"></asp:Label></td>
                    </td>
                        <td>
                        </td>
                    </tr>
                   
                    <tr style="height: 10px">
                        <td class="auto-style8"></td>
                    </tr>
                                      <tr>
                        <td class="auto-style8">
                            <asp:Label runat="server" ID="Label1" Text="Ward:"></asp:Label></td>
                        </td>
                    <td>
                        <asp:Label runat="server" ID="lblWard"></asp:Label></td>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style8"></td>
                    </tr>
                                      <tr>
                        <td class="auto-style8">
                            <asp:Label runat="server" ID="Label4" Text="Booth:"></asp:Label></td>
                        </td>
                    <td>
                        <asp:Label runat="server" ID="lblBooth"></asp:Label></td>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style8"></td>
                    </tr>
                                      <tr>
                        <td class="auto-style8">
                            <asp:Label runat="server" ID="Label3" Text="Total :"></asp:Label> <asp:Label runat="server" ID="lblt" ></asp:Label></td>
                        </td>
                    <td>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label></td>
                    </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td class="auto-style8"></td>
                    </tr>
                    </table>
                        <table style="border-style: ridge; border-color: inherit; border-width: thin; width: 818px; text-align:left; ">
                            <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
                              <tr>
                         <td class="auto-style7" >
                            <asp:Label runat="server" ID="Label5" Text="Time"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:Label runat="server" ID="Label6" Text="Male" ></asp:Label></td>
                        <td class="auto-style6">
                            <asp:Label runat="server" ID="Label7" Text="Female"></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="Label8" Text="Other"></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="Label9" Text="Total Voters" ></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="Label10" Text="Percentage" ></asp:Label></td>
                        
                    </tr> <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
                            <tr>
                         <td class="auto-style7" >
                            <asp:Label runat="server" ID="RT11" Text="7:30 to 9:30" ></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="RT12" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal1(this)"></asp:TextBox></td>
                        <td class="auto-style6">
                            <asp:TextBox ID="RT13" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal1(this)"></asp:TextBox></td>
                                <td>
                            <asp:TextBox ID="RT14" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal1(this)"></asp:TextBox></td>
                                <td>
                            <asp:Label runat="server" ID="RT15" ></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="RT16"  ></asp:Label></td>
                    </tr> <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
 <tr>
                         <td class="auto-style7" >
                            <asp:Label runat="server" ID="RT21" Text="7:30 to 11:30"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="RT22" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal2(this)"></asp:TextBox></td>
                        <td class="auto-style6">
                            <asp:TextBox ID="RT23" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal2(this)"></asp:TextBox></td>
                                <td>
                            <asp:TextBox ID="RT24" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal2(this)"></asp:TextBox></td>
                                <td>
                            <asp:Label runat="server" ID="RT25" ></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="RT26"  ></asp:Label></td>
                    </tr> <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>

                             <tr>
                         <td class="auto-style7" >
                            <asp:Label runat="server" ID="RT31" Text="7:30 to 1:30"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="RT32" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal3(this)"></asp:TextBox></td>
                        <td class="auto-style6">
                            <asp:TextBox ID="RT33" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal3(this)"></asp:TextBox></td>
                                <td>
                            <asp:TextBox ID="RT34" runat="server" Width="80px" MaxLength="4" Text="0" onkeypress="return numbersonly(this,event)" onchange="calulateTotal3(this)"></asp:TextBox></td>
                                <td>
                            <asp:Label runat="server" ID="RT35" ></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="RT36"  ></asp:Label></td>
                    </tr>
                             <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
                             <tr>
                         <td class="auto-style7" >
                            <asp:Label runat="server" ID="RT41" Text="7:30 to 3:30"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="RT42" runat="server" Width="80px" MaxLength="4" onkeypress="return numbersonly(this,event)" onchange="calulateTotal4(this)"></asp:TextBox></td>
                        <td class="auto-style6">
                            <asp:TextBox ID="RT43" runat="server" Width="80px" MaxLength="4" onkeypress="return numbersonly(this,event)" onchange="calulateTotal4(this)"></asp:TextBox></td>
                                <td>
                            <asp:TextBox ID="RT44" runat="server"  Width="80px" MaxLength="4" onkeypress="return numbersonly(this,event)" onchange="calulateTotal4(this)"></asp:TextBox></td>
                                <td>
                            <asp:Label runat="server" ID="RT45" ></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="RT46"  ></asp:Label></td>
                    </tr> <tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
                             <tr>
                         <td class="auto-style7" >
                            <asp:Label runat="server" ID="RT51" Text="7:30 to 5:30"></asp:Label></td>
                   <td class="auto-style5">
                        <asp:TextBox ID="RT52" runat="server"  Width="80px" MaxLength="4" onkeypress="return numbersonly(this,event)" onchange="calulateTotal5(this)"></asp:TextBox></td>
                        <td class="auto-style6">
                            <asp:TextBox ID="RT53" runat="server" Width="80px"  MaxLength="4" onkeypress="return numbersonly(this,event)" onchange="calulateTotal5(this)"></asp:TextBox></td>
                                <td>
                            <asp:TextBox ID="RT54" runat="server"  Width="80px" MaxLength="4" onkeypress="return numbersonly(this,event)" onchange="calulateTotal5(this)"></asp:TextBox></td>
                                <td>
                            <asp:Label runat="server" ID="RT55" ></asp:Label></td>
                                <td>
                            <asp:Label runat="server" ID="RT56"  ></asp:Label></td>
                    </tr><tr style="height: 10px">
                        <td class="auto-style7"></td>
                    </tr>
                            </table>
                        <table style="width: 700px;text-align:left;">
                    <tr>
                        <%--<td class="auto-style1"></td>
                        <td class="auto-style9"></td>--%>
                        <td style="text-align: center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="sub" runat="server" OnClick="btnSubmit_Click" />
                            
                        <%--<asp:Button Text="Back" ID="btnback" CssClass="btn btn-default" runat="server" OnClick="btnback_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-default" runat="server" OnClick="btnClear_Click" />--%>
                        </td>
                    </tr>
                </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <div>
        <div class="borderOuter-div-AddCandidte" style="overflow: auto">
            <div id="dvGrid" style="height: auto; width: 100%;" align="center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvPollingData" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True"
                            PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanging="gvPollingData_SelectedIndexChanging">
                            <Columns>
                                <%--<asp:BoundField HeaderText="FundID" DataField="FundID" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="70px" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField HeaderText="FromWhom" DataField="FromWhom" ItemStyle-Width="60px" />
                                <asp:BoundField HeaderText="FundType" DataField="FundType" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="PaidBy" DataField="PaidBy" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="CheckNo" DataField="CheckNo" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Provider BankName" DataField="ProviderBankName" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Provider Name" DataField="ProviderName" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" ItemStyle-Width="70px" />
                                <asp:BoundField HeaderText="IsActive" DataField="IsActive" ItemStyle-Width="70px" />--%>

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
                        <asp:AsyncPostBackTrigger ControlID="gvPollingData" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <head>
        <title></title>
        <script>
            function numbersonly(evt) {
                //debugger;
                var charCode = (evt.fwhich) ? evt.which : event.keyCode;
                if (charCode != 46 && charCode > 31
                        && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }

           
            function calulateTotal1(evt) {
                //debugger;
                var m = document.getElementById("<%=RT12.ClientID%>").value;
                var f = document.getElementById("<%=RT13.ClientID%>").value;
                var o = document.getElementById("<%=RT14.ClientID%>").value;
                var wTot = document.getElementById("<%=hfTotal.ClientID%>").value;

                var mc = document.getElementById("<%=hfMaleCnt.ClientID%>").value;
                var fc = document.getElementById("<%=hfFemaleCnt.ClientID%>").value;
                var oc = document.getElementById("<%=hfOtherCnt.ClientID%>").value;

                var z = 0;
                if (+mc >= +m && +fc >= +f && +oc >= +o)
                {
                    var t = +m + +f + +o;
                    var p = (+t / +wTot) * 100;

                    document.getElementById("<%=RT15.ClientID%>").innerText = t.toFixed(2);
                    document.getElementById("<%=RT16.ClientID%>").innerText = p.toFixed(2);

                    return true;
                }
                else {
                    document.getElementById("<%=RT12.ClientID%>").value = z;
                    document.getElementById("<%=RT13.ClientID%>").value = z;
                    document.getElementById("<%=RT14.ClientID%>").value = z;
                    document.getElementById("<%=RT15.ClientID%>").innerText = z;
                    document.getElementById("<%=RT16.ClientID%>").innerText = z;
                    alert('Please Enter Valid Voting Count');
                    return false;
                }
            }
            function calulateTotal2(evt) {
                debugger;
                var m = document.getElementById("<%=RT22.ClientID%>").value;
                var f = document.getElementById("<%=RT23.ClientID%>").value;
                var o = document.getElementById("<%=RT24.ClientID%>").value;

                var m1 = document.getElementById("<%=RT12.ClientID%>").value;
                var f1 = document.getElementById("<%=RT13.ClientID%>").value;
                var o1 = document.getElementById("<%=RT14.ClientID%>").value;

                var wTot = document.getElementById("<%=hfTotal.ClientID%>").value;

                var mc = document.getElementById("<%=hfMaleCnt.ClientID%>").value;
                var fc = document.getElementById("<%=hfFemaleCnt.ClientID%>").value;
                var oc = document.getElementById("<%=hfOtherCnt.ClientID%>").value;
                var z = 0;
                if (+mc >= +m && +fc >= +f && +oc >= +o && (+m >= +m1 || +m == 0) && (+f >= +f1 || +f == 0) && (+o >= +o1 || +o == 0)) {
                    var t = +m + +f + +o;
                    var p = (+t / +wTot) * 100;

                    document.getElementById("<%=RT25.ClientID%>").innerText = t.toFixed(2);
                    document.getElementById("<%=RT26.ClientID%>").innerText = p.toFixed(2);

                    return true;
                }
                else {
                    document.getElementById("<%=RT22.ClientID%>").value = z;
                    document.getElementById("<%=RT23.ClientID%>").value = z;
                    document.getElementById("<%=RT24.ClientID%>").value = z;
                    document.getElementById("<%=RT25.ClientID%>").innerText = z;
                    document.getElementById("<%=RT26.ClientID%>").innerText = z;
                    alert('Please Enter Valid Voting Count');
                    return false;
                }

            }

            function calulateTotal3(evt) {
                debugger;
                var m = document.getElementById("<%=RT32.ClientID%>").value;
                var f = document.getElementById("<%=RT33.ClientID%>").value;
                var o = document.getElementById("<%=RT34.ClientID%>").value;
                var wTot = document.getElementById("<%=hfTotal.ClientID%>").value;
                var mc = document.getElementById("<%=hfMaleCnt.ClientID%>").value;
                var fc = document.getElementById("<%=hfFemaleCnt.ClientID%>").value;
                var oc = document.getElementById("<%=hfOtherCnt.ClientID%>").value;

                var m2 = document.getElementById("<%=RT22.ClientID%>").value;
                var f2 = document.getElementById("<%=RT23.ClientID%>").value;
                var o2 = document.getElementById("<%=RT24.ClientID%>").value;

                var z = 0;
                if (+mc >= +m && +fc >= +f && +oc >= +o && (+m >= +m2 || +m == 0) && (+f >= +f2 || +f == 0) && (+o >= +o2 || +o == 0)) {
                    var t = +m + +f + +o;
                    var p = (+t / +wTot) * 100;

                    document.getElementById("<%=RT35.ClientID%>").innerText = t.toFixed(2);
                    document.getElementById("<%=RT36.ClientID%>").innerText = p.toFixed(2);

                    return true;
                }
                else {
                    document.getElementById("<%=RT32.ClientID%>").value = z;
                    document.getElementById("<%=RT33.ClientID%>").value = z;
                    document.getElementById("<%=RT34.ClientID%>").value = z;
                    document.getElementById("<%=RT35.ClientID%>").innerText = z;
                    document.getElementById("<%=RT36.ClientID%>").innerText = z;
                    alert('Please Enter Valid Voting Count');
                    return false;
                }
                              
            }


            function calulateTotal4(evt) {
                debugger;
                var m = document.getElementById("<%=RT42.ClientID%>").value;
                var f = document.getElementById("<%=RT43.ClientID%>").value;
                var o = document.getElementById("<%=RT44.ClientID%>").value;
                var wTot = document.getElementById("<%=hfTotal.ClientID%>").value;
                var mc = document.getElementById("<%=hfMaleCnt.ClientID%>").value;
                var fc = document.getElementById("<%=hfFemaleCnt.ClientID%>").value;
                var oc = document.getElementById("<%=hfOtherCnt.ClientID%>").value;

                var m3 = document.getElementById("<%=RT32.ClientID%>").value;
                var f3 = document.getElementById("<%=RT33.ClientID%>").value;
                var o3 = document.getElementById("<%=RT34.ClientID%>").value;

                var z = 0;
                if (+mc >= +m && +fc >= +f && +oc >= +o && (+m >= +m3 || +m == 0) && (+f >= +f3 || +f == 0) && (+o >= +o3 || +o == 0)) {
                    var t = +m + +f + +o;
                    var p = (+t / +wTot) * 100;

                    document.getElementById("<%=RT45.ClientID%>").innerText = t.toFixed(2);
                    document.getElementById("<%=RT46.ClientID%>").innerText = p.toFixed(2);

                    return true;
                }
                else {
                    document.getElementById("<%=RT42.ClientID%>").value = z;
                    document.getElementById("<%=RT43.ClientID%>").value = z;
                    document.getElementById("<%=RT44.ClientID%>").value = z;
                    document.getElementById("<%=RT45.ClientID%>").innerText = z;
                    document.getElementById("<%=RT46.ClientID%>").innerText = z;
                    alert('Please Enter Valid Voting Count');
                    return false;
                }
              
            }

            function calulateTotal5(evt) {
                debugger;
                var m = document.getElementById("<%=RT52.ClientID%>").value;
                var f = document.getElementById("<%=RT53.ClientID%>").value;
                var o = document.getElementById("<%=RT54.ClientID%>").value;
                var wTot = document.getElementById("<%=hfTotal.ClientID%>").value;
                var mc = document.getElementById("<%=hfMaleCnt.ClientID%>").value;
                var fc = document.getElementById("<%=hfFemaleCnt.ClientID%>").value;
                var oc = document.getElementById("<%=hfOtherCnt.ClientID%>").value;

                var m4 = document.getElementById("<%=RT42.ClientID%>").value;
                var f4 = document.getElementById("<%=RT43.ClientID%>").value;
                var o4 = document.getElementById("<%=RT44.ClientID%>").value;

                var z = 0;
                if (+mc >= +m && +fc >= +f && +oc >= +o && (+m >= +m3 || +m == 0) && (+f >= +f3 || +f == 0) && (+o >= +o3 || +o == 0)) {
                    var t = +m + +f + +o;
                    var p = (+t / +wTot) * 100;

                    document.getElementById("<%=RT55.ClientID%>").innerText = t.toFixed(2);
                    document.getElementById("<%=RT56.ClientID%>").innerText = p.toFixed(2);

                    return true;
                }
                else {
                    document.getElementById("<%=RT52.ClientID%>").value = z;
                    document.getElementById("<%=RT53.ClientID%>").value = z;
                    document.getElementById("<%=RT54.ClientID%>").value = z;
                    document.getElementById("<%=RT55.ClientID%>").innerText = z;
                    document.getElementById("<%=RT56.ClientID%>").innerText = z;
                    alert('Please Enter Valid Voting Count');
                    return false;
                }
            }
        </script>
    </head>
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }

        .auto-style5 {
            width: 144px;
        }

        .auto-style6 {
            width: 164px;
        }

        .auto-style7 {
            width: 188px;
        }

        .auto-style8 {
            width: 294px;
        }
        .auto-style9 {
            width: 120px;
        }
    </style>
</asp:Content>
