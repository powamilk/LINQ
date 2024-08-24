using LINQ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BUS.Interface
{
    public interface IPhimService
    {
        IEnumerable<Phim> LayTatCaPhim();
        IEnumerable<Phim> LayPhimLonHon100Phut();
        IEnumerable<Phim> LayPhimTheoDaoDien(string daoDien);
        IEnumerable<Phim> LayPhimMoiNhat();
        IEnumerable<Phim> LayPhimTheoNgayPhatHanhSau(DateOnly date);
        IEnumerable<Phim> LayPhimTheoTheLoai(string tenTheLoai);
        IEnumerable<Phim> LayPhimCoMoTaKhongRong();
        IEnumerable<Phim> LayPhimThoiLuongDuoi120();
        Phim LayPhimDauTienTheoThangPhatHanh(int month);
        IEnumerable<Phim> LayPhimTheoTuKhoaTrongTen(string keyword);
        IEnumerable<object> LayPhimVaSoNgayDenNgayPhatHanh(int minThoiLuong);
        IEnumerable<Phim> LayPhimTheoTenVaTheLoai(string tenPhim, string tenTheLoai);
        IEnumerable<Phim> LayPhimTheoTuKhoaVaThoiLuongHon90(string keyword);
        IEnumerable<Phim> LayPhimKhongCoMoTa();
        Phim LayPhimCoThoiLuongNganNhat();
        IEnumerable<Phim> LayTopNPhimTheoTheLoai(string tenTheLoai, int n);
        IEnumerable<Phim> LayPhimPhatHanhTruocNam(int year);
        IEnumerable<Phim> LayPhimTheoTheLoaiVaSapXep(string theLoai);
        IEnumerable<Phim> LayPhimTheoKhoangThoiLuong(int minThoiLuong, int maxThoiLuong);
        Phim LayPhimDauTienCoTheLoaiVaMoTa(string tenTheLoai);
        IEnumerable<object> LayPhimTheoThangVaDemSoLuongTheLoai(int month);
        IEnumerable<Phim> Lay5PhimMoiNhatSapXepTheoThoiLuong();
        IEnumerable<Phim> LayPhimTheoTuKhoaVaDaoDien(string keyword, string daoDien);
        IEnumerable<Phim> LayPhimCoNhieuTheLoai();
        IEnumerable<Phim> LayPhimTheoTenDaoDien(string partialName);
        Phim LayPhimPhatHanhSomNhatVaDemTheLoai();
        IEnumerable<Phim> LayPhimCoTuKhoaTrongTenVaThoiLuongHon90(string keyword);
        IEnumerable<Phim> LayTopNPhimTheoTheLoai(int n, string tenTheLoai);
        IEnumerable<Phim> LayPhimPhatHanhTruocThang(int month);
        IEnumerable<Phim> LayPhimTheoThangVaTheLoai(string tenTheLoai);
        IEnumerable<Phim> LayPhimTheoThangVaSapXep(int month);
        void ThemPhim(Phim phim);
        void CapNhatPhim(Phim phim);
        void XoaPhim(int id);

        void ThemPhimVaTheLoai(Phim phim, string tenTheLoai);
        void CapNhatPhimTheoTheLoai(string theLoai, DateOnly thoiGianPhatHanh, string daoDienMoi);
        void XoaPhimVaLienKet(string tenPhim);
        void ThemTheLoaiVaLienKetPhim(string tenTheLoai, string tenPhim);
        void CapNhatTheLoai(string tenCu, string tenMoi);
        void XoaTheLoaiVaLienKet(string tenTheLoai);
        void ThemLienKetPhimVaTheLoai(string tenPhim, string tenTheLoai);
        void CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai(string theLoai1, string theLoai2, DateOnly thoiGianPhatHanhMoi);
        void XoaPhimPhatHanhTruocNam2020();
        void ThemPhimMoiVaLienKet(string tenPhim, string daoDien, DateOnly thoiGianPhatHanh, string theLoai);
        void CapNhatMoTaPhimVaKiemTraTheLoai(int phimId, string moTaMoi);
        void XoaTheLoaiVaKiemTraPhim(int theLoaiId);
        void ThemNhieuTheLoaiChoPhim(int phimId, List<string> theLoai);
        void CapNhatDaoDienChoPhimLonHon120(string daoDienMoi);
        void XoaTheLoaiKhongCoPhim();
        void ThemPhimMoiKiemTra(string tenPhim, string daoDien, string theLoai, DateOnly thoiGianPhatHanh);
        void CapNhatThoiLuongChoPhimTheoTheLoai(string kyTu, int thoiLuongMoi);
        void XoaPhimVaKiemTraTheLoai(string tenPhim);
        void ThemNhieuPhimVaLienKet(List<Phim> phimList, List<string> theLoaiList);
        void CapNhatMoTaChoPhimCoKyTuC(string moTaMoi);
        void XoaPhimThoiLuongDuoi60KiemTraTheLoai();
        void ThemDaoDienMoiChoPhimPhatHanhNam2023(string daoDienMoi);
        void CapNhatTheLoaiChoPhim(int phimId, string tenTheLoaiMoi);
        void XoaTheLoaiLonHon5KiemTraPhim();
        void ThemTheLoaiMoiVaLienKet(string tenTheLoaiMoi, int phimId);
        void CapNhatTheLoaiChoPhimTrangThai1();
        void XoaPhimKhongCoTheLoaiPhatHanhTruocThang6();
        void ThemDanhSachTheLoaiChoTatCaPhim(List<string> danhSachTheLoai);
        void CapNhatTatCaTheLoaiChoPhim(int phimId, List<string> danhSachTheLoaiMoi);
        void XoaPhimNam2019VaKiemTraTheLoai();


    }
}
