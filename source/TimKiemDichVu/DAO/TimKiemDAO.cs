using System;
using System.Collections.Generic;

using System.Text;
using DTO;

namespace DAO
{
    public class TimKiemDAO:DB
    {

        private TuKhoaDichVuDAO _tkDV;
        private TuKhoaDuongDAO _tkD;
        private TuKhoaPhuongDAO _tkP;
        private TuKhoaQuanHuyenDAO _tkQH;
        private TuKhoaTenDiaDiemDAO _tkTDD;
        private TuKhoaTinhThanhDAO _tkTT;
        private DuLieuDAO _dlDAO;
        public TimKiemDAO():base()
        {
            _dlDAO = new DuLieuDAO();
            _tkD = new TuKhoaDuongDAO();
            _tkDV = new TuKhoaDichVuDAO();
            _tkP = new TuKhoaPhuongDAO();
            _tkQH = new TuKhoaQuanHuyenDAO();
            _tkTDD = new TuKhoaTenDiaDiemDAO();
            _tkTT = new TuKhoaTinhThanhDAO();
            _dlDAO.Dbmanager = _dbmanager;
            _tkD.Dbmanager = _dlDAO.Dbmanager;
            _tkDV.Dbmanager = _dlDAO.Dbmanager;
            _tkD.Dbmanager = _dlDAO.Dbmanager;
            _tkP.Dbmanager = _dlDAO.Dbmanager;
            _tkQH.Dbmanager = _dlDAO.Dbmanager;
            _tkTDD.Dbmanager = _dlDAO.Dbmanager;
            _tkTT.Dbmanager = _dlDAO.Dbmanager;
        }
        private  int _resultCount;

        public  int ResultCount
        {
            get { return _resultCount; }
        }


        public int Pages()
        {
            int _pages = _resultCount/Comm.PageSize;
            return _resultCount % Comm.PageSize == 0 ? _pages : _pages + 1;
        }
        private  string _sqlSearch;

