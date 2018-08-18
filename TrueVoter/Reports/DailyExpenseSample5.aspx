<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/UserSite.Master" CodeBehind="DailyExpenseSample5.aspx.cs" Inherits="TrueVoter.Reports.DailyExpenseSample5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borderOuter-div-Form" id="divForPrint">
        <div class="borderHeading-div">
            <div align="Center" style="font-size: large; font-weight: bold">नमुना-५</div>
        </div>
        <div align="Center" style="font-size: large; font-weight: bold">राजकीय पक्ष - उमेदवारांची यादी</div>
        <%--<div style="height: 9px"></div>
                    <div style="height: 9px"></div>--%>
        <br />
        <br />
        <div style="border: groove">
            <table style="width: 100%; height: 143px;">
                <tr>
                    <td class="auto-style1">पक्षाचे नाव :</td>
                    <td>
                        <asp:Label ID="lblParty" runat="server"></asp:Label></td>
                    <td class="auto-style2">जिल्ह्याचे नाव:</td>
                    <td>
                        <asp:Label ID="lblDistrictNm" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1">स्थानिक स्वराज्य संस्थेचे नाव :</td>
                    <td>
                        <asp:Label ID="lblLocalBody" runat="server"></asp:Label></td>
                    <td class="auto-style2">सार्वत्रिक निवडणूक \पोट निवडणूक:</td>
                    <td>
                        <asp:Label ID="lblElection" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1">एकूण लढविलेल्या जागा :</td>
                    <td>
                        <asp:Label ID="lblTotalSeat" runat="server"></asp:Label></td>
                    <td class="auto-style2">मतदानाचा दिनांक:</td>
                    <td>
                        <asp:Label ID="lblVotingDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1">दिनांक:</td>
                    <td>
                        <asp:Label ID="lblDate" runat="server"></asp:Label></td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label9" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div style="height: 9px"></div>
        <div style="height: 9px"></div>
        <div>
            <asp:GridView ID="gridViewPrivew" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="table table-hover table-bordered">
                <Columns>
                    <asp:BoundField HeaderText="अ.क्र" DataField="Id" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="स्थानिक स्वराज्य सस्थेचे नाव" DataField="LocalBodyName" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="प्रभाग /गट" DataField="WardNo" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="जागा / seat क्र" DataField="SeatNo" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="उमेदवाराचे नाव" DataField="CandidateName" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="छाननीत वैध/अवैध" DataField="Verified" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="माघार घेतली/ घेतली नाही" DataField="NomiWithdraw" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="विजयी/ पराभूत" DataField="ElectionResult" ItemStyle-Width="5%"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <table>
            <tr>
                <td style="padding-left: 10px">
                    <asp:Label ID="lbldateDetails" runat="server" Text="दिनांक .............रोजी ...........वा नमुना ५ सादर करित आहे."></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 27px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px">
                    <asp:Label ID="lblDailyExpenseSample" runat="server" Text="सदर नमुना 5 हा दिनांक . . . . .   रोजी प्राप्त झाला. "></asp:Label>
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
                        <asp:Label ID="lblTip1" runat="server" Style="padding-left: 5px" Text="(१)   एकूण उमेदवारांची माहिती स्थानिक स्वराज्य संस्थांनिहाय नमुना 5 मध्ये, निकाल लागल्यापासून 90 दिवसाच्या आत, जिल्हाधिकारी/  महापालिका आयुक्त यांना सादर करावा. सदर नमुना त्यांच्यामार्फत छाननी होऊन राज्य निवडणूक आयोगाकडे अग्रेषित होईल याची खात्री करावी."></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 37px">
                    <asp:Label ID="lblTip2" runat="server" Text="(२) सादर करतेवेळी न चुकता पोहोच घ्यावी. सदर पोहोच हि भविष्यात बचावासाठी उपयोगी होऊ शकेल."></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 37px">
                    <asp:Label ID="lblTip3" runat="server" Text="(३) ओंनलाईन पद्धतीने पक्षाच्या सर्व उमेदवाराने नामनिर्देशन पत्र भरले असल्यास सदर नमुना 5 ऑटोमॅटिक तयार होईल. पक्षाच्या पदाधिकाऱ्याने फक्त नमुना डाऊनलोड करून, तपासून,  प्रिंट करून, सही करून, (१) प्रमाणे सादर करावा."></asp:Label>
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
