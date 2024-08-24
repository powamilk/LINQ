using LINQ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.DAL.Repositories.Interface
{
    public interface IPhimRepo
    {
        IEnumerable<Phim> LayTatCaPhim(); // Dùng chung cho nhiều câu
        IEnumerable<Phim> LayPhimLonHon100Phut(); // Câu 1
        IEnumerable<Phim> LayPhimTheoDaoDien(string daoDien); // Câu 2
        IEnumerable<Phim> LayPhimMoiNhat(); // Câu 3
        IEnumerable<Phim> LayPhimTheoNgayPhatHanhSau(DateOnly date); // Câu 4
        IEnumerable<Phim> LayPhimTheoTheLoai(string tenTheLoai); // Câu 5
        IEnumerable<Phim> LayPhimCoMoTaKhongRong(); // Câu 6
        IEnumerable<Phim> LayPhimThoiLuongDuoi120(); // Câu 7
        Phim LayPhimDauTienTheoThangPhatHanh(int month); // Câu 8
        IEnumerable<Phim> LayPhimTheoTuKhoaTrongTen(string keyword); // Câu 9
        IEnumerable<object> LayPhimVaSoNgayDenNgayPhatHanh(int minThoiLuong); // Câu 10
        IEnumerable<Phim> LayPhimTheoTenVaTheLoai(string tenPhim, string tenTheLoai); // Câu 11
        IEnumerable<Phim> LayPhimCoTuKhoaVaThoiLuongHon90(string keyword); // Câu 12
        IEnumerable<Phim> LayPhimKhongCoMoTa(); // Câu 13
        Phim LayPhimCoThoiLuongNganNhat(); // Câu 14
        IEnumerable<Phim> LayTopNPhimTheoTheLoai(string tenTheLoai, int n); // Câu 15
        IEnumerable<Phim> LayPhimPhatHanhTruocNam(int year); // Câu 16
        IEnumerable<Phim> LayPhimTheoTheLoaiVaSapXep(string theLoai); // Câu 17
        IEnumerable<Phim> LayPhimTheoKhoangThoiLuong(int minThoiLuong, int maxThoiLuong); // Câu 18
        Phim LayPhimDauTienCoTheLoaiVaMoTa(string tenTheLoai); // Câu 19
        IEnumerable<object> LayPhimTheoThangVaDemSoLuongTheLoai(int month); // Câu 20
        IEnumerable<Phim> Lay5PhimMoiNhatSapXepTheoThoiLuong(); // Câu 21
        IEnumerable<Phim> LayPhimTheoTuKhoaVaDaoDien(string keyword, string daoDien); // Câu 22
        IEnumerable<Phim> LayPhimCoNhieuTheLoai(); // Câu 23
        IEnumerable<Phim> LayPhimTheoTenDaoDien(string partialName); // Câu 24
        Phim LayPhimPhatHanhSomNhatVaDemTheLoai(); // Câu 25
        IEnumerable<Phim> LayPhimCoTuKhoaTrongTenVaThoiLuongHon90(string keyword); // Câu 26
        IEnumerable<Phim> LayTopNPhimTheoTheLoai(int n, string tenTheLoai); // Câu 27
        IEnumerable<Phim> LayPhimPhatHanhTruocThang(int month); // Câu 28
        IEnumerable<Phim> LayPhimTheoThangVaTheLoai(string tenTheLoai); // Câu 29
        IEnumerable<Phim> LayPhimTheoThangVaSapXep(int month); // Câu 30
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
