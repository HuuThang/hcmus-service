using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;
using System.Linq;
namespace DAO
{
    public class DuLieuDAO:DAO
    {
        private DichVuDAO _dvDAO;
        private TenDiaDiemDAO _tddDAO;
        private PhuongDAO _pDAO;
        private DuongDAO _dDAO;
        private QuanHuyenDAO _qhDAO;
        private TinhThanhDAO _ttDAO;
        public DuLieuDAO()
            : base()
        {
            _tableName = "DULIEU";
            _fileds = new string[] { "MaDuLieu", "MaDichVu","MaTenDiaDiem","SoNha","MaDuong","MaPhuong","MaQuanHuyen","MaTinhThanh","KinhDo","ViDo","ChuThich"  };
            _dDAO = new DuongDAO();
            _dvDAO = new DichVuDAO();
            _tddDAO = new TenDiaDiemDAO();
            _pDAO = new PhuongDAO();
            _qhDAO = new QuanHuyenDAO();
            _ttDAO = new TinhThanhDAO();
            InitDAORef();

        }

        private void InitDAORef()
        {
            _dDAO.Dbmanager = _dbmanager;
            _dvDAO.Dbmanager = _dbmanager;
            _tddDAO.Dbmanager = _dbmanager;
            _pDAO.Dbmanager = _dbmanager;
            _qhDAO.Dbmanager = _dbmanager;
            _ttDAO.Dbmanager = _dbmanager;
        }
        private DuLieuDTO createDuLieuFromReader(IDataReader reader)
        {
            
            DuLieuDTO dl = new DuLieuDTO();
            try
            {
                dl.MaDuLieu = Convert.ToInt32(reader[_fileds[0]]);
                dl.DichVu = _dvDAO.getDichVuInDulieu(Convert.ToInt32(reader[_fileds[1]]));
                dl.TenDiaDiem = _tddDAO.getTenDiaDiemInDulieu(Convert.ToInt32(reader[_fileds[2]]));
                dl.SoNha = reader[_fileds[3]] == null ? "" : reader[_fileds[3]].ToString();
                dl.Duong = _dDAO.getDuongInDulieu(Convert.ToInt32(reader[_fileds[4]]));
                dl.Phuong = _pDAO.getPhuongInDulieu(Convert.ToInt32(reader[_fileds[5]]));
                dl.QuanHuyen = _qhDAO.getQuanHuyenInDulieu(Convert.ToInt32(reader[_fileds[6]]));
                dl.TinhThanh = _ttDAO.getTinhThanhInDulieu(Convert.ToInt32(reader[_fileds[7]]));
                dl.KinhDo = Convert.ToDouble(reader[_fileds[8]]);
                dl.ViDo = Convert.ToDouble(reader[_fileds[9]]);
                dl.ChuThich = reader[_fileds[10]] == null ? "" : reader[_fileds[10]].ToString();
            }
            catch (Exception)
            {
            }
            return dl;
        }
        private DuLieuDTO createDuLieuFromRow(DataRow row)
        {

            DuLieuDTO dl = new DuLieuDTO();
            try
            {
                dl.MaDuLieu = Convert.ToInt32(row[_fileds[0]]);
                dl.DichVu = _dvDAO.getDichVuInDulieu(Convert.ToInt32(row[_fileds[1]]));
                dl.TenDiaDiem = _tddDAO.getTenDiaDiemInDulieu(Convert.ToInt32(row[_fileds[2]]));
                dl.SoNha = row[_fileds[3]] == null ? "" : row[_fileds[3]].ToString();
                dl.Duong = _dDAO.getDuongInDulieu(Convert.ToInt32(row[_fileds[4]]));
                dl.Phuong = _pDAO.getPhuongInDulieu(Convert.ToInt32(row[_fileds[5]]));
                dl.QuanHuyen = _qhDAO.getQuanHuyenInDulieu(Convert.ToInt32(row[_fileds[6]]));
                dl.TinhThanh = _ttDAO.getTinhThanhInDulieu(Convert.ToInt32(row[_fileds[7]]));
                dl.KinhDo = Convert.ToDouble(row[_fileds[8]]);
                dl.ViDo = Convert.ToDouble(row[_fileds[9]]);
                dl.ChuThich = row[_fileds[10]] == null ? "" : row[_fileds[10]].ToString();
            }
            catch (Exception)
            {
            }
            return dl;
        }
        /// <summary>
        /// Lấy tất cả dữ liệu(Có dùng ko?)
        /// </summary>
        /// <returns></returns>
        public  List<DuLieuDTO> getListDuLieu()
        {
            List<DuLieuDTO> lst = new List<DuLieuDTO>();
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.getList();
                while (_iReader.Read())
                    lst.Add(createDuLieuFromReader(_iReader));
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
        /// Lấy 1 dòng dữ liệu khi biết mã số
        /// </summary>
        /// <returns></returns>
        public DuLieuDTO getDuLieu(int id)
        {
            IDataReader _iReader = null;
            try
            {
                openConnect();
                _iReader = base.get(id);
                if (_iReader.Read())
                    return createDuLieuFromReader(_iReader);
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

        /// <summary>
        /// Lấy danh sách theo sql
        /// </summary>
        /// <returns></returns>
        ///
        public List<DuLieuDTO> getListDuLieu(string _sql, int _start, int _end)
        {
            List<DuLieuDTO> lst = new List<DuLieuDTO>();
            InitDAORef();
            DataTable _dtb = null;
            _dtb = base.getTable(_sql);

            int _nRows = _dtb.Rows.Count;
            if (_dtb == null || _nRows == 0)
                return lst;
            
            if (_end > _nRows)
                _end = _nRows;
            
            for (int i = _start; i < _end; i++)
            {
                lst.Add(createDuLieuFromRow(_dtb.Rows[i]));
            }
            
            _dtb.Dispose();
            
            return lst;
        }
    }
}
