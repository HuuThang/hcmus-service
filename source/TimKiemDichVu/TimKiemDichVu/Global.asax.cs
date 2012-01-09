using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TimKiemDichVu
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
                "Home", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "TimKiem", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "TimKiem", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
        protected void Session_Start()
        {
            SessionInfoOfUser _sessionInfo = new SessionInfoOfUser();
            Session["SessionInfo"] = _sessionInfo;   
        }
        
        private static Dictionary<string, string> _AppReg;

        public static string formatInputString(string str)
        {
            if (str == null || str == string.Empty)
                return "";
            foreach (string var in _AppReg.Keys)
            {
                string[] arr = _AppReg[var].Split('|');
                foreach (string var1 in arr)
                {
                    str = str.Replace(var1, var);
                }
            }
            string rs = string.Empty;
            bool isClock = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    rs += str[i].ToString();
                    isClock = false;
                    continue;
                }
                if (!isClock)
                {
                    rs += str[i].ToString();
                    isClock = true;
                    continue;
                }
            }
            
            return rs.Trim();
        }
        protected void Application_Start()
        {
            _AppReg = new Dictionary<string, string>();
            _AppReg.Add("a", "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|A|À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ");
            _AppReg.Add("b", "B");
            _AppReg.Add("c", "C");
            _AppReg.Add("f", "F");
            _AppReg.Add("h", "H");
            _AppReg.Add("k", "K");
            _AppReg.Add("t", "T");
            _AppReg.Add("x", "X");
            _AppReg.Add("p", "P");
            _AppReg.Add("j", "J");
            _AppReg.Add("n", "N");
            _AppReg.Add("w", "W");
            _AppReg.Add("l", "L");
            _AppReg.Add("r", "R");
            _AppReg.Add("q", "Q");
            _AppReg.Add("e", "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ");
            _AppReg.Add("i", "ì|í|ị|ỉ|ĩ|Ì|Í|Ị|Ỉ|Ĩ");
            _AppReg.Add("o", "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ");
            _AppReg.Add("u", "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ");
            _AppReg.Add("y", "ỳ|ý|ỵ|ỷ|ỹ|Ỳ|Ý|Ỵ|Ỷ|Ỹ");
            _AppReg.Add("d", "Đ|đ");
            _AppReg.Add("m", "M");
            _AppReg.Add("g", "G");
            
            // Khi dùng chức năng phân trang phải đảm bảo id của bản dữ liệu phải theo thứ tự và id bắt đầu từ 1
            DAO.Comm.PageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["page_size"]);
            _page_rang1 = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["page_range1"]);
            _page_range2 = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["page_range2"]);

            DAO.Comm.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["Connection"];

            Application["ListDV"] = new DAO.DichVuDAO().getListDichVu();

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }

        private static int _page_rang1;

        public static int Page_range1
        {
            get { return _page_rang1; }
        }
        private static int _page_range2;

        public static int Page_range2
        {
            get { return _page_range2; }
            set { _page_range2 = value; }
        }

        public static bool IsNumeric(string value)
        {
            string pattern = "(^[-+]?\\d+(,?\\d*)*\\.?\\d*([Ee][-+]\\d*)?$)|(^[-+]?\\d?(,?\\d*)*\\.\\d+([Ee][-+]\\d*)?$)";
            Regex regEx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            return regEx.Match(value).Success && value.Length < int.MaxValue.ToString().Length;
        } 
    }
}