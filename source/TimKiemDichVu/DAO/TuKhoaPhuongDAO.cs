﻿using System;
using System.Collections.Generic;

using System.Text;

namespace DAO
{
    public class TuKhoaPhuongDAO:TuKhoaDAO
    {
        public TuKhoaPhuongDAO():base("TUKHOAPHUONG", new string[]{"MaTuKhoaPhuong", "TuKhoaPhuong", "MaPhuong"})
        {
        }

        public override string _builtSQL( params List<DTO.TuKhoaDTO>[] arrListTuKhoa)
        {

            if (isEmpty(arrListTuKhoa))
                return String.Format("select * from {0} where  INSTR(@dk, {1}) > 0", _tableName, _fileds[1]);
            StringBuilder sql1 = new StringBuilder("select MaPhuong from DULIEU where");
            int flag = 0;
            if (!isEmpty(arrListTuKhoa[0]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[0], ref sql1, "MaDichVu", ref flag);
            if (!isEmpty(arrListTuKhoa[1]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[1], ref sql1, "MaTinhThanh", ref flag);
            if (!isEmpty(arrListTuKhoa[2]))
                TuKhoaDAO._builtSQL(arrListTuKhoa[2], ref sql1, "MaPhuong", ref flag);
            string sql2 = String.Format("select * from {0} where  INSTR(@dk, {1}) > 0 And MaPhuong in ({2})", _tableName, _fileds[1], sql1);
            return sql2;
        }
    }
}
