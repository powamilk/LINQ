using System;
using System.Collections.Generic;

namespace LINQ.DAL.Entities;

public partial class Phim
{
    public int PhimId { get; set; }

    public string TenPhim { get; set; } = null!;

    public DateOnly? ThoiGianPhatHanh { get; set; }

    public string? DaoDien { get; set; }

    public int? ThoiLuong { get; set; }

    public int? TrangThai { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<TheLoai> TheLoais { get; set; } = new List<TheLoai>();
}
