using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;
namespace DAO
{
    public class PhuongDAO:DAO
    {
        public PhuongDAO()
            : base()
        {
            _tableName = "PHUONG";
            _fileds = new string[] { "MaPhuong", "TenPhuong" };
        }
        public PhuongDTO createPhuongFromReader(IDataReader iReader)
        {
            PhuongDTO p = new PhuongDTO();
            p.MaPhuong = Convert.ToInt32(iReader[_fileds[0]]);
            p.TenPhuong = iReader[_fileds[1]].ToString();
            return p;
        }
        public  List<PhuongDTO> getListPhuong()
        {
            List<PhuongDTO> lst = new List<PhuongDTO>();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createPhuongFromReader(_iReader));
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
        public PhuongDTO getPhuongInDulieu(int id)
        {
            PhuongDTO dv = new PhuongDTO();
            IDataReader _iReader = base.get(id);
            if (_iReader.Read())
                dv = createPhuongFromReader(_iReader);
            _iReader.Close();
            return dv;
        }
        public PhuongDTO getPhuong(int id)
        {
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    return createPhuongFromReader(_iReader);
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
