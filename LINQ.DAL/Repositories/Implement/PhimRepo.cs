using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.DAL.Entities;
using LINQ.DAL.Repositories.Interface;


namespace LINQ.DAL.Repositories.Implement
{
    public class PhimRepo : IPhimRepo
    {
        private readonly AppDbContext _context;

        public PhimRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<string> LayDangSachPhimCoThoiLuongLonHon100phut()
        {
            return _context.Phims
                .Where(p => p.ThoiLuong > 100)
                .OrderBy(p => p.TenPhim)
                .Select(p => $"{p.TenPhim} - {string.Join(",", p.TheLoais.Select(tlp => tlp.TenTheLoai))}")
                .ToList();
        }

        public List<Phim> LayPhimCoThoiLuongDuoi120p()
        {
            return _context.Phims
                .Where(p => p.ThoiLuong < 120)
                .OrderBy(p => p.ThoiGianPhatHanh)
                .ThenBy(p => p.TenPhim).ToList();   
        }

        public List<Phim> LayPhimKhongCoMoTa()
        {
            return _context.Phims
                .Where(p => string.IsNullOrEmpty(p.MoTa))
                .OrderBy(p => p.DaoDien)
                .ThenBy(p => p.TenPhim)
                .ToList();
        }

        public List<Phim> LayPhimPhatHanhTruoc2023()
        {
            return _context.Phims
                .Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Year < 2023)
                .OrderBy(p => p.ThoiGianPhatHanh)
                .ToList();
        }

        public List<Phim> LocCacPhimCoTuHaiTrongTen()
        {
            return _context.Phims
                .Where(p => p.TenPhim.Contains("Hài"))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Take(2)
                .ToList();
        }

        //public List<string> LayTenPhmVaSoNgayConLaiDenNgayPhatHanh()
        //{
        //    //return _context.Phims.Where(p => p.ThoiLuong > 90 && p.ThoiGianPhatHanh.HasValue)
        //    //    .Select( p=> $"{p.TenPhim} - {(p.ThoiGianPhatHanh.Value - DateTime.Now).Days} Ngày" ).ToList();    
        //}

        public List<Phim> LocPhimCoChuCTrongTen()
        {
            return _context.Phims.Where(p => p.TenPhim.Contains("C")).OrderBy(p => p.ThoiGianPhatHanh).Take(3).ToList();
        }

        public List<Phim> LocPhimCoMoTaKhongRong()
        {
            return _context.Phims
                .Where(p => !string.IsNullOrEmpty(p.MoTa))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Take(3)
                .ToList();
        }

        //public List<Phim> LayPhimPhatHanhSauNgay(DateTime ngay)
        //{
        //    return _context.Phims
        //        .Where(p => p.ThoiGianPhatHanh > ngay)
        //        .OrderByDescending(p => p.ThoiGianPhatHanh)
        //        .ToList(); 
        //}

        public List<Phim> LocPhimTheoDaoDienVaLay2PhimDauTien(string daoDien)
        {
            return _context.Phims
                .Where(p => p.DaoDien == daoDien)
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Take(2).ToList();
        }

