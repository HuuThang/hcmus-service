using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;
namespace DAO
{
    public abstract  class TuKhoaDAO:DAO
    {
        public TuKhoaDAO(string _tableName, string[] _fileds)
            : base()
        {
            this._tableName = _tableName;
            this._fileds = _fileds;
        }
        public  TuKhoaDTO createTuKhoaFromReader(IDataReader iReader)
        {
            TuKhoaDTO p = new TuKhoaDTO();
            p.MaTuKhoa = Convert.ToInt32(iReader[_fileds[0]]);
            p.TuKhoa = iReader[_fileds[1]].ToString();
            p.KhoaNgoai = Convert.ToInt32(iReader[_fileds[2]]);
            return p;
        }
        public  List<TuKhoaDTO> getListTuKhoa()
        {
            List<TuKhoaDTO> lst = new List<TuKhoaDTO>();
            try
            {
                openConnect();
                IDataReader _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createTuKhoaFromReader(_iReader));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                closeConnect();
            }
            return lst;
        }
        public TuKhoaDTO getTuKhoa()
        {
            try
            {
                openConnect();
                IDataReader _iReader = base.getList();
                if (_iReader.Read())
                    return createTuKhoaFromReader(_iReader);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                closeConnect();
            }
            return null;
        }
        public static bool isEmpty(params List<TuKhoaDTO>[] lst)
        {
            if (lst == null || lst.Length == 0)
                return true;
            int count = 0;
            foreach (var item in lst)
            {
                if (item == null || item.Count == 0)
                    count++;
            }
            return count == lst.Length;
        }
        public static   void _builtSQL(List<TuKhoaDTO> lst, ref StringBuilder _sql, string _filed, ref int _flag)
        {
            if (lst != null && lst.Count > 0)
            {
                _sql.Append(_flag == 0 ? "" : " And ");
                _flag++;
                _sql.AppendFormat(" {0} in ({1}", _filed, lst[0].KhoaNgoai);
                for (int i = 1; i < lst.Count; i++)
                {
                    _sql.AppendFormat(",{0}", lst[i].KhoaNgoai);
                }
                _sql.Append(")");
            }
        }
        public abstract string _builtSQL(params List<TuKhoaDTO>[] arrListTuKhoa);

        /// <summary>
        /// Lấy danh sách theo sql
        /// </summary>
        /// <returns></returns>
        ///
        public List<TuKhoaDTO> getListTuKhoa(ref string _chuoiDieuKien, params List<TuKhoaDTO>[] arrListTuKhoa)
        {
            if (_chuoiDieuKien == null || _chuoiDieuKien == "")
                return null;
            List<TuKhoaDTO> lst = new List<TuKhoaDTO>();
            IDataReader _iReader = null;
            _iReader = base.getList(_builtSQL(arrListTuKhoa), _chuoiDieuKien);
            while (_iReader.Read())
            {
                
                lst.Add(createTuKhoaFromReader(_iReader));
                //_chuoiDieuKien = _chuoiDieuKien.Replace(_iReader[1].ToString(), "");
            }
            _iReader.Close();
            return lst.Count == 0 ? null : lst;
        }

    }
}
