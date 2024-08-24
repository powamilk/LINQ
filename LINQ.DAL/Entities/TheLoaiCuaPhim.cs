using System;
using System.Collections.Generic;

namespace LINQ.DAL.Entities;

public partial class TheLoaiCuaPhim
{
    public int PhimId { get; set; }

    public int TheLoaiId { get; set; }

    public int? TrangThai { get; set; }

    public virtual Phim Phim { get; set; } = null!;

    public virtual TheLoai TheLoai { get; set; } = null!;
}
