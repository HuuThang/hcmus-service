using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public class DuongDTO
    {
        private int _maDuong;

        public int MaDuong
        {
            get { return _maDuong; }
            set { _maDuong = value; }
        }
        private string _tenDuong;

        public string TenDuong
        {
            get { return _tenDuong; }
            set { _tenDuong = value; }
        }
    }
}
