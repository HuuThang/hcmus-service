<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="/Content/images/icon.ico" />
    <link type="text/css" rel="stylesheet" href="/Content/styles/page.css" />
    <script type="text/javascript" src="/Content/scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="/Content/scripts/page.js"></script>
    <title>	Tìm kiếm dịch vụ</title>
</head>
<body>
    <div>
<div class="mainsearchbox">
    <form name="frmsearch" id="frmsearch" method="get" action="/TimKiem/" onsubmit="">
        	<div class="biglogo">
            	<img src="/Content/images/logo.png" />
            </div>
        	<div>
            	<input name="keyword" id="keyword" type="text" value="" />
            </div>
        	<div>
				<input id="frmsearchsubmit" type="submit" value="Tìm kiếm" />
            </div>
    </form>
</div>
<div class="mainfooter">Ho Chi Minh City University of Science - Software Project Management - 10HCB - Group 8 © 2011</div>
    </div>
</body>
</html>
