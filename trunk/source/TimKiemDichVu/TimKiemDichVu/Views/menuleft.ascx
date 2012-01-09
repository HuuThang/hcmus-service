<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
       
    TimKiemDichVu.SessionInfoOfUser _sessionInfo = Session["SessionInfo"] == null ? new TimKiemDichVu.SessionInfoOfUser() : 
        (TimKiemDichVu.SessionInfoOfUser)Session["SessionInfo"]; 
    String keyWord = "";
    String kw = "";
    if (Request.QueryString["keyword"] != null)
    {
        keyWord = Request.QueryString["keyword"];
    }
    if (keyWord.Trim() != "")
    {
        kw = "&keyword=" + keyWord.Replace(" ", "+");
    }
    Object dichVu = _sessionInfo.DichVu;
    if (Model is DTO.DuLieuDTO)
    {
        dichVu = ((DTO.DuLieuDTO)Model).DichVu.MaDichVu;
    }
    if (dichVu.Equals(-1))
    {
%>
        <a href="/TimKiem/?dv=-1<%=kw %>"><div class="listitem listitemselected">Tất cả dịch vụ</div></a>
<%
    }
    else
    {
%>

        <a href="/TimKiem/?dv=-1<%=kw %>"><div class="listitem">Tất cả dịch vụ</div></a>
<%
    }
    List<DTO.DichVuDTO> lst = (List<DTO.DichVuDTO>)Application["ListDV"];
    foreach (var item in lst)
    {
%>
        <%
        
        if (dichVu.Equals(item.MaDichVu))
        {
        %>
                <div class="listitem listitemselected"><%=item.TenDichVu%></div>
        <%
        }
        else
        {
        %>
                <a  href="/TimKiem/?dv=<%=item.MaDichVu + kw %>"><div class="listitem"><%=item.TenDichVu %></div></a>
            
<%
        }
    }
%>
