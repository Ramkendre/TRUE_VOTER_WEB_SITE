<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptGroupExpense.aspx.cs" Inherits="TrueVoter.Reports.rptGroupExpense" MasterPageFile="~/MasterPages/UserSite.Master" %>

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
            window.location.href = "../Reports/frmGroupExpense.aspx";
        }
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 145px;
            height: 37px;
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

        .auto-style5 {
            width: 210px;
            height: 34px;
        }

        .auto-style6 {
            height: 34px;
        }

        .auto-style7 {
            width: 145px;
            height: 34px;
        }

        .auto-style8 {
            width: 210px;
            height: 35px;
        }

        .auto-style9 {
            height: 35px;
        }

        .auto-style10 {
            width: 145px;
            height: 35px;
        }

        .auto-style11 {
            width: 145px;
            height: 29px;
        }

        .auto-style12 {
            height: 29px;
        }

        .auto-style13 {
            width: 210px;
            height: 36px;
        }

        .auto-style14 {
            height: 36px;
        }

        .auto-style15 {
            width: 145px;
            height: 36px;
        }

        .auto-style16 {
            width: 210px;
            height: 37px;
        }

        .auto-style17 {
            height: 37px;
        }

        .auto-style18 {
            height: 28px;
        }

        .auto-style19 {
            height: 28px;
            width: 164px;
        }

        .auto-style20 {
            height: 28px;
            width: 179px;
        }

        .auto-style21 {
            width: 210px;
            height: 29px;
        }

        .auto-style22 {
            height: 34px;
            width: 281px;
        }

        .auto-style23 {
            height: 35px;
            width: 281px;
        }

        .auto-style24 {
            height: 29px;
            width: 281px;
        }

        .auto-style25 {
            height: 36px;
            width: 281px;
        }

        .auto-style26 {
            height: 37px;
            width: 281px;
        }

        .auto-style27 {
            height: 38px;
            width: 164px;
        }

        .auto-style28 {
            height: 38px;
            width: 179px;
        }

        .auto-style29 {
            height: 38px;
        }

        .auto-style30 {
            height: 39px;
            width: 164px;
        }

        .auto-style31 {
            height: 39px;
            width: 179px;
        }

        .auto-style32 {
            height: 39px;
        }

        .auto-style33 {
            height: 40px;
            width: 164px;
        }

        .auto-style34 {
            height: 40px;
            width: 179px;
        }

        .auto-style35 {
            height: 40px;
        }
    </style>

    <%-- <style>
        
    </style>--%>
    <div class="borderOuter-div-Form" id="divPrint">

        <%--<div class="borderOuter-div-Form" id="divPrint">--%>
        <div class="borderHeading-div">
            <div align="Center" style="font-size: large; font-weight: bold">नमुना-1</div>
        </div>

        <div align="Center" style="font-size: large; font-weight: bold">गट खर्च तपशील</div>
        <br />
        <div style="border: groove">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style5">उमेदवाराचे नाव :</td>
                    <td class="auto-style22">
                        <asp:Label ID="lblcandidateName1" runat="server"></asp:Label></td>
                    <td class="auto-style7">उमेदवाराचे नाव:</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblcandidateName2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style8">उमेदवाराचे नाव :</td>
                    <td class="auto-style23">
                        <asp:Label ID="lblcandidateName3" runat="server"></asp:Label></td>
                    <td class="auto-style10">उमेदवाराचे नाव:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblcandidateName4" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">गटाचे नाव:</td>
                    <td>
                        <asp:Label ID="lblGroupName" runat="server"></asp:Label></td>


                    <td class="auto-style11">जिल्ह्याचे नाव:</td>
                    <td class="auto-style12">
                        <asp:Label ID="lblDistrictNm" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style13">पक्षाचे नाव :</td>
                    <td class="auto-style25">
                        <asp:Label ID="lblParty" runat="server"></asp:Label></td>
                    <td class="auto-style15">सार्वत्रिक\पोट निवडणूक:</td>
                    <td class="auto-style14">
                        <asp:Label ID="lblElection" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style16">स्थानिक स्वराज्य संस्थेचे नाव :</td>
                    <td class="auto-style26">
                        <asp:Label ID="lblLocalBodyId" runat="server"></asp:Label></td>
                    <td class="auto-style2">मतदानाचा दिनांक:</td>
                    <td class="auto-style17">
                        <asp:Label ID="lblVotingDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style16">प्रभाग/गण/गट क्रमांक :</td>
                    <td class="auto-style26">
                        <asp:Label ID="lblWardNo" runat="server"></asp:Label></td>
                    <td class="auto-style21">दिनांक:</td>
                    <td class="auto-style24">
                        <asp:Label ID="lblProgramdt" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvDaillyExpenses" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false" ShowFooter="true" CssClass="table table-hover table-bordered">
                <Columns>
                    <%--<asp:TemplateField HeaderText="अ.क्र" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("PK_Id")+""+Eval("d") %>' ID="lblind" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="अ.क्र" DataField="PK_Id" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="खर्चाची मुख्य बाब" DataField="ExpenseType" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="खर्चाची आंतर बाब" DataField="SubExpenseType" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="दिनांक" DataField="Date" ItemStyle-Width="5%" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundField>
                    <asp:BoundField HeaderText="संख्या/ क्षेत्रफळ/ दिवस" DataField="Qty_Size_Area" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="प्रति दर" DataField="Rate" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="चेक/ रोखीने" DataField="PaymentMode" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="पावती" DataField="InvoiceNo" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" DataField="SourceOfExpense" ItemStyle-Width="5%"></asp:BoundField>
                    <asp:BoundField HeaderText="पक्षाचा की/ इतर व्यक्तीचा नाव" DataField="PartyName" ItemStyle-Width="5%"></asp:BoundField>
                    <%--<asp:BoundField HeaderText="पक्षाचा केलेल्या खर्चाच्या बाबत मोबाईल" DataField="PartyNo" ItemStyle-Width="5%"></asp:BoundField>--%>
                    <asp:BoundField HeaderText="एकूण खर्च" DataField="TotalExpense" ItemStyle-Width="5%"></asp:BoundField>
                </Columns>
                <EmptyDataTemplate>Nil Expenses</EmptyDataTemplate>
            </asp:GridView>
            <br />
            <div align="Center" style="font-size: large; font-weight: bold">गट खर्च वितरण</div>
            <br />
            <div style="border: groove">
                <table style="width: 100%; height: 155px; margin-bottom: 10px;">
                    <tr>
                        <td class="auto-style27">Candidate Name:</td>
                        <td class="auto-style28">
                            <asp:Label ID="M1" runat="server"></asp:Label></td>
                        <td class="auto-style29">Mobile No:</td>
                        <td class="auto-style29">
                            <asp:Label ID="NO1" runat="server"></asp:Label></td>
                        <td class="auto-style29">Share :</td>
                        <td class="auto-style29">
                            <asp:Label ID="S1" runat="server"></asp:Label></td>
                        <td class="auto-style29">Status :</td>
                        <td class="auto-style29">
                            <asp:Label ID="ST1" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style30">Candidate Name:</td>
                        <td class="auto-style31">
                            <asp:Label ID="M2" runat="server"></asp:Label></td>
                        <td class="auto-style32">Mobile No:</td>
                        <td class="auto-style32">
                            <asp:Label ID="NO2" runat="server"></asp:Label></td>
                        <td class="auto-style32">Share :</td>
                        <td class="auto-style32">
                            <asp:Label ID="S2" runat="server"></asp:Label></td>
                        <td class="auto-style32">Status :</td>
                        <td class="auto-style32">
                            <asp:Label ID="ST2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style33">Candidate Name:</td>
                        <td class="auto-style34">
                            <asp:Label ID="M3" runat="server"></asp:Label></td>
                        <td class="auto-style35">Mobile No:</td>
                        <td class="auto-style35">
                            <asp:Label ID="NO3" runat="server"></asp:Label></td>
                        <td class="auto-style35">Share :</td>
                        <td class="auto-style35">
                            <asp:Label ID="S3" runat="server"></asp:Label></td>
                        <td class="auto-style35">Status :</td>
                        <td class="auto-style35">
                            <asp:Label ID="ST3" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style19">Candidate Name:</td>
                        <td class="auto-style20">
                            <asp:Label ID="M4" runat="server"></asp:Label></td>
                        <td class="auto-style18">Mobile No:</td>
                        <td class="auto-style18">
                            <asp:Label ID="NO4" runat="server"></asp:Label></td>
                        <td class="auto-style18">Share :</td>
                        <td class="auto-style18">
                            <asp:Label ID="S4" runat="server"></asp:Label></td>
                        <td class="auto-style18">Status :</td>
                        <td class="auto-style18">
                            <asp:Label ID="ST4" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <br />
            <table>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="Label1" runat="server" Text="व्यक्तिगत पातळीवरील गट खर्च"></asp:Label>:
                        <asp:Label ID="lblPGroupExp" runat="server" Style="font-weight: bold"></asp:Label><asp:Label ID="Label2" Text="/-" runat="server" Style="font-weight: bold"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td style="padding-left: 10px">
                        <asp:Label ID="lbldateDetails" runat="server" Text="दिनांक .............रोजी ...........वा मी निधीबाबतचा तपशिल नमुना _ _ सदर करत आहे."></asp:Label>
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
                        <asp:Label ID="lblDailyExpenseSample" runat="server" Text="सदर निधीबाबतचा तपशिल नमुना _ _, दिनांक .............रोजी ...........वा मला प्राप्त झाला."></asp:Label>
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
    <%--</div>--%>
</asp:Content>
