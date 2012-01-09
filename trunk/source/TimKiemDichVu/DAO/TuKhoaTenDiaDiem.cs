using System;
using System.Collections.Generic;

using System.Text;

namespace DAO
{
    public class TuKhoaTenDiaDiemDAO:TuKhoaDAO
    {
        public TuKhoaTenDiaDiemDAO():base("TUKHOADIADIEM", new string[]{"MaTuKhoaTenDiaDiem", "TuKhoaTenDiaDiem", "MaTenDiaDiem"})
        {
        }
        public override string _builtSQL(params List<DTO.TuKhoaDTO>[] arrListTuKhoa)
        {

            if (isEmpty(arrListTuKhoa))
                return String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0", _tableName, _fileds[1]);
            StringBuilder sql1 = new StringBuilder("select DISTINCT MaTenDiaDiem from DULIEU where");
            int flag = 0;
            if (!isEmpty(arrListTuKhoa[0]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[0], ref sql1, "MaDichVu", ref flag);
            if (!isEmpty(arrListTuKhoa[1]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[1], ref sql1, "MaTinhThanh", ref flag);
            if (!isEmpty(arrListTuKhoa[2]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[2], ref sql1, "MaPhuong", ref flag);
            if (!isEmpty(arrListTuKhoa[3]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[3], ref sql1, "MaDuong", ref flag);
            if (!isEmpty(arrListTuKhoa[4]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[4], ref sql1, "MaTenDiaDiem", ref flag);
            string sql2 = String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0 And MaTenDiaDiem in ({2})", _tableName, _fileds[1], sql1);
            return sql2;
        }
    }
}
