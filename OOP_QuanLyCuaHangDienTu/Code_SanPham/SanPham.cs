using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOP_QuanLyCuaHangDienTu;

namespace OOP_QuanLyCuaHangDienTu.Code_SanPham
{
   public abstract class SanPham : Interface_SanPham
    {
        //Fields
        protected string sMaSP;
        protected string sTenSP;
        protected string sLoaiSP;
        protected string sThuongHieu;
        protected string sTrangThai;
        protected int sSoluong;
        protected float sGiaban;

        //Properties
        public string MaSP
        {
            get { return this.sMaSP; }
            set { this.sMaSP = value; }
        }
        public string TenSP
        {
            get { return this.sTenSP; }
            set { this.sTenSP = value; }
        }
        public string ThuongHieu
        {
            get { return this.sThuongHieu; }
            set { this.sThuongHieu = value; }
        }
        public string TrangThai
        {
            get { return this.sTrangThai; }
            set { this.sTrangThai = value; }
        }
        public int SoLuong
        {
            get { return this.sSoluong; }
            set { this.sSoluong = value; }
        }
        public float Giaban
        {
            get { return this.sGiaban; }
            set { this.sGiaban = value; }
        }
        public string LoaiSP
        {
            get { return this.sLoaiSP; }
            set { this.sLoaiSP = value; }
        }

        //Constructors
        public SanPham() { }
        public SanPham(string maSP) { }
        public SanPham(string loaiSP, string maSP, string tenSP, string thuongHieu, float giaBan, int soLuong, string trangThai)
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
        public abstract void Nhap();
        public void Hien()
        {
            Console.WriteLine("\t|| {0,-15} ||  {1,-4}  ||  {2,-33}  ||  {3,-13}  ||   {4,-14}  ||   {5,-10} || {6,-12} || ",LoaiSP, MaSP, TenSP, ThuongHieu, Giaban, SoLuong, TrangThai);
        }
        public string toString()
        {
            return LoaiSP + "#" + MaSP + "#" + TenSP + "#" + ThuongHieu + "#" + Giaban + "#" + SoLuong + "#" + TrangThai;
        }
        public static bool operator >(SanPham a, SanPham b)
        {
            return a.SoLuong > b.SoLuong;
        }
        public static bool operator <(SanPham a, SanPham b)
        {
            return a.SoLuong < b.SoLuong;
        }
    }
}
