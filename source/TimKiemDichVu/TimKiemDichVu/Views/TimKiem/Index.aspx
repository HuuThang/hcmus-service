<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Template.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DTO.DuLieuDTO>>" %>
<%@ Register src="~/Views/menuleft.ascx" tagname="menuleft" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	Tìm kiếm dịch vụ - Tìm với từ khóa "<%=Request.Params["keyword"] %>"
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="resultcount">
    <div class="left">
    	<div>Tìm kiếm</div>
    </div>
    <div class="right">
        <%
            TimKiemDichVu.SessionInfoOfUser _sessionInfo = Session["SessionInfo"] == null ? new TimKiemDichVu.SessionInfoOfUser() : 
                (TimKiemDichVu.SessionInfoOfUser)Session["SessionInfo"]; 
         %>
     	<div>Tìm thấy <%= _sessionInfo.ResultCount.ToString().Replace(".", ",")%> kết quả (<%= _sessionInfo.TimeRun.ToString().Replace(".", ",")%> giây)</div>
    </div>
    <div class="clear"></div>
</div>
<div class="mainfield">
    <div class="left list">
        <uc1:menuleft ID="menuleft" runat="server" />
    </div>
    <div class="right">
    <%
        foreach (var item in Model)
        {
    %>      
            <a href="/TimKiem/ChiTiet/?id=<%= item.MaDuLieu %>&keyword=<%=Request.Params["keyword"] %>">
            <div class="result">
                <div class="result_name"><%= item.TenDiaDiem.TenDiaDiem %></div>
                <div class="result_address"><%= item.SoNha %> <%= item.Duong.TenDuong%>, Phường <%= item.Phuong.TenPhuong%>, Quận <%= item.QuanHuyen.TenQuanHuyen%>, <%= item.TinhThanh.TenTinhThanh%></div>
                <div class="result_notes">Vĩ độ : <%= item.ViDo%>, Kinh độ : <%= item.KinhDo%></div>
            </div>
            </a>
    <%         
        }
    %>
        <div class="pagging">
            <%=ViewData["pagging"]%>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

