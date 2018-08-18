<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="TrueVoter.Reports.FAQ" MasterPageFile="~/MasterPages/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="borderOuter-div-Form">
        <div class="borderHeading-div">
            <div>
                <asp:Label ID="lblHeading" runat="server" Text="HELP" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <table cellspacing="5" cellpadding="5">
                <tr align="center">
                    <td>
                        <div style="width: 80%; font-size: large">
                            निवडणूक आयोगाच्या सुचने नुसार, नामनिर्देश फॉर्म भरल्या पासून प्रत्येक उमेदवाराला त्याचा निवडणुकी संबंधित खर्च TRUE VOTER app द्वारे दररोज नियमित भरून दुसऱ्या दिवशी निवडणूक अधिकाऱ्याला फक्त प्रपत्र 1 ची प्रिंट काढून व व्हावचार व बिलाच्या सत्य प्रतीसोबत निवडणूक अधिकाऱ्याकडे सादर करावयाचा आहे. 

                                    प्रपत्र 2, 3, 4 हे सर्वांत शेवटी निवडणूक ताखेपासून एक मही न्याच्या आत आपल्या नातेवाईकांनी मित्रांनी पार्टीने केलेल्या व इतर खर्चासह एकत्रित पणे सादर करावयाचे आहे.

                                    निवडणूक तारखेपर्यंत फक्त रोज प्रपत्र 1 सादर करणे गरजेचे आहे

                                    निवडणूक आयोगाचे आदेश डाउनलोड करण्याची सुविधा दिलेली आहे.
                        </div>
                        <br />
                        <br />
                        <asp:LinkButton ID="lnkbtnOrder1" runat="server" Text="ORDER ABOUT USE OF TRUE VOTER APP FOR FILLING DAILY EXPENSES" ForeColor="Blue" OnClick="lnkbtnOrder1_Click"></asp:LinkButton>
                        <br />
                        <br />
                        <asp:LinkButton ID="lnkbtnOrder2" runat="server" Text="ORDER NO:1 ABOUT DAILY DAILY EXPENSES" ForeColor="Blue" OnClick="lnkbtnOrder2_Click"></asp:LinkButton>
                        <br />
                        <br />
                        <asp:LinkButton ID="lnkbtnOrder3" runat="server" Text="ORDER NO:2 ABOUT DAILY DAILY EXPENSES" ForeColor="Blue" OnClick="lnkbtnOrder3_Click"></asp:LinkButton>
                        <br />
                        <br />
                        <div style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="Officer Help" Font-Bold="true" Font-Size="Small"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnoffAppPro" runat="server" Text="Tutorial Presentation for Officer App registration Process" ForeColor="Blue" OnClick="lnkbtnoffAppPro_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnofficerFunction" runat="server" Text="Tutorial Presentation For Functions for Officers" ForeColor="Blue" OnClick="lnkbtnofficerFunction_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnstandardrates" runat="server" Text="Tutorial Presentation For filling Standard Rates for Officers" ForeColor="Blue" OnClick="lnkbtnstandardrates_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnElectionActi" runat="server" Text="Tutorial Presentation for Officer Election Activity Process" ForeColor="Blue" OnClick="lnkbtnElectionActi_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnElectionData" runat="server" Text="Tutorial Presentation for Officer Election Data Process" ForeColor="Blue" OnClick="lnkbtnElectionData_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnEmergencyService" runat="server" Text="Tutorial Presentation for Officer Emergency Service" ForeColor="Blue" OnClick="lnkbtnEmergencyService_Click"></asp:LinkButton>
                            <br />
                            <br />
                        </div>
                        <div style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text="Candidate Help" Font-Bold="true" Font-Size="Small"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="btnCandiAppRegPro" runat="server" Text="Tutorial Presentation for Candidate App Registration & Fill DailyExpenses" ForeColor="Blue" OnClick="btnCandiAppRegPro_Click"></asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="lnkbtnDailyExpecandi" runat="server" Text="Tutorial Presentation for Filling Candidate Group Daily Expense" ForeColor="Blue" OnClick="lnkbtnDailyExpecandi_Click"></asp:LinkButton>
                            <br />
                            <br />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
