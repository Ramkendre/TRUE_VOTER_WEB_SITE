<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/UserSite.Master" CodeBehind="DailyExpenseSample4.aspx.cs" Inherits="TrueVoter.Reports.DailyExpenseSample4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function Print() {
            var mywindow = window.open('', 'PRINT', 'height=800,width=1000');
            mywindow.document.write('<html><head><title>' + document.title + '</title>');
            mywindow.document.write('<style type="text/css">#btnPrint { display: none; }</style>');
            mywindow.document.write('</head><body>');
            mywindow.document.write($("#divPrint").html());
            mywindow.document.write('</body></html>');
            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10*/
            mywindow.print();
            mywindow.close();
            return true;
        }

        function Back() {
            window.location.href = "../Reports/frmHomeUser.aspx";
        }
    </script>
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

        /*#btnPrint {
            float: right;
            font-size: 1.0em !important;
            padding: 3px !important;
            margin-right: 0px !important;
        }*/

        @media print {
            #btnPrint {
                display: none;
            }
        }
    </style>
    <div class="borderOuter-div-Form" id="div1">

        <div class="borderOuter-div-Form" id="divPrint">
            <div class="borderHeading-div">
                <div align="Center" style="font-size: large; font-weight: bold">नमुना-४</div>
            </div>
            <br />
            <div align="Center" style="font-size: large; font-weight: bold">उमेदवार - निधीबाबतचा तपशिल (देणगी, भेट, कर्ज, पक्ष निधी इ.)</div>
            <br />
            <br />
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
                        <td class="auto-style2">दिनांक:</td>
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
            <br />
            <div>
                <asp:GridView ID="gvDonation" CssClass="table table-hover table-bordered" runat="server" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="gvDonation_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="अ.क्र" DataField="FundID" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" DataField="FromText" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="निधीचा प्रकार (देणगी, भेट, कर्ज इ.)" DataField="FundTYpeTxt" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="निधी देणाऱ्याचा नाव व पत्ता" DataField="ProviderName" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="निधी देणाऱ्याचा संपर्क क्रमांक" DataField="MobileNo" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="दिनांक" DataField="Date" ItemStyle-Width="5%" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                        <asp:BoundField HeaderText="रोख/ चेक/ डि.डी. / इतर प्रकारे" DataField="PaidBy" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="देणाऱ्याच्या बँकेचे नाव व शाखा" DataField="ProviderBankName" ItemStyle-Width="5%"></asp:BoundField>
                        <asp:BoundField HeaderText="रक्कम" DataField="Amount" ItemStyle-Width="5%"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <table>
                    <tr>
                        <td style="padding-left: 10px">
                            <asp:Label ID="lbldateDetails" runat="server" Text="दिनांक .............रोजी ...........वा मी निधीबाबतचा तपशिल नमुना ४ सदर करत आहे."></asp:Label>
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
                            <asp:Label ID="lblDailyExpenseSample" runat="server" Text="सदर निधीबाबतचा तपशिल नमुना ४, दिनांक .............रोजी ...........वा मला प्राप्त झाला."></asp:Label>
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
            </div>
        </div>
        <div style="height: 15px;">
            <table style="width: 100%;">
                <tr>
                    <td></td>
                    <td align="right">
                        <input type="button" id="btnback" value="Back" onclick="return Back();" /></td>
                    <td>
                        <input type="button" id="btnPrint" value="Print" onclick="return Print();" /></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
