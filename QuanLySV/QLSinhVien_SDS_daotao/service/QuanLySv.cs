using FluentNHibernate.Automapping;
using QLSinhVien_SDS_daotao.Implement.Interface;
using QLSinhVien_SDS_daotao.Model;
using QLSinhVien_SDS_daotao.repository.Interface;
using QLSinhVien_SDS_daotao.service.Interface;
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
        private readonly ISinhVienRepository _sinhVienRepository;
        //private readonly ILopHocRepository _lopHocRepository;
        private readonly IQuanLyLh _quanLyLh;
        public QuanLySv(ISinhVienRepository sinhVienRepository, IQuanLyLh quanLyLh)
        {
            _sinhVienRepository = sinhVienRepository ?? throw new ArgumentNullException(nameof(sinhVienRepository));
            _quanLyLh = quanLyLh ?? throw new ArgumentNullException(nameof(quanLyLh));
        }
        public DateTime setDate(string dobString)
        {
            return DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public string layDsachSv()
        {
            string str = "";
            List<SinhVien> listSinhVien = _sinhVienRepository.getAllSinhVien();
            foreach (var sv in listSinhVien)
            {

                str += sv + "\n";
            }
            return str;
        }

        public string sapXepSinhVien()
        {
            List<SinhVien> listSinhVienSort = _sinhVienRepository.getAllSinhVien();
            listSinhVienSort.Sort((sv1, sv2) => sv1.Ten.Split(' ').Last().CompareTo(sv2.Ten.Split(' ').Last()));
            string str = "";
            foreach (var sv in listSinhVienSort)
            {
                str += sv + "\n";
            }
            return str;
        }

        public Boolean suaSv(int maSo)
        {
            SinhVien sv = _sinhVienRepository.getSinhVienById(maSo);
            if (sv != null)
            {
              var sinhvien =   nhapThongTinSv(sv);
                _sinhVienRepository.insertSinhVien(sinhvien);
                return true;
            }
            return false;
                    
                   
        }

        public Boolean themSv()
        {
            SinhVien sinhvien = new SinhVien();
            var sv = nhapThongTinSv(sinhvien);
            if (sv != null)
            {
                _sinhVienRepository.insertSinhVien(sv);

                return true;
            }
            return false;
        }

        public string timKiemSv(int maSo)
        {
            var sinhVienSearch = _sinhVienRepository.getSinhVienById(maSo);
            Console.WriteLine("Sinh vien can tim: ");
            return sinhVienSearch.ToString();
        }

        public Boolean xoaSv(int maSo)
        {
            var sinhVienToRemove = _sinhVienRepository.getSinhVienById(maSo);
            if (sinhVienToRemove != null)
            {
                _sinhVienRepository.deleteSinhVien(sinhVienToRemove);
                return true;
            }
            return false;
        }

        private SinhVien nhapThongTinSv(SinhVien sv)
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
                "\n" + _quanLyLh.danhSachLopHoc());
            int idLopHocSv = int.Parse(Console.ReadLine());
            if (!(idLopHocSv == null) || !(idLopHocSv == 0))
            {
                sv.LHoc = _quanLyLh.listLopHoc().FirstOrDefault(l => l.ID == idLopHocSv);
            }
            return sv;
        }
    }
}
