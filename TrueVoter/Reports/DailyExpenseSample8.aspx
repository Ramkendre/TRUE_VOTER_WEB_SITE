<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyExpenseSample8.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.DailyExpenseSample8" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div class="borderOuter-div-Form1" id="divForPrintno">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading1" runat="server" Text="नमुना-8" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>

        <div align="center" id="divForPrint">
            <table>
                <tr>
                    <td align="center"><strong>नमुना-8</strong></td>
                </tr>
                <tr>
                    <td align="center"><strong>राजकीय पक्षाचे शपथपत्र</strong><br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 30px">
                        <asp:Label ID="lblsam1" runat="server" Text="मी नावे"></asp:Label>&nbsp;<asp:Label ID="lblname" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="वडीलाचे/पतीचे नाव"></asp:Label>&nbsp;
                            <asp:Label ID="lblfathername" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label6" runat="server" Text="वय"></asp:Label>&nbsp;
                            <asp:Label ID="lblAge" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label7" runat="server" Text="वर्ष, राहणार"></asp:Label>&nbsp;
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label8" runat="server" Text="राजकीय पक्षाचा"></asp:Label>&nbsp;
                        <asp:Label ID="lblPartyName" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="Label17" runat="server" Text="पदाधिकारी असून पक्षाचे मुख्य कार्यालय "></asp:Label><asp:Label ID="lblPartyOfficeAdd" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="Label19" runat="server" Text="पत्यावर आहे. मी या शपथपत्राद्वारे पक्षातर्फे, पक्षाने मला प्राधिकृत केले असल्याने, मी गांर्भीयपूर्वक व मनपूर्वक पक्षातर्फे पुढीलप्रमाणे जाहिर करतो आहे की,"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblfour" runat="server" Text="1.पक्षातर्फे नामनिर्देशन पत्र भरणाऱ्या स्था. स्व. संस्थानिहाय उमेदवारांची यादी प्रपत्र 5 प्रमाणे दिली आहे. सदर यादी व त्यातील तपशिल अचूक व बरोबर आहे.  या सर्व उमेदवारांना पक्षातर्फे निवडणूक लढविण्यासाठी प्रपत्र-अ व प्रपत्र-ब देण्यात आले होते."></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblfive" runat="server" Text="2.माझ्या पक्षाने स्था. स्व. सं. निहाय निवडणुकीसाठी केलेला सामान्य खर्च प्रपत्र 6 प्रमाणे अचूक  दिलेला आहे. पक्षाने केलेले सर्व निवडणूक खर्चाचे खरे व बिनचूक हिशोब ठेवलेले आहेत, तसेच खर्चाचे पूरक पुराव्याचे कागद देखील जतन केलेले आहेत."></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblsix" runat="server" Text="3.माझ्या पक्षाने उमेदवारनिहाय,  उमेदवारांच्या निवडणूक प्रचारासाठी केलेला खर्च हा प्रपत्र 7 प्रमाणे अचूक दिलेला आहे. पक्षाने केलेले सर्व निवडणूक खर्चाचे खरे व बिनचूक हिशोब ठेवलेले आहेत, तसेच खर्चाचे पूरक पुराव्याचे कागद देखील जतन केलेले आहेत."></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblseven" runat="server" Text="4.माझ्या पक्षाने राज्य निवडणूक आयोगाचे आदेश क्र........... मधील सर्व निदेशाचे तंतोतंत पालन केलेले आहे."></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lbleight" runat="server" Text="5.माझ्या पक्षाने सादर केलेल्या  खर्चामध्ये कोणतीही बाबत लपवून ठेवलेली नाही किंवा रोखून ठेवलेली नाही.  "></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblnine" runat="server" Text="6.माझ्या पक्षाने केलेला सर्वसामान्य खर्च व उमेदवारनिहाय खर्च (उचित प्रमाणात विभाजीत (Directly divided between them) व संविभाजीत ( Indirectly Apportioned between them)) सादर केलेला असून, तो संपूर्ण, खरा व अचुकपणे नमुन्यात अंतर्भूंत केलेला आहे. "></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lblten" runat="server" Text="7.माझ्या पक्षाने ठेवलेले हिशोबाची पुस्तके व त्यासंबंधातील खर्चाच्या पृष्ठयार्थ ठेवलेले पावती/बिल/ व्हाऊचर इ. यांच्या मूळ प्रती; मी अगर प्रतिनिधी हा,  जिल्हाधिकारी/ महापालिका आयुक्त  यांच्या मागणीनुसार पडताळणीसाठी न चुकता व विनाविलंब सादर करु."></asp:Label>
                        <br />
                        <br />
                    </td>

                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lbllast" runat="server" Text="8.माझ्या पक्षाने पेड न्यूजचा अवलंब केलेला नाही. पण तरीही तशी तक्रार आल्यास, त्याबाबत समितीने पक्षाचे म्हणने ऐकून घेतलेला निर्णय माझ्या पक्षाला मान्य असेल."></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="Label9" runat="server" Text="9.माझ्या पक्षाने सादर केलेले निवडणूक खर्चात तसेच उमेदवाराने सादर केलेल्या खर्चात काही तफावत आढळल्यास, आम्हाला संधी दिल्यानंतर जिल्हाधिकारी/ महापालिका आयुक्त यांनी घेतलेला निर्णय आम्हाला मान्य असेल. "></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="Label10" runat="server" Text="10.जर राज्य निवडणूक आयोगाच्या आदेशाचे पालन झाले नाही तर राज्य निवडणूक आयोग राजकीय पक्ष नोंदणी आदेश 2009 अन्वये माझा पक्ष कारवाई पात्र असेन याची पक्षाला कल्पना आहे."></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="Label11" runat="server" Text="वरील केलेले विधान हे खरे आहे. या विधानात कोणतीही माहिती खोटी व लपवून ठेवलेली नाही. "></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 570px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblsign" runat="server" Text="अभिसाक्षी"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="Label1" runat="server" Text="माझ्या समक्ष दिनांक"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lbltodate" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="रोजी"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblplace" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Text="येथे श्री"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblofficerName" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="यांनी शपथपूर्वक कथन केले आहे."></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div align="center" style="height: 15px;">
        <input type="button" id="btnPrint" value="Print" onclick="return Print();" />
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #btnPrint {
            float:none;
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
       <script type="text/javascript">
        function Print() {
            var divprint = window.open('', 'PRINT', 'height=800,width=1000');
            divprint.document.write('<html><head><title>' + document.title + '</title>');
            divprint.document.write('<style type="text/css">#btnPrint { display: none; }</style>');
            divprint.document.write('</head><body>');
            divprint.document.write($("#divForPrint").html());
            divprint.document.write('</body></html>');
            divprint.document.close(); // necessary for IE >= 10
            divprint.focus(); // necessary for IE >= 10*/
            divprint.print();
            divprint.close();
            return true;
        }
    </script>
</asp:Content>
