<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
    <div class="left">
    	<div class="smalllogo"><a href="/Home/?rl=10101"><img src="/Content/images/logo.png" /></a></div>
    </div>
    <div class="searchbox">
        <form name="frmsearch" id="frmsearch" method="get" action="/TimKiem/" onsubmit="">
                    <input name="keyword" id="keyword" type="text" value="<%= Request.Params["keyword"] %>" />
                    <input id="frmsearchsubmit" type="submit" value="Tìm kiếm" />
        </form>
    </div>
    <div class="clear"></div>
