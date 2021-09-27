using OOP_QuanLyCuaHangDienTu.Code_SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_QuanLyCuaHangDienTu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GiaoDien a = new GiaoDien();
            a.TaiKhoan();
        }
    }
}
