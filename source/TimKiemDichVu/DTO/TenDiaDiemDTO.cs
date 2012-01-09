using System;
using System.Collections.Generic;
using DTO;
using System.Text;

namespace DTO
{
    public class TenDiaDiemDTO
    {
        private int _maTenDiaDiem;

        public int MaTenDiaDiem
        {
            get { return _maTenDiaDiem; }
            set { _maTenDiaDiem = value; }
        }
        private string _tenDiaDiem;

        public string TenDiaDiem
        {
            get { return _tenDiaDiem; }
            set { _tenDiaDiem = value; }
        }

    }
}
