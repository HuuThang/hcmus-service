using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public class DichVuDTO
    {
        private int _maDichVu;

        public int MaDichVu
        {
            get { return _maDichVu; }
            set { _maDichVu = value; }
        }
        private string _tenDichVu;

        public string TenDichVu
        {
            get { return _tenDichVu; }
            set { _tenDichVu = value; }
        }

    }
}
