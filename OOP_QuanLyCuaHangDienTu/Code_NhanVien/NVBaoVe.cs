using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_QuanLyCuaHangDienTu.Interface;

namespace OOP_QuanLyCuaHangDienTu.Code_NhanVien
{
    public class NVBaoVe : NhanVien,Interface_NVBaoVe
    {
        //Fields

        //Properties

        //Constructors
        public NVBaoVe() : base()
        {

        }
        public NVBaoVe(string tenNV, string maNV, string quequan, string chucvu, int namsinh, int calam, int luongcb) : base(tenNV, maNV, quequan, chucvu, namsinh, calam, luongcb)
        {

        }
        //Hàm Hủy 
        ~NVBaoVe()
        {

        }
        //Method
        //Nhập
        public override void Nhap()
        {
            base.Nhap();
            tinhluongCT();
        }

        //Hàm xuất
        //TÍnh toán
        public override void tinhluongCT()
        {
            this.LuongChinhThuc = this.LuongCB + (this.Calam * 300000);
        }
    }
}
