using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_QuanLyCuaHangDienTu.Sourcecode
{
    class PhieuNhap
    {
        //Fields
        protected string sMaPN, sNCC, sdiachi, ssdt;
        protected DateTime sNgayNhap;
        protected int sSoLuong, sTongTien;

        //Properties
        public string MaPN
        {
            get { return this.sMaPN; }
            set { this.sMaPN = value; }
        }
        public string NCC
        {
            get { return this.sNCC; }
            set { this.sNCC = value; }
        }
        public string diachi
        {
            get { return this.sdiachi; }
            set { this.sdiachi = value; }
        }
        public string sdt
        {
            get { return this.ssdt; }
            set { this.ssdt = value; }
        }
        public DateTime NgayNhap
        {
            get { return this.sNgayNhap; }
            set { this.sNgayNhap = value; }
        }
        public int SoLuong
        {
            get { return this.sSoLuong; }
            set { this.sSoLuong = value; }
        }
        public int TongTien
        {
            get { return this.sTongTien; }
            set { this.sTongTien = value; }
        }

        //Constructors
        public PhieuNhap() { }

        public PhieuNhap(string maPN, string nCC, string diachi, string sdt, DateTime ngayNhap, int soLuong, int tongTien)
        {
            MaPN = maPN;
            NCC = nCC;
            this.diachi = diachi;
            this.sdt = sdt;
            NgayNhap = ngayNhap;
            SoLuong = soLuong;
            TongTien = tongTien;
        }

        //Method
        public void Nhap()
        {

            Console.Write("\t\tTên nhà cung cấp     : ");
            NCC = Console.ReadLine();
            Console.Write("\t\tĐịa chỉ              : ");
            diachi = Console.ReadLine();
            Console.Write("\t\tSố điện thoại        : ");
            sdt = Console.ReadLine();
            Console.Write("\t\tNgày nhập(dd/mm/yyyy): ");
            string a = Console.ReadLine();
            string[] b = a.Split('/');
            DateTime d = new DateTime(int.Parse(b[2]), int.Parse(b[1]), int.Parse(b[0]));
            NgayNhap = d;
        }
        public void Hien()
        {
            Console.WriteLine("||{0,-4}||   {1,-20}   || {2,-15}  || {3,-10}   ||  {4,-10}  || {5,-7}  || {6,-10} ||"
                , MaPN, NCC, diachi, sdt, NgayNhap.ToString("dd/MM/yyyy"), SoLuong, TongTien);
        }
        public string toStringPN()
        {
            return MaPN + "#" + NCC + "#" + diachi + "#" + sdt + "#" + NgayNhap.ToString("dd/MM/yyyy") + "#" + SoLuong + "#" + TongTien;
        }
    }
    class ChiTietPN
    {
        //Fields
        protected string sMaPN, sMaSP;
        protected int sSoLuong, sGiaNhap, sTongGia;

        //Properties
        public string MaPN
        {
            get { return this.sMaPN; }
            set { this.sMaPN = value; }
        }
        public string MaSP
        {
            get { return this.sMaSP; }
            set { this.sMaSP = value; }
        }
        public int SoLuong
        {
            get { return this.sSoLuong; }
            set { this.sSoLuong = value; }
        }
        public int GiaNhap
        {
            get { return this.sGiaNhap; }
            set { this.sGiaNhap = value; }
        }
        public int TongGia
        {
            get { return this.sTongGia; }
            set { this.sTongGia = value; }
        }

        //Constructors
        public ChiTietPN() { }

        public ChiTietPN(string maPN, string maSP, int soLuong, int giaNhap, int tongGia)
        {
            MaPN = maPN;
            MaSP = maSP;
            SoLuong = soLuong;
            GiaNhap = giaNhap;
            TongGia = tongGia;
        }

        //Method
        public void NhapCT()
        {
            Console.Write("\t\tMã sản phẩm : ");
            MaSP = Console.ReadLine();
            Console.Write("\t\tGiá nhập 1 sản phẩm: ");
            GiaNhap = int.Parse(Console.ReadLine());
            Console.Write("\t\tNhập số lượng sản phẩm nhập về: ");
            SoLuong = int.Parse(Console.ReadLine());
        }
        public void HienCT()
        {
            Console.WriteLine("||{0,-4}||   {1,-4}   || {2,-10}  || {3,-10} || {4,-10} ||"
                , MaPN, MaSP, SoLuong, GiaNhap, TongGia);
        }
        public string toStringCT()
        {
            return MaPN + "#" + MaSP + "#" + SoLuong + "#" + GiaNhap + "#" + TongGia;
        }
    }
    class DSPhieuNhap
    {
        List<PhieuNhap> ds = new List<PhieuNhap>();
        List<ChiTietPN> dss = new List<ChiTietPN>();
        PhieuNhap pn = new PhieuNhap();
        ChiTietPN ct = new ChiTietPN();
        public void DocTepPN()
        {
            StreamReader sr = File.OpenText("phieunhap.txt");//Được sử dụng để đọc các ký tự từ một tệp
            string s;
            try
            {
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length > 0)
                    {
                        string[] l = new string[7];
                        l = s.Split('#');
                        PhieuNhap pn = new PhieuNhap(l[0], l[1], l[2], l[3], DateTime.Parse(l[4]), int.Parse(l[5]), int.Parse(l[6]));
                        ds.Add(pn);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DocTepCT()
        {
            StreamReader sr = File.OpenText("chitietphieunhap.txt");
            string[] l;
            string s;
            try// try catch dùng để xử lý ngoại lệ
            {
                while ((s = sr.ReadLine()) != null)
                {
                    ChiTietPN ct = new ChiTietPN();
                    l = s.Split('#');
                    ct.MaPN = l[0];
                    ct.MaSP = l[1];
                    ct.SoLuong = int.Parse(l[2]);
                    ct.GiaNhap = int.Parse(l[3]);
                    ct.TongGia = int.Parse(l[4]);
                    dss.Add(ct);
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GhiTepPN()
        {
            StreamWriter sw1 = new StreamWriter("phieunhap.txt");//Được sử dụng để ghi các ký tự tới một tệp
            foreach (PhieuNhap x in ds)
            {
                sw1.WriteLine(x.toStringPN());
            }
            sw1.Close();
        }
        public void GhiTepCT()
        {
            StreamWriter sw2 = new StreamWriter("chitietphieunhap.txt");
            foreach (ChiTietPN x in dss)
            {
                sw2.WriteLine(x.toStringCT());
            }
            sw2.Close();
        }
        // CHỨC NĂNG HIỆN THỊ DS PHIẾU NHẬP
        public void Hien()
        {
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine("\n\t\t\t******************************THÔNG TIN HÓA ĐƠN NHẬP HÀNG THỨ {0}*******************************************", i + 1);
                Console.WriteLine("\t\t\tMã Hóa Đơn Nhập : {0,-5}                                              Ngày Nhập: {1,10}", ds[i].MaPN, ds[i].NgayNhap.ToString("dd/MM/yyyy"));
                Console.WriteLine("\t\t\tTên Nhà Cung Cấp: {0,-30}", ds[i].NCC);
                Console.WriteLine("\t\t\tĐịa Chỉ: {0,-50}          SĐT: {1,11}", ds[i].diachi, ds[i].sdt);
                Console.WriteLine("\n\t\t\t  _______________________________________________________________________________________________________ ");
                Console.WriteLine("\t\t\t | Mã SP |                      TÊN SẢN PHẨM                       | SỐ LƯỢNG |  GIÁ NHẬP  | THÀNH TIỀN  |");
                Console.WriteLine("\t\t\t ---------------------------------------------------------------------------------------------------------");
                StreamReader sr = new StreamReader("chitietphieunhap.txt");
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    PhieuNhap pn = new PhieuNhap();
                    DSSanPham dssp = new DSSanPham();
                    string[] a = s.Split('#');
                    if (a[0] == ds[i].MaPN)
                        Console.WriteLine("\t\t\t | {0,-5} |   {1,-51}   | {2,-7}  | {3,-10} | {4,-11} |"
                    , a[1], dssp.LayTenSanPham(a[1]), int.Parse(a[2]), float.Parse(a[3]), int.Parse(a[4]));
                }
                sr.Close();
                Console.WriteLine("\t\t\t |_______________________________________________________________________________________________________|");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t Tổng Số  :                                                           {0,-7}", ds[i].SoLuong);
                Console.WriteLine("\t\t\t Tổng Tiền:                                                                                  {0,-11}", ds[i].TongTien);
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public void HienChiTiet(string Ma)
        {
            StreamReader l = new StreamReader("phieunhap.txt");
            string s1;
            while ((s1 = l.ReadLine()) != null)
            {
                string[] x = s1.Split('#');
                if (x[0] == Ma)
                {
                    Console.WriteLine("\t\t Mã Hóa Đơn Nhập : {0,-5}                                              Ngày Nhập: {1,10}", x[0], DateTime.Parse(x[4]).ToString("dd/MM/yyyy"));
                    Console.WriteLine("\t\t Tên Nhà Cung Cấp: {0}", x[1]);
                    Console.WriteLine("\t\t Địa Chỉ: {0,-50}          SĐT: {1,11}", x[2], x[3]);
                    Console.WriteLine("\t\t  _______________________________________________________________________________________________________ ");
                    Console.WriteLine("\t\t | Mã SP |                      TÊN SẢN PHẨM                       | SỐ LƯỢNG |  GIÁ NHẬP  | THÀNH TIỀN  |");
                    Console.WriteLine("\t\t ---------------------------------------------------------------------------------------------------------");
                    StreamReader sr = new StreamReader("chitietphieunhap.txt");
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {

                        DSSanPham dssp = new DSSanPham();
                        string[] a = s.Split('#');
                        if (a[0] == Ma)
                            Console.WriteLine("\t\t | {0,-5} |   {1,-51}   | {2,-7}  | {3,-10} | {4,-11} |"
                     , a[1], dssp.LayTenSanPham(a[1]), int.Parse(a[2]), float.Parse(a[3]), int.Parse(a[4]));
                    }
                    sr.Close();
                    Console.WriteLine("\t\t |_______________________________________________________________________________________________________|");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t Tổng Số  :                                                           {0,-7}", int.Parse(x[5]));
                    Console.WriteLine("\t\t Tổng Tiền:                                                                                  {0,-11}", float.Parse(x[6]));
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            l.Close();

        }
        //CHỨC NĂNG TÌM KIẾM PHIẾU NHẬP
        public void TKMa()
        {
            bool ok = false;
            Console.Write("\n\t\tNhập mã phiếu nhập cần tìm kiếm: ");
            string a = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {

                if (ds[i].MaPN.Equals(a)) // IndexOf tìm vị trí hiện thị của chuỗi
                {
                    ok = true;
                    Console.WriteLine("\n\t\t_____________________________________PHIẾU NHẬP THỨ {0} TRONG DANH SÁCH______________________________________", i + 1);
                    HienChiTiet(a);
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tKhông tìm thấy mã hóa đơn {0} ", a);
        }
        public void TKTen()
        {
            int j = 0;//khai báo biến kiểu nguyên có tên là j và khởi tạo giá trị là 0.
            Console.Write("\n\t\tNhập tên nhà cung cấp cần tìm kiếm: ");
            string b = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].NCC.StartsWith(b))
                {
                    j = 1;
                    Console.WriteLine("\n\t\t_____________________________________PHIẾU NHẬP THỨ {0} TRONG DANH SÁCH______________________________________", i + 1);
                    HienChiTiet(ds[i].MaPN);
                }
            }
            if (j == 0)
                Console.WriteLine("\n\t\tKhông tìm thấy tên nhà cung cấp {0} ", b);
        }
        public void TKNgay()
        {
            int j = 0;
            Console.Write("\n\t\tNhập ngày cần tìm kiếm(dd/MM/yyyy): ");
            DateTime ngay = DateTime.Parse(Console.ReadLine());
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].NgayNhap == ngay)
                {
                    j = 1;
                    Console.WriteLine("\n\t\t_____________________________________PHIẾU NHẬP THỨ {0} TRONG DANH SÁCH______________________________________", i + 1);
                    HienChiTiet(ds[i].MaPN);
                }
            }
            if (j == 0)
                Console.WriteLine("\n\t  Không tìm thấy ngày nhập " + ngay);
        }
        // CHỨC NĂNG XÓA PHIẾU NHẬP
        public void Xoa()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã phiếu nhập cần xóa: ");
            string ma = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaPN.Equals(ma))
                {
                    ok = true;//tim thay
                    ds.RemoveAt(i);//RemoveAt Xoa tai vi tri
                    GhiTepPN();
                    break;//thoat
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tKhông tồn tại phiếu nhập có mã " + ma);
            else
            {
                StreamWriter sw = new StreamWriter("chitietphieunhap.txt");
                for (int j = 0; j < dss.Count; j++)
                {
                    if (ma != dss[j].MaPN)
                        sw.WriteLine(dss[j].MaPN + "#" + dss[j].MaSP + "#" + dss[j].SoLuong + "#" + dss[j].GiaNhap + "#" + dss[j].TongGia);
                }
                sw.Close();
                Console.WriteLine("\n\t\tĐÃ XÓA PHIẾU NHẬP CÓ MÃ " + ma);
            }
        }
        // CHỨC NĂNG THÊM PHIẾU NHẬP 
        public void SuaSL()
        {
            ct.MaPN = pn.MaPN;
            ct.NhapCT();
            ct.TongGia = ct.SoLuong * ct.GiaNhap;
            dss.Add(ct);
            DSSanPham dssp = new DSSanPham();
            List<SanPham> sp = new List<SanPham>();
            dssp.DocTep();
            dssp.SuaPN(ct.MaSP, ct.SoLuong);
            dssp.GhiTep();
        }
        public void Them1PN()
        {
            PhieuNhap t = new PhieuNhap();
            bool ok = false;
            Console.Write("\n\t\tNhập mã phiếu nhập   : ");
            t.MaPN = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaPN.Equals(t.MaPN))
                {
                    ok = true;
                    Console.WriteLine("\n\t  Mã phiếu nhập đã tồn tại. Vui lòng nhập lại!");
                }
            }
            if (!ok)
            {
                t.Nhap();
                Console.Write("\t\tNhập số lượng sản phẩm nhập về: ");
                int n = int.Parse(Console.ReadLine());
                int[] x = new int[n];
                int[] y = new int[n];
                StreamWriter sw = File.AppendText("chitietphieunhap.txt");//Mở một tệp đang tồn tại và ghi phần nội dung vào cuối file.
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\n\t\t NHẬP THÔNG TIN SẢN PHẨM THỨ {0}!", i + 1);
                    SuaSL();
                    sw.WriteLine(ct.MaPN + "#" + ct.MaSP + "#" + ct.SoLuong + "#" + ct.GiaNhap + "#" + ct.TongGia);
                    y[i] = ct.SoLuong;
                    x[i] = ct.TongGia;
                    Console.WriteLine("\t\tThành tiền: " + x[i]);
                }
                sw.Close();
                for (int i = 0; i < n; i++)
                {
                    t.TongTien += x[i];

                    t.SoLuong += y[i];

                }
                Console.WriteLine("\t\tTổng số   : " + t.SoLuong);
                Console.WriteLine("\t\tTổng tiền : " + t.TongTien);
                ds.Add(t);
            }
        }
        public void Them()
        {

            Console.Write("\t\tNhập số lượng phiếu nhập cần thêm: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n\t\t* Nhập thông tin phiếu nhập thứ {0} *", i + 1);
                Them1PN();
                GhiTepPN();
            }
            Console.WriteLine("\t\tĐÃ THÊM PHIẾU NHẬP HÀNG");
        }
        public void MenuPhieuNhap()
        {
            DocTepPN();
            DocTepCT();
            while (true)
            {

                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*-----------------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*                           QUẢN LÝ DANH SÁCH HÓA ĐƠN NHẬP                          *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*                                                                                   *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*  1. Hiện Thị Danh Sách Hóa Đơn Nhập    |   5. Tìm Kiếm Hóa Đơn Nhập Theo Mã       *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*  2. Thêm Hóa Đơn Nhập Hàng             |   6. Tìm Kiếm Hóa Đơn Nhập Theo Tên NCC  *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*  3. Xóa Hóa Đơn Nhập Hàng              |   7. Quay Lại                            *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*  4. Tìm Kiếm Hóa Đơn Theo Ngày         |   8. Thoát Khỏi Chương Trình             *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*                                                                                   *");
                Console.SetCursorPosition(20, 13); Console.WriteLine("*-----------------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 14); Console.Write("  Mời bạn chọ công việc(1->8): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        Hien(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        DSSanPham sp = new DSSanPham();
                        sp.DocTep();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------THÊM PHIẾU HÓA ĐƠN NHẬP---------------*");
                        Them();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------XÓA THÔNG TIN HÓA ĐƠN NHẬP----------------*");
                        do
                        {
                            Console.WriteLine();
                            Xoa();
                            Console.Write("\n\t\tBạn có muốn xóa phiếu nhập khác không (C/K)? ");
                        } while (Console.ReadLine() == "c" || Console.ReadLine() == "C");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*---------------TÌM KIẾM PHIẾU NHẬP THEO NGÀY----------------*");
                        TKNgay();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*---------------TÌM KIẾM PHIẾU NHẬP THEO MÃ----------------*");
                        TKMa();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*---------------TÌM KIẾM PHIẾU NHẬP THEO TÊN NCC----------------*");
                        TKTen();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        MenuQL a = new MenuQL();
                        a.MenuChinh();
                        break;
                    case 8: Environment.Exit(0); break;
                }
            }
        }
    }
}
