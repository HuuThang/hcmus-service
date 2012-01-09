using System;
using System.Collections.Generic;
using DTO;
using System.Text;
using System.Data;
namespace DAO
{
    public  class DichVuDAO: DAO
    {

        public DichVuDAO()
            : base()
        {
            _tableName = "DICHVU";
            _fileds = new string[] { "MaDichVu", "TenDichVu" };
        }
        public DichVuDTO createDichVuFromReader(IDataReader iReader)
        {
            DichVuDTO dv = new DichVuDTO();
            dv.MaDichVu = Convert.ToInt32(iReader[_fileds[0]]);
            dv.TenDichVu = iReader[_fileds[1]].ToString();
            return dv;
        }
        /// <summary>
        /// Lấy danh sách tất cả các dịch vụ
        /// </summary>
        /// <returns></returns>
        public  List<DichVuDTO> getListDichVu()
        {
            List<DichVuDTO> lst = new List<DichVuDTO>();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createDichVuFromReader(_iReader));
                _iReader.Close();
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

        /// <summary>
        /// Phương thức này ko dùng đơn lẻ.
        /// Lấy 1 dịch vụ khi biết mã số 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DichVuDTO getDichVuInDulieu(int id)
        {
            DichVuDTO dv = new DichVuDTO();
            IDataReader _iReader = base.get(id);
            if (_iReader.Read())
                dv = createDichVuFromReader(_iReader);
            _iReader.Close();
            return dv;
        }
        /// <summary>
        /// Lấy 1 dịch vụ khi biết mã số. Dùng đơn lẻ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DichVuDTO getDichVu(int id)
        {
            DichVuDTO dl = new DichVuDTO();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    dl = createDichVuFromReader(_iReader);

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
            return dl;
        }




    }
}
