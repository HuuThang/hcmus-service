using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DTO;
using DAO;
namespace TimKiemDichVu.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        public ActionResult Index()
        {
            SessionInfoOfUser _sessionInfo = getSession();
            // [1] Kiểm Có xác định mã dich vụ ko?
            if (Request.QueryString["dv"] != null && MvcApplication.IsNumeric(Request.QueryString["dv"]))
            {
                _sessionInfo.DichVu = Convert.ToInt32(Request.QueryString["dv"]);
            }
            // kết thúc [1]

            TimKiemDAO tkDAO = new TimKiemDAO();
            // [2] Kiểm tra có phải người dùng chọn link phân trang ko?
            int _currentpage = 1;
            if (Request.QueryString["keyword"] != null && Request.QueryString["pagecurrent"] != null && MvcApplication.IsNumeric(Request.QueryString["pagecurrent"]) && _sessionInfo.SqlSearch != null && _sessionInfo.Pages != 0)
            {
                _currentpage = Convert.ToInt32(Request.QueryString["pagecurrent"]);
                if (_currentpage <= _sessionInfo.Pages)
                {
                    ViewData["pagging"] = _pagging();
                    tkDAO.SqlSearch = _sessionInfo.SqlSearch;
                    return View(tkDAO.getPage(_currentpage));
                }
            }
            // Kết thúc [2]

            // [3] Xử lý keyword 
            string keyword = MvcApplication.formatInputString(Request.QueryString["keyword"]);
            _sessionInfo.KeyWord = keyword;
            // Kết thúc [3]

            // [4] Tính thời gian tìm kiếm
            DateTime time1 = DateTime.Now;

            List<DuLieuDTO> lst = _sessionInfo.DichVu == -1 ? tkDAO.timKiem(keyword) : tkDAO.timKiem(keyword, _sessionInfo.DichVu);
            
            DateTime time2 = DateTime.Now;
            TimeSpan ts = time2 - time1;
            _sessionInfo.TimeRun = (ts.Seconds + (float)ts.Milliseconds / 1000);
            // Kết thúc [4]
            
            // [5] Lưu giữ lại các thông tin tìm kiếm
            _sessionInfo.ResultCount = tkDAO.ResultCount;
            _sessionInfo.SqlSearch = tkDAO.SqlSearch;
            _sessionInfo.Pages = tkDAO.Pages();
            // Kết thúc [5]
            ViewData["pagging"] = _pagging();
            
            return View(lst);
            
        }

        public ActionResult ChiTiet(int id)
        {
            DuLieuDAO dlDAO = new DuLieuDAO();
            DuLieuDTO duLieu = dlDAO.getDuLieu(id);
            return View(duLieu);
        }
 
        private String _pagging()
        {
            SessionInfoOfUser _sessionInfo = getSession();
            int pages = _sessionInfo.Pages;
            if (pages <= 1)
                return String.Empty;
            StringBuilder _rs = new StringBuilder();
            int _pagenumber = pages > MvcApplication.Page_range1 ? MvcApplication.Page_range1 : pages;

            if (Request.QueryString["_pagenumber"] != null && MvcApplication.IsNumeric(Request.QueryString["_pagenumber"]))
                _pagenumber = Convert.ToInt32(Request.QueryString["_pagenumber"]);
            
            int _pagecurrent = 1;

            if (Request.QueryString["pagecurrent"] != null && MvcApplication.IsNumeric(Request.QueryString["pagecurrent"]))
                _pagecurrent = Convert.ToInt32(Request.QueryString["pagecurrent"]);
            
            String kw = String.Empty;
            if (Request.QueryString["keyword"] != null)
                kw = Request.QueryString["keyword"];
             
            int _end = _pagenumber + _pagecurrent;// trang cuối cùng được hiện thị.  
            if (_end > pages)
                _end = pages;
            int _start = 1;
            int _page_rang2 = MvcApplication.Page_range2;
            if (_end > _page_rang2)// Nếu thỏa tính lại trang bắt đầu hiện thị.
            {
                int _v = _end / _page_rang2 - 1;
                _start = _v > 0 ? _v * _page_rang2 + _end % _page_rang2 : _end % _page_rang2;
            }
            if(_pagecurrent > 1)
                _rs.AppendFormat("<div><a href=\"/TimKiem/?pagenumber={0}&pagecurrent={1}&keyword={2}\">Trước</a></div>", _end, _pagecurrent - 1, kw);
            for (int i = _start; i <= _end; i++)
            {
                if(i != _pagecurrent)
                    _rs.AppendFormat("<div><a href=\"/TimKiem/?pagenumber={0}&pagecurrent={1}&keyword={2}\">{1}</a></div>", _end, i, kw);
                else
                    _rs.AppendFormat("<div><span>{0}</span></div>", i);
            }
            if (_pagecurrent < pages)
                _rs.AppendFormat("<div><a href=\"/TimKiem/?pagenumber={0}&pagecurrent={1}&keyword={2}\">Tiếp</a></div>", _end, _pagecurrent + 1, kw);
            return _rs.ToString();
        }
        public SessionInfoOfUser getSession()
        {
            if (Session["SessionInfo"] != null)
                return (SessionInfoOfUser)Session["SessionInfo"];
            return new SessionInfoOfUser();
        }
    }
}
