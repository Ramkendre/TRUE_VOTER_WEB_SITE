<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyExpenseSample1.aspx.cs" Inherits="TrueVoter.Reports.DailyExpenseSample1" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div class="borderOuter-div-Form1" id="divForPrint">
        <div align="center">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="borderHeading-div">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="Daily Expense" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <table>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDate" Text="Select Date"></asp:Label></td>
                                <td>:</td>
                                <td class="auto-style4" id="Date">
                                    <asp:TextBox ID="txtDate" TextMode="Date" Width="300px" Height="34px"  runat="server" ValidationGroup="sub"  placeholder="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="Enter ten digit Number" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td>
                                    
                                </td>
                            </tr>
                        </table>
                        <div class="form-group">
                            <asp:Button ID="btnShowGrid" runat="server" Width="103px" Height="36px" OnClick="btnShowGrid_Click" Text="Show Data" ValidationGroup="sub" CssClass="btn btn-default" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnBack" runat="server" Text="Back" Width="103px" Height="36px" OnClick="btnBack_Click" CssClass="btn btn-default" />
                        </div>
                        <div style="height: 9px"></div>
                        <div style="height: 9px"></div>
                        <div>
                            <asp:GridView ID="gridViewPrivew" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-hover table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="PK_Id" HeaderText="अ.क्र" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date" HeaderText="खर्चाचा दिनांक" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ExpenseType" HeaderText="खर्चाची मुख्य बाब" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SubExpenseType" HeaderText="खर्चाची आंतर बाब" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty_Size_Area" HeaderText="संख्या/क्षेत्रफळ/दिवस" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rate" HeaderText="प्रति दर" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PaymentMode" HeaderText="चेक/ रोखीने" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InvoiceNo" HeaderText="पावती" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SourceOfExpense" HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalExpense" HeaderText="एकूण खर्च" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#33adff" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                <EmptyDataTemplate>Nil Expenses</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div style="height: 9px"></div>
                        <div style="height: 9px"></div>
                        <div>
                            <asp:Button ID="btnFinalPrint" runat="server" OnClick="btnFinalPrint_Click" Text="Print" Visible="false" CssClass="btn btn-default" OnClientClick="return confirm('Ones you Print these record You can not change them. Do you want to Print?')" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancle" runat="server" Text="Back" OnClick="btnBack_Click" Visible="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewPDF" runat="server">
                    <div style="height: 15px;">
                        <input type="button" id="btnPrint" value="Print" onclick="return Print();" />
                    </div>
                    <br />
                    <div style="height: 9px"></div>
                    <div align="Center" style="font-size: large; font-weight: bold">नमुना-१</div>
                    <div style="height: 9px"></div>
                    <div align="Center" style="font-size: large; font-weight: bold">उमेदवार - दैनंदिन निवडणूक खर्च</div>
                    <div style="height: 9px"></div>
                    <div style="height: 9px"></div>
                    <div style="border: groove">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style1">उमेदवाराचे नाव :</td>
                                <td>
                                    <asp:Label ID="lblcandidateName" runat="server"></asp:Label></td>
                                <td class="auto-style2">जिल्ह्याचे नाव:</td>
                                <td>
                                    <asp:Label ID="lblDistrictNm" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">पक्षाचे नाव :</td>
                                <td>
                                    <asp:Label ID="lblParty" runat="server"></asp:Label></td>
                                <td class="auto-style2">सार्वत्रिक\पोट निवडणूक:</td>
                                <td>
                                    <asp:Label ID="lblElection" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">स्थानिक स्वराज्य संस्थेचे नाव :</td>
                                <td>
                                    <asp:Label ID="lblLocalBodyId" runat="server"></asp:Label></td>
                                <td class="auto-style2">मतदानाचा दिनांक:</td>
                                <td>
                                    <asp:Label ID="lblVotingDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">प्रभाग/गण/गट क्रमांक :</td>
                                <td>
                                    <asp:Label ID="lblWardNo" runat="server"></asp:Label></td>
                                <td class="auto-style2">खर्चाचा दिनांक:</td>
                                <td>
                                    <asp:Label ID="lblExpenseDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">जागा / seat  क्र :</td>
                                <td>
                                    <asp:Label ID="lblSeat" runat="server"></asp:Label></td>
                                <td class="auto-style2">&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label9" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                    <div style="height: 9px"></div>
                    <div style="height: 9px"></div>
                    <div>
                        <asp:GridView ID="gvDaillyExpenses" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false" ShowFooter="true" CssClass="table table-hover table-bordered">
                            <Columns>
                                <asp:BoundField HeaderText="अ.क्र" DataField="PK_Id" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="खर्चाची मुख्य बाब" DataField="ExpenseType" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="खर्चाची आंतर बाब" DataField="SubExpenseType" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="संख्या/क्षेत्रफळ/दिवस" DataField="Qty_Size_Area" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="प्रति दर" DataField="Rate" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="चेक/ रोखीने" DataField="PaymentMode" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="पावती" DataField="InvoiceNo" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" DataField="SourceOfExpense" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="पक्षाचा की/ इतर व्यक्तीचा नाव" DataField="PartyName" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="पक्षाचा केलेल्या खर्चाच्या बाबत मोबाईल" DataField="PartyNo" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="एकूण खर्च" DataField="TotalExpense" ItemStyle-Width="5%"></asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>Nil Expenses</EmptyDataTemplate>
                        </asp:GridView>
                        <%--<div align="right">
                                    <table style="padding-right:25px">
                                        <tr>
                                            <td style="text-align: left;padding-right:30px ;font-weight:bold">
                                                <asp:Label ID="lbltxtTotal" runat="server" Text="एकूण:"></asp:Label>
                                            </td>
                                            <td style="text-align: left; padding-right:25px">
                                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>
                    </div>
                    <div style="height: 9px"></div>
                    <table>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lbldateDetails" runat="server" Text="दिनांक .............रोजी ...........वा मी दैनंदिन खर्चाचा नमुना १ सदर करत आहे."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 27px"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="lblSignatureCandidate" runat="server" Text="उमेदवाराची सही"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblDailyExpenseSample" runat="server" Text="सदर दैनंदिन खर्चाचा नमुना १, दिनांक .............रोजी ...........वा मला प्राप्त झाला."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 27px"></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 570px">
                                <asp:Label ID="lblOfficerSign" runat="server" Text="सही निवडणूक निर्णय अधिकारी प्रभाग / गण / गट .......स्थानिक स्वराज्य संस्था "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>टीप : 
                        <asp:Label ID="lblTip1" runat="server" Style="padding-left: 5px" Text="(१)  दररोज खर्च नोंदवून सदर नमुना १ दुसऱ्या दिवशी दुपार २ वाजे पर्यंत निवडणूक निर्णय अधिकारी यांना सादर करावा."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 37px">
                                <asp:Label ID="lblTip2" runat="server" Text="(2)  सादर करतेवेळी उमेदवाराने न चुकता पोहोच घ्यावी. सदर पोहोच हि भविष्यात उमेदवाराला बचावासाठी उपयोगी होऊ शकेल."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 37px">
                                <asp:Label ID="lblTip3" runat="server" Text="(३)  ओंन लाईन पद्धतीने खर्च भरल्यास सदर नमुना ऑटोमॅटिक तयार होईल. उमेदवाराने फक्त नमुना डाऊनलोड करून, तपासून, प्रिंट करून, सही करून, (१) प्रमाणे सादर करावा."></asp:Label>
                            </td>
                        </tr>
                    </table>

                </asp:View>
            </asp:MultiView>
        </div>
        <div>
        </div>
    </div>

     <script type="text/javascript">
         $(document).ready(function () {
             $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
             //$("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
         });
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 144px;
        }

        .auto-style2 {
            width: 151px;
        }

        .auto-style3 {
            width: 164px;
        }

        .auto-style4 {
            width: 389px;
        }

        #btnPrint {
            float: right;
            font-size: 1.0em !important;
            padding: 3px !important;
            margin-right: 0px !important;
        }

        @media print {
            #btnPrint {
                display: none;
            }
        }
    </style>
    \
   <script type="text/javascript">
       function Print() {
           var mywindow = window.open('', 'PRINT', 'height=800,width=1000');
           mywindow.document.write('<html><head><title>' + document.title + '</title>');
           mywindow.document.write('<style type="text/css">#btnPrint { display: none; }</style>');
           mywindow.document.write('</head><body>');
           mywindow.document.write($("#divForPrint").html());
           mywindow.document.write('</body></html>');
           mywindow.document.close(); // necessary for IE >= 10
           mywindow.focus(); // necessary for IE >= 10*/
           mywindow.print();
           mywindow.close();
           return true;
       }
   </script>

    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function Date() {
            $("#Date").datepicker();
        });
    </script>
</asp:Content>
