using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public class PhuongDTO
    {
        private int _maPhuong;

        public int MaPhuong
        {
            get { return _maPhuong; }
            set { _maPhuong = value; }
        }
        private string _tenPhuong;

        public string TenPhuong
        {
            get { return _tenPhuong; }
            set { _tenPhuong = value; }
        }
    }
}
