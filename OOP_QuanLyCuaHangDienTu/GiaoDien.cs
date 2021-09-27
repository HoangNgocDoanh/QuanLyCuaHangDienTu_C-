using OOP_QuanLyCuaHangDienTu.Code_NhanVien;
using OOP_QuanLyCuaHangDienTu.Code_SanPham;
using OOP_QuanLyCuaHangDienTu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_QuanLyCuaHangDienTu
{
    public class GiaoDien
    {
        List<Interface_SanPham> danhsach = new List<Interface_SanPham>();
        List<Interface_NVQuanLy> lQL = new List<Interface_NVQuanLy>();
        List<Interface_NVThuNgan> lTG = new List<Interface_NVThuNgan>();
        List<Interface_NVBaoVe> lBV = new List<Interface_NVBaoVe>();
        //Nhân Viên
        public void DocTepNV()
        {
            try
            {
                StreamReader sr = File.OpenText("nhanvien.txt");//Mở một tệp đang tồn tại
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length > 0)
                    {
                        string[] l = new string[7];
                        l = s.Split('#');
                        int check;
                        Interface_NVQuanLy ql = new NVQuanLy();
                        Interface_NVThuNgan tg = new NVThuNgan();
                        Interface_NVBaoVe bv = new NVBaoVe();
                        if (l[3] == "Quản Lý")
                        {
                            ql = new NVQuanLy(l[0], l[1], l[2], l[3], int.Parse(l[4]), int.Parse(l[5]), int.Parse(l[6]));
                            check = 1;
                        }
                        else if (l[3] == "Thu Ngân")
                        {
                            tg = new NVThuNgan(l[0], l[1], l[2], l[3], int.Parse(l[4]), int.Parse(l[5]), int.Parse(l[6]));
                            check = 2;
                        }
                        else
                        {
                            bv = new NVBaoVe(l[0], l[1], l[2], l[3], int.Parse(l[4]), int.Parse(l[5]), int.Parse(l[6]));
                            check = 3;
                        }
                        if (check == 1)
                        {
                            int kt = 0;
                            foreach (Interface_NVQuanLy x in lQL) if (x.MaNV == ql.MaNV) kt = 1;
                            if (kt == 0) lQL.Add(ql);
                        }
                        else if (check == 2)
                        {
                            int kt = 0;
                            foreach (Interface_NVThuNgan x in lTG) if (x.MaNV == tg.MaNV) kt = 1;
                            if (kt == 0) lTG.Add(tg);
                        }
                        else
                        {
                            int kt = 0;
                            foreach (Interface_NVBaoVe x in lBV) if (x.MaNV == bv.MaNV) kt = 1;
                            if (kt == 0) lBV.Add(bv);
                        }
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GhiTepNV()
        {
            StreamWriter sw = new StreamWriter("nhanvien.txt");
            foreach (Interface_NVQuanLy x in lQL)
            {
                sw.WriteLine(x.toString());
            }
            foreach (Interface_NVThuNgan y in lTG)
            {
                sw.WriteLine(y.toString());
            }
            foreach (Interface_NVBaoVe z in lBV)
            {
                sw.WriteLine(z.toString());
            }
            sw.Close();
        }
        public void TKMaNV(string ma)
        {
            bool ok = false;
            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG===========================================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].MaNV.Equals(ma))
                {
                    ok = true;
                    lQL[i].Hien();
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].MaNV.Equals(ma))
                {
                    ok = true;
                    lTG[i].Hien();
                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].MaNV.Equals(ma))
                {
                    ok = true;
                    lBV[i].Hien();
                }
            }
            Console.WriteLine("\t=============================================================================================================================================================");
            if (!ok)
                Console.WriteLine("Mã Sản Phẩm Không Tồn Tại");
        }
        public void TKCvuNV(string cv)
        {
            bool ok = false;
            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG===========================================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].Chucvu.Equals(cv))
                {
                    ok = true;
                    lQL[i].Hien();
                    
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].Chucvu.Equals(cv))
                {
                    ok = true;
                    lQL[i].Hien();

                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].Chucvu.Equals(cv))
                {
                    ok = true;
                    lQL[i].Hien();

                }
            }
            Console.WriteLine("\t=============================================================================================================================================================");
            if (!ok)
                Console.WriteLine("Chức Vụ Không Tồn Tại");
        }
        public void TKTenNV(string ten)
        {
            bool ok = false;
            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG===========================================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].TenNV.Equals(ten))
                {
                    ok = true;
                    lQL[i].Hien();
                    
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].TenNV.Equals(ten))
                {
                    ok = true;
                    lQL[i].Hien();

                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].TenNV.Equals(ten))
                {
                    ok = true;
                    lBV[i].Hien();

                }
            }
            Console.WriteLine("\t=============================================================================================================================================================");
            if (!ok)
                Console.WriteLine("Tên Nhân Viên Không Tồn Tại");
        }
        public void suatenNV()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã nhân viên cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập tên mới : ");
            string b = Console.ReadLine();
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].MaNV.Equals(a))
                {
                    ok = true;
                    lQL[i].TenNV = b;
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].MaNV.Equals(a))
                {
                    ok = true;
                    lTG[i].TenNV = b;
                }
            }
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lTG[i].MaNV.Equals(a))
                {
                    ok = true;
                    lQL[i].TenNV = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã nhân viên không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t Tên nhân viên đã sửa thành công !\n");
                TKMaNV(a);
            }
        }
        public void suaqueNV()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã nhân viên cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập quê quán mới : ");
            string b = Console.ReadLine();
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].MaNV.Equals(a))
                {
                    ok = true;
                    lQL[i].Quequan = b;
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].MaNV.Equals(a))
                {
                    ok = true;
                    lTG[i].Quequan = b;
                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].MaNV.Equals(a))
                {
                    ok = true;
                    lBV[i].Quequan = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã nhân viên không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t Quê quán nhân viên đã sửa thành công !\n");
                TKMaNV(a);
            }
        }
        public void suanamsinhNV()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã nhân viên cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập năm sinh mới : ");
            int b = int.Parse(Console.ReadLine());
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].MaNV.Equals(a))
                {
                    ok = true;
                    lQL[i].Namsinh = b;
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].MaNV.Equals(a))
                {
                    ok = true;
                    lTG[i].Namsinh = b;
                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].MaNV.Equals(a))
                {
                    ok = true;
                    lBV[i].Namsinh = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã nhân viên không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t Năm sinh nhân viên đã sửa thành công !\n");
                TKMaNV(a);
            }
        }
        public void suacvNV()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã nhân viên cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập chức vụ mới : ");
            string b = Console.ReadLine();
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].MaNV.Equals(a))
                {
                    ok = true;
                    lQL[i].Chucvu = b;
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].MaNV.Equals(a))
                {
                    ok = true;
                    lTG[i].Chucvu = b;
                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].MaNV.Equals(a))
                {
                    ok = true;
                    lBV[i].Chucvu = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã nhân viên không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t Chức vụ nhân viên đã sửa thành công !\n");
                TKMaNV(a);
            }
        }
        public void SuaNV()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine(" _______________________________________________ ");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|         CÁC HÌNH THỨC SỬA NHÂN VIÊN           |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|-----------------------------------------------|");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|            1. Sửa Tên Nhân Viên               |");
                Console.SetCursorPosition(20, 9); Console.WriteLine("|            2. Sửa Quê Quán Nhân Viên          |");
                Console.SetCursorPosition(20, 10); Console.WriteLine("|            3. Sửa Năm Sinh Nhân Viên          |");
                Console.SetCursorPosition(20, 11); Console.WriteLine("|            4. Sửa Chức Vụ Nhân Viên           |");
                Console.SetCursorPosition(20, 12); Console.WriteLine("|            5. Quay Lại                        |");
                Console.SetCursorPosition(20, 13); Console.WriteLine("|_______________________________________________|");
                Console.SetCursorPosition(20, 15); Console.Write(" Nhập công việc bạn muốn thực hiện(1->5) : ");
                int chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        Console.Clear();
                        char temp;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-------------SỬA TÊN NHÂN VIÊN--------------*");
                        do
                        {
                            Console.WriteLine();
                            suatenNV();
                            GhiTepNV();
                            Console.Write("\n\t\tBạn có muốn sửa tên nhân viên khác không (C/K)? ");
                            temp = char.Parse(Console.ReadLine());
                        } while (temp == 'c' || temp == 'C');
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        char b;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-------------SỬA QUÊ QUÁN NHÂN VIÊN------------*");
                        do
                        {
                            Console.WriteLine();
                            suaqueNV();
                            GhiTepNV();
                            Console.Write("\n\t\tBạn có muốn sửa quê quán nhân viên khác không (C/K)? ");
                            b = char.Parse(Console.ReadLine());
                        } while (b == 'c' || b == 'C');
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        char c;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------SỬA NĂM SINH NHÂN VIÊN---------------*");
                        do
                        {
                            Console.WriteLine();
                            suanamsinhNV();
                            GhiTepNV();
                            Console.Write("\n\t\tBạn có muốn sửa năm sinh nhân viên khác không (C/K)? ");
                            c = char.Parse(Console.ReadLine());
                        } while (c == 'c' || c == 'C');
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        char d;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------SỬA CHỨC VỤ NHÂN VIÊN-------------*");
                        do
                        {
                            Console.WriteLine();
                            suacvNV();
                            GhiTepNV();
                            Console.Write("\n\t\tBạn có muốn sửa chức vụ nhân viên khác không (C/K)? ");
                            d = char.Parse(Console.ReadLine());
                        } while (d == 'c' || d == 'C');
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        MenuNV(); ; break;
                }
            }
        }
        public void xoaNV()
        {
            bool ok = false;
            Console.Write("\t\t\tNhập mã nhân viên cần xóa: ");
            string ma = Console.ReadLine();
            for (int i = 0; i < lQL.Count; i++)
            {
                if (lQL[i].MaNV.Equals(ma))
                {
                    ok = true;//tim thay
                    lQL.RemoveAt(i);//RemoveAt Xoa tai vi tri i 
                    Console.WriteLine("\n\t\t    NHÂN VIÊN {0} ĐÃ XÓA KHỎI DANH SÁCH ", ma);
                    break;//thoat
                }
            }
            for (int i = 0; i < lTG.Count; i++)
            {
                if (lTG[i].MaNV.Equals(ma))
                {
                    ok = true;//tim thay
                    lTG.RemoveAt(i);//RemoveAt Xoa tai vi tri i 
                    Console.WriteLine("\n\t\t    NHÂN VIÊN {0} ĐÃ XÓA KHỎI DANH SÁCH ", ma);
                    break;//thoat
                }
            }
            for (int i = 0; i < lBV.Count; i++)
            {
                if (lBV[i].MaNV.Equals(ma))
                {
                    ok = true;//tim thay
                    lBV.RemoveAt(i);//RemoveAt Xoa tai vi tri i 
                    Console.WriteLine("\n\t\t    NHÂN VIÊN {0} ĐÃ XÓA KHỎI DANH SÁCH ", ma);
                    break;//thoat
                }
            }
            if (!ok)
                Console.WriteLine("Không tồn tại mã " + ma);
        }
        public void Them1NV()
        {
            Interface_NVQuanLy ql = new NVQuanLy();
            Interface_NVThuNgan tg = new NVThuNgan();
            Interface_NVBaoVe bv = new NVBaoVe();
            Console.Write("\t\t Chọn chức vụ nhân viên(Quản lý/Thu ngân/Bảo vệ)(1->3): ");
            int a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                ql.Chucvu = "Quản Lý";
            }
            else if (a == 2)
            {
                tg.Chucvu = "Thu Ngân";
            }
            else
            {
                bv.Chucvu = "Bảo Vệ";
            }
            bool ok = false;
            Console.Write("\t\t Nhập mã nhân viên: ");
            if (a == 1)
            {
                ql.MaNV = Console.ReadLine();
                for (int i = 0; i < lQL.Count; i++)
                {
                    if (lQL[i].MaNV.Equals(ql.MaNV))//So sánh 2 chuỗi có giống nhau hay không
                    {
                        ok = true;
                        Console.WriteLine("\n\t\tĐã tồn tại mã nhân viên trong danh sách. Vui lòng nhập lại!");
                    }
                }
            }
            else if (a == 2)
            {
                tg.MaNV = Console.ReadLine();
                for (int i = 0; i < lTG.Count; i++)
                {
                    if (lTG[i].MaNV.Equals(tg.MaNV))//So sánh 2 chuỗi có giống nhau hay không
                    {
                        ok = true;
                        Console.WriteLine("\n\t\tĐã tồn tại mã nhân viên trong danh sách. Vui lòng nhập lại!");
                    }
                }
            }
            else
            {
                bv.MaNV = Console.ReadLine();
                for (int i = 0; i < lBV.Count; i++)
                {
                    if (lBV[i].MaNV.Equals(bv.MaNV))//So sánh 2 chuỗi có giống nhau hay không
                    {
                        ok = true;
                        Console.WriteLine("\n\t\tĐã tồn tại mã nhân viên trong danh sách. Vui lòng nhập lại!");
                    }
                }
            }
            if (!ok)//Chưa tồn tại mã nếu biến Ok khác true thì sẽ thực hiện các lệnh 
            {
                if (a == 1)
                {
                    ql.Nhap();
                    lQL.Add(ql);
                }
                else if (a == 2)
                {
                    tg.Nhap();
                    lTG.Add(tg);
                }
                else
                {
                    bv.Nhap();
                    lBV.Add(bv);
                }
                Console.WriteLine("\t\tNHÂN VIÊN ÐÃ ÐƯỢC THÊM VÀO TRONG DANH SÁCH !");
            }
        }
        public void ThemNV()
        {
            Console.Write("\t\tNhập số lượng nhân viên cần thêm: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n\t\tNhập thông tin nhân viên thứ {0} ", i + 1);
                Them1NV();
                GhiTepNV();
            }
        }
        public void HienThiNV()
        {
            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG==============================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t---------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Interface_NVQuanLy x in lQL)
            {
                x.Hien();
            }
            foreach (Interface_NVThuNgan x in lTG)
            {
                x.Hien();
            }
            foreach (Interface_NVBaoVe x in lBV)
            {
                x.Hien();
            }
            Console.WriteLine("\t===================================================================================================================================================");
        }
        public void Quanly()
        {

            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG===========================================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Interface_NVQuanLy x in lQL)
            {
                x.Hien();
            }
            Console.WriteLine("\t==============================================================================================================================================================");
        }
        public void BaoVe()
        {

            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG===========================================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Interface_NVBaoVe x in lBV)
            {
                x.Hien();
            }
            Console.WriteLine("\t==============================================================================================================================================================");
        }
        public void ThuNgan()
        {

            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN NHÂN VIÊN CỦA CỬA HÀNG===========================================================================");
            Console.WriteLine("\t||          Tên Nhân Viên          ||   Mã   ||   Quê Quán  ||   Chức Vụ   ||    Năm Sinh   || Số ngày công (Ngày) ||  Lương Chính Thức (VNĐ) ||");
            Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Interface_NVThuNgan x in lTG)
            {
                x.Hien();
            }
            Console.WriteLine("\t=============================================================================================================================================================");
        }
        public string MaxLuong()
        {
            DocTepNV();
            NVQuanLy maxql = new NVQuanLy("", "", "", "", 0, 0, 0);
            NVThuNgan maxtg = new NVThuNgan("", "", "", "", 0, 0, 0);
            NVBaoVe maxbv = new NVBaoVe("", "", "", "", 0, 0, 0);
            string maxma = "";
            int maxmon = 0;
            foreach (NVQuanLy a in lQL)
            {
                if (a > maxql)
                {
                    maxql = a;
                    maxmon = a.LuongChinhThuc;
                    maxma = a.MaNV;
                }
            }
            foreach (NVThuNgan b in lTG)
            {
                if (b > maxtg)
                {
                    maxtg = b;
                    if (maxtg.LuongChinhThuc > maxmon)
                    {
                        maxmon = maxtg.LuongChinhThuc;
                        maxma = maxtg.MaNV;
                    }
                }
            }
            foreach (NVBaoVe c in lBV)
            {
                if (c > maxbv)
                {
                    maxbv = c;
                    if (maxbv.LuongChinhThuc > maxmon)
                    {
                        maxmon = maxbv.LuongChinhThuc;
                        maxma = maxbv.MaNV;
                    }
                }
            }
            return maxma;
        }
        //MENU
        public void MenuChinh()
        {

            Console.SetCursorPosition(20, 5); Console.WriteLine(" =============================================================================");
            Console.SetCursorPosition(20, 6); Console.WriteLine(" ||               =======>  QUẢN LÝ CỬA HÀNG ĐIỆN TỬ  <=======               ||");
            Console.SetCursorPosition(20, 7); Console.WriteLine(" ||                                                                          ||");
            Console.SetCursorPosition(20, 8); Console.WriteLine(" ||   1. Quản Lý Sản Phẩm            ||       4. Thông Tin Cửa Hàng          ||");
            Console.SetCursorPosition(20, 9); Console.WriteLine(" ||                                  ||                                      ||");
            Console.SetCursorPosition(20, 10); Console.WriteLine(" ||   2. Quản Lý Cửa Hàng            ||       5. Thống Kê Sản Phẩm           ||");
            Console.SetCursorPosition(20, 11); Console.WriteLine(" ||                                  ||                                      ||");
            Console.SetCursorPosition(20, 12); Console.WriteLine(" ||   3. Tìm Kiếm Thông Tin          ||       6. Thoát Khỏi Chương Trình     ||");
            Console.SetCursorPosition(20, 13); Console.WriteLine(" ||                                                                          ||");
            Console.SetCursorPosition(20, 14); Console.WriteLine(" =============================================================================");
            Console.SetCursorPosition(20, 16); Console.Write(" Mời Bạn Chọn Công Việc (1-6): ");
            int t = int.Parse(Console.ReadLine());
            Console.Clear();
            do
            {
                switch (t)
                {
                    case 1:
                        MenuSP();
                        Console.ReadKey();
                        break;
                    case 2:
                        MenuNV();
                        Console.ReadKey();
                        break;
                    case 3:
                        MenuTK();
                        Console.ReadKey();
                        break;
                    case 4:
                        ThongTinCuaHang();
                        Console.ReadKey();
                        break;
                    case 5:
                        ThongKeSP();
                        Console.ReadKey();
                        break;
                    case 6: Environment.Exit(0); break;
                }
            } while (true);
        }
        public static void ThongTinCuaHang()
        {
            Console.WriteLine("                         ********************************************************");
            Console.WriteLine("                         *                 CỬA HÀNG ĐIỆN TỬ UTE                 *");
            Console.WriteLine("                         * Số 1 Võ Văn Ngân - Phường Bình Thọ, Thủ Đức - TPHCM  *");
            Console.WriteLine("                         *......................................................*");
            Console.WriteLine("                         *   Liên hệ chúng tôi:                                 *");
            Console.WriteLine("                         *                     -SĐT  : 0946 669 966-0123 169 96 *");
            Console.WriteLine("                         *                     -Email: dientuute@gmail.com      *");
            Console.WriteLine("                         ********************************************************");
            Console.WriteLine("             \n");
            Console.WriteLine("             \n");
            Console.ReadKey();
            Console.WriteLine("Press enter to return main menu..");
            ConsoleKeyInfo pr = new ConsoleKeyInfo();
            pr = Console.ReadKey();
            if (pr.Key==ConsoleKey.Enter)
            {
                Console.Clear();
                GiaoDien a = new GiaoDien();
                a.MenuChinh();
            }
        }
        public void TaiKhoan()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            // Console.Clear();
            string tk;
            string mk;
            int d = 0;
            ConsoleKeyInfo[] pas;
            do
            {
                pas = new ConsoleKeyInfo[20];
                tk = mk = "";
                Console.Clear();
                Console.WriteLine("                         ********************************************************");
                Console.WriteLine("                         *                       ĐỒ ÁN                          *");
                Console.WriteLine("                         *               Quản lý bán hàng điện tử               *");
                Console.WriteLine("                         *......................................................*");
                Console.WriteLine("                         *                                                      *");
                Console.WriteLine("                         *   Giáo Viên Hướng Dẫn: TS: Lê Văn Vinh               *");
                Console.WriteLine("                         *      Sinh Viên Thực Hiện  : Lê Nguyễn Thanh Nhân     *");
                Console.WriteLine("                         *                             Hoàng Ngọc Doanh         *");
                Console.WriteLine("                         ********************************************************");
                Console.WriteLine("             \n");
                Console.SetCursorPosition(30, 11); Console.Write(" _________________________________________");
                Console.SetCursorPosition(30, 12); Console.Write("|                 ĐĂNG NHẬP               |");
                Console.SetCursorPosition(30, 13); Console.Write("|-----------------------------------------|");
                Console.SetCursorPosition(30, 14); Console.Write("|                                         |");
                Console.SetCursorPosition(30, 15); Console.Write("|  Tài Khoản:");
                Console.SetCursorPosition(67, 15); Console.Write("|");
                Console.SetCursorPosition(30, 15); Console.Write("|");
                Console.SetCursorPosition(30, 16); Console.Write("|");
                Console.SetCursorPosition(43, 14); Console.Write(" ____________________");
                Console.SetCursorPosition(43, 15); Console.Write("|                    |       |");
                Console.SetCursorPosition(43, 16); Console.Write("|____________________|       |");
                Console.SetCursorPosition(30, 17); Console.Write("|                                         |");
                Console.SetCursorPosition(30, 18); Console.Write("|                                         |");
                Console.SetCursorPosition(30, 19); Console.Write("|  Mật Khẩu:");
                Console.SetCursorPosition(67, 19); Console.Write("|");
                Console.SetCursorPosition(30, 18); Console.Write("|");
                Console.SetCursorPosition(30, 19); Console.Write("|");
                Console.SetCursorPosition(30, 20); Console.Write("|");
                Console.SetCursorPosition(43, 18); Console.Write(" ____________________");
                Console.SetCursorPosition(43, 19); Console.Write("|                    |       |");
                Console.SetCursorPosition(43, 20); Console.Write("|____________________|       |");
                Console.SetCursorPosition(30, 21); Console.Write("|                                         |");
                Console.SetCursorPosition(30, 22); Console.Write("|_________________________________________|");
                Console.SetCursorPosition(44, 15); tk = Console.ReadLine();
                Console.SetCursorPosition(44, 20);
                int i = 0, j = 44;
                do
                {
                    Console.SetCursorPosition(j, 19);//Đặt giao diện vị trí con trỏ (trái sang, trên)
                    pas[i] = Console.ReadKey();

                    if (pas[i].Key != ConsoleKey.Backspace)//Kiểm tra có phải là phím Backspace hay không
                    {
                        Console.SetCursorPosition(j, 19);
                        Console.Write("*");
                        mk = mk + pas[i].KeyChar.ToString();
                        j++;
                        i++;
                    }
                    else
                    {
                        if (i != 0)
                        {
                            j--;
                            Console.SetCursorPosition(j, 19);
                            Console.Write(" ");
                            mk = mk.Remove(mk.Length - 1, 1);
                            Console.SetCursorPosition(j, 19);
                        }
                    }

                }
                while (pas[i - 1].Key != ConsoleKey.Enter);//Kiểm tra có phải là phím Enter hay không
                Console.WriteLine("\n");
                mk = mk.Remove(mk.Length - 1, 1);
                if (tk != "admin" || mk != "admin")
                {
                    Console.SetCursorPosition(24, 25);
                    Console.WriteLine("Tên tài khoản hoặc mật khẩu đăng nhập không chính xác! Vui lòng nhập lại.");
                    d = d + 1;
                    Console.SetCursorPosition(26, 27);
                    Console.Write("Bạn Có Muốn Đăng Nhập Lại Không?(C/K)");
                    string kt = Console.ReadLine();
                    if (kt == "c" || kt == "C")
                    {
                        Console.Clear();
                    }
                    else
                        Environment.Exit(0);// Thoát khỏi chương trình
                }

            } while ((tk != "admin" || mk != "admin") && (d != 3));
            if (d == 3)
            {
                Console.SetCursorPosition(25, 15);
                Console.Write("*** BẠN ĐÃ ĐĂNG NHẬP QUÁ BA LẦN VUI LÒNG QUAY LẠI SAU !***");
            }
            else
            {
                if (tk == "admin" && mk == "admin")
                {
                    Console.Clear();
                    MenuChinh();
                }
            }
        }
        public void MenuSP()
        {
            DocTepSP();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*                        QUẢN LÝ DANH SÁCH SẢN PHẨM                      *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*                                                                        *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*  1. Hiện Thị Danh Sách Sản Phẩm   |  5. Tìm Kiếm Sản Phẩm Theo Mã      *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*  2. Thêm Sản Phẩm                 |  6. Tìm Kiếm Sản Phẩm Theo Tên     *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*  3. Sửa Thông Tin Sản Phẩm        |  7. Quay Lại                       *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*  4. Xóa Thông Tin Sản Phẩm        |  8. Thoát Khỏi Chương Trình        *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*                                                                        *");
                Console.SetCursorPosition(20, 13); Console.WriteLine("*------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 15); Console.Write(" Mời Bạn Chọn Công Việc (1->8): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        HienThiSP();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*--------------THÊM THÔNG TIN SẢN PHẨM--------------*");
                        ThemSP();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        SuaSP(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------XÓA THÔNG TIN SẢN PHẨM----------------*");
                        do
                        {
                            Console.WriteLine();
                            XoaSP();
                            GhiTepSP();
                            Console.Write("\n\t\t  Bạn có muốn xóa sản phẩm khác không (C/K)? ");
                        } while (Console.ReadLine() == "c" || Console.ReadLine() == "C");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO MÃ-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("Nhập mã sản phẩm cần tìm kiếm: ");
                        string ma = Console.ReadLine();
                        TKMaSP(ma); Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO TÊN SP-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("\n\t\tNhập tên sản phẩm cần tìm kiếm: ");
                        string b = Console.ReadLine();
                        TKTenSP(b); Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        MenuChinh();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void MenuNV()
        {
            DocTepNV();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*                        QUẢN LÝ NHÂN SỰ CỬA HÀNG                        *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*                                                                        *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*  1. Hiện Thị Danh Sách Nhân Viên  |  4. Xóa Thông Tin Nhân Viên        *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*  2. Thêm Nhân Viên                |  5. Quay lại Menu Chính            *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*  3. Sửa Thông Tin Nhân Viên       |  6. Escape                         *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*                                                                        *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 14); Console.Write(" Mời Bạn Chọn Công Việc (1->6): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        HienThiNV();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*--------------THÊM THÔNG TIN SẢN PHẨM--------------*");
                        ThemNV();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        SuaNV(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------XÓA THÔNG TIN SẢN PHẨM----------------*");
                        do
                        {
                            Console.WriteLine();
                            xoaNV();
                            GhiTepNV();
                            Console.Write("\n\t\t  Bạn có muốn xóa sản phẩm khác không (C/K)? ");
                        } while (Console.ReadLine() == "c" || Console.ReadLine() == "C");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        MenuChinh();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void TKSanPham()
        {
            DocTepSP();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 3); Console.WriteLine(" _______________TÌM KIẾM SẢN PHẨM_____________ ");
                Console.SetCursorPosition(20, 4); Console.WriteLine("|     1. Tìm Kiếm Theo Mã Sản Phẩm            |");
                Console.SetCursorPosition(20, 5); Console.WriteLine("|     2. Tìm Kiếm Theo Tên Sản Phẩm           |");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|     3. Tìm Kiếm Theo Giá Sản Phẩm           |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|     4. Quay Lại                             |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 10); Console.Write("Nhập công việc bạn muốn thực hiện: ");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO MÃ-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("Nhập mã sản phẩm cần tìm kiếm: ");
                        string ma = Console.ReadLine();
                        TKMaSP(ma); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO TÊN SP-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("\n\t\tNhập tên sản phẩm cần tìm kiếm: ");
                        string b = Console.ReadLine();
                        TKTenSP(b); Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO GiÁ SP-----------------*");
                        TKGiaSP(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuTK(); break;
                }
            }
        }
        public void TKNhanVien()
        {
            DocTepNV();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 3); Console.WriteLine(" _______________TÌM KIẾM NHÂN VIÊN____________ ");
                Console.SetCursorPosition(20, 4); Console.WriteLine("|     1. Tìm Kiếm Theo Mã Nhân Viên           |");
                Console.SetCursorPosition(20, 5); Console.WriteLine("|     2. Tìm Kiếm Theo Tên Nhân Viên          |");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|     3. Tìm Kiếm Theo Chức Vụ Nhân Viên      |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|     4. Quay Lại                             |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 10); Console.Write("Nhập công việc bạn muốn thực hiện: ");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO MÃ NHÂN VIÊN-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("Nhập mã nhân viên cần tìm kiếm: ");
                        string ma = Console.ReadLine();
                        TKMaNV(ma); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO TÊN NHÂN VIÊN-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("\n\t\tNhập tên sản phẩm cần tìm kiếm: ");
                        string b = Console.ReadLine();
                        TKTenNV(b); Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO CHỨC VỤ-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("\n\t\tNhập chức vụ cần tìm kiếm(Quản lý/Thu ngân/Bảo vệ)(1->3): ");
                        int dem = int.Parse(Console.ReadLine());
                        string temp;
                        if (dem == 1) temp = "Quản Lý";
                        else if (dem == 2) temp = "Thu Ngân";
                        else temp = "Bảo Vệ";
                        TKCvuNV(temp); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuTK(); break;
                }
            }
        }
        public void MenuTK()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*----------------TÌM KIẾM------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*     1. Tìm Kiếm Nhân Viên                *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*     2. Tìm Kiếm Sản Phẩm                 *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*     3. Nhân Viên Lương Cao Nhất Công Ty  *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*     4. Sản Phẩm Số Lượng Nhiều Nhất      *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*     5. Quay Lại                          *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*     6. Thoát                             *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*------------------------------------------*");
                Console.SetCursorPosition(20, 14); Console.Write("  Mời Bạn Chọn Công Việc (1-6): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        TKNhanVien(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        DocTepSP();
                        TKSanPham();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        TKMaNV(MaxLuong());
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        TKMaSP(MaxSP());
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        MenuChinh();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        //Sản Phẩm
        public void HienThiSP()
        {
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM CỦA CỬA HÀNG HIỆN TẠI====================================================================");
            Console.WriteLine("\t||  Loại Sản Phẩm  ||   Mã    ||           Tên Sản Phẩm              ||   Thương Hiệu   ||        Giá        ||   Số Lượng   ||  Tình Trạng  ||");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (SanPham x in danhsach)
            {
                x.Hien();
            }
            Console.WriteLine("\t=================================================================================================================================================");
        }
        public void SapHetSP()
        {
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM SẮP BÁN HẾT CỦA CỬA HÀNG=================================================================");
            Console.WriteLine("\t||  Loại Sản Phẩm  ||   Mã    ||           Tên Sản Phẩm              ||   Thương Hiệu   ||        Giá        ||   Số Lượng   ||  Tình Trạng  ||");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < danhsach.Count; i++)
            {
                if ((danhsach[i].SoLuong) > 0 && (danhsach[i].SoLuong) <= 10)
                {
                    danhsach[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================================");
        }
        public void HetSP()
        {
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM ĐÃ BÁN HẾT CỦA CỬA HÀNG==================================================================");
            Console.WriteLine("\t||  Loại Sản Phẩm  ||   Mã    ||           Tên Sản Phẩm              ||   Thương Hiệu   ||        Giá        ||   Số Lượng   ||  Tình Trạng  ||");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < danhsach.Count; i++)
            {
                if ((danhsach[i].TrangThai) == "Hết hàng")
                {
                    danhsach[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================================");

        }
        public void ThongKeSP()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 6); Console.WriteLine(" _____________________________________________ ");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|              THỐNG KÊ SẢN PHẨM              |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|---------------------------------------------|");
                Console.SetCursorPosition(20, 9); Console.WriteLine("|     1. Thống Kê Tất Cả Sản Phẩm             |");
                Console.SetCursorPosition(20, 10); Console.WriteLine("|     2. Thống Kê Các Sản Phẩm Sắp Hết        |");
                Console.SetCursorPosition(20, 11); Console.WriteLine("|     3. Thống Kê Các Sản Phẩm Đã Hết         |");
                Console.SetCursorPosition(20, 12); Console.WriteLine("|     4. Quay Lại                             |");
                Console.SetCursorPosition(20, 13); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 15); Console.Write("  Chọn công việc bạn muốn thực hiện(1->4): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear(); HienThiSP();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear(); SapHetSP();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear(); HetSP();
                        Console.ReadKey();
                        break;
                    case 4:
                         Console.Clear(); MenuChinh();
                        break;
                }
            }
        }
        public void SuaSP()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine(" _______________________________________________ ");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|         CÁC HÌNH THỨC SỬA SẢN PHẨM            |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|-----------------------------------------------|");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|            1. Sửa Giá Sản Phẩm                |");
                Console.SetCursorPosition(20, 9); Console.WriteLine("|            2. Sửa Số Lượng Sản Phẩm           |");
                Console.SetCursorPosition(20, 10); Console.WriteLine("|            3. Sửa Tên Sản Phẩm                |");
                Console.SetCursorPosition(20, 11); Console.WriteLine("|            4. Sửa Thương Hiệu Sản Phẩm        |");
                Console.SetCursorPosition(20, 12); Console.WriteLine("|            5. Quay Lại                        |");
                Console.SetCursorPosition(20, 13); Console.WriteLine("|_______________________________________________|");
                Console.SetCursorPosition(20, 15); Console.Write(" Nhập công việc bạn muốn thực hiện : ");
                int chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        Console.Clear();
                        char temp;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-------------SỬA GIÁ BÁN SẢN PHẨM------------*");
                        do
                        {
                            Console.WriteLine();
                            SuagiaSP();
                            GhiTepSP();
                            Console.Write("\n\t\tBạn có muốn sửa giá sản phẩm khác không (C/K)? ");
                            temp = char.Parse(Console.ReadLine());
                        } while (temp == 'c' || temp == 'C');
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        char b;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-------------SỬA SỐ LƯỢNG SẢN PHẨM------------*");
                        do
                        {
                            Console.WriteLine();
                            SuasoluongSP();
                            GhiTepSP();
                            Console.Write("\n\t\tBạn có muốn sửa số lượng sản phẩm khác không (C/K)? ");
                            b = char.Parse(Console.ReadLine());
                        } while (b == 'c' || b == 'C');
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        char c;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------SỬA TÊN SẢN PHẨM----------------*");
                        do
                        {
                            Console.WriteLine();
                            SuaTenSP();
                            GhiTepSP();
                            Console.Write("\n\t\tBạn có muốn sửa tên sản phẩm khác không (C/K)? ");
                            c = char.Parse(Console.ReadLine());
                        } while (c == 'c' || c == 'C');
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        char d;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------SỬA THƯƠNG HIỆU SẢN PHẨM------------*");
                        do
                        {
                            Console.WriteLine();
                            SuaThuongHieuSP();
                            GhiTepSP();
                            Console.Write("\n\t\tBạn có muốn sửa số lượng sản phẩm khác không (C/K)? ");
                            d = char.Parse(Console.ReadLine());
                        } while (d == 'c' || d == 'C');
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        MenuSP(); ; break;
                }
            }
        }
        public void DocTepSP()
        {
            try
            {
                Interface_SanPham sp;
                int check = 0;
                StreamReader sr = File.OpenText("sanpham.txt");//Mở một tệp đang tồn tại
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length > 0)
                    {
                        string[] l = new string[7];
                        l = s.Split('#');
                        if (l[0] == "TiVi") sp = new TiVi(l[0], l[1], l[2], l[3], float.Parse(l[4]), int.Parse(l[5]), l[6]);
                        else if (l[0] == "Tủ Lạnh") sp = new TuLanh(l[0], l[1], l[2], l[3], float.Parse(l[4]), int.Parse(l[5]), l[6]);
                        else sp = new DieuHoa(l[0], l[1], l[2], l[3], float.Parse(l[4]), int.Parse(l[5]), l[6]);
                        foreach (Interface_SanPham temp in danhsach)
                        {
                            if (temp.MaSP == sp.MaSP) check = 1;
                        }
                        if (check == 0) danhsach.Add(sp);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GhiTepSP()
        {
            StreamWriter sw = new StreamWriter("sanpham.txt");
            foreach (SanPham x in danhsach)
            {
                sw.WriteLine(x.toString());
            }
            sw.Close();
        }
        public void Them1SP()
        {
            Interface_SanPham sp;
            Console.Write("\t\t Chọn loại sản phẩm(TiVi/Tủ Lạnh/Điều Hòa)(1->3): ");
            int a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                sp = new TiVi();
                sp.LoaiSP = "TiVi";
            }
            else if (a == 2)
            {
                sp = new TuLanh();
                sp.LoaiSP = "Tủ Lạnh";
            }
            else
            {
                sp = new DieuHoa();
                sp.LoaiSP = "Điều Hòa";
            }
            bool ok = false;
            Console.Write("\t\t Nhập mã sản phẩm: ");
            sp.MaSP = Console.ReadLine();
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(sp.MaSP))//So sánh 2 chuỗi có giống nhau hay không
                {
                    ok = true;
                    Console.WriteLine("\n\t\tĐã tồn tại mã hóa đơn trong danh sách. Vui lòng nhập lại!");
                }
            }
            if (!ok)//Chưa tồn tại mã nếu biến Ok khác true thì sẽ thực hiện các lệnh 
            {
                sp.Nhap();
                danhsach.Add(sp);
                Console.WriteLine("\t\tSẢN PHẨM ÐÃ ÐƯỢC THÊM VÀO TRONG DANH SÁCH !");
            }
        }
        public void ThemSP()
        {
            Console.Write("\t\tNhập số lượng sản phẩm cần thêm: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n\t\tNhập thông tin sản phẩm thứ {0} ", i + 1);
                Them1SP();
                GhiTepSP();
            }
        }
        public void SuaTenSP()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập tên mới : ");
            string b = Console.ReadLine();
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(a))
                {
                    ok = true;
                    danhsach[i].TenSP = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t Tên sản phẩm đã sửa thành công !\n");
                TKMaSP(a);
            }
        }
        public void SuaThuongHieuSP()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập tên thương hiệu mới: ");
            string b = Console.ReadLine();
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(a))
                {
                    ok = true;
                    danhsach[i].ThuongHieu = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\n\t\t   Thương hiệu sản phẩm đã sửa thành công !\n");
                TKMaSP(a);
            }
        }
        public void SuagiaSP()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập đơn giá mới : ");
            float b = float.Parse(Console.ReadLine());
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(a))
                {
                    ok = true;
                    danhsach[i].Giaban = b;
                }
            }

            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t   Giá sản phẩm đã sửa thành công !\n");
                TKMaSP(a);
            }
        }
        public void SuasoluongSP()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập số lượng sản phẩm mới: ");
            int b = int.Parse(Console.ReadLine());
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(a))
                {
                    ok = true;
                    danhsach[i].SoLuong = b;
                    if (danhsach[i].SoLuong > 0)
                    {
                        danhsach[i].TrangThai = "Còn";
                    }
                    else danhsach[i].TrangThai = "Hết hàng ";
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t   Số lượng sản phẩm đã sửa thành công !\n");
                TKMaSP(a);
            }
        }
        public void XoaSP()
        {
            bool ok = false;
            Console.Write("\t\t\tNhập mã sản phẩm cần xóa: ");
            string ma = Console.ReadLine();
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(ma))
                {
                    ok = true;//tim thay
                    danhsach.RemoveAt(i);//RemoveAt Xoa tai vi tri i 
                    Console.WriteLine("\n\t\t    SẢN PHẨM {0} ĐÃ XÓA KHỎI DANH SÁCH ", ma);
                    break;//thoat
                }
            }
            if (!ok)
                Console.WriteLine("Không tồn tại mã " + ma);
        }
        public void TKMaSP(string ma)
        {
            bool ok = false;
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM TÌM THEO MÃ=============================================================================");
            Console.WriteLine("\t||  Loại Sản Phẩm  ||   Mã    ||           Tên Sản Phẩm              ||   Thương Hiệu   ||        Giá        ||   Số Lượng   ||  Tình Trạng  ||");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].MaSP.Equals(ma))
                {
                    ok = true;
                    danhsach[i].Hien();
                    break;
                }
            }
            Console.WriteLine("\t===============================================================================================================================================");
            if (!ok)
                Console.WriteLine("Mã Sản Phẩm Không Tồn Tại");
        }
        public void TKTenSP(String b)
        {
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM TÌM KIẾM THEO TÊN=======================================================================");
            Console.WriteLine("\t||  Loại Sản Phẩm  ||   Mã    ||           Tên Sản Phẩm              ||   Thương Hiệu   ||        Giá        ||   Số Lượng   ||  Tình Trạng  ||");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------------------------------------------------------");
            int j = 0;//khai báo biến kiểu nguyên có tên là j và khởi tạo giá trị là 0.
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].TenSP.StartsWith(b)) //Str1.StartsWith(Str2):Kiểm tra xem chuỗi Str1 có bắt đầu bằng chuỗi Str2 không?
                {
                    j = 1;
                    danhsach[i].Hien();
                }
            }
            if (j == 0)
                Console.WriteLine("\t\tKhông tìm thấy tên sản phẩm {0} ", b);
        }
        public void TKGiaSP()
        {
            Console.WriteLine("\n\t\tMời Bạn Nhâp Khoảng Giá Cần Tìm Kiếm:");
            Console.Write("\t\tGiá Min: ");
            float min = float.Parse(Console.ReadLine());
            Console.Write("\t\tGiá Max: ");
            float max = float.Parse(Console.ReadLine());
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM TÌM THEO GIÁ============================================================================");
            Console.WriteLine("\t||  Loại Sản Phẩm  ||   Mã    ||           Tên Sản Phẩm              ||   Thương Hiệu   ||        Giá        ||   Số Lượng   ||  Tình Trạng  ||");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < danhsach.Count; i++)
            {
                if (danhsach[i].Giaban >= min && danhsach[i].Giaban <= max)
                {
                    danhsach[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================================");
        }
        public string MaxSP()
        {
            DocTepSP();
            SanPham max = new TiVi("", "", "", "", 0, 0, "");
            foreach (SanPham a in danhsach)
            {
                if (a > max) max = a;
            }
            return max.MaSP;
        }
        // HÀM PHỤ
        public string LayTenSanPham(string MaSP)
        {
            StreamReader sr = new StreamReader("sanpham.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] a = s.Split('#');
                if (a[0] == MaSP) return a[1];
            }
            sr.Close();
            return "";
        }
        public string LayGiaSanPham(string MaSP)
        {
            StreamReader sr = new StreamReader("sanpham.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] a = s.Split('#');
                if (a[0] == MaSP) return a[3];
            }
            sr.Close();
            return "";
        }
        public string LaySLSanPham(string MaSP)
        {
            StreamReader sr = new StreamReader("sanpham.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] a = s.Split('#');
                if (a[0] == MaSP) return a[4];
            }
            sr.Close();
            return "";
        }
    }
}