using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;
namespace DAO
{
    public class QuanHuyenDAO: DAO
    {
        public QuanHuyenDAO()
            : base()
        {
            _tableName = "QUANHUYEN";
            _fileds = new string[] { "MaQuanHuyen", "TenQuanHuyen" };
        }
        public QuanHuyenDTO createQuanHuyenFromReader(IDataReader iReader)
        {
            QuanHuyenDTO p = new QuanHuyenDTO();
            p.MaQuanHuyen = Convert.ToInt32(iReader[_fileds[0]]);
            p.TenQuanHuyen = iReader[_fileds[1]].ToString();
            return p;
        }
        public  List<QuanHuyenDTO> getListQuanHuyen()
        {
            List<QuanHuyenDTO> lst = new List<QuanHuyenDTO>();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createQuanHuyenFromReader(_iReader));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_iReader != null)
                    _iReader.Close();
                closeConnect();
            }
            return lst;
        }
        public QuanHuyenDTO getQuanHuyenInDulieu(int id)
        {
            QuanHuyenDTO dv = new QuanHuyenDTO();
            IDataReader _iReader = base.get(id);
            if (_iReader.Read())
                dv = createQuanHuyenFromReader(_iReader);
            _iReader.Close();
            return dv;
        }
        public QuanHuyenDTO getQuanHuyen(int id)
        {
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    return createQuanHuyenFromReader(_iReader);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                if (_iReader != null)
                    _iReader.Close();
                closeConnect();
            }
            return null;
        }


    }
}
