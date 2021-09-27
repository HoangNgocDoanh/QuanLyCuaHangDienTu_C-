using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_QuanLyCuaHangDienTu.Interface
{
    public interface Interface_NVBaoVe
    {
        //Properties
        string TenNV { get; set; }
        string MaNV { get; set; }
        string Quequan { get; set; }
        string Chucvu { get; set; }
        int Namsinh { get; set; }
        int LuongCB { get; set; }
        int Calam { get; set; }
        int LuongChinhThuc { get; set; }
        //Method
        void Nhap();
        void tinhluongCT();
        void Hien();
        string toString();
    }
}
