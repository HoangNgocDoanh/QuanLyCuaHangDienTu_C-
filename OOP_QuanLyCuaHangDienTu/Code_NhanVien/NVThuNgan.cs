using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_QuanLyCuaHangDienTu.Interface;

namespace OOP_QuanLyCuaHangDienTu.Code_NhanVien
{
    public class NVThuNgan : NhanVien, Interface_NVThuNgan
    {
        //Trường thuộc tính
        //Hàm thuộc tính
        //Hàm tạo
        public NVThuNgan() : base()
        {

        }
        public NVThuNgan(string tenNV, string maNV, string quequan, string chucvu, int namsinh,int calam, int luongcb) : base(tenNV, maNV, quequan, chucvu, namsinh, calam, luongcb)
        {

        }
        //hàm hủy
        ~NVThuNgan()
        {

        }
        //Method
        //Nhập
        public override void Nhap()
        {
            base.Nhap();
            tinhluongCT();
        }

        //TÍnh toán
        public override  void tinhluongCT()
        {
            this.LuongChinhThuc = this.LuongCB + (this.Calam * 500000);
        }
    }
}
