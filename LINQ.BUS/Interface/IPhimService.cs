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
        List<string> LayDangSachPhimCoThoiLuongLonHon100phut();
        List<Phim> LocPhimTheoDaoDienVaLay2PhimDauTien(string daoDien);
        List<string> LocPhimTheoTheLoai(string theLoai);
        List<Phim> LocPhimCoMoTaKhongRong();
        List<Phim> LayPhimCoThoiLuongDuoi120p();
        Phim TimPhimDauTienPhatHanhVaoThangHai();
        List<Phim> LocPhimCoChuCTrongTen();
        List<string> LocVaSapXepPhimTheoTheLoai(string tenPhim);
        List<Phim> LocCacPhimCoTuHaiTrongTen();
        List<Phim> LayPhimKhongCoMoTa();
        Phim TimPhimCoThoiLuongNganNhat();
        List<Phim> LocPhimTheoTheLoaiKinhDi();
        List<Phim> LayPhimPhatHanhTruoc2023();
        List<string> LayTenPhimVaDaoDienTheoTheLoai(string tenTheLoai);
        List<string> LayBaPhimCoThoiLuongTu90Den150Phut();
        string TimPhimTinhCamDauTienCoMoTa();
        List<string> LayPhimTheoThangVaSoLuongTheLoai();
        List<string> LayNamPhimMoiNhatTheoThoiLuongGiamDan();
        List<string> LocPhimTheoTheLoaiVaLayTenPhim(string tenTheLoai);
        List<string> LayPhimCoTuKhoaPhimTrongTen();
        string TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai();
        List<string> LocPhimHaiCoThoiLuongLonHon90phut();
        List<string> LayHaiPhimHanhDong();
        List<string> LocPhimKhongCoMoTa();
        List<string> LocPhimPhatHanhTruocThang11();
        List<string> LayBaPhimHanhDong();
        List<string> LayPhimPhatHanhTuThangHaiTroDi();
        List<string> LocPhimKinhDi();
    }
}
