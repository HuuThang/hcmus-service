using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public class QuanHuyenDTO
    {
        private int _maQuanHuyen;

        public int MaQuanHuyen
        {
            get { return _maQuanHuyen; }
            set { _maQuanHuyen = value; }
        }
        private string _tenQuanHuyen;

        public string TenQuanHuyen
        {
            get { return _tenQuanHuyen; }
            set { _tenQuanHuyen = value; }
        }

    }
}
