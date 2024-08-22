using LINQ.BUS.Implement;
using LINQ.BUS.Interface;
using LINQ.BUS.Implement;
using LINQ.DAL;
using LINQ.DAL.Entities;
using LINQ.DAL.Repositories.Implement;
using LINQ.DAL.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace LINQ.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var serviceProvider = new ServiceCollection()
                .AddSingleton<AppDbContext>()
            .AddSingleton<IPhimRepo, PhimRepo>()
                .AddSingleton<IPhimService, PhimService>()
            .BuildServiceProvider();

            var phimService = serviceProvider.GetService<IPhimService>();

            while (true)
            {
                Console.WriteLine("Chọn một tùy chọn:");
                Console.WriteLine("1. Lấy danh sách phim có thời lượng lớn hơn 100 phút");
                Console.WriteLine("2. Lọc phim theo đạo diễn và lấy 2 phim đầu tiên");
                Console.WriteLine("3. Lọc phim theo thể loại");
                Console.WriteLine("4. Lọc phim có mô tả không rỗng");
                Console.WriteLine("5. Lấy phim có thời lượng dưới 120 phút");
                Console.WriteLine("6. Tìm phim đầu tiên phát hành vào tháng hai");
                Console.WriteLine("7. Lọc phim có chữ 'C' trong tên");
                Console.WriteLine("8. Lọc và sắp xếp phim theo thể loại");
                Console.WriteLine("9. Lọc các phim có từ 'Hài' trong tên");
                Console.WriteLine("10. Lấy phim không có mô tả");
                Console.WriteLine("11. Tìm phim có thời lượng ngắn nhất");
                Console.WriteLine("12. Lọc phim theo thể loại Kinh Dị");
                Console.WriteLine("13. Lấy phim phát hành trước năm 2023");
                Console.WriteLine("14. Lấy tên phim và đạo diễn theo thể loại");
                Console.WriteLine("15. Lấy 3 phim có thời lượng từ 90 đến 150 phút");
                Console.WriteLine("16. Tìm phim tình cảm đầu tiên có mô tả");
                Console.WriteLine("17. Lấy phim theo tháng và số lượng thể loại");
                Console.WriteLine("18. Lấy năm phim mới nhất theo thời lượng giảm dần");
                Console.WriteLine("19. Lọc phim theo thể loại và lấy tên phim");
                Console.WriteLine("20. Lấy phim có từ khóa 'Phim' trong tên");
                Console.WriteLine("21. Tìm phim có thời gian phát hành sớm nhất và số lượng thể loại");
                Console.WriteLine("22. Lọc phim hài có thời lượng lớn hơn 90 phút");
                Console.WriteLine("23. Lấy hai phim hành động");
                Console.WriteLine("24. Lọc phim không có mô tả");
                Console.WriteLine("25. Lọc phim phát hành trước tháng 11");
                Console.WriteLine("26. Lấy ba phim hành động");
                Console.WriteLine("27. Lấy phim phát hành từ tháng hai trở đi");
                Console.WriteLine("28. Lọc phim kinh dị");
                Console.WriteLine("29. Thoát");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LayDanhSachPhimCoThoiLuongLonHon100phut(phimService);
                        break;
                    case "2":
                        LocPhimTheoDaoDienVaLay2PhimDauTien(phimService);
                        break;
                    case "3":
                        LocPhimTheoTheLoai(phimService);
                        break;
                    case "4":
                        LocPhimCoMoTaKhongRong(phimService);
                        break;
                    case "5":
                        LayPhimCoThoiLuongDuoi120p(phimService);
                        break;
                    case "6":
                        TimPhimDauTienPhatHanhVaoThangHai(phimService);
                        break;
                    case "7":
                        LocPhimCoChuCTrongTen(phimService);
                        break;
                    case "8":
                        LocVaSapXepPhimTheoTheLoai(phimService);
                        break;
                    case "9":
                        LocCacPhimCoTuHaiTrongTen(phimService);
                        break;
                    case "10":
                        LayPhimKhongCoMoTa(phimService);
                        break;
                    case "11":
                        TimPhimCoThoiLuongNganNhat(phimService);
                        break;
                    case "12":
                        LocPhimTheoTheLoaiKinhDi(phimService);
                        break;
                    case "13":
                        LayPhimPhatHanhTruoc2023(phimService);
                        break;
                    case "14":
                        LayTenPhimVaDaoDienTheoTheLoai(phimService);
                        break;
                    case "15":
                        LayBaPhimCoThoiLuongTu90Den150Phut(phimService);
                        break;
                    case "16":
                        TimPhimTinhCamDauTienCoMoTa(phimService);
                        break;
                    case "17":
                        LayPhimTheoThangVaSoLuongTheLoai(phimService);
                        break;
                    case "18":
                        LayNamPhimMoiNhatTheoThoiLuongGiamDan(phimService);
                        break;
                    case "19":
                        LocPhimTheoTheLoaiVaLayTenPhim(phimService);
                        break;
                    case "20":
                        LayPhimCoTuKhoaPhimTrongTen(phimService);
                        break;
                    case "21":
                        TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai(phimService);
                        break;
                    case "22":
                        LocPhimHaiCoThoiLuongLonHon90phut(phimService);
                        break;
                    case "23":
                        LayHaiPhimHanhDong(phimService);
                        break;
                    case "24":
                        LocPhimKhongCoMoTa(phimService);
                        break;
                    case "25":
                        LocPhimPhatHanhTruocThang11(phimService);
                        break;
                    case "26":
                        LayBaPhimHanhDong(phimService);
                        break;
                    case "27":
                        LayPhimPhatHanhTuThangHaiTroDi(phimService);
                        break;
                    case "28":
                        LocPhimKinhDi(phimService);
                        break;
                    case "29":
                        return;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void LayDanhSachPhimCoThoiLuongLonHon100phut(IPhimService phimService)
        {
            var phimList = phimService.LayDangSachPhimCoThoiLuongLonHon100phut();
            Console.WriteLine("Danh sách phim có thời lượng lớn hơn 100 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LocPhimTheoDaoDienVaLay2PhimDauTien(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên đạo diễn:");
            var daoDien = Console.ReadLine();

            var phimList = phimService.LocPhimTheoDaoDienVaLay2PhimDauTien(daoDien);
            Console.WriteLine($"Danh sách 2 phim đầu tiên của đạo diễn {daoDien}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LocPhimTheoTheLoai(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên thể loại:");
            var theLoai = Console.ReadLine();

            var phimList = phimService.LocPhimTheoTheLoai(theLoai);
            Console.WriteLine($"Danh sách phim thuộc thể loại {theLoai}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LocPhimCoMoTaKhongRong(IPhimService phimService)
        {
            var phimList = phimService.LocPhimCoMoTaKhongRong();
            Console.WriteLine("Danh sách phim có mô tả không rỗng:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.MoTa}");
            }
        }

        static void LayPhimCoThoiLuongDuoi120p(IPhimService phimService)
        {
            var phimList = phimService.LayPhimCoThoiLuongDuoi120p();
            Console.WriteLine("Danh sách phim có thời lượng dưới 120 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void TimPhimDauTienPhatHanhVaoThangHai(IPhimService phimService)
        {
            var phim = phimService.TimPhimDauTienPhatHanhVaoThangHai();
            if (phim != null)
            {
                Console.WriteLine($"Phim đầu tiên phát hành vào tháng hai: {phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phim nào phát hành vào tháng hai.");
            }
        }

        static void LocPhimCoChuCTrongTen(IPhimService phimService)
        {
            var phimList = phimService.LocPhimCoChuCTrongTen();
            Console.WriteLine("Danh sách phim có chữ 'C' trong tên:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LocVaSapXepPhimTheoTheLoai(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên phim:");
            var tenPhim = Console.ReadLine();

            var theLoaiList = phimService.LocVaSapXepPhimTheoTheLoai(tenPhim);
            Console.WriteLine($"Danh sách thể loại của phim {tenPhim}:");
            foreach (var theLoai in theLoaiList)
            {
                Console.WriteLine(theLoai);
            }
        }

        static void LocCacPhimCoTuHaiTrongTen(IPhimService phimService)
        {
            var phimList = phimService.LocCacPhimCoTuHaiTrongTen();
            Console.WriteLine("Danh sách phim có từ 'Hài' trong tên:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LayPhimKhongCoMoTa(IPhimService phimService)
        {
            var phimList = phimService.LayPhimKhongCoMoTa();
            Console.WriteLine("Danh sách phim không có mô tả:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.DaoDien}");
            }
        }

        static void TimPhimCoThoiLuongNganNhat(IPhimService phimService)
        {
            var phim = phimService.TimPhimCoThoiLuongNganNhat();
            if (phim != null)
            {
                Console.WriteLine($"Phim có thời lượng ngắn nhất: {phim.TenPhim} - {phim.ThoiLuong} phút");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phim nào.");
            }
        }

        static void LocPhimTheoTheLoaiKinhDi(IPhimService phimService)
        {
            var phimList = phimService.LocPhimTheoTheLoaiKinhDi();
            Console.WriteLine("Danh sách phim thuộc thể loại Kinh Dị:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LayPhimPhatHanhTruoc2023(IPhimService phimService)
        {
            var phimList = phimService.LayPhimPhatHanhTruoc2023();
            Console.WriteLine("Danh sách phim phát hành trước năm 2023:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LayTenPhimVaDaoDienTheoTheLoai(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên thể loại:");
            var tenTheLoai = Console.ReadLine();

            var phimList = phimService.LayTenPhimVaDaoDienTheoTheLoai(tenTheLoai);
            Console.WriteLine($"Danh sách phim và đạo diễn thuộc thể loại {tenTheLoai}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LayBaPhimCoThoiLuongTu90Den150Phut(IPhimService phimService)
        {
            var phimList = phimService.LayBaPhimCoThoiLuongTu90Den150Phut();
            Console.WriteLine("Danh sách 3 phim có thời lượng từ 90 đến 150 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void TimPhimTinhCamDauTienCoMoTa(IPhimService phimService)
        {
            var phim = phimService.TimPhimTinhCamDauTienCoMoTa();
            if (phim != null)
            {
                Console.WriteLine($"Phim tình cảm đầu tiên có mô tả: {phim}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phim nào.");
            }
        }

        static void LayPhimTheoThangVaSoLuongTheLoai(IPhimService phimService)
        {
            var phimList = phimService.LayPhimTheoThangVaSoLuongTheLoai();
            Console.WriteLine("Danh sách phim theo tháng và số lượng thể loại:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LayNamPhimMoiNhatTheoThoiLuongGiamDan(IPhimService phimService)
        {
            var phimList = phimService.LayNamPhimMoiNhatTheoThoiLuongGiamDan();
            Console.WriteLine("Danh sách phim mới nhất theo thời lượng giảm dần:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LocPhimTheoTheLoaiVaLayTenPhim(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên thể loại:");
            var tenTheLoai = Console.ReadLine();

            var phimList = phimService.LocPhimTheoTheLoaiVaLayTenPhim(tenTheLoai);
            Console.WriteLine($"Danh sách tên phim thuộc thể loại {tenTheLoai}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LayPhimCoTuKhoaPhimTrongTen(IPhimService phimService)
        {
            var phimList = phimService.LayPhimCoTuKhoaPhimTrongTen();
            Console.WriteLine("Danh sách phim có từ khóa 'Phim' trong tên:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai(IPhimService phimService)
        {
            var phim = phimService.TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai();
            if (phim != null)
            {
                Console.WriteLine($"Phim có thời gian phát hành sớm nhất và số lượng thể loại: {phim}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phim nào.");
            }
        }

        static void LocPhimHaiCoThoiLuongLonHon90phut(IPhimService phimService)
        {
            var phimList = phimService.LocPhimHaiCoThoiLuongLonHon90phut();
            Console.WriteLine("Danh sách phim hài có thời lượng lớn hơn 90 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LayHaiPhimHanhDong(IPhimService phimService)
        {
            var phimList = phimService.LayHaiPhimHanhDong();
            Console.WriteLine("Danh sách hai phim hành động:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LocPhimKhongCoMoTa(IPhimService phimService)
        {
            var phimList = phimService.LocPhimKhongCoMoTa();
            Console.WriteLine("Danh sách phim không có mô tả:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LocPhimPhatHanhTruocThang11(IPhimService phimService)
        {
            var phimList = phimService.LocPhimPhatHanhTruocThang11();
            Console.WriteLine("Danh sách phim phát hành trước tháng 11:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LayBaPhimHanhDong(IPhimService phimService)
        {
            var phimList = phimService.LayBaPhimHanhDong();
            Console.WriteLine("Danh sách ba phim hành động:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LayPhimPhatHanhTuThangHaiTroDi(IPhimService phimService)
        {
            var phimList = phimService.LayPhimPhatHanhTuThangHaiTroDi();
            Console.WriteLine("Danh sách phim phát hành từ tháng hai trở đi:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }

        static void LocPhimKinhDi(IPhimService phimService)
        {
            var phimList = phimService.LocPhimKinhDi();
            Console.WriteLine("Danh sách phim kinh dị:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim);
            }
        }
    }
}