        public  string SqlSearch
        {
            get { return _sqlSearch; }
            set { _sqlSearch = value; }
        }

        
        /// <summary>
        /// Tìm kiếm trên tất cả các dịch vụ
        /// </summary>
        /// <param name="_strChuoiDieuKien"></param>
        /// <returns></returns>
        public List<DuLieuDTO> timKiem(string  _strChuoiDieuKien)
        {
            List<DuLieuDTO> lst = new List<DuLieuDTO>();
            try
            {
                openConnect();
           
                //B1. Tìm trong table TUKHOADICHVU

                List<TuKhoaDTO> lstTKDV = _tkDV.getListTuKhoa(ref _strChuoiDieuKien);

                //B2. Tìm trong table TUKHOATINHTHANH
                List<TuKhoaDTO> lstTKTT = _tkTT.getListTuKhoa(ref _strChuoiDieuKien, lstTKDV);

                //B3. Tìm trong table TUKHOAQUANHUYEN
                List<TuKhoaDTO> lstTKQH = _tkQH.getListTuKhoa(ref _strChuoiDieuKien, lstTKDV, lstTKTT);

                //B4. Tìm trong table TUKHOAPHUONG
                List<TuKhoaDTO> lstTKP = _tkP.getListTuKhoa(ref _strChuoiDieuKien, lstTKDV, lstTKTT, lstTKQH);

                //B5. Tìm trong table TUKHOADUONG
                List<TuKhoaDTO> lstTKD = _tkD.getListTuKhoa(ref _strChuoiDieuKien, lstTKDV, lstTKTT, lstTKQH, lstTKP);

                //B6. Tìm trong table TUKHOADIADIEM
                List<TuKhoaDTO> lstTKTDD = _tkTDD.getListTuKhoa(ref _strChuoiDieuKien, lstTKDV, lstTKTT, lstTKQH, lstTKP, lstTKD);

                
                if (TuKhoaDAO.isEmpty(lstTKD, lstTKDV, lstTKP, lstTKQH, lstTKTDD, lstTKTT))
                    return lst;
                StringBuilder _sql = new StringBuilder("select DISTINCT * from DULIEU Where ");
                int flag = 0;
                TuKhoaDAO._builtSQL(lstTKDV, ref _sql, "MaDichVu", ref flag);
                TuKhoaDAO._builtSQL(lstTKTT, ref _sql, "MaTinhThanh", ref flag);
                TuKhoaDAO._builtSQL(lstTKTDD, ref _sql, "MaTenDiaDiem", ref flag);
                TuKhoaDAO._builtSQL(lstTKP, ref _sql, "MaPhuong", ref flag);
                TuKhoaDAO._builtSQL(lstTKQH, ref _sql, "MaQuanHuyen", ref flag);
                TuKhoaDAO._builtSQL(lstTKD, ref _sql, "MaDuong", ref flag);
                _sqlSearch = _sql.ToString();
                lst = _dlDAO.getListDuLieu(_sql.ToString(), 0, Comm.PageSize);
                // Hủy
                lstTKD = lstTKP = lstTKQH = lstTKTDD = lstTKTT = null;
                // Lưu lại result count
                _resultCount = Convert.ToInt32(_dbmanager.ExecuteScalar(System.Data.CommandType.Text, _sqlSearch.Replace("*", " count(*) ").ToString()));
                    

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

        public List<DuLieuDTO> getPage(int page)
        {
            List<DuLieuDTO> lst = new List<DuLieuDTO>();
            try
            {
                openConnect();
                int _end = Comm.PageSize * page;
                int _start = _end - Comm.PageSize;
                lst = _dlDAO.getListDuLieu(_sqlSearch, _start, _end);
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
        /// <summary>
        /// Tìm kiếm với mã dịch vụ đã xác định
        /// </summary>
        /// <param name="_strChuoiDieuKien"></param>
        /// <param name="_maDichVu"></param>
        /// <returns>List<DuLieuDTO></returns>
        public List<DuLieuDTO> timKiem(string _strChuoiDieuKien, int _maDichVu)
        {
            openConnect();
            List<DuLieuDTO> lst = new List<DuLieuDTO>();
            try
            {
                //B1. Tìm trong table TUKHOATINHTHANH
                List<TuKhoaDTO> lstTKTT = _tkTT.getListTuKhoa(ref _strChuoiDieuKien, null);

                //B2. Tìm trong table TUKHOAQUANHUYEN
                List<TuKhoaDTO> lstTKQH = _tkQH.getListTuKhoa(ref _strChuoiDieuKien, null, lstTKTT);

                //B3. Tìm trong table TUKHOAPHUONG
                List<TuKhoaDTO> lstTKP = _tkP.getListTuKhoa(ref _strChuoiDieuKien, null, lstTKTT, lstTKQH);

                //B4. Tìm trong table TUKHOADUONG
                List<TuKhoaDTO> lstTKD = _tkD.getListTuKhoa(ref _strChuoiDieuKien, null, lstTKTT, lstTKQH, lstTKP);

                //B5. Tìm trong table TUKHOADIADIEM
                List<TuKhoaDTO> lstTKTDD = _tkTDD.getListTuKhoa(ref _strChuoiDieuKien, null, lstTKTT, lstTKQH, lstTKP, lstTKD);

                
                if (TuKhoaDAO.isEmpty(lstTKD, lstTKP, lstTKQH, lstTKTDD, lstTKTT))
                    return lst;
                
                StringBuilder _sql = new StringBuilder();
                _sql.AppendFormat("select DISTINCT * from DULIEU b Where MaDichVu={0} And ", _maDichVu);
                int flag = 0;
                TuKhoaDAO._builtSQL(lstTKTT, ref _sql, "MaTinhThanh", ref flag);
                TuKhoaDAO._builtSQL(lstTKTDD, ref _sql, "MaTenDiaDiem", ref flag);
                TuKhoaDAO._builtSQL(lstTKP, ref _sql, "MaPhuong", ref flag);
                TuKhoaDAO._builtSQL(lstTKQH, ref _sql, "MaQuanHuyen", ref flag);
                TuKhoaDAO._builtSQL(lstTKD, ref _sql, "MaDuong", ref flag);
                _sqlSearch = _sql.ToString();

                lst = _dlDAO.getListDuLieu(_sql.ToString(), 0, Comm.PageSize);
                // Hủy
                lstTKD = lstTKP = lstTKQH = lstTKTDD = lstTKTT = null;
                // Lưu lại result count
                _resultCount = Convert.ToInt32(_dbmanager.ExecuteScalar(System.Data.CommandType.Text, _sqlSearch.Replace("*", " count(*) ").ToString()));
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
        

    }
}