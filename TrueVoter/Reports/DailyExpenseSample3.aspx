<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyExpenseSample3.aspx.cs" Inherits="TrueVoter.Reports.DailyExpenseSample3" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">
    <div class="borderOuter-div-Form1" id="divForPrint">
        <asp:Panel ID="Panel1" runat="server">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="नमुना-३" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>        
            <div>
                <center>
                <table style="width:80%">
                    <tr>
                        <td style="font-size:large">
                            निवडणूक आयोगाच्या सुचने नुसार, नामनिर्देश फॉर्म भरल्या पासून प्रत्येक उमेदवाराला त्याचा निवडणुकी संबंधित खर्च TRUE VOTER app द्वारे दररोज नियमित भरून दुसऱ्या दिवशी निवडणूक अधिकाऱ्याला फक्त प्रपत्र 1 ची प्रिंट काढून व व्हावचार व बिलाच्या सत्य प्रतीसोबत निवडणूक अधिकाऱ्याकडे सादर करावयाचा आहे. 

                            प्रपत्र 2, 3, 4 हे सर्वांत शेवटी निवडणूक ताखेपासून एक मही न्याच्या आत आपल्या नातेवाईकांनी मित्रांनी पार्टीने केलेल्या व इतर खर्चासह एकत्रित पणे सादर करावयाचे आहे.

                            निवडणूक तारखेपर्यंत फक्त रोज प्रपत्र 1 सादर करणे गरजेचे आहे

                            निवडणूक आयोगाचे आदेश डाउनलोड करण्याची सुविधा दिलेली आहे.
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:center">
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnOrder1" runat="server" Text="ORDER ABOUT USE OF TRUE VOTER APP FOR FILLING DAILY EXPENSES" OnClick="lnkbtnOrder1_Click" ForeColor="Blue"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnOrder2" runat="server" Text="ORDER NO:1 ABOUT DAILY DAILY EXPENSES" OnClick="lnkbtnOrder2_Click" ForeColor="Blue"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnOrder3" runat="server" Text="ORDER NO:2 ABOUT DAILY DAILY EXPENSES" OnClick="lnkbtnOrder3_Click" ForeColor="Blue"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:button text="Next" ID="btnNext" CssClass="btn btn-default" runat="server" OnClick="btnNext_Click" /><br /><br />
                        </td>
                    </tr>
                </table>
                    </center>
            </div>
        </asp:Panel>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <%--<div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading1" runat="server" Text="नमुना-३" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
            </div>--%>
                <div class="form-group">
                    <div align="center">
                        <table style="width: 709px; display: none">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblCanName" Text="Enter Name"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ControlToValidate="txtName" ErrorMessage="Enter your Name" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblNomidate" Text="Enter Nomination Date"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtNomiDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ControlToValidate="txtNomiDate" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblElectionDt" Text="Enter Election Date"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txteletionDt" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="sub" ControlToValidate="txteletionDt" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblResult" Text="Enter Result Date"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtresultDt" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="sub" ControlToValidate="txtresultDt" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblAget" Text="Enter Your Age"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtAge" runat="server" MaxLength="3" placeholder="Your Age" CssClass="form-control" onkeypress="return numbersonly(this,event)"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="sub" ControlToValidate="txtAge" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblFatherNames" Text="Enter Your Father Name"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtfathername" runat="server" placeholder="Your Father Name" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="sub" ControlToValidate="txtfathername" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblOrderNos" Text="Enter Election Order No"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtOrderNo" runat="server" placeholder="Election Order No." CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="sub" ControlToValidate="txtOrderNo" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblplaceee" Text="Enter Place"></asp:Label></td>
                                <td class="auto-style3">:</td>
                                <td>
                                    <asp:TextBox ID="txtplaces" runat="server" placeholder="Enter Place" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="sub" ControlToValidate="txtplaces" ForeColor="Red" ErrorMessage="Enter your Name" Text="*"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 10px">
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style2"></td>
                                <td class="auto-style3"></td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="sub" OnClientClick="return validate();" CssClass="btn btn-default" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Admin/Home" CssClass="btn btn-default" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div align="center">
                   <div style="height: 15px;">
                        <input type="button" id="btnPrint" value="Print" onclick="return Print();" />
                    </div>
                    <table>
                        <tr>
                            <td align="center"><strong>नमुना-३</strong></td>
                        </tr>
                        <tr>
                            <td align="center"><strong>उमेदवाराचे शपथपत्र</strong><br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 30px">
                                <asp:Label ID="lblsam1" runat="server" Text="मी नावे"></asp:Label>&nbsp;<asp:Label ID="lblname" runat="server" Font-Size="Larger" Font-Bold="true"></asp:Label>&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="वडीलाचे/पतीचे नाव"></asp:Label>&nbsp;
                            <asp:Label ID="lblfathername" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label6" runat="server" Text="वय"></asp:Label>&nbsp;
                            <asp:Label ID="lblAge" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label7" runat="server" Text="वर्ष, राहणार"></asp:Label>&nbsp;
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label8" runat="server" Text="याद्वारे गांर्भीयपूर्वक व मनपूर्वक पुढीलप्रमाणे या शपथपत्राद्वारे जाहिर करतो आहे की,"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="Label9" runat="server" Text="1.मी"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblname2" runat="server" Font-Size="Larger" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                            <%--<asp:Label ID="Label10" runat="server" Text="महानगरपालिका/नगरपालिका/नगरपंचायत/ जिल्हापरिषद/पंचायत समितीच्या"></asp:Label>--%>&nbsp;
                            <asp:Label ID="Label10" runat="server" Text=", "></asp:Label>
                            <asp:Label ID="lblWardNo" runat="server" Font-Size="Larger" Font-Bold="true"></asp:Label>&nbsp;
                            <asp:Label ID="Label11" runat="server" Text="प्रभाग क्रमांक/गट/ गण मधुन सार्वत्रिक /पोट निवडणूक दिनांक"></asp:Label>&nbsp;
                            <asp:Label ID="lblElectiondate" runat="server"></asp:Label>&nbsp;
                            <asp:Label ID="Label12" runat="server" Text="मधुन निवडणूक लढविली होती व तिचा निकाल" ></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblResultDate" runat="server"></asp:Label>
                                &nbsp; &nbsp;<asp:Label ID="Label13" runat="server" Text="  रोजी घोषित करण्यात आला होता आणि सदर निकालानुसार मी विजयी/पराभूत झालो आहे."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="Label14" runat="server" Text="2.मी / माझ्या प्रतिनिधीने नामनिर्देशन दिनांक"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblNominationDate" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="Label15" runat="server" Text="ते निकाल घोषित करण्यात आलेल्या दिनांक"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblResultDate2" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="Label16" runat="server" Text=", दोन्ही दिवस धरुन; या काळात केलेले सर्व निवडणूक खर्चाचे खरे व बिनचूक हिशोब ठेवलेले आहेत, तसेच खर्चाचे पूरक पुराव्याचे कागद देखील जतन केले आहे."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="Label17" runat="server" Text="3.मी राज्य निवडणूक आयोगाचे आदेश क्र"></asp:Label>.&nbsp;&nbsp;
                            <asp:Label ID="lblOrderNO" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="Label18" runat="server" Text="मधील सर्व निदेशाचे तंतोतंत पालन केलेले आहे."></asp:Label>
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblfour" runat="server" Text="3.मी सादर केलेल्या  खर्चामध्ये कोणतीही बाबत लपवून ठेवलेली नाही किंवा रोखून ठेवलेली नाही."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblfive" runat="server" Text="4.मी स्वत: केलेला खर्च, पक्षाने माझ्यासाठी केलेला खर्च व इतर व्यक्तींनी माझ्यासाठी केलेला खर्च संपूर्णपणे, खरे व अचुकपणे माझ्या एकूण खर्चात अंतर्भूंत केलेला आहे. "></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblsix" runat="server" Text="5.मी निवडणुकीकरिता देणगी, भेटी, कर्ज, पक्ष निधी इत्यादि स्वरुपात गोळा केलेला निधीचा अचूक तपशिल सादर केला आहे.  हा सर्व निधी स्वखुशीने देण्यात आलेला आहे."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblseven" runat="server" Text="6.मी ठेवलेले हिशोबाचे पुस्तके व त्यासंबंधातील खर्चाच्या पृष्ठयार्थ ठेवलेले पावती/बिल/ व्हाऊचर इ. यांच्या मूळ प्रती, मी निवडणूक अधिकारी / निवडणूक निर्णय अधिकारी यांच्या मागणीनुसार पडताळणीसाठी न चुकता व विनाविलंब सादर करील."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lbleight" runat="server" Text="7.मी सादर केलेल्या खर्चाचे दर जर प्रचलित स्थानिक दरापेक्षा कमी असल्यास व त्याबाबत माझा खुलासा ‍ निवडणूक अधिकारी / निवडणूक निर्णय अधिकारी यांना मान्य नसल्यास ; त्यांनी ठरविलेला प्रचलित स्थानिक दराप्रमाणे खर्च मला मान्य असेल."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblnine" runat="server" Text="8.मी पेड न्यूजचा अवलंब केलेला नाही. पण तरीही तशी तक्रार आल्यास, त्याबाबतच्या समितीने घेतलेला निर्णय मला मान्य असेल."></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px">
                                <asp:Label ID="lblten" runat="server" Text="9.मी सादर केलेले निवडणूक खर्च जर, राज्य निवडणूक आयोगाने ठरवून दिलेल्या वेळेमध्ये व आवश्यक रितीने खर्च केले, हिशोब ठेवले अगर नमुन्यात सादर केली नसतील तर मी कारवाईस पात्र असेन याची मला कल्पना आहे."></asp:Label>
                                <br />
                                <br />
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left: 100px">
                                <asp:Label ID="lbllast" runat="server" Text="वरील केलेले विधान हे खरे आहे. या विधानात कोणतीही माहिती खोटी व लपवून ठेवलेली नाही."></asp:Label>
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
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 174px;
        }

        .auto-style3 {
            width: 22px;
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
    <%--<script type="text/javascript">
        $(function () {
            $("#txtNomiDate").datepicker({ dateFormat: "yy/mm/dd" });
        });
    </script>--%>
    <%--<script type="text/javascript">
        document.getElementById("#txtNomiDate").value = Date().toString("yyyy-MM-dd");
    </script>--%>    
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

