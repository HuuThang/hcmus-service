using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;
namespace DAO
{
    public class TinhThanhDAO:DAO
    {
                public TinhThanhDAO()
            : base()
        {
            _tableName = "TINHTHANH";
            _fileds = new string[] { "MaTinhThanh", "TenTinhThanh" };
        }
        public TinhThanhDTO createTinhThanhFromReader(IDataReader iReader)
        {
            TinhThanhDTO p = new TinhThanhDTO();
            p.MaTinhThanh = Convert.ToInt32(iReader[_fileds[0]]);
            p.TenTinhThanh = iReader[_fileds[1]].ToString();
            return p;
        }
        public  List<TinhThanhDTO> getListTinhThanh()
        {
            List<TinhThanhDTO> lst = new List<TinhThanhDTO>();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createTinhThanhFromReader(_iReader));
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
        public TinhThanhDTO getTinhThanhInDulieu(int id)
        {
            TinhThanhDTO dv = new TinhThanhDTO();
            IDataReader _iReader = base.get(id);
            if (_iReader.Read())
                dv = createTinhThanhFromReader(_iReader);
            _iReader.Close();
            return dv;
        }
        public TinhThanhDTO getTinhThanh(int id)
        {
            IDataReader _iReader=null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    return createTinhThanhFromReader(_iReader);
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
