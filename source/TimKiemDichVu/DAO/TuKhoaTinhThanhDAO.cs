using System;
using System.Collections.Generic;

using System.Text;

namespace DAO
{
    public class TuKhoaTinhThanhDAO:TuKhoaDAO
    {
        public TuKhoaTinhThanhDAO():base("TUKHOATINHTHANH", new string[]{"MaTuKhoaTinhThanh", "TuKhoaTinhThanh", "MaTinhThanh"})
        {
        }
        public override string _builtSQL(params List<DTO.TuKhoaDTO>[] arrListTuKhoa)
        {

            if (isEmpty(arrListTuKhoa))
                return String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0", _tableName, _fileds[1]);
            StringBuilder sql1 = new StringBuilder("select DISTINCT MaTinhThanh from DULIEU where");
            int flag = 0;
            if (!isEmpty(arrListTuKhoa[0]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[0], ref sql1, "MaDichVu", ref flag);
            string sql2 = String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0 And MaTinhThanh in ({2})", _tableName, _fileds[1], sql1);
            return sql2;
        }
    }
}
