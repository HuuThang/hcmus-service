using System;
using System.Collections.Generic;

using System.Text;

namespace DAO
{
    public class TuKhoaQuanHuyenDAO:TuKhoaDAO
    {
        public TuKhoaQuanHuyenDAO():base("TUKHOAQUANHUYEN", new string[]{"MaTuKhoaQuanHuyen", "TuKhoaQuanHuyen", "MaQuanHuyen"})
        {
        }
        public override string _builtSQL(params List<DTO.TuKhoaDTO>[] arrListTuKhoa)
        {

            if (isEmpty(arrListTuKhoa))
                return String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0", _tableName, _fileds[1]);
            StringBuilder sql1 = new StringBuilder("select DISTINCT MaQuanHuyen from DULIEU where");
            int flag = 0;
            if (!isEmpty(arrListTuKhoa[0]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[0], ref sql1, "MaDichVu", ref flag);
            if (!isEmpty(arrListTuKhoa[1]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[1], ref sql1, "MaTinhThanh", ref flag);
            string sql2 = String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0 And MaQuanHuyen in ({2})", _tableName, _fileds[1], sql1);
            return sql2;
        }
    }
}