        public List<string> LocPhimTheoTheLoai(string theLoai)
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == theLoai))
                .Select(p => p.TenPhim).ToList();
        }

        public List<Phim> LocPhimTheoTheLoaiKinhDi()
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == "Kinh Dị"))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Take(3) .ToList(); 
        }

        public List<string> LocVaSapXepPhimTheoTheLoai(string tenPhim)
        {
            return _context.Phims
                .Where(p => p.TenPhim == tenPhim)
                .SelectMany(p => p.TheLoais)
                .OrderBy(tl => tl.TenTheLoai)
                .Select(tl => tl.TenTheLoai).ToList();
        }

        public Phim TimPhimCoThoiLuongNganNhat()
        {
            return _context.Phims
                .OrderBy(p => p.ThoiLuong)
                .FirstOrDefault();
        }

        public Phim TimPhimDauTienPhatHanhVaoThangHai()
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month == 2).FirstOrDefault();
        }

        public List<string> LayTenPhimVaDaoDienTheoTheLoai(string tenTheLoai)
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == tenTheLoai))
                .Select(p => $"{p.TenPhim} - {p.DaoDien}")
                .ToList();
        }

        public List<string> LayBaPhimCoThoiLuongTu90Den150Phut()
        {
            return _context.Phims
                .Where(p => p.ThoiLuong >= 90 && p.ThoiLuong <= 150)
                .OrderBy(p => p.TenPhim)
                .Take(3)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh}")
                .ToList();
        }

        public string TimPhimTinhCamDauTienCoMoTa()
        {
            var phim = _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == "Tình Cảm") && !string.IsNullOrEmpty(p.MoTa))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .FirstOrDefault();

            return phim != null ? $"{phim.TenPhim} - {phim.ThoiGianPhatHanh}" : "Không tìm thấy phim nào.";
        }

        public List<string> LayPhimTheoThangVaSoLuongTheLoai()
        {
            return _context.Phims
                .Where(p => p.ThoiGianPhatHanh.HasValue &&
                            (p.ThoiGianPhatHanh.Value.Month == 1 || p.ThoiGianPhatHanh.Value.Month == 2))
                .Select(p => $"{p.TenPhim} - {p.TheLoais.Count} thể loại")
                .ToList();
        }

        public List<string> LayNamPhimMoiNhatTheoThoiLuongGiamDan()
        {
            return _context.Phims
                .OrderByDescending(p => p.ThoiGianPhatHanh)
                .Take(5)
                .OrderByDescending(p => p.ThoiLuong)
                .Select(p => $"{p.TenPhim} - {p.ThoiLuong} phút")
                .ToList();
        }

        public List<string> LayPhimCoTuKhoaPhimTrongTen()
        {
            return _context.Phims
                .Where(p => p.TenPhim.Contains("Phim"))
                .OrderBy(p => p.DaoDien)
                .Select(p => $"{p.TenPhim} - {p.DaoDien}")
                .ToList();
        }

        public List<string> LocPhimTheoTheLoaiVaLayTenPhim(string tenTheLoai)
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == tenTheLoai))
                .Select(p => p.TenPhim)
                .ToList();
        }

        public string TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai()
        {
            var phim = _context.Phims
                .OrderBy(p => p.ThoiGianPhatHanh)
                .FirstOrDefault();

            return phim != null ? $"{phim.TenPhim} - {phim.TheLoais.Count} thể loại" : "Không tìm thấy phim nào.";
        }

        public List<string> LocPhimHaiCoThoiLuongLonHon90phut()
        {
            return _context.Phims
                .Where(p => p.TenPhim.Contains("Hài") && p.ThoiLuong > 90)
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh}")
                .ToList();
        }

        public List<string> LayHaiPhimHanhDong()
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == "Hành Động"))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .ThenBy(p => p.DaoDien)
                .Take(2)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh} - {p.DaoDien}")
                .ToList();
        }

        public List<string> LocPhimKhongCoMoTa()
        {
            return _context.Phims
                .Where(p => string.IsNullOrEmpty(p.MoTa))
                .SelectMany(p => p.TheLoais.Select(tl => $"{p.TenPhim} - {tl.TenTheLoai}"))
                .ToList();
        }

        public List<string> LocPhimPhatHanhTruocThang11()
        {
            return _context.Phims
                .Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month < 11)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh}")
                .ToList();
        }

        public List<string> LayBaPhimHanhDong()
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == "Hành Động"))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Take(3)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh}")
                .ToList();
        }

        public List<string> LayPhimPhatHanhTuThangHaiTroDi()
        {
            return _context.Phims
                .Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month >= 2)
                .OrderBy(p => p.TenPhim)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh}")
                .ToList();
        }

        public List<string> LocPhimKinhDi()
        {
            return _context.Phims
                .Where(p => p.TheLoais.Any(tl => tl.TenTheLoai == "Kinh Dị"))
                .OrderBy(p => p.ThoiGianPhatHanh)
                .Select(p => $"{p.TenPhim} - {p.ThoiGianPhatHanh}")
                .ToList();
        }

    }
}
