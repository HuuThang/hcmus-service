using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;
namespace DAO
{
    public class DuongDAO:DAO
    {
        public DuongDAO()
            : base()
        {
            _tableName = "DUONG";
            _fileds = new string[] { "MaDuong", "TenDuong" };
        }
        public DuongDTO createDuongFromReader(IDataReader iReader)
        {
            DuongDTO d = new DuongDTO();
            d.MaDuong = Convert.ToInt32(iReader[_fileds[0]]);
            d.TenDuong = iReader[_fileds[1]].ToString();
            return d;
        }
        public  List<DuongDTO> getListDuong()
        {
            List<DuongDTO> lst = new List<DuongDTO>();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createDuongFromReader(_iReader));
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
        public DuongDTO getDuongInDulieu(int id)
        {
            DuongDTO dv = new DuongDTO();
            IDataReader _iReader = base.get(id);
            if (_iReader.Read())
                dv = createDuongFromReader(_iReader);
            _iReader.Close();
            return dv;
        }
        /// <summary>
        /// Lấy 1 đường khi biết id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DuongDTO getDuong(int id)
        {
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    return createDuongFromReader(_iReader);
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
