<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyExpenseSample9.aspx.cs" MasterPageFile="~/MasterPages/UserSite.Master" Inherits="TrueVoter.Reports.DailyExpenseSample9" %>

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
    <%--<div class="borderOuter-div-Form" id="div1">--%>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div class="borderOuter-div-Form" >
                <div class="borderHeading-div">
                    <div align="Center" style="font-size: large; font-weight: bold">नमुना-9</div>
                </div>
                <div class="form-group" align="center">
                    <table>
                        <tr style="height: 10px">
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblDate" Text="From Date"></asp:Label></td>
                            <td>:</td>
                            <td class="auto-style4" id="Date">
                                <asp:TextBox ID="txtFromDate" TextMode="Date" Width="300px" Height="34px" runat="server" ValidationGroup="sub" placeholder="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="Requriedfield1" runat="server" ValidationGroup="sub" ForeColor="Red" ControlToValidate="txtFromDate" Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="Label1" Text="To Date"></asp:Label></td>
                            <td>:</td>
                            <td class="auto-style4" id="Td1">
                                <asp:TextBox ID="txtToDate" TextMode="Date" Width="300px" Height="34px" runat="server" ValidationGroup="sub" placeholder="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ForeColor="Red" ControlToValidate="txtToDate" Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                    </table>
                </div>
                <div style="height: 9px"></div>
                <div align="center">
                    <asp:Button ID="btnFinalPrint" runat="server" OnClick="btnFinalPrint_Click" Text="Print" Visible="true" CssClass="btn btn-default" OnClientClick="return confirm('Ones you Print these record You can not change them. Do you want to Print?')" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancle" runat="server" Text="Back" PostBackUrl="~/Reports/frmHomeUser.aspx" Visible="true" CssClass="btn btn-default" />
                </div>
                </div>
        </asp:View>
        <asp:View ID="ViewPDF" runat="server">
            <div class="borderOuter-div-Form1" id="divPrint">
                <div class="borderHeading-div">
                    <div align="Center" style="font-size: large; font-weight: bold">नमुना-9</div>
                </div>
                <br />
                <div align="Center" style="font-size: large; font-weight: bold">राजकीय पक्ष - निधीबाबतचा तपशिल (देणगी, भेट, कर्ज, पक्ष निधी इ.)</div>
                <br />
                <br />
                <div style="border: groove">
                    <table style="width: 100%;">
                        <%--<tr>
                        <td class="auto-style1">उमेदवाराचे नाव :</td>
                        <td>
                            <asp:Label ID="lblcandidateName" runat="server"></asp:Label></td>
                        <td class="auto-style2">जिल्ह्याचे नाव:</td>
                        <td>
                            <asp:Label ID="lblDistrictNm" runat="server"></asp:Label></td>
                    </tr>--%>
                        <tr>
                            <td class="auto-style1">पक्षाचे नाव :</td>
                            <td>
                                <asp:Label ID="lblParty" runat="server"></asp:Label></td>
                            <%--<td class="auto-style2">सार्वत्रिक\पोट निवडणूक:</td>
                        <td>
                            <asp:Label ID="lblElection" runat="server"></asp:Label></td>--%>
                            <td class="auto-style2">दिनांक:</td>
                            <td>
                                <asp:Label ID="lblExpenseDate" runat="server"></asp:Label></td>
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
                            <td class="auto-style1">निधी स्विकारल्याचा कालावधी :</td>
                            <td>
                                <asp:Label ID="lblFromDate" runat="server"></asp:Label></td>
                            <%--<td class="auto-style2">दिनांक:</td>
                            <td>
                                <asp:Label ID="lblToDate" runat="server"></asp:Label></td>--%>
                        </tr>
                        <%--<tr>
                        <td class="auto-style1">जागा / seat  क्र :</td>
                        <td>
                            <asp:Label ID="lblSeat" runat="server"></asp:Label></td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>
                            <asp:Label ID="Label9" runat="server"></asp:Label></td>
                    </tr>--%>
                    </table>
                </div>
                <br />
                <div >
                    <asp:GridView ID="gvDonation" CssClass="table table-hover table-bordered" runat="server" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" ShowFooter="true">
                        <Columns>
                            <asp:BoundField HeaderText="अ.क्र" DataField="FundID" ItemStyle-Width="5%"></asp:BoundField>
                            <%--<asp:BoundField HeaderText="स्वतःचा की/ पक्षाचा की/ इतर व्यक्तीचा" DataField="FromText" ItemStyle-Width="5%"></asp:BoundField>--%>

                            <asp:BoundField HeaderText="निधी देणाऱ्याचा नाव व पत्ता" DataField="ProviderName" ItemStyle-Width="5%"></asp:BoundField>
                            <asp:BoundField HeaderText="निधी देणाऱ्याचा संपर्क क्रमांक" DataField="MobileNo" ItemStyle-Width="5%"></asp:BoundField>
                            <asp:BoundField HeaderText="दिनांक" DataField="Date" ItemStyle-Width="5%" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField HeaderText="रोख/ चेक/ डि.डी. / इतर प्रकारे" DataField="PaidBy" ItemStyle-Width="5%"></asp:BoundField>
                            <asp:BoundField HeaderText="देणाऱ्याच्या बँकेचे नाव व शाखा" DataField="ProviderBankName" ItemStyle-Width="5%"></asp:BoundField>
                            <asp:BoundField HeaderText="निधीचा प्रकार (देणगी, भेट, कर्ज इ.)" DataField="FundTYpeTxt" ItemStyle-Width="5%"></asp:BoundField>
                            <asp:BoundField HeaderText="रक्कम" DataField="Amount" ItemStyle-Width="5%"></asp:BoundField>
                        </Columns>
                    </asp:GridView><br /><br />
                    <div style="text-align:right">
                    <asp:Label ID="lblSignatureCandidate" runat="server" Text="पक्षाच्या पदाधिकाऱ्याचा सही" ></asp:Label><br />
                     <asp:Label ID="Label5" runat="server" Text="(सही करणाऱ्याचे नाव,पद)"></asp:Label><br />
                     <asp:Label ID="Label9" runat="server" Text="पक्षाचे नाव"></asp:Label>
                        </div>
                    <div>
                    <%--<table align="right">
                        <tr>
                            <td style="text-align:right">
                                <asp:Label ID="lblSignatureCandidate" runat="server" Text="पक्षाच्या पदाधिकाऱ्याचा सही"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label5" runat="server" Text="(सही करणाऱ्याचे नाव,पद)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label9" runat="server" Text="पक्षाचे नाव"></asp:Label>
                            </td>
                        </tr>
                    </table>--%>
                        </div>
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

        </asp:View>
    </asp:MultiView>
    <%--</div>--%>
</asp:Content>
