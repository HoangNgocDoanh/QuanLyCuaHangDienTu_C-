using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_QuanLyCuaHangDienTu.Interface;

namespace OOP_QuanLyCuaHangDienTu.Code_NhanVien
{
    public class NVQuanLy : NhanVien, Interface_NVQuanLy
    {
        //Fields
        private int iThamnien;
        //Properties
        public int Thamnien
        {
            get { return this.iThamnien; }
            set { this.iThamnien = value; }
        }
        //Constructors
        public NVQuanLy() : base()
        {

        }
        public NVQuanLy(string tenNV, string maNV, string quequan, string chucvu, int namsinh, int calam, int luongcb) : base(tenNV,maNV,quequan,chucvu,namsinh,calam, luongcb)
        {

        }
        //Finalizer
        ~NVQuanLy()
        {

        }
        //Method
        //Nhập
        public override void Nhap()
        {
            base.Nhap();
            tinhluongCT();
            Console.Write("\t\tNhập Thâm Niên : ");
            this.iThamnien = Convert.ToInt32(Console.ReadLine());
        }
        //Xuất
        //Tính toán
        public override void tinhluongCT()
        {
            
            if (this.Thamnien >= 5)
            {
                this.LuongChinhThuc = this.LuongCB + (this.Calam * 600000) + 500000;
            }
            else
            {
                this.LuongChinhThuc = this.LuongCB + (this.Calam * 600000);
            }
        }
    }
}
