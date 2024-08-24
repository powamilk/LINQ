using System;
using System.Collections.Generic;

namespace LINQ.DAL.Entities;

public partial class TheLoai
{
    public int TheLoaiId { get; set; }

    public string TenTheLoai { get; set; } = null!;

    public virtual ICollection<TheLoaiCuaPhim> TheLoaiCuaPhims { get; set; } = new List<TheLoaiCuaPhim>();
}
