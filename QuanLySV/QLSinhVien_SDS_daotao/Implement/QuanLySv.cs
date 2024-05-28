using QLSinhVien_SDS_daotao.Implement.Interface;
using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Implement
{
    internal class QuanLySv : IQuanLySv
    {
        public DateTime setDate(string dobString)
        {
            return DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public string layDsachSv(List<SinhVien> listSv)
        {
            string str = "";
            foreach (var sv in listSv)
            {
                str += sv.displaySv();
            }
            return str;
        }

        public string sapXepSinhVien(List<SinhVien> listSv)
        {
            List<SinhVien> listSinhVienSort = listSv;
            listSinhVienSort.Sort((sv1, sv2) => sv1.Ten.Split(' ').Last().CompareTo(sv2.Ten.Split(' ').Last()));
            string str = "";
            foreach (var sv in listSinhVienSort)
            {
                str += sv.displaySv();
            }
            return str;
        }

        public Boolean suaSv(int maSo, List<SinhVien> listSv, List<LopHoc> listLh)
        {
            foreach (var sv in listSv)
            {
                if (sv.ID == maSo)
                {
                    Console.Write("Ten sinh vien: ");
                    string tenSv = Console.ReadLine();
                    if (!string.IsNullOrEmpty(tenSv)) sv.Ten = tenSv.Trim();
                    Console.Write("Ngay sinh sinh vien: ");
                    string ngaySinhSv = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ngaySinhSv)) sv.NgaySinh = setDate(ngaySinhSv.Trim());
                    Console.Write("Dia chi sinh vien: ");
                    string diaChiSv = Console.ReadLine();
                    if (!string.IsNullOrEmpty(diaChiSv)) sv.DiaChi = diaChiSv.Trim();
                    Console.Write("Lop hoc(danh sach lop hoc):" +
                        "\n1. 65IT1,2. 65IT2,3. 65IT3,4. 65IT4,5. 65IT5,6. 65IT6: ");
                    int lopHocSv = int.Parse(Console.ReadLine());
                    if (!(lopHocSv == null) || !(lopHocSv == 0))
                    {
                        LopHoc lhocSv = new LopHoc();
                        foreach (var lh in listLh)
                        {
                            if (lh.ID == lopHocSv)
                            {
                                lhocSv = lh;
                                break;
                            }
                        }
                        sv.LHoc = lhocSv;
                    }
                    return true;

                }
            }
            return false;
        }

        public Boolean themSv( List<SinhVien> listSv, List<LopHoc> listLh)
        {
            
            Console.WriteLine("Nhap thong tin sinh vien");

            //if (maSoSv != 0 || maSoSv != null)
            //{
                Console.WriteLine("Ma so sinh vien: ");
                Console.Write("Ten sinh vien: ");
                string tenSv = Console.ReadLine();
                Console.Write("Ngay sinh sinh vien: ");
                string ngaySinhSv = Console.ReadLine();
                Console.Write("Dia chi sinh vien: ");
                string diaChiSv = Console.ReadLine();
                Console.Write("Lop hoc(danh sach lop hoc):" +
                    "\n1. 65IT1,2. 65IT2,3. 65IT3,4. 65IT4,5. 65IT5,6. 65IT6: ");
                int idlopHocSv = int.Parse(Console.ReadLine());
                LopHoc lhocSv = new LopHoc();
                foreach (var lh in listLh)
                {
                    if (lh.ID == idlopHocSv)
                    {
                        lhocSv = lh;
                        break;
                    }
                }
                SinhVien sv = new SinhVien() {  Ten = tenSv, NgaySinh = setDate(ngaySinhSv), DiaChi = diaChiSv, LHoc = lhocSv };
                
                listSv.Add(sv);
                using (var session = FluentNHibernateHelper.OpenSession())

                {

                    session.SaveOrUpdate(sv);

                }
                return true;
            //}
            //return false;
        }

        public string timKiemSv(int maSo, List<SinhVien> listSv)
        {
            var sinhVienSearch = listSv.SingleOrDefault(sv => sv.ID == maSo);
            Console.WriteLine("Sinh vien can tim: ");
            return sinhVienSearch.displaySv();
        }

        public Boolean xoaSv(int maSo, List<SinhVien> listSv)
        {
            var sinhVienToRemove = listSv.SingleOrDefault(sv => sv.ID == maSo);
            if (sinhVienToRemove != null)
            {
                listSv.Remove(sinhVienToRemove);
                return true;
            }
            return false;
        }
    }
}
