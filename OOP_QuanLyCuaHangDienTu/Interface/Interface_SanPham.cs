using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_QuanLyCuaHangDienTu
{
    public interface Interface_SanPham
    {
        //Properties
        string MaSP { get; set; }
        string TenSP { get; set; }
        string ThuongHieu { get; set; }
        string TrangThai { get; set; }
        int SoLuong { get; set; }
        float Giaban { get; set; }
        string LoaiSP { get; set; }
        //Method
        void Nhap();
        void Hien();
        string toString();
    }
}
