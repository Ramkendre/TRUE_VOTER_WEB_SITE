<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyExpenseSample2.aspx.cs" Inherits="TrueVoter.Reports.DailyExpenseSample2" MasterPageFile="~/MasterPages/UserSite.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="BodyContent" runat="server">

    <div class="borderOuter-div-Form1" id="divForPrint">
        <div align="center">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="borderHeading-div">
                        <div>
                            नमुना-2
                        </div>
                    </div>

                    <center>               
                <div>
                     <asp:Panel ID= "Panel2"  runat = "server">
                   <table id="TableData" style="width:80%">
                        <tr>
                            <td style="font-size:large">
                                        निवडणूक आयोगाच्या सुचने नुसार, नामनिर्देश फॉर्म भरल्या पासून प्रत्येक उमेदवाराला त्याचा निवडणुकी संबंधित खर्च TRUE VOTER app द्वारे दररोज नियमित भरून दुसऱ्या दिवशी निवडणूक अधिकाऱ्याला फक्त प्रपत्र 1 ची प्रिंट काढून व व्हावचार व बिलाच्या सत्य प्रतीसोबत निवडणूक अधिकाऱ्याकडे सादर करावयाचा आहे. 

                                        प्रपत्र 2, 3, 4 हे सर्वांत शेवटी निवडणूक ताखेपासून एक मही न्याच्या आत आपल्या नातेवाईकांनी मित्रांनी पार्टीने केलेल्या व इतर खर्चासह एकत्रित पणे सादर करावयाचे आहे.

                                        निवडणूक तारखेपर्यंत फक्त रोज प्रपत्र 1 सादर करणे गरजेचे आहे

                                        निवडणूक आयोगाचे आदेश डाउनलोड करण्याची सुविधा दिलेली आहे.
                                              <br />
                                        <br />
                                 </td>
                                </tr>
                        <tr>
                            <td style="text-align:center">
                                        <asp:LinkButton ID="lnkbtnOrder1" runat="server" Text="ORDER ABOUT USE OF TRUE VOTER APP FOR FILLING DAILY EXPENSES" OnClick="lnkbtnOrder1_Click" ForeColor="Blue"></asp:LinkButton>
                                        <br />
                                        <br />
                                        <asp:LinkButton ID="lnkbtnOrder2" runat="server" Text="ORDER NO:1 ABOUT DAILY DAILY EXPENSES" OnClick="lnkbtnOrder2_Click" ForeColor="Blue"></asp:LinkButton>
                                        <br />
                                        <br />
                                        <asp:LinkButton ID="lnkbtnOrder3" runat="server" Text="ORDER NO:2 ABOUT DAILY DAILY EXPENSES" OnClick="lnkbtnOrder3_Click" ForeColor="Blue"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:button text="Next" ID="btnNext" CssClass="btn btn-default" runat="server" OnClick="btnNext_Click" />
                      </td>
                        </tr>   
                    </table>
                     </asp:Panel>
                    <br />
                </div>
                     </center>
                    <div class="form-group">
                        <asp:Panel ID="Panel1" runat="server">

                            <table id="TableForm" style="width: 539px">
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label runat="server" ID="lblMobNo" Text="Enter Mobile No"></asp:Label></td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtLoginMobile" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ControlToValidate="txtLoginMobile" ErrorMessage="Enter ten digit Number" Text="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td></td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblDate" Text="Select Date:"></asp:Label></td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                                    </td>
                                </tr>--%>

                                <tr>
                                    <td class="auto-style4"></td>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="sub" OnClick="btnSubmit_Click" CssClass="btn btn-default" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </asp:View>
                <asp:View ID="ViewPDF" runat="server">
                    <div style="height: 15px;">
                        <input type="button" id="btnPrint" value="Print" onclick="return Print();" />
                    </div>
                    <br />
                    <div style="height: 9px"></div>
                    <div align="Center" style="font-size: large; font-weight: bold">नमुना-2</div>
                    <div style="height: 9px"></div>
                    <div align="Center" style="font-size: large; font-weight: bold">उमेदवार - एकूण निवडणूक खर्च</div>
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
                    <div style="height: 9px"></div>
                    <div style="height: 9px"></div>
                    <div>
                        <asp:GridView ID="gvDaillyExpenses" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="table table-hover table-bordered">
                            <%--OnDataBound="gvDaillyExpenses_DataBound"--%>
                            <Columns>
                                <asp:BoundField HeaderText="अ.क्र" DataField="PK_Id" ItemStyle-Width="5%" Visible="false">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="खर्चाची मुख्य बाब" DataField="ExpenseType" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="खर्चाची आंतर बाब" DataField="SubExpenseType" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <%--<asp:BoundField HeaderText="संख्या/क्षेत्रफळ/दिवस" DataField="Qty_Size_Area" ItemStyle-Width="5%"></asp:BoundField>--%>
                                <asp:BoundField HeaderText="प्रति दर" DataField="Rate" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <%--<asp:BoundField HeaderText="चेक/ रोखीने" DataField="PaymentMode" ItemStyle-Width="5%"></asp:BoundField>--%>
                                <asp:BoundField HeaderText="दिनांक" DataField="Date" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Width="5%"></asp:BoundField>
                                <asp:BoundField HeaderText="पावती" DataField="InvoiceNo" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <%--<asp:BoundField HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" DataField="SourceOfExpense" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                        </asp:BoundField>--%>
                                <asp:BoundField HeaderText="पक्षाचा की/ इतर व्यक्तीचा नाव" DataField="PartyName" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <%--<asp:BoundField HeaderText="पक्षाचा केलेल्या खर्चाच्या बाबत मोबाईल" DataField="PartyNo" ItemStyle-Width="5%">
                                        <ItemStyle Width="5%" />
                                        </asp:BoundField>--%>
                                <asp:BoundField HeaderText="एकूण खर्च" DataField="TotalExpense" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle Font-Bold="True" />
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
                                <asp:Label ID="lbldateDetails" runat="server" Text="दिनांक .............रोजी ...........वा मी एकूण निवडणूक खर्चाचा नमुना २ सदर करत आहे.."></asp:Label>
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
                            <td style="padding-left: 570px; text-align: right">
                                <asp:Label ID="Label1" runat="server" Text="सही"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 570px; text-align: right">
                                <asp:Label ID="lblOfficerSign" runat="server" Text="जिल्हाधिकारी / महापालिका आयुक्त"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 570px; text-align: right">
                                <asp:Label ID="Label2" runat="server" Text="एवं निवडणूक अधिकारी "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 570px; text-align: right">
                                <asp:Label ID="Label3" runat="server" Text="स्थानिक स्वराज्य संस्था"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>टीप : 
                        <asp:Label ID="lblTip1" runat="server" Style="padding-left: 5px" Text="(१)एकूण खर्च सदर नमुना २ प्रमाणे निवडणूक निकाल लागल्यापासून ३० दिवसांच्या आत, जिल्हाधिकारी/  महापालिका आयुक्त यांना सादर करावा."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 37px">
                                <asp:Label ID="lblTip2" runat="server" Text="(२)सादर करतेवेळी उमेदवाराने न चुकता पोहोच घ्यावी. सदर पोहोच हि भविष्यात उमेदवाराला बचावासाठी उपयोगी होऊ शकेल."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 37px">
                                <asp:Label ID="lblTip3" runat="server" Text="(३)ओंन लाईन पद्धतीने दैनंदिन खर्च भरल्यास सदर नमुना २ ऑटोमॅटिक तयार होईल. उमेदवाराने फक्त नमुना डाऊनलोड करून, तपासून,  प्रिंट करून, सही करून, (१) प्रमाणे सादर करावा."></asp:Label>
                            </td>
                        </tr>
                    </table>

                </asp:View>
            </asp:MultiView>
        </div>
        <div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../js/jquery.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 211px;
        }

        .auto-style2 {
            width: 205px;
        }

        .auto-style4 {
            width: 116px;
        }

        .auto-style5 {
            width: 15px;
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

