using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using QLSinhVien_SDS_daotao.Implement;
using QLSinhVien_SDS_daotao.Implement.Interface;
using QLSinhVien_SDS_daotao.Model;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace QLSinhVien_SDS_daotao
{
    internal class Program
    {

        private readonly static IQuanLySv _quanLySv = new QuanLySv();
        //private static ConnectDB cn = new ConnectDB();

        static void Main(string[] args)

        {
            //cn.ConnectDatabase();
            List<GiaoVien> listGiaoVien;
            List<LopHoc> listLopHoc;
            List<SinhVien> listSinhVien;
            // danh sách giáo viên, lớp học, sinh vien test
            GiaoVien gv1 = new GiaoVien() { ID = 1, Ten = "Nguyen Van Minh", NgaySinh = setDate("04/06/1986") };
            GiaoVien gv2 = new GiaoVien() { ID = 2, Ten = "Tran Van Tuan", NgaySinh = setDate("04/06/1986") };
            GiaoVien gv3 = new GiaoVien() { ID = 3, Ten = "Le Van Binh", NgaySinh = setDate("07/08/1993" )};
            GiaoVien gv4 = new GiaoVien() { ID = 4, Ten = "Nguyen Thi Hoa", NgaySinh = setDate("05/08/1987") };
            GiaoVien gv5 = new GiaoVien() { ID = 5, Ten = "Tran Thi Nhung", NgaySinh = setDate("09/06/1988" )};
            GiaoVien gv6 = new GiaoVien() { ID = 6, Ten = "Le Xuan Minh", NgaySinh = setDate("09/05/1970" )};
            listGiaoVien = new List<GiaoVien>() { gv1, gv2, gv3, gv4, gv5, gv6 };
            
            LopHoc lh1 = new LopHoc() { ID = 1, TenLop = "65IT1", MonHoc = "Dai so", GVien = listGiaoVien[0] };
            LopHoc lh2 = new LopHoc() { ID = 2, TenLop = "65IT2", MonHoc = "Giai tich", GVien = listGiaoVien[1] };
            LopHoc lh3 = new LopHoc() { ID = 3, TenLop = "65IT3", MonHoc = "Toan roi rac", GVien = listGiaoVien[2] };
            LopHoc lh4 = new LopHoc() { ID = 4, TenLop = "65IT4", MonHoc = "Lap trinh Web", GVien = listGiaoVien[3] };
            LopHoc lh5 = new LopHoc() { ID = 5, TenLop = "65IT5", MonHoc = "Lap trinh OOP", GVien = listGiaoVien[4] };
            LopHoc lh6 = new LopHoc() { ID = 6, TenLop = "65IT6", MonHoc = "Tin hoc dai cuong", GVien = listGiaoVien[5] };
            listLopHoc = new List<LopHoc>() { lh1, lh2, lh3, lh4, lh5, lh6 };
            SinhVien sv1 = new SinhVien() { ID = 1, Ten = "Le Anh Minh", NgaySinh = setDate("01/12/2003"), DiaChi = "Ha Noi", LHoc = listLopHoc[0] };
            SinhVien sv2 = new SinhVien() { ID = 2, Ten = "Nguyen Duc Anh", NgaySinh = setDate("04/04/2002"), DiaChi = "Ha Noi", LHoc = listLopHoc[1] };
            SinhVien sv3 = new SinhVien() { ID = 3, Ten = "Le Van Khoa", NgaySinh = setDate("10/08/2003"), DiaChi = "Ha Noi", LHoc = listLopHoc[2] };
            listSinhVien = new List<SinhVien>() { sv1, sv2, sv3 };




            Console.WriteLine("Phan mem quan ly sinh vien \n");

            while (true)
            {
                menuSv();

                int choice = 8;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                if (choice == 1)
                {
                    Console.WriteLine("Danh sach sinh vien: \n");
                    Console.WriteLine(_quanLySv.layDsachSv(listSinhVien));
                }
                else if (choice == 2)
                {
                    if (_quanLySv.themSv(listSinhVien, listLopHoc))
                        Console.WriteLine("Thêm Sv thành công \n");
                }
                else if (choice == 3)
                {
                    Console.Write("Nhap ma sinh vien can sua: ");
                    int maSvSearch = int.Parse(Console.ReadLine());
                    if (_quanLySv.suaSv(maSvSearch, listSinhVien, listLopHoc))
                        Console.WriteLine("Sua Sv thành công \n");

                }
                else if (choice == 4)
                {
                    Console.Write("Nhap ma sinh vien can xoa: ");
                    int maSvSearch = int.Parse(Console.ReadLine());
                    if (_quanLySv.xoaSv(maSvSearch, listSinhVien))
                        Console.WriteLine("Xoa sinh vien thanh cong");
                }
                else if (choice == 5)
                {
                    _quanLySv.sapXepSinhVien(listSinhVien);
                }
                else if (choice == 6)
                {
                    Console.Write("Nhap ma sinh vien can tim: ");
                    int maSvSearch = int.Parse(Console.ReadLine());
                    _quanLySv.timKiemSv(maSvSearch, listSinhVien);

                }
                else if (choice == 0)
                {
                    Console.WriteLine("\nCam on ban da su dung chuong trinh");
                    break;
                }
                else
                {
                    Console.WriteLine("\nNhap sai cu phap moi nhap lai");
                }



            }

        }

        public static void menuSv()
        {
            Console.WriteLine("Danh sach cac chuc nang: ");
            Console.WriteLine("\n1. Xem danh sach sinh vien" +
                "\n2. Them moi sinh vien" +
                "\n3. Chinh sua thong tin sinh vien" +
                "\n4. Xoa sinh vien" +
                "\n5. Sap xep du lieu theo ten" +
                "\n6. Tim kiem sinh vien theo ma so sinh vien" +
                "\n0. Thoat khoi chuong trinh");
            Console.Write("Moi ban nhap lua chon chuc nang: ");
        }

        public static DateTime setDate(string dobString)
        {
            return DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

    }
}
