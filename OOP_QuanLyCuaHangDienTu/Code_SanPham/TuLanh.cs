using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_QuanLyCuaHangDienTu.Code_SanPham
{
    class TuLanh : SanPham
    {
        //Fields

        //Properties

        //Constructors
        public TuLanh() { }
        public TuLanh(string maSP) { }
        public TuLanh(string loaiSP, string maSP, string tenSP, string thuongHieu, float giaBan, int soLuong, string trangThai)
        {
            this.LoaiSP = loaiSP;
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.ThuongHieu = thuongHieu;
            this.Giaban = giaBan;
            this.SoLuong = soLuong;
            this.TrangThai = trangThai;
        }
        //Method
        public override void Nhap()
        {
            Console.Write("\t\t Tên sản phẩm: ");
            TenSP = Console.ReadLine();
            Console.Write("\t\t Thương hiệu : ");
            ThuongHieu = Console.ReadLine();
            Console.Write("\t\t Giá bán     : ");
            Giaban = float.Parse(Console.ReadLine());
            Console.Write("\t\t Số Lượng    : ");
            SoLuong = int.Parse(Console.ReadLine());
            if (SoLuong > 0)
            {
                TrangThai = "Còn";
            }
            else TrangThai = "Hết hàng ";
        }
    }
}
