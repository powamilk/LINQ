using LINQ.BUS.Interface;
using LINQ.DAL.Entities;
using LINQ.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BUS.Implement
{
    public class PhimService : IPhimService
    {
        private readonly IPhimRepo _phimRepo;

        public PhimService(IPhimRepo phimRepo)
        {
            _phimRepo = phimRepo;
        }

        public List<string> LayDangSachPhimCoThoiLuongLonHon100phut()
        {
            return _phimRepo.LayDangSachPhimCoThoiLuongLonHon100phut();
        }

        public List<Phim> LocPhimTheoDaoDienVaLay2PhimDauTien(string daoDien)
        {
            return _phimRepo.LocPhimTheoDaoDienVaLay2PhimDauTien(daoDien);
        }

        public List<string> LocPhimTheoTheLoai(string theLoai)
        {
            return _phimRepo.LocPhimTheoTheLoai(theLoai);
        }

        public List<Phim> LocPhimCoMoTaKhongRong()
        {
            return _phimRepo.LocPhimCoMoTaKhongRong();
        }

        public List<Phim> LayPhimCoThoiLuongDuoi120p()
        {
            return _phimRepo.LayPhimCoThoiLuongDuoi120p();
        }

        public Phim TimPhimDauTienPhatHanhVaoThangHai()
        {
            return _phimRepo.TimPhimDauTienPhatHanhVaoThangHai();
        }

        public List<Phim> LocPhimCoChuCTrongTen()
        {
            return _phimRepo.LocPhimCoChuCTrongTen();
        }

        public List<string> LocVaSapXepPhimTheoTheLoai(string tenPhim)
        {
            return _phimRepo.LocVaSapXepPhimTheoTheLoai(tenPhim);
        }

        public List<Phim> LocCacPhimCoTuHaiTrongTen()
        {
            return _phimRepo.LocCacPhimCoTuHaiTrongTen();
        }

        public List<Phim> LayPhimKhongCoMoTa()
        {
            return _phimRepo.LayPhimKhongCoMoTa();
        }

        public Phim TimPhimCoThoiLuongNganNhat()
        {
            return _phimRepo.TimPhimCoThoiLuongNganNhat();
        }

        public List<Phim> LocPhimTheoTheLoaiKinhDi()
        {
            return _phimRepo.LocPhimTheoTheLoaiKinhDi();
        }

        public List<Phim> LayPhimPhatHanhTruoc2023()
        {
            return _phimRepo.LayPhimPhatHanhTruoc2023();
        }

        public List<string> LayTenPhimVaDaoDienTheoTheLoai(string tenTheLoai)
        {
            return _phimRepo.LayTenPhimVaDaoDienTheoTheLoai(tenTheLoai);
        }

        public List<string> LayBaPhimCoThoiLuongTu90Den150Phut()
        {
            return _phimRepo.LayBaPhimCoThoiLuongTu90Den150Phut();
        }

        public string TimPhimTinhCamDauTienCoMoTa()
        {
            return _phimRepo.TimPhimTinhCamDauTienCoMoTa();
        }

        public List<string> LayPhimTheoThangVaSoLuongTheLoai()
        {
            return _phimRepo.LayPhimTheoThangVaSoLuongTheLoai();
        }

        public List<string> LayNamPhimMoiNhatTheoThoiLuongGiamDan()
        {
            return _phimRepo.LayNamPhimMoiNhatTheoThoiLuongGiamDan();
        }

        public List<string> LocPhimTheoTheLoaiVaLayTenPhim(string tenTheLoai)
        {
            return _phimRepo.LocPhimTheoTheLoaiVaLayTenPhim(tenTheLoai);
        }

        public List<string> LayPhimCoTuKhoaPhimTrongTen()
        {
            return _phimRepo.LayPhimCoTuKhoaPhimTrongTen();
        }

        public string TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai()
        {
            return _phimRepo.TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai();
        }

        public List<string> LocPhimHaiCoThoiLuongLonHon90phut()
        {
            return _phimRepo.LocPhimHaiCoThoiLuongLonHon90phut();
        }

        public List<string> LayHaiPhimHanhDong()
        {
            return _phimRepo.LayHaiPhimHanhDong();
        }

        public List<string> LocPhimKhongCoMoTa()
        {
            return _phimRepo.LocPhimKhongCoMoTa();
        }

        public List<string> LocPhimPhatHanhTruocThang11()
        {
            return _phimRepo.LocPhimPhatHanhTruocThang11();
        }

        public List<string> LayBaPhimHanhDong()
        {
            return _phimRepo.LayBaPhimHanhDong();
        }

        public List<string> LayPhimPhatHanhTuThangHaiTroDi()
        {
            return _phimRepo.LayPhimPhatHanhTuThangHaiTroDi();
        }

        public List<string> LocPhimKinhDi()
        {
            return _phimRepo.LocPhimKinhDi();
        }
    }
}
