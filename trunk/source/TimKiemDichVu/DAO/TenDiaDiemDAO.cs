using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using DTO;
namespace DAO
{
    public class TenDiaDiemDAO:DAO
    {
        public TenDiaDiemDAO()
            : base()
        {
            _tableName = "TENDIADIEM";
            _fileds = new string[] { "MaTenDiaDiem", "TenDiaDiem" };
        }
        public TenDiaDiemDTO createTenDiaDiemFromReader(IDataReader iReader)
        {
            TenDiaDiemDTO tdd = new TenDiaDiemDTO();
            tdd.MaTenDiaDiem = Convert.ToInt32(iReader[_fileds[0]]);
            tdd.TenDiaDiem = iReader[_fileds[1]].ToString();
            return tdd;
        }
        public  List<TenDiaDiemDTO> getListTenDiaDiem()
        {
            List<TenDiaDiemDTO> lst = new List<TenDiaDiemDTO>();
            try
            {
                openConnect();
                IDataReader _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createTenDiaDiemFromReader(_iReader));
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
        public TenDiaDiemDTO getTenDiaDiemInDulieu(int id)
        {
            TenDiaDiemDTO dv = new TenDiaDiemDTO();
            IDataReader _iReader = base.get(id);
            if (_iReader.Read())
                dv = createTenDiaDiemFromReader(_iReader);
            _iReader.Close();
            return dv;
        }
        public TenDiaDiemDTO getTenDiaDiem(int id)
        {
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    return createTenDiaDiemFromReader(_iReader);
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
