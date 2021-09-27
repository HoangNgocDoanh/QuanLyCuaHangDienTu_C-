using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_QuanLyCuaHangDienTu.Code_NhanVien
{
    public class NhanVien
    {
        //Trường thuộc tính (Fields)
        protected string sTenNV;
        protected string sMaNV;
        protected string sQuequan;
        protected string sChucvu;
        protected int iNamsinh;
        protected int iLuongCB;
        protected int iCalam;
        protected int iLuongChinhThuc;
        //Hàm thuộc tính (Properties)
        public string TenNV
        {
            get { return this.sTenNV; }
            set { this.sTenNV = value; }
        }
        public string MaNV
        {
            get { return this.sMaNV; }
            set { this.sMaNV = value; }
        }
        public string Quequan
        {
            get { return this.sQuequan; }
            set { this.sQuequan = value; }
        }
        public string Chucvu
        {
            get { return this.sChucvu; }
            set { this.sChucvu = value; }
        }
        public int Namsinh
        {
            get { return this.iNamsinh; }
            set { this.iNamsinh = value; }
        }
        public int LuongCB
        {
            get { return this.iLuongCB; }
            set { this.iLuongCB = value; }
        }
        public int Calam
        {
            get { return this.iCalam; }
            set { this.iCalam = value; }
        }
        public int LuongChinhThuc
        {
            get { return this.iLuongChinhThuc; }
            set { this.iLuongChinhThuc = value; }
        }

        //Hàm tạo (Constructors)
        public NhanVien()
        {

        }
        public NhanVien(string tenNV, string maNV, string quequan, string chucvu, int namsinh, int calam, int luongcb)
        {
            this.TenNV = tenNV;
            this.MaNV = maNV;
            this.Quequan = quequan;
            this.Chucvu = chucvu;
            this.Namsinh = namsinh;
            this.LuongCB = luongcb;
            this.Calam = calam;
            this.tinhluongCT();
        }
        //Method
        public virtual void Nhap()
        {
            tinhluongCT();
            Console.Write("\t\tNhập Tên Nhân Viên: ");
            this.TenNV = Console.ReadLine();
            Console.Write("\t\tNhập Quê quán: ");
            this.Quequan = Console.ReadLine();
            Console.Write("\t\tNhập Năm Sinh: ");
            this.Namsinh = int.Parse(Console.ReadLine());
            Console.Write("\t\tNhập Lương cơ bản: ");
            this.LuongCB = int.Parse(Console.ReadLine());
            Console.Write("\t\tNhập Số Ca làm: ");
            this.Calam = int.Parse(Console.ReadLine());
        }
        //Tính toán
        public virtual void tinhluongCT()
        {
            this.LuongChinhThuc = this.LuongCB;
        }
        public void Hien()
        {
            Console.WriteLine("\t|| {0,-31} ||  {1,-1}  ||  {2,-9}  ||  {3,-9}  ||   {4,-10}  ||   {5,-17} || {6,-23} || ", TenNV, MaNV, Quequan, Chucvu, Namsinh, Calam, LuongChinhThuc);
        }
        public string toString()
        {
            return TenNV + "#" + MaNV + "#" + Quequan + "#" + Chucvu + "#" + Namsinh + "#" + Calam + "#" + LuongCB;
        }
        public static bool operator >(NhanVien a, NhanVien b)
        {
            return a.LuongChinhThuc > b.LuongChinhThuc;
        }
        public static bool operator <(NhanVien a, NhanVien b)
        {
            return a.LuongChinhThuc < b.LuongChinhThuc;
        }
    }
}
