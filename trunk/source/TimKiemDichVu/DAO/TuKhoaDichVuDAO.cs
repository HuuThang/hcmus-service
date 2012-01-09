using System;
using System.Collections.Generic;

using System.Text;

namespace DAO
{
    public class TuKhoaDichVuDAO:TuKhoaDAO
    {
        public TuKhoaDichVuDAO():base("TUKHOADICHVU", new string[]{"MaTuKhoaDichVu", "TuKhoaDichVu", "MaDichVu"})
        {
        }
        public override string _builtSQL(params List<DTO.TuKhoaDTO>[] arrListTuKhoa)
        {
            string sql2 = String.Format("select DISTINCT * from {0} where  INSTR(@dk, {1}) > 0", _tableName, _fileds[1]);
            return sql2;
        }
    }
}
