<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/UserSite.Master" CodeBehind="DailyExpenseSample6.aspx.cs" Inherits="TrueVoter.Reports.DailyExpenseSample6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="borderOuter-div-Form" id="divForPrint">
            <div class="borderHeading-div">
               
                <div align="Center" style="font-size: large; font-weight: bold">नमुना-६</div>
            </div> 
                <%-- <div style="height: 9px"></div>--%>
            <br />
                <div align="Center" style="font-size: large; font-weight: bold">पक्षाने केलेला सर्व सामान्य निवडणुकीचा खर्च</div>
               <br />
               <%--  <div style="height: 9px"></div>--%>
            <div class="form-group">
                <asp:GridView ID="gvPartyExpense" CssClass="table table-hover table-bordered" runat="server" OnDataBound="gvPartyExpense_DataBound"  AutoGenerateColumns="false" ShowFooter="true">
                    <Columns>
                        <asp:BoundField HeaderText="अ.क्र" DataField="Id" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="खर्चाची मुख्य बाब" DataField="ExpenseHead" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="खर्चाची आंतर बाब" DataField="SubExpenseHead" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="तपशिल" DataField="Description" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="दिनांक" DataField="ExpenseDate" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="कोण-कोणत्या स्था.स्व.संस्थेच्या निवडणुकीसाठी खर्च केला, त्यांची नावे" DataField="LocalBody" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="खर्चाची रक्कम" DataField="Amount" ItemStyle-Width="5%"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <table>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lbldateDetails" runat="server" Text="दिनांक .............रोजी ...........वा नमुना ६ सादर करित आहे."></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="height: 27px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="Label1" runat="server" Text="पक्षाच्या पदाधिकाऱ्याची सही"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="Label5" runat="server" Text="(सही करणाऱ्याचे नाव, पद)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="Label6" runat="server" Text="पक्षाचे नाव "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblDailyExpenseSample" runat="server" Text="सदर नमुना ६ हा दिनांक . . . . . .  रोजी प्राप्त झाला. "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 27px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="Label2" runat="server" Text="सही"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="lblOfficerSign" runat="server" Text="जिल्हाधिकारी / महापालिका आयुक्त"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="Label3" runat="server" Text="एवं निवडणूक अधिकारी "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 570px; text-align: right">
                        <asp:Label ID="Label4" runat="server" Text="स्थानिक स्वराज्य संस्था"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>टीप : 
                        <asp:Label ID="lblTip1" runat="server" Style="padding-left: 5px" Text="(१)एकूण सर्व सामान्य खर्चाची माहिती स्थानिक स्वराज्य संस्थांनिहाय नमुना 6 मध्ये, निकाल लागल्यापासून 90 दिवसाच्या आत, जिल्हाधिकारी/  महापालिका आयुक्त यांना सादर करावा. सदर नमुना त्यांच्यामार्फत छाननी होऊन राज्य निवडणूक आयोगाकडे अग्रेषित होईल याची खात्री करावी."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 37px">
                        <asp:Label ID="lblTip2" runat="server" Text="(२)सादर करतेवेळी न चुकता पोहोच घ्यावी. सदर पोहोच हि भविष्यात बचावासाठी उपयोगी होऊ शकेल."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 37px">
                        <asp:Label ID="lblTip3" runat="server" Text="(३)ओंनलाईन पद्धतीने पक्षाचा खर्च भरला असल्यास सदर नमुना 6 ऑटोमॅटिक तयार होईल. पक्षाच्या पदाधिकाऱ्याने फक्त नमुना डाऊनलोड करून, तपासून,  प्रिंट करून, सही करून, (१) प्रमाणे सादर करावा."></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    <div align="center" style="height: 15px;">
        <input type="button" id="btnPrint" value="Print" onclick="return Print();" />
    </div>
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
    </asp:Content>
   
