using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.DAL.Entities;
using LINQ.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace LINQ.DAL.Repositories.Implement
{
    public class PhimRepo : IPhimRepo
    {
        private readonly AppDbContext _context;

        public PhimRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Phim> LayTatCaPhim() // Dùng chung cho nhiều câu
        {
            return _context.Phims.ToList();
        }

        public IEnumerable<Phim> LayPhimLonHon100Phut() // Câu 1
        {
            return _context.Phims.Where(p => p.ThoiLuong > 100).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoDaoDien(string daoDien) // Câu 2
        {
            return _context.Phims.Where(p => p.DaoDien == daoDien).ToList();
        }

        public IEnumerable<Phim> LayPhimMoiNhat() // Câu 3
        {
            return _context.Phims.OrderByDescending(p => p.ThoiGianPhatHanh).Take(2).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoNgayPhatHanhSau(DateOnly date) // Câu 4
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh > date).OrderByDescending(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoTheLoai(string tenTheLoai) // Câu 5
        {
            return _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == tenTheLoai)).ToList();
        }

        public IEnumerable<Phim> LayPhimCoMoTaKhongRong() // Câu 6
        {
            return _context.Phims.Where(p => !string.IsNullOrEmpty(p.MoTa)).OrderBy(p => p.ThoiGianPhatHanh).Take(3).ToList();
        }

        public IEnumerable<Phim> LayPhimThoiLuongDuoi120() // Câu 7
        {
            return _context.Phims.Where(p => p.ThoiLuong < 120).OrderBy(p => p.ThoiGianPhatHanh).ThenBy(p => p.TenPhim).ToList();
        }

        public Phim LayPhimDauTienTheoThangPhatHanh(int month) // Câu 8
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month == month)
                                 .OrderBy(p => p.ThoiGianPhatHanh).FirstOrDefault();
        }

        public IEnumerable<Phim> LayPhimTheoTuKhoaTrongTen(string keyword) // Câu 9
        {
            return _context.Phims.Where(p => p.TenPhim.Contains(keyword)).OrderBy(p => p.ThoiGianPhatHanh).Take(5).ToList();
        }

        public IEnumerable<object> LayPhimVaSoNgayDenNgayPhatHanh(int minThoiLuong) // Câu 10
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            return _context.Phims
                .Where(p => p.ThoiLuong > minThoiLuong && p.ThoiGianPhatHanh.HasValue)
                .Select(p => new
                {
                    p.TenPhim,
                    DaysUntilRelease = (p.ThoiGianPhatHanh.Value.ToDateTime(TimeOnly.MinValue) - currentDate.ToDateTime(TimeOnly.MinValue)).Days
                })
                .ToList();
        }

        public IEnumerable<Phim> LayPhimTheoTenVaTheLoai(string tenPhim, string tenTheLoai) // Câu 11
        {
            return _context.Phims.Where(p => p.TenPhim == tenPhim && p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == tenTheLoai))
                                 .OrderBy(p => p.TheLoaiCuaPhims.Select(tlp => tlp.TheLoai.TenTheLoai)).ToList();
        }

        public IEnumerable<Phim> LayPhimCoTuKhoaVaThoiLuongHon90(string keyword) // Câu 12
        {
            return _context.Phims.Where(p => p.TenPhim.Contains(keyword) && p.ThoiLuong > 90)
                                 .OrderBy(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayPhimKhongCoMoTa() // Câu 13
        {
            return _context.Phims.Where(p => string.IsNullOrEmpty(p.MoTa))
                                 .OrderBy(p => p.DaoDien).ThenBy(p => p.TenPhim).ToList();
        }

        public Phim LayPhimCoThoiLuongNganNhat() // Câu 14
        {
            return _context.Phims.OrderBy(p => p.ThoiLuong).FirstOrDefault();
        }

        public IEnumerable<Phim> LayTopNPhimTheoTheLoai(string tenTheLoai, int n) // Câu 15
        {
            return _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == tenTheLoai))
                                 .OrderBy(p => p.ThoiGianPhatHanh).Take(n).ToList();
        }

        public IEnumerable<Phim> LayPhimPhatHanhTruocNam(int year) // Câu 16
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Year < year)
                                 .OrderBy(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoTheLoaiVaSapXep(string theLoai) // Câu 17
        {
            return _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == theLoai))
                                 .OrderBy(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoKhoangThoiLuong(int minThoiLuong, int maxThoiLuong) // Câu 18
        {
            return _context.Phims.Where(p => p.ThoiLuong >= minThoiLuong && p.ThoiLuong <= maxThoiLuong)
                                 .OrderBy(p => p.TenPhim).ToList();
        }

        public Phim LayPhimDauTienCoTheLoaiVaMoTa(string tenTheLoai) // Câu 19
        {
            return _context.Phims.FirstOrDefault(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == tenTheLoai)
                                                    && !string.IsNullOrEmpty(p.MoTa));
        }

        public IEnumerable<object> LayPhimTheoThangVaDemSoLuongTheLoai(int month) // Câu 20
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && (p.ThoiGianPhatHanh.Value.Month == month
                                    || p.ThoiGianPhatHanh.Value.Month == month + 1))
                .Select(p => new
                {
                    p.TenPhim,
                    TheLoaiCount = p.TheLoaiCuaPhims.Count
                }).ToList();
        }

        public IEnumerable<Phim> Lay5PhimMoiNhatSapXepTheoThoiLuong() // Câu 21
        {
            return _context.Phims.OrderByDescending(p => p.ThoiGianPhatHanh)
                                 .ThenByDescending(p => p.ThoiLuong).Take(5).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoTuKhoaVaDaoDien(string keyword, string daoDien) // Câu 22
        {
            return _context.Phims.Where(p => p.TenPhim.Contains(keyword) && p.DaoDien == daoDien)
                                 .OrderBy(p => p.DaoDien).ToList();
        }

        public IEnumerable<Phim> LayPhimCoNhieuTheLoai() // Câu 23
        {
            return _context.Phims.Where(p => p.TheLoaiCuaPhims.Count > 1).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoTenDaoDien(string partialName) // Câu 24
        {
            return _context.Phims.Where(p => p.DaoDien.Contains(partialName)).ToList();
        }

        public Phim LayPhimPhatHanhSomNhatVaDemTheLoai() // Câu 25
        {
            return _context.Phims.OrderBy(p => p.ThoiGianPhatHanh).FirstOrDefault();
        }

        public IEnumerable<Phim> LayPhimCoTuKhoaTrongTenVaThoiLuongHon90(string keyword) // Câu 26
        {
            return _context.Phims.Where(p => p.TenPhim.Contains("Hai") && p.ThoiLuong > 90)
                                 .OrderBy(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayTopNPhimTheoTheLoai(int n, string tenTheLoai) // Câu 27
        {
            return _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == tenTheLoai))
                                 .OrderBy(p => p.ThoiGianPhatHanh).Take(n).ToList();
        }

        public IEnumerable<Phim> LayPhimPhatHanhTruocThang(int month) // Câu 28
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month < month)
                                 .OrderBy(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoThangVaTheLoai(string tenTheLoai) // Câu 29
        {
            return _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == tenTheLoai))
                                 .OrderBy(p => p.ThoiGianPhatHanh).ToList();
        }

        public IEnumerable<Phim> LayPhimTheoThangVaSapXep(int month) // Câu 30
        {
            return _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month >= month)
                                 .OrderBy(p => p.TenPhim).ToList();
        }

        public void ThemPhim(Phim phim)
        {
            _context.Phims.Add(phim);
            _context.SaveChanges();
        }

        public void CapNhatPhim(Phim phim)
        {
            _context.Phims.Update(phim);
            _context.SaveChanges();
        }

        public void XoaPhim(int id)
        {
            var phim = _context.Phims.Find(id);
            if (phim != null)
            {
                _context.Phims.Remove(phim);
                _context.SaveChanges();
            }
        }

        public void ThemPhimVaTheLoai(Phim phim, string tenTheLoai)
        {
            var theLoai = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoai);
            if (theLoai == null)
            {
                theLoai = new TheLoai { TenTheLoai = tenTheLoai };
                _context.TheLoais.Add(theLoai);
            }

            _context.Phims.Add(phim);
            _context.SaveChanges();

            var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoai.TheLoaiId };
            _context.TheLoaiCuaPhims.Add(lienKet);
            _context.SaveChanges();
        }

        public void CapNhatPhimTheoTheLoai(string theLoai, DateOnly thoiGianPhatHanh, string daoDienMoi)
        {
            var phimList = _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == theLoai)).ToList();
            foreach (var phim in phimList)
            {
                phim.ThoiGianPhatHanh = thoiGianPhatHanh;
                phim.DaoDien = daoDienMoi;
                _context.Phims.Update(phim);
            }
            _context.SaveChanges();
        }

        public void XoaPhimVaLienKet(string tenPhim)
        {
            var phim = _context.Phims.FirstOrDefault(p => p.TenPhim == tenPhim);
            if (phim != null)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.Phims.Remove(phim);
                _context.SaveChanges();
            }
        }

        public void ThemTheLoaiVaLienKetPhim(string tenTheLoai, string tenPhim)
        {
            var phim = _context.Phims.FirstOrDefault(p => p.TenPhim == tenPhim);
            var theLoai = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoai);

            if (phim != null && theLoai == null)
            {
                theLoai = new TheLoai { TenTheLoai = tenTheLoai };
                _context.TheLoais.Add(theLoai);
                _context.SaveChanges();
            }

            if (phim != null && theLoai != null)
            {
                var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoai.TheLoaiId };
                _context.TheLoaiCuaPhims.Add(lienKet);
                _context.SaveChanges();
            }
        }

        public void CapNhatTheLoai(string tenCu, string tenMoi)
        {
            var theLoai = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenCu);
            if (theLoai != null)
            {
                theLoai.TenTheLoai = tenMoi;
                _context.TheLoais.Update(theLoai);
                _context.SaveChanges();
            }
        }

        public void XoaTheLoaiVaLienKet(string tenTheLoai)
        {
            var theLoai = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoai);
            if (theLoai != null)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.TheLoaiId == theLoai.TheLoaiId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.TheLoais.Remove(theLoai);
                _context.SaveChanges();
            }
        }

        public void ThemLienKetPhimVaTheLoai(string tenPhim, string tenTheLoai)
        {
            var phim = _context.Phims.FirstOrDefault(p => p.TenPhim == tenPhim);
            var theLoai = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoai);

            if (phim != null && theLoai != null)
            {
                var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoai.TheLoaiId };
                _context.TheLoaiCuaPhims.Add(lienKet);
                _context.SaveChanges();
            }
        }

        public void CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai(string theLoai1, string theLoai2, DateOnly thoiGianPhatHanhMoi)
        {
            var phimList = _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == theLoai1)
                                                  && p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai == theLoai2)).ToList();
            foreach (var phim in phimList)
            {
                phim.ThoiGianPhatHanh = thoiGianPhatHanhMoi;
                _context.Phims.Update(phim);
            }
            _context.SaveChanges();
        }

        public void XoaPhimPhatHanhTruocNam2020()
        {
            var phimList = _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Year < 2020).ToList();
            foreach (var phim in phimList)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.Phims.Remove(phim);
            }
            _context.SaveChanges();
        }

        public void ThemPhimMoiVaLienKet(string tenPhim, string daoDien, DateOnly thoiGianPhatHanh, string theLoai)
        {
            var phim = new Phim { TenPhim = tenPhim, DaoDien = daoDien, ThoiGianPhatHanh = thoiGianPhatHanh };
            _context.Phims.Add(phim);
            _context.SaveChanges();

            var theLoaiEntity = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == theLoai);
            if (theLoaiEntity != null)
            {
                var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoaiEntity.TheLoaiId };
                _context.TheLoaiCuaPhims.Add(lienKet);
                _context.SaveChanges();
            }
        }

        public void CapNhatMoTaPhimVaKiemTraTheLoai(int phimId, string moTaMoi)
        {
            var phim = _context.Phims.Find(phimId);
            if (phim != null)
            {
                phim.MoTa = moTaMoi;
                _context.Phims.Update(phim);
                _context.SaveChanges();
            }
        }

        public void XoaTheLoaiVaKiemTraPhim(int theLoaiId)
        {
            var theLoai = _context.TheLoais.Find(theLoaiId);
            if (theLoai != null)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.TheLoaiId == theLoaiId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.TheLoais.Remove(theLoai);
                _context.SaveChanges();
            }
        }

        public void ThemNhieuTheLoaiChoPhim(int phimId, List<string> theLoai)
        {
            foreach (var tenTheLoai in theLoai)
            {
                var theLoaiEntity = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoai);
                if (theLoaiEntity == null)
                {
                    theLoaiEntity = new TheLoai { TenTheLoai = tenTheLoai };
                    _context.TheLoais.Add(theLoaiEntity);
                    _context.SaveChanges();
                }

                var lienKet = new TheLoaiCuaPhim { PhimId = phimId, TheLoaiId = theLoaiEntity.TheLoaiId };
                _context.TheLoaiCuaPhims.Add(lienKet);
            }
            _context.SaveChanges();
        }

        public void CapNhatDaoDienChoPhimLonHon120(string daoDienMoi)
        {
            var phimList = _context.Phims.Where(p => p.ThoiLuong > 120).ToList();
            foreach (var phim in phimList)
            {
                phim.DaoDien = daoDienMoi;
                _context.Phims.Update(phim);
            }
            _context.SaveChanges();
        }

        public void XoaTheLoaiKhongCoPhim()
        {
            var theLoais = _context.TheLoais.Where(tl => !tl.TheLoaiCuaPhims.Any()).ToList();
            _context.TheLoais.RemoveRange(theLoais);
            _context.SaveChanges();
        }

        public void ThemPhimMoiKiemTra(string tenPhim, string daoDien, string theLoai, DateOnly thoiGianPhatHanh)
        {
            var phim = new Phim { TenPhim = tenPhim, DaoDien = daoDien, ThoiGianPhatHanh = thoiGianPhatHanh };
            _context.Phims.Add(phim);
            _context.SaveChanges();

            var theLoaiEntity = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == theLoai);
            if (theLoaiEntity != null)
            {
                var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoaiEntity.TheLoaiId };
                _context.TheLoaiCuaPhims.Add(lienKet);
                _context.SaveChanges();
            }
        }

        public void CapNhatThoiLuongChoPhimTheoTheLoai(string kyTu, int thoiLuongMoi)
        {
            var phimList = _context.Phims.Where(p => p.TheLoaiCuaPhims.Any(tlp => tlp.TheLoai.TenTheLoai.Contains(kyTu))).ToList();
            foreach (var phim in phimList)
            {
                phim.ThoiLuong = thoiLuongMoi;
                _context.Phims.Update(phim);
            }
            _context.SaveChanges();
        }

        public void XoaPhimVaKiemTraTheLoai(string tenPhim)
        {
            var phim = _context.Phims.FirstOrDefault(p => p.TenPhim == tenPhim);
            if (phim != null)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.Phims.Remove(phim);
                _context.SaveChanges();
            }
        }

        public void ThemNhieuPhimVaLienKet(List<Phim> phimList, List<string> theLoaiList)
        {
            foreach (var phim in phimList)
            {
                _context.Phims.Add(phim);
                _context.SaveChanges();

                foreach (var theLoai in theLoaiList)
                {
                    var theLoaiEntity = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == theLoai);
                    if (theLoaiEntity != null)
                    {
                        var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoaiEntity.TheLoaiId };
                        _context.TheLoaiCuaPhims.Add(lienKet);
                    }
                }
                _context.SaveChanges();
            }
        }

        public void CapNhatMoTaChoPhimCoKyTuC(string moTaMoi)
        {
            var phimList = _context.Phims.Where(p => p.TenPhim.Contains("C")).ToList();
            foreach (var phim in phimList)
            {
                phim.MoTa = moTaMoi;
                _context.Phims.Update(phim);
            }
            _context.SaveChanges();
        }

        public void XoaPhimThoiLuongDuoi60KiemTraTheLoai()
        {
            var phimList = _context.Phims.Where(p => p.ThoiLuong < 60).ToList();
            foreach (var phim in phimList)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.Phims.Remove(phim);
            }
            _context.SaveChanges();
        }

        public void ThemDaoDienMoiChoPhimPhatHanhNam2023(string daoDienMoi)
        {
            var phimList = _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Year == 2023).ToList();
            foreach (var phim in phimList)
            {
                phim.DaoDien = daoDienMoi;
                _context.Phims.Update(phim);
            }
            _context.SaveChanges();
        }

        public void CapNhatTheLoaiChoPhim(int phimId, string tenTheLoaiMoi)
        {
            var phim = _context.Phims.Find(phimId);
            if (phim != null)
            {
                var theLoaiCuaPhim = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                foreach (var tlp in theLoaiCuaPhim)
                {
                    var theLoai = _context.TheLoais.Find(tlp.TheLoaiId);
                    if (theLoai != null)
                    {
                        theLoai.TenTheLoai = tenTheLoaiMoi;
                        _context.TheLoais.Update(theLoai);
                    }
                }
                _context.SaveChanges();
            }
        }

        public void XoaTheLoaiLonHon5KiemTraPhim()
        {
            var theLoais = _context.TheLoais.Where(tl => tl.TheLoaiId > 5).ToList();
            foreach (var theLoai in theLoais)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.TheLoaiId == theLoai.TheLoaiId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.TheLoais.Remove(theLoai);
            }
            _context.SaveChanges();
        }

        public void ThemTheLoaiMoiVaLienKet(string tenTheLoaiMoi, int phimId)
        {
            var theLoai = new TheLoai { TenTheLoai = tenTheLoaiMoi };
            _context.TheLoais.Add(theLoai);
            _context.SaveChanges();

            var lienKet = new TheLoaiCuaPhim { PhimId = phimId, TheLoaiId = theLoai.TheLoaiId };
            _context.TheLoaiCuaPhims.Add(lienKet);
            _context.SaveChanges();
        }

        public void CapNhatTheLoaiChoPhimTrangThai1()
        {
            var phimList = _context.Phims.Where(p => p.TrangThai == 1).ToList();
            foreach (var phim in phimList)
            {
                var theLoaiCuaPhim = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                foreach (var tlp in theLoaiCuaPhim)
                {
                    var theLoai = _context.TheLoais.Find(tlp.TheLoaiId);
                    if (theLoai != null)
                    {
                        theLoai.TenTheLoai = "Hài kịch";
                        _context.TheLoais.Update(theLoai);
                    }
                }
                _context.SaveChanges();
            }
        }

        public void XoaPhimKhongCoTheLoaiPhatHanhTruocThang6()
        {
            var phimList = _context.Phims.Where(p => !p.TheLoaiCuaPhims.Any() && p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Month < 6).ToList();
            foreach (var phim in phimList)
            {
                _context.Phims.Remove(phim);
            }
            _context.SaveChanges();
        }

        public void ThemDanhSachTheLoaiChoTatCaPhim(List<string> danhSachTheLoai)
        {
            foreach (var phim in _context.Phims.ToList())
            {
                foreach (var tenTheLoai in danhSachTheLoai)
                {
                    var theLoaiEntity = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoai);
                    if (theLoaiEntity == null)
                    {
                        theLoaiEntity = new TheLoai { TenTheLoai = tenTheLoai };
                        _context.TheLoais.Add(theLoaiEntity);
                        _context.SaveChanges();
                    }

                    var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoaiEntity.TheLoaiId };
                    _context.TheLoaiCuaPhims.Add(lienKet);
                }
            }
            _context.SaveChanges();
        }

        public void CapNhatTatCaTheLoaiChoPhim(int phimId, List<string> danhSachTheLoaiMoi)
        {
            var phim = _context.Phims.Find(phimId);
            if (phim != null)
            {
                var theLoaiCuaPhim = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                foreach (var tlp in theLoaiCuaPhim)
                {
                    _context.TheLoaiCuaPhims.Remove(tlp);
                }
                _context.SaveChanges();

                foreach (var tenTheLoaiMoi in danhSachTheLoaiMoi)
                {
                    var theLoaiEntity = _context.TheLoais.FirstOrDefault(tl => tl.TenTheLoai == tenTheLoaiMoi);
                    if (theLoaiEntity == null)
                    {
                        theLoaiEntity = new TheLoai { TenTheLoai = tenTheLoaiMoi };
                        _context.TheLoais.Add(theLoaiEntity);
                        _context.SaveChanges();
                    }

                    var lienKet = new TheLoaiCuaPhim { PhimId = phim.PhimId, TheLoaiId = theLoaiEntity.TheLoaiId };
                    _context.TheLoaiCuaPhims.Add(lienKet);
                }
            }
            _context.SaveChanges();
        }

        public void XoaPhimNam2019VaKiemTraTheLoai()
        {
            var phimList = _context.Phims.Where(p => p.ThoiGianPhatHanh.HasValue && p.ThoiGianPhatHanh.Value.Year == 2019).ToList();
            foreach (var phim in phimList)
            {
                var lienKets = _context.TheLoaiCuaPhims.Where(tlp => tlp.PhimId == phim.PhimId).ToList();
                _context.TheLoaiCuaPhims.RemoveRange(lienKets);
                _context.Phims.Remove(phim);
            }
            _context.SaveChanges();
        }

    }
}
