using System;
using System.Collections.Generic;

using System.Text;

namespace DTO
{
    public class DuLieuDTO
    {
        public DuLieuDTO()
        {
            _duong = new DuongDTO();
            _phuong = new PhuongDTO();
            _quanHuyen = new QuanHuyenDTO();
            _tenDiaDiem = new TenDiaDiemDTO();
            _tinhThanh = new TinhThanhDTO();
            _dichVu = new DichVuDTO();
        }
        private int _maDuLieu;

        public int MaDuLieu
        {
            get { return _maDuLieu; }
            set { _maDuLieu = value; }
        }
        private DichVuDTO _dichVu;

        public DichVuDTO DichVu
        {
            get { return _dichVu; }
            set { _dichVu = value; }
        }
        private TenDiaDiemDTO _tenDiaDiem;

        public TenDiaDiemDTO TenDiaDiem
        {
            get { return _tenDiaDiem; }
            set { _tenDiaDiem = value; }
        }
        private string _soNha;

        public string SoNha
        {
            get { return _soNha; }
            set { _soNha = value; }
        }
        private DuongDTO _duong;

        public DuongDTO Duong
        {
            get { return _duong; }
            set { _duong = value; }
        }
        private PhuongDTO _phuong;

        public PhuongDTO Phuong
        {
            get { return _phuong; }
            set { _phuong = value; }
        }
        private QuanHuyenDTO _quanHuyen;

        public QuanHuyenDTO QuanHuyen
        {
            get { return _quanHuyen; }
            set { _quanHuyen = value; }
        }
        private TinhThanhDTO _tinhThanh;

        public TinhThanhDTO TinhThanh
        {
            get { return _tinhThanh; }
            set { _tinhThanh = value; }
        }
        private double _kinhDo;

        public double KinhDo
        {
            get { return _kinhDo; }
            set { _kinhDo = value; }
        }
        private double _viDo;

        public double ViDo
        {
            get { return _viDo; }
            set { _viDo = value; }
        }
        private string _chuThich;

        public string ChuThich
        {
            get { return _chuThich; }
            set { _chuThich = value; }
        }

    }
}
