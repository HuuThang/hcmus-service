<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Register src="~/Views/menuleft.ascx" tagname="menuleft" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tìm kiếm dịch vụ - Chi tiết địa điểm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    DTO.DuLieuDTO dl = Model;
%>
<div class="resultcount">
    <div class="left">
    	<div>Địa điểm</div>
    </div>
    <div class="right">
     	<div>&nbsp;</div>
    </div>
    <div class="clear"></div>
</div>
<div class="mainfield">
    <div class="left list">
        <uc1:menuleft ID="menuleft" runat="server" />
    </div>
    <div class="right">
    	<div class="resultlist">
            <div class="result">
                <div class="result_name"><%= dl.TenDiaDiem.TenDiaDiem %></div>
                <div class="result_address"><%= dl.SoNha %> <%= dl.Duong.TenDuong %>, Phường <%= dl.Phuong.TenPhuong %>, Quận <%= dl.QuanHuyen.TenQuanHuyen %>, <%= dl.TinhThanh.TenTinhThanh %></div>
                <div class="result_notes">Vĩ độ : <%= dl.ViDo %>, Kinh độ : <%= dl.KinhDo %></div>
            </div>
    
            <div class="result">
                Hình ảnh trên google map
            </div>
            <div class="result_image">
				<div id="div_id" style="height:500px; width:600px"></div>
            </div>
    
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
<%
    DTO.DuLieuDTO dl = Model;
%>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&language=vi"></script>
<script type="text/javascript">
    var map;
    var vido = <%= dl.ViDo %>; // vĩ độ
    var kinhdo = <%= dl.KinhDo %>; // kinh độ
    function initialize() {
        var myLatlng = new google.maps.LatLng(vido, kinhdo);
        var myOptions = {
            zoom: 16, // tỷ lệ bản đồ
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        map = new google.maps.Map(document.getElementById("div_id"), myOptions);

        var text; // thông tin địa điểm
        text = "            <div class=\"result\">"
+ "                <div class=\"result_name\"><%= dl.TenDiaDiem.TenDiaDiem %></div>"
+ "                <div class=\"result_address\"><%= dl.SoNha %> <%= dl.Duong.TenDuong %>, Phường <%= dl.Phuong.TenPhuong %>, Quận <%= dl.QuanHuyen.TenQuanHuyen %>, <%= dl.TinhThanh.TenTinhThanh %></div>"
+ "                <div class=\"result_notes\">Vĩ độ : <%= dl.ViDo %>, Kinh độ : <%= dl.KinhDo %></div>"
+ "            </div>";
        var infowindow = new google.maps.InfoWindow(
    {
        content: text,
        position: myLatlng
    });
        infowindow.open(map);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: "<%= dl.TenDiaDiem.TenDiaDiem %>" // tên địa điểm, hiển thị khi trỏ chuột vào địa điểm
        });
    }
    if(vido != 0 || kinhdo != 0){
        window.onload = initialize;
    }
</script>
</asp:Content>
