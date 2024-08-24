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
        // 20 /8 
        public IEnumerable<Phim> LayTatCaPhim()
        {
            return _phimRepo.LayTatCaPhim();
        }

        public IEnumerable<Phim> LayPhimLonHon100Phut()
        {
            return _phimRepo.LayPhimLonHon100Phut();
        }

        public IEnumerable<Phim> LayPhimTheoDaoDien(string daoDien)
        {
            return _phimRepo.LayPhimTheoDaoDien(daoDien);
        }

        public IEnumerable<Phim> LayPhimMoiNhat()
        {
            return _phimRepo.LayPhimMoiNhat();
        }

        public IEnumerable<Phim> LayPhimTheoNgayPhatHanhSau(DateOnly date)
        {
            return _phimRepo.LayPhimTheoNgayPhatHanhSau(date);
        }

        public IEnumerable<Phim> LayPhimTheoTheLoai(string tenTheLoai)
        {
            return _phimRepo.LayPhimTheoTheLoai(tenTheLoai);
        }

        public IEnumerable<Phim> LayPhimCoMoTaKhongRong()
        {
            return _phimRepo.LayPhimCoMoTaKhongRong();
        }

        public IEnumerable<Phim> LayPhimThoiLuongDuoi120()
        {
            return _phimRepo.LayPhimThoiLuongDuoi120();
        }

        public Phim LayPhimDauTienTheoThangPhatHanh(int month)
        {
            return _phimRepo.LayPhimDauTienTheoThangPhatHanh(month);
        }

        public IEnumerable<Phim> LayPhimTheoTuKhoaTrongTen(string keyword)
        {
            return _phimRepo.LayPhimTheoTuKhoaTrongTen(keyword);
        }

        public IEnumerable<object> LayPhimVaSoNgayDenNgayPhatHanh(int minThoiLuong)
        {
            return _phimRepo.LayPhimVaSoNgayDenNgayPhatHanh(minThoiLuong);
        }

        public IEnumerable<Phim> LayPhimTheoTenVaTheLoai(string tenPhim, string tenTheLoai)
        {
            return _phimRepo.LayPhimTheoTenVaTheLoai(tenPhim, tenTheLoai);
        }

        public IEnumerable<Phim> LayPhimTheoTuKhoaVaThoiLuongHon90(string keyword)
        {
            return _phimRepo.LayPhimCoTuKhoaTrongTenVaThoiLuongHon90(keyword);
        }

        public IEnumerable<Phim> LayPhimKhongCoMoTa()
        {
            return _phimRepo.LayPhimKhongCoMoTa();
        }

        public Phim LayPhimCoThoiLuongNganNhat()
        {
            return _phimRepo.LayPhimCoThoiLuongNganNhat();
        }

        public IEnumerable<Phim> LayTopNPhimTheoTheLoai(string tenTheLoai, int n)
        {
            return _phimRepo.LayTopNPhimTheoTheLoai(tenTheLoai, n);
        }

        public IEnumerable<Phim> LayPhimPhatHanhTruocNam(int year)
        {
            return _phimRepo.LayPhimPhatHanhTruocNam(year);
        }

        public IEnumerable<Phim> LayPhimTheoTheLoaiVaSapXep(string theLoai)
        {
            return _phimRepo.LayPhimTheoTheLoaiVaSapXep(theLoai);
        }

        public IEnumerable<Phim> LayPhimTheoKhoangThoiLuong(int minThoiLuong, int maxThoiLuong)
        {
            return _phimRepo.LayPhimTheoKhoangThoiLuong(minThoiLuong, maxThoiLuong);
        }

        public Phim LayPhimDauTienCoTheLoaiVaMoTa(string tenTheLoai)
        {
            return _phimRepo.LayPhimDauTienCoTheLoaiVaMoTa(tenTheLoai);
        }

        public IEnumerable<object> LayPhimTheoThangVaDemSoLuongTheLoai(int month)
        {
            return _phimRepo.LayPhimTheoThangVaDemSoLuongTheLoai(month);
        }

        public IEnumerable<Phim> Lay5PhimMoiNhatSapXepTheoThoiLuong()
        {
            return _phimRepo.Lay5PhimMoiNhatSapXepTheoThoiLuong();
        }

        public IEnumerable<Phim> LayPhimTheoTuKhoaVaDaoDien(string keyword, string daoDien)
        {
            return _phimRepo.LayPhimTheoTuKhoaVaDaoDien(keyword, daoDien);
        }

        public IEnumerable<Phim> LayPhimCoNhieuTheLoai()
        {
            return _phimRepo.LayPhimCoNhieuTheLoai();
        }

        public IEnumerable<Phim> LayPhimTheoTenDaoDien(string partialName)
        {
            return _phimRepo.LayPhimTheoTenDaoDien(partialName);
        }

        public Phim LayPhimPhatHanhSomNhatVaDemTheLoai()
        {
            return _phimRepo.LayPhimPhatHanhSomNhatVaDemTheLoai();
        }

        public IEnumerable<Phim> LayPhimCoTuKhoaTrongTenVaThoiLuongHon90(string keyword)
        {
            return _phimRepo.LayPhimCoTuKhoaTrongTenVaThoiLuongHon90(keyword);
        }

        public IEnumerable<Phim> LayTopNPhimTheoTheLoai(int n, string tenTheLoai)
        {
            return _phimRepo.LayTopNPhimTheoTheLoai(n, tenTheLoai);
        }

        public IEnumerable<Phim> LayPhimPhatHanhTruocThang(int month)
        {
            return _phimRepo.LayPhimPhatHanhTruocThang(month);
        }

        public IEnumerable<Phim> LayPhimTheoThangVaTheLoai(string tenTheLoai)
        {
            return _phimRepo.LayPhimTheoThangVaTheLoai(tenTheLoai);
        }

        public IEnumerable<Phim> LayPhimTheoThangVaSapXep(int month)
        {
            return _phimRepo.LayPhimTheoThangVaSapXep(month);
        }

        public void ThemPhim(Phim phim)
        {
            _phimRepo.ThemPhim(phim);
        }

        public void CapNhatPhim(Phim phim)
        {
            _phimRepo.CapNhatPhim(phim);
        }

        public void XoaPhim(int id)
        {
            _phimRepo.XoaPhim(id);
        }

        // 22 /8 
        public void ThemPhimVaTheLoai(Phim phim, string tenTheLoai)
        {
            _phimRepo.ThemPhimVaTheLoai(phim, tenTheLoai);
        }

        public void CapNhatPhimTheoTheLoai(string theLoai, DateOnly thoiGianPhatHanh, string daoDienMoi)
        {
            _phimRepo.CapNhatPhimTheoTheLoai(theLoai, thoiGianPhatHanh, daoDienMoi);
        }

        public void XoaPhimVaLienKet(string tenPhim)
        {
            _phimRepo.XoaPhimVaLienKet(tenPhim);
        }

        public void ThemTheLoaiVaLienKetPhim(string tenTheLoai, string tenPhim)
        {
            _phimRepo.ThemTheLoaiVaLienKetPhim(tenTheLoai, tenPhim);
        }

        public void CapNhatTheLoai(string tenCu, string tenMoi)
        {
            _phimRepo.CapNhatTheLoai(tenCu, tenMoi);
        }

        public void XoaTheLoaiVaLienKet(string tenTheLoai)
        {
            _phimRepo.XoaTheLoaiVaLienKet(tenTheLoai);
        }

        public void ThemLienKetPhimVaTheLoai(string tenPhim, string tenTheLoai)
        {
            _phimRepo.ThemLienKetPhimVaTheLoai(tenPhim, tenTheLoai);
        }

        public void CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai(string theLoai1, string theLoai2, DateOnly thoiGianPhatHanhMoi)
        {
            _phimRepo.CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai(theLoai1, theLoai2, thoiGianPhatHanhMoi);
        }

        public void XoaPhimPhatHanhTruocNam2020()
        {
            _phimRepo.XoaPhimPhatHanhTruocNam2020();
        }

        public void ThemPhimMoiVaLienKet(string tenPhim, string daoDien, DateOnly thoiGianPhatHanh, string theLoai)
        {
            _phimRepo.ThemPhimMoiVaLienKet(tenPhim, daoDien, thoiGianPhatHanh, theLoai);
        }

        public void CapNhatMoTaPhimVaKiemTraTheLoai(int phimId, string moTaMoi)
        {
            _phimRepo.CapNhatMoTaPhimVaKiemTraTheLoai(phimId, moTaMoi);
        }

        public void XoaTheLoaiVaKiemTraPhim(int theLoaiId)
        {
            _phimRepo.XoaTheLoaiVaKiemTraPhim(theLoaiId);
        }

        public void ThemNhieuTheLoaiChoPhim(int phimId, List<string> theLoai)
        {
            _phimRepo.ThemNhieuTheLoaiChoPhim(phimId, theLoai);
        }

        public void CapNhatDaoDienChoPhimLonHon120(string daoDienMoi)
        {
            _phimRepo.CapNhatDaoDienChoPhimLonHon120(daoDienMoi);
        }

        public void XoaTheLoaiKhongCoPhim()
        {
            _phimRepo.XoaTheLoaiKhongCoPhim();
        }

        public void ThemPhimMoiKiemTra(string tenPhim, string daoDien, string theLoai, DateOnly thoiGianPhatHanh)
        {
            _phimRepo.ThemPhimMoiKiemTra(tenPhim, daoDien, theLoai, thoiGianPhatHanh);
        }

        public void CapNhatThoiLuongChoPhimTheoTheLoai(string kyTu, int thoiLuongMoi)
        {
            _phimRepo.CapNhatThoiLuongChoPhimTheoTheLoai(kyTu, thoiLuongMoi);
        }

        public void XoaPhimVaKiemTraTheLoai(string tenPhim)
        {
            _phimRepo.XoaPhimVaKiemTraTheLoai(tenPhim);
        }

        public void ThemNhieuPhimVaLienKet(List<Phim> phimList, List<string> theLoaiList)
        {
            _phimRepo.ThemNhieuPhimVaLienKet(phimList, theLoaiList);
        }

        public void CapNhatMoTaChoPhimCoKyTuC(string moTaMoi)
        {
            _phimRepo.CapNhatMoTaChoPhimCoKyTuC(moTaMoi);
        }

        public void XoaPhimThoiLuongDuoi60KiemTraTheLoai()
        {
            _phimRepo.XoaPhimThoiLuongDuoi60KiemTraTheLoai();
        }

        public void ThemDaoDienMoiChoPhimPhatHanhNam2023(string daoDienMoi)
        {
            _phimRepo.ThemDaoDienMoiChoPhimPhatHanhNam2023(daoDienMoi);
        }

        public void CapNhatTheLoaiChoPhim(int phimId, string tenTheLoaiMoi)
        {
            _phimRepo.CapNhatTheLoaiChoPhim(phimId, tenTheLoaiMoi);
        }

        public void XoaTheLoaiLonHon5KiemTraPhim()
        {
            _phimRepo.XoaTheLoaiLonHon5KiemTraPhim();
        }

        public void ThemTheLoaiMoiVaLienKet(string tenTheLoaiMoi, int phimId)
        {
            _phimRepo.ThemTheLoaiMoiVaLienKet(tenTheLoaiMoi, phimId);
        }

        public void CapNhatTheLoaiChoPhimTrangThai1()
        {
            _phimRepo.CapNhatTheLoaiChoPhimTrangThai1();
        }

        public void XoaPhimKhongCoTheLoaiPhatHanhTruocThang6()
        {
            _phimRepo.XoaPhimKhongCoTheLoaiPhatHanhTruocThang6();
        }

        public void ThemDanhSachTheLoaiChoTatCaPhim(List<string> danhSachTheLoai)
        {
            _phimRepo.ThemDanhSachTheLoaiChoTatCaPhim(danhSachTheLoai);
        }

        public void CapNhatTatCaTheLoaiChoPhim(int phimId, List<string> danhSachTheLoaiMoi)
        {
            _phimRepo.CapNhatTatCaTheLoaiChoPhim(phimId, danhSachTheLoaiMoi);
        }

        public void XoaPhimNam2019VaKiemTraTheLoai()
        {
            _phimRepo.XoaPhimNam2019VaKiemTraTheLoai();
        }


    }
}
