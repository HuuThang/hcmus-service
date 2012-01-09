using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public  class TuKhoaDTO
    {
        private int _maTuKhoa;

        public int MaTuKhoa
        {
            get { return _maTuKhoa; }
            set { _maTuKhoa = value; }
        }
        private string _TuKhoa;

        public string TuKhoa
        {
            get { return _TuKhoa; }
            set { _TuKhoa = value; }
        }
        private int _khoaNgoai;

        public int KhoaNgoai
        {
            get { return _khoaNgoai; }
            set { _khoaNgoai = value; }
        }
    }
}
