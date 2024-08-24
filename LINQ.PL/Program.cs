using LINQ.DAL;
using LINQ.DAL.Entities;
using LINQ.DAL.Repositories.Implement;
using LINQ.DAL.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using LINQ.BUS.Implement;
using LINQ.BUS.Interface;
using LINQ.DAL.Repositories.Interface;

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
                Console.WriteLine("31. Thêm phim mới và thể loại 'Hành Động'");
                Console.WriteLine("32. Cập nhật phim có thể loại 'Hài kịch'");
                Console.WriteLine("33. Xóa phim có tên 'Phim A'");
                Console.WriteLine("34. Thêm thể loại 'Hài' cho phim 'Phim B'");
                Console.WriteLine("35. Cập nhật tên thể loại 'Kinh dị' thành 'Kinh Dị Mới'");
                Console.WriteLine("36. Xóa thể loại 'Phiêu Lưu'");
                Console.WriteLine("37. Thêm mối quan hệ giữa 'Phim C' và 'Kinh Dị Mới'");
                Console.WriteLine("38. Cập nhật thời gian phát hành cho phim thuộc 'Hài kịch' và 'Kinh Dị Mới'");
                Console.WriteLine("39. Xóa phim phát hành trước năm 2020");
                Console.WriteLine("40. Thêm phim mới 'Phim B' và liên kết với 'Hài'");
                Console.WriteLine("41. Cập nhật mô tả phim có ID 3");
                Console.WriteLine("42. Xóa thể loại có ID 4");
                Console.WriteLine("43. Thêm thể loại cho phim có ID 5");
                Console.WriteLine("44. Cập nhật đạo diễn mới cho phim có thời lượng > 120 phút");
                Console.WriteLine("45. Xóa thể loại không liên kết với phim nào");
                Console.WriteLine("46. Thêm phim mới và kiểm tra số lượng phim");
                Console.WriteLine("47. Cập nhật thời lượng phim theo thể loại có chứa 'A'");
                Console.WriteLine("48. Xóa phim có tên 'Phim X' và kiểm tra thể loại liên quan");
                Console.WriteLine("49. Thêm 3 phim mới và liệt kê phim vừa thêm");
                Console.WriteLine("50. Cập nhật mô tả cho phim có tên chứa 'C'");
                Console.WriteLine("51. Xóa phim có thời lượng dưới 60 phút và kiểm tra thể loại");
                Console.WriteLine("52. Thêm đạo diễn mới cho phim phát hành năm 2023");
                Console.WriteLine("53. Cập nhật tên thể loại cho phim có ID 1");
                Console.WriteLine("54. Xóa thể loại có ID lớn hơn 5 và kiểm tra phim bị ảnh hưởng");
                Console.WriteLine("55. Thêm thể loại mới và liên kết với phim đã có");
                Console.WriteLine("56. Cập nhật thể loại 'Hài kịch' cho phim có trạng thái 1");
                Console.WriteLine("57. Xóa phim không có thể loại và phát hành trước tháng 6");
                Console.WriteLine("58. Thêm danh sách thể loại cho tất cả các phim và hiển thị");
                Console.WriteLine("59. Cập nhật tất cả thể loại cho phim có ID 1");
                Console.WriteLine("60. Xóa phim phát hành năm 2019 và hiển thị bảng TheLoaiCuaPhim");
                Console.WriteLine("61. Thoát");

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
                    case "31":
                        ThemPhimVaTheLoai(phimService);
                        break;
                    case "32":
                        CapNhatPhimTheoTheLoai(phimService);
                        break;
                    case "33":
                        XoaPhimVaLienKet(phimService);
                        break;
                    case "34":
                        ThemTheLoaiVaLienKetPhim(phimService);
                        break;
                    case "35":
                        CapNhatTheLoai(phimService);
                        break;
                    case "36":
                        XoaTheLoaiVaLienKet(phimService);
                        break;
                    case "37":
                        ThemLienKetPhimVaTheLoai(phimService);
                        break;
                    case "38":
                        CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai(phimService);
                        break;
                    case "39":
                        XoaPhimPhatHanhTruocNam2020(phimService);
                        break;
                    case "40":
                        ThemPhimMoiVaLienKet(phimService);
                        break;
                    case "41":
                        CapNhatMoTaPhimVaKiemTraTheLoai(phimService);
                        break;
                    case "42":
                        XoaTheLoaiVaKiemTraPhim(phimService);
                        break;
                    case "43":
                        ThemNhieuTheLoaiChoPhim(phimService);
                        break;
                    case "44":
                        CapNhatDaoDienChoPhimLonHon120(phimService);
                        break;
                    case "45":
                        XoaTheLoaiKhongCoPhim(phimService);
                        break;
                    case "46":
                        ThemPhimMoiKiemTra(phimService);
                        break;
                    case "47":
                        CapNhatThoiLuongChoPhimTheoTheLoai(phimService);
                        break;
                    case "48":
                        XoaPhimVaKiemTraTheLoai(phimService);
                        break;
                    case "49":
                        ThemNhieuPhimVaLienKet(phimService);
                        break;
                    case "50":
                        CapNhatMoTaChoPhimCoKyTuC(phimService);
                        break;
                    case "51":
                        XoaPhimThoiLuongDuoi60KiemTraTheLoai(phimService);
                        break;
                    case "52":
                        ThemDaoDienMoiChoPhimPhatHanhNam2023(phimService);
                        break;
                    case "53":
                        CapNhatTheLoaiChoPhim(phimService);
                        break;
                    case "54":
                        XoaTheLoaiLonHon5KiemTraPhim(phimService);
                        break;
                    case "55":
                        ThemTheLoaiMoiVaLienKet(phimService);
                        break;
                    case "56":
                        CapNhatTheLoaiChoPhimTrangThai1(phimService);
                        break;
                    case "57":
                        XoaPhimKhongCoTheLoaiPhatHanhTruocThang6(phimService);
                        break;
                    case "58":
                        ThemDanhSachTheLoaiChoTatCaPhim(phimService);
                        break;
                    case "59":
                        CapNhatTatCaTheLoaiChoPhim(phimService);
                        break;
                    case "60":
                        XoaPhimNam2019VaKiemTraTheLoai(phimService);
                        break;
                    case "61":
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
            var phimList = phimService.LayPhimLonHon100Phut();
            Console.WriteLine("Danh sách phim có thời lượng lớn hơn 100 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocPhimTheoDaoDienVaLay2PhimDauTien(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên đạo diễn:");
            var daoDien = Console.ReadLine();

            var phimList = phimService.LayPhimTheoDaoDien(daoDien);
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

            var phimList = phimService.LayPhimTheoTheLoai(theLoai);
            Console.WriteLine($"Danh sách phim thuộc thể loại {theLoai}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocPhimCoMoTaKhongRong(IPhimService phimService)
        {
            var phimList = phimService.LayPhimCoMoTaKhongRong();
            Console.WriteLine("Danh sách phim có mô tả không rỗng:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.MoTa}");
            }
        }

        static void LayPhimCoThoiLuongDuoi120p(IPhimService phimService)
        {
            var phimList = phimService.LayPhimThoiLuongDuoi120();
            Console.WriteLine("Danh sách phim có thời lượng dưới 120 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void TimPhimDauTienPhatHanhVaoThangHai(IPhimService phimService)
        {
            var phim = phimService.LayPhimDauTienTheoThangPhatHanh(2);
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
            var phimList = phimService.LayPhimTheoTuKhoaTrongTen("C");
            Console.WriteLine("Danh sách phim có chữ 'C' trong tên:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LocVaSapXepPhimTheoTheLoai(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên thể loại:");
            var theLoai = Console.ReadLine();

            var phimList = phimService.LayPhimTheoTheLoaiVaSapXep(theLoai);
            Console.WriteLine($"Danh sách phim thuộc thể loại {theLoai} và sắp xếp theo thời gian phát hành:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocCacPhimCoTuHaiTrongTen(IPhimService phimService)
        {
            var phimList = phimService.LayPhimCoTuKhoaTrongTenVaThoiLuongHon90("Hai");
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
            var phim = phimService.LayPhimCoThoiLuongNganNhat();
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
            var phimList = phimService.LayPhimTheoTheLoai("Kinh Dị");
            Console.WriteLine("Danh sách phim thuộc thể loại Kinh Dị:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.ThoiGianPhatHanh}");
            }
        }

        static void LayPhimPhatHanhTruoc2023(IPhimService phimService)
        {
            var phimList = phimService.LayPhimPhatHanhTruocNam(2023);
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

            var phimList = phimService.LayPhimTheoTenVaTheLoai(tenTheLoai, tenTheLoai);
            Console.WriteLine($"Danh sách phim và đạo diễn thuộc thể loại {tenTheLoai}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine($"{phim.TenPhim} - {phim.DaoDien}");
            }
        }

        static void LayBaPhimCoThoiLuongTu90Den150Phut(IPhimService phimService)
        {
            var phimList = phimService.LayPhimTheoKhoangThoiLuong(90, 150);
            Console.WriteLine("Danh sách 3 phim có thời lượng từ 90 đến 150 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void TimPhimTinhCamDauTienCoMoTa(IPhimService phimService)
        {
            var phim = phimService.LayPhimDauTienCoTheLoaiVaMoTa("Tình Cảm");
            if (phim != null)
            {
                Console.WriteLine($"Phim tình cảm đầu tiên có mô tả: {phim.TenPhim}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phim nào.");
            }
        }

        static void LayPhimTheoThangVaSoLuongTheLoai(IPhimService phimService)
        {
            var phimList = phimService.LayPhimTheoThangVaDemSoLuongTheLoai(2);
            Console.WriteLine("Danh sách phim theo tháng và số lượng thể loại:");

            foreach (var phim in phimList)
            {
                dynamic p = phim;
                Console.WriteLine($"{p.TenPhim} - Số lượng thể loại: {p.TheLoaiCount}");
            }
        }


        static void LayNamPhimMoiNhatTheoThoiLuongGiamDan(IPhimService phimService)
        {
            var phimList = phimService.Lay5PhimMoiNhatSapXepTheoThoiLuong();
            Console.WriteLine("Danh sách phim mới nhất theo thời lượng giảm dần:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocPhimTheoTheLoaiVaLayTenPhim(IPhimService phimService)
        {
            Console.WriteLine("Nhập tên thể loại:");
            var tenTheLoai = Console.ReadLine();

            var phimList = phimService.LayPhimTheoTheLoai(tenTheLoai);
            Console.WriteLine($"Danh sách tên phim thuộc thể loại {tenTheLoai}:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LayPhimCoTuKhoaPhimTrongTen(IPhimService phimService)
        {
            var phimList = phimService.LayPhimTheoTuKhoaTrongTen("Phim");
            Console.WriteLine("Danh sách phim có từ khóa 'Phim' trong tên:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void TimPhimCoThoiGianPhatHanhSomNhatVaSoLuongTheLoai(IPhimService phimService)
        {
            var phim = phimService.LayPhimPhatHanhSomNhatVaDemTheLoai();
            if (phim != null)
            {
                Console.WriteLine($"Phim có thời gian phát hành sớm nhất và số lượng thể loại: {phim.TenPhim}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phim nào.");
            }
        }

        static void LocPhimHaiCoThoiLuongLonHon90phut(IPhimService phimService)
        {
            var phimList = phimService.LayPhimCoTuKhoaTrongTenVaThoiLuongHon90("Hai");
            Console.WriteLine("Danh sách phim hài có thời lượng lớn hơn 90 phút:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LayHaiPhimHanhDong(IPhimService phimService)
        {
            var phimList = phimService.LayTopNPhimTheoTheLoai("Hành Động", 2);
            Console.WriteLine("Danh sách hai phim hành động:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocPhimKhongCoMoTa(IPhimService phimService)
        {
            var phimList = phimService.LayPhimKhongCoMoTa();
            Console.WriteLine("Danh sách phim không có mô tả:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocPhimPhatHanhTruocThang11(IPhimService phimService)
        {
            var phimList = phimService.LayPhimPhatHanhTruocThang(11);
            Console.WriteLine("Danh sách phim phát hành trước tháng 11:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LayBaPhimHanhDong(IPhimService phimService)
        {
            var phimList = phimService.LayTopNPhimTheoTheLoai("Hành Động", 3);
            Console.WriteLine("Danh sách ba phim hành động:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LayPhimPhatHanhTuThangHaiTroDi(IPhimService phimService)
        {
            var phimList = phimService.LayPhimTheoThangVaSapXep(2);
            Console.WriteLine("Danh sách phim phát hành từ tháng hai trở đi:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void LocPhimKinhDi(IPhimService phimService)
        {
            var phimList = phimService.LayPhimTheoTheLoai("Kinh Dị");
            Console.WriteLine("Danh sách phim kinh dị:");
            foreach (var phim in phimList)
            {
                Console.WriteLine(phim.TenPhim);
            }
        }

        static void ThemPhimVaTheLoai(IPhimService phimService)
        {
            var phim = new Phim { TenPhim = "Phim Moi", DaoDien = "Dao Dien Moi", ThoiGianPhatHanh = new DateOnly(2024, 1, 1) };
            phimService.ThemPhimVaTheLoai(phim, "Hành Động");
            Console.WriteLine("Đã thêm phim và thể loại.");
        }

        static void CapNhatPhimTheoTheLoai(IPhimService phimService)
        {
            phimService.CapNhatPhimTheoTheLoai("Hài kịch", new DateOnly(2024, 1, 1), "Dao Dien Moi");
            Console.WriteLine("Đã cập nhật thông tin phim.");
        }

        static void XoaPhimVaLienKet(IPhimService phimService)
        {
            phimService.XoaPhimVaLienKet("Phim A");
            Console.WriteLine("Đã xóa phim và các liên kết.");
        }

        static void ThemTheLoaiVaLienKetPhim(IPhimService phimService)
        {
            phimService.ThemTheLoaiVaLienKetPhim("Hài", "Phim B");
            Console.WriteLine("Đã thêm thể loại và liên kết.");
        }

        static void CapNhatTheLoai(IPhimService phimService)
        {
            phimService.CapNhatTheLoai("Kinh dị", "Kinh Dị Mới");
            Console.WriteLine("Đã cập nhật thể loại.");
        }

        static void XoaTheLoaiVaLienKet(IPhimService phimService)
        {
            phimService.XoaTheLoaiVaLienKet("Phiêu Lưu");
            Console.WriteLine("Đã xóa thể loại và các liên kết.");
        }

        static void ThemLienKetPhimVaTheLoai(IPhimService phimService)
        {
            phimService.ThemLienKetPhimVaTheLoai("Phim C", "Kinh Dị Mới");
            Console.WriteLine("Đã thêm liên kết giữa phim và thể loại.");
        }

        static void CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai(IPhimService phimService)
        {
            phimService.CapNhatThoiGianPhatHanhChoPhimThuocHaiTheLoai("Hài kịch", "Kinh Dị Mới", new DateOnly(2024, 1, 1));
            Console.WriteLine("Đã cập nhật thời gian phát hành.");
        }

        static void XoaPhimPhatHanhTruocNam2020(IPhimService phimService)
        {
            phimService.XoaPhimPhatHanhTruocNam2020();
            Console.WriteLine("Đã xóa các phim phát hành trước năm 2020.");
        }

        static void ThemPhimMoiVaLienKet(IPhimService phimService)
        {
            phimService.ThemPhimMoiVaLienKet("Phim B", "Đạo diễn B", new DateOnly(2023, 1, 1), "Hài");
            Console.WriteLine("Đã thêm phim mới và liên kết với thể loại.");
        }

        static void CapNhatMoTaPhimVaKiemTraTheLoai(IPhimService phimService)
        {
            phimService.CapNhatMoTaPhimVaKiemTraTheLoai(3, "Mô tả mới");
            Console.WriteLine("Đã cập nhật mô tả phim.");
        }

        static void XoaTheLoaiVaKiemTraPhim(IPhimService phimService)
        {
            phimService.XoaTheLoaiVaKiemTraPhim(4);
            Console.WriteLine("Đã xóa thể loại và các liên kết liên quan.");
        }

        static void ThemNhieuTheLoaiChoPhim(IPhimService phimService)
        {
            phimService.ThemNhieuTheLoaiChoPhim(5, new List<string> { "Tình Cảm", "Hành Động", "Kinh Dị" });
            Console.WriteLine("Đã thêm nhiều thể loại cho phim.");
        }

        static void CapNhatDaoDienChoPhimLonHon120(IPhimService phimService)
        {
            phimService.CapNhatDaoDienChoPhimLonHon120("Đạo diễn Mới");
            Console.WriteLine("Đã cập nhật đạo diễn mới.");
        }

        static void XoaTheLoaiKhongCoPhim(IPhimService phimService)
        {
            phimService.XoaTheLoaiKhongCoPhim();
            Console.WriteLine("Đã xóa các thể loại không có liên kết với phim.");
        }

        static void ThemPhimMoiKiemTra(IPhimService phimService)
        {
            phimService.ThemPhimMoiKiemTra("Phim Mới", "Đạo diễn Mới", "Thể loại Mới", new DateOnly(2024, 1, 1));
            Console.WriteLine("Đã thêm phim mới và kiểm tra số lượng phim.");
        }

        static void CapNhatThoiLuongChoPhimTheoTheLoai(IPhimService phimService)
        {
            phimService.CapNhatThoiLuongChoPhimTheoTheLoai("A", 150);
            Console.WriteLine("Đã cập nhật thời lượng cho phim theo thể loại.");
        }

        static void XoaPhimVaKiemTraTheLoai(IPhimService phimService)
        {
            phimService.XoaPhimVaKiemTraTheLoai("Phim X");
            Console.WriteLine("Đã xóa phim và kiểm tra các thể loại liên quan.");
        }

        static void ThemNhieuPhimVaLienKet(IPhimService phimService)
        {
            var phimList = new List<Phim>
            {
                new Phim { TenPhim = "Phim 1", DaoDien = "Đạo diễn 1", ThoiGianPhatHanh = new DateOnly(2024, 1, 1) },
                new Phim { TenPhim = "Phim 2", DaoDien = "Đạo diễn 2", ThoiGianPhatHanh = new DateOnly(2024, 1, 2) },
                new Phim { TenPhim = "Phim 3", DaoDien = "Đạo diễn 3", ThoiGianPhatHanh = new DateOnly(2024, 1, 3) }
            };
            var theLoaiList = new List<string> { "Thể loại 1", "Thể loại 2", "Thể loại 3" };
            phimService.ThemNhieuPhimVaLienKet(phimList, theLoaiList);
            Console.WriteLine("Đã thêm 3 phim mới và liên kết thể loại.");
        }

        static void CapNhatMoTaChoPhimCoKyTuC(IPhimService phimService)
        {
            phimService.CapNhatMoTaChoPhimCoKyTuC("Mô tả mới cho phim có chữ C");
            Console.WriteLine("Đã cập nhật mô tả cho phim có chữ C.");
        }

        static void XoaPhimThoiLuongDuoi60KiemTraTheLoai(IPhimService phimService)
        {
            phimService.XoaPhimThoiLuongDuoi60KiemTraTheLoai();
            Console.WriteLine("Đã xóa các phim có thời lượng dưới 60 phút và kiểm tra thể loại.");
        }

        static void ThemDaoDienMoiChoPhimPhatHanhNam2023(IPhimService phimService)
        {
            phimService.ThemDaoDienMoiChoPhimPhatHanhNam2023("Đạo diễn Mới");
            Console.WriteLine("Đã thêm đạo diễn mới cho phim phát hành năm 2023.");
        }

        static void CapNhatTheLoaiChoPhim(IPhimService phimService)
        {
            phimService.CapNhatTheLoaiChoPhim(1, "Thể loại mới");
            Console.WriteLine("Đã cập nhật thể loại cho phim có ID 1.");
        }

        static void XoaTheLoaiLonHon5KiemTraPhim(IPhimService phimService)
        {
            phimService.XoaTheLoaiLonHon5KiemTraPhim();
            Console.WriteLine("Đã xóa các thể loại có ID lớn hơn 5 và kiểm tra phim bị ảnh hưởng.");
        }

        static void ThemTheLoaiMoiVaLienKet(IPhimService phimService)
        {
            phimService.ThemTheLoaiMoiVaLienKet("Thể loại Mới", 1);
            Console.WriteLine("Đã thêm thể loại mới và liên kết với phim có ID 1.");
        }

        static void CapNhatTheLoaiChoPhimTrangThai1(IPhimService phimService)
        {
            phimService.CapNhatTheLoaiChoPhimTrangThai1();
            Console.WriteLine("Đã cập nhật thể loại 'Hài kịch' cho phim có trạng thái 1.");
        }

        static void XoaPhimKhongCoTheLoaiPhatHanhTruocThang6(IPhimService phimService)
        {
            phimService.XoaPhimKhongCoTheLoaiPhatHanhTruocThang6();
            Console.WriteLine("Đã xóa phim không có thể loại và phát hành trước tháng 6.");
        }

        static void ThemDanhSachTheLoaiChoTatCaPhim(IPhimService phimService)
        {
            phimService.ThemDanhSachTheLoaiChoTatCaPhim(new List<string> { "Thể loại 1", "Thể loại 2" });
            Console.WriteLine("Đã thêm danh sách thể loại cho tất cả các phim.");
        }

        static void CapNhatTatCaTheLoaiChoPhim(IPhimService phimService)
        {
            phimService.CapNhatTatCaTheLoaiChoPhim(1, new List<string> { "Thể loại Mới 1", "Thể loại Mới 2" });
            Console.WriteLine("Đã cập nhật tất cả thể loại cho phim có ID 1.");
        }

        static void XoaPhimNam2019VaKiemTraTheLoai(IPhimService phimService)
        {
            phimService.XoaPhimNam2019VaKiemTraTheLoai();
            Console.WriteLine("Đã xóa các phim phát hành năm 2019 và kiểm tra bảng TheLoaiCuaPhim.");
        }
    }
}
