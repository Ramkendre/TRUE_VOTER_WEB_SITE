<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignLatLog.aspx.cs" Inherits="TrueVoter.Reports.AssignLatLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false"></script>
    <script type="text/javascript" lang="javascript">
        window.onload = function () {

            var mapOptions =
                {
                    center: new google.maps.LatLng(21.1463100, 79.0849100), zoom: 5,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);



            google.maps.event.addListener(map, 'click', function (e) {
                debugger
                var lat1 = e.latLng.lat();
                var lng1 = e.latLng.lng();
                document.getElementById('HiddenFieldLat').value = e.latLng.lat();
                document.getElementById('HiddenFieldLong').value = e.latLng.lng();
                document.getElementById("lat").innerText = e.latLng.lat();
                document.getElementById("longi").innerText = e.latLng.lng();

                var myLatLng = { lat: lat1, lng: lng1 };

                var marker = new google.maps.Marker({
                    position: myLatLng,
                    map: map,
                    animation: google.maps.Animation.Xp,
                    title: 'suraj'
                });
                google.maps.event.addListener(map, 'rightclick', function (event) {
                    marker.setMap(null);
                });
            });
        }

        function numbersonly(evt) {
            //debugger;
            var charCode = (evt.fwhich) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
                    && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }


    </script>
    <title>Assign latitude and longitude | True Voter</title>
    <style type="text/css">
        .auto-style1 {
            width: 457px;
            text-align: right;
        }

        .auto-style4 {
            width: 397px;
        }

        .auto-style5 {
            width: 107px;
            text-align: left;
        }
        .auto-style6 {
            width: 300px;
            text-align: right;
        }
        .auto-style7 {
            width: 321px;
            text-align: left;
        }
        .auto-style8 {
            width: 253px;
        }
        .auto-style9 {
            width: 152px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="color: white; background: #0c38b2; width: 100%; height: 40px;" align="center">
                <asp:Label ID="lblHeading" runat="server" Text="Assign Latitude & Longitude" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
            <input id="HiddenFieldLat" type="hidden" value="" runat="server" />
            <input id="HiddenFieldLong" type="hidden" value="" runat="server" />
            <table style="width: 74%; margin-left: 240px">
                <tr>
                    <td class="auto-style5">Enter AC No:</td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:TextBox ID="txtAcNo" runat="server" MaxLength="4" PlaceHolder="e.g. 25" onkeypress="return numbersonly(this,event)" Style="text-align: left" Width="151px"></asp:TextBox></td>
                    <td class="auto-style9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="sub" ErrorMessage="*" ControlToValidate="txtAcNo" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style5">Enter Part No:</td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:TextBox ID="txtPartNo" runat="server" MaxLength="4" PlaceHolder="e.g. 2" onkeypress="return numbersonly(this,event)" Style="margin-left: 0px" Width="150px"></asp:TextBox></td>
                    <td class="auto-style9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="sub" ControlToValidate="txtPartNo" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style5">Enter Name:</td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:TextBox ID="txtsearch" runat="server" MaxLength="10" Width="149px"></asp:TextBox></td>
                    <td class="auto-style9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="sub" ControlToValidate="txtsearch" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style5"> </td>
                    <td style="text-align: left" class="auto-style4">
                        <asp:Button ID="btnGetData" runat="server" ValidationGroup="sub" Text="Get Details" OnClick="btnGetData_Click" />&nbsp;&nbsp;
                   
                    
                        <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Admin/Home" Style="text-align: left" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="sub" />
                    </td>
                </tr>

            </table>
            <br />
        </div>
        <div>
        </div>
        <div>
            <table style="width: 100%">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Latname" runat="server" Text="Latitude:" ForeColor="#ff0000" Font-Bold="true" style="text-align: justify"></asp:Label>

                        <asp:Label ID="lat" runat="server"></asp:Label></td>
                    <td class="auto-style7">
                        <asp:Label ID="longname" runat="server" Text="Longitude:" Style="text-align: left" Font-Bold="true" ForeColor="#ff0000"></asp:Label>

                        <asp:Label ID="longi" runat="server"></asp:Label></td>
                    <td class="auto-style8">
                        <asp:Label ID="cnt" runat="server" Text="" Font-Bold="true" Visible="false"></asp:Label>
                        <asp:Label ID="Latname0" runat="server" Text="Recored Inserted" Font-Bold="true" Visible="false"></asp:Label>
                        </td>
                    <td>Note:Right Click to Clear Map Pointer</td>
                </tr>
            </table>
        </div>
        <div>
            <center><table style="width: 100%">
                <tr>
                    <td class="auto-style1">
                        <div style="width: 500px; height: 460px;">
                            <asp:GridView ID="gvAsslatlog" runat="server" AllowPaging="True" DataKeyNames="IDCARD_NO" AutoGenerateColumns="false" PageSize="14" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvAsslatlog_PageIndexChanging" Width="100%" hight="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField HeaderText="Check">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="IDCARD NO" DataField="IDCARD_NO" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        </div>
                        
                    </td>
                    <td>
                        <div id="dvMap" style="width: 500px; height: 460px;"></div>
                    </td>
                </tr>
            </table></center>

        </div>
    </form>
</body>
</html>
