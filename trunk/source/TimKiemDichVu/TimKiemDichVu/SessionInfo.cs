using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimKiemDichVu
{
    public class SessionInfoOfUser
    {
        public SessionInfoOfUser()
        {
            _dichVu = -1;
            _pages = 0;
            _sqlSearch = null;
            _keyWord = null;
            _timeRun = 0;
            _resultCount = 0;
        }
        private int _dichVu;

        public int DichVu
        {
            get { return _dichVu; }
            set { _dichVu = value; }
        }
        private int _pages;

        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        private String _sqlSearch;

        public String SqlSearch
        {
            get { return _sqlSearch; }
            set { _sqlSearch = value; }
        }
        private String _keyWord;

        public String KeyWord
        {
            get { return _keyWord; }
            set { _keyWord = value; }
        }
        private float _timeRun;

        public float TimeRun
        {
            get { return _timeRun; }
            set { _timeRun = value; }
        }
        private int _resultCount;

        public int ResultCount
        {
            get { return _resultCount; }
            set { _resultCount = value; }
        }
 
    }
}