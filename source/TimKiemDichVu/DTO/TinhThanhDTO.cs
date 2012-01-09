using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public class TinhThanhDTO
    {
        private int _maTinhThanh;

        public int MaTinhThanh
        {
            get { return _maTinhThanh; }
            set { _maTinhThanh = value; }
        }
        private string _tenTinhThanh;

        public string TenTinhThanh
        {
            get { return _tenTinhThanh; }
            set { _tenTinhThanh = value; }
        }

    }
}
