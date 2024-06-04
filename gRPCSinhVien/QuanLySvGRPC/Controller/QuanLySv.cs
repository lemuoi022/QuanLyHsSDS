using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;
using System.Globalization;

namespace QuanLySvGRPC.Controller
{
    public class QuanLySv : IQuanLySv
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
        public List<SinhVien> layDsachSv()
        {
            List<SinhVien> listSinhVien = _sinhVienRepository.getAllSinhVien();
          
            return listSinhVien;
        }

        public List<SinhVien> sapXepSinhVien()
        {
            List<SinhVien> listSinhVienSort = _sinhVienRepository.getAllSinhVien();
            listSinhVienSort.Sort((sv1, sv2) => sv1.Ten.Split(' ').Last().CompareTo(sv2.Ten.Split(' ').Last()));
            
            return listSinhVienSort;
        }

        public SinhVien themHoacSuaSv(SinhVien sv)
        {
            if (sv != null)
            {
                sv = _sinhVienRepository.insertOrUpadateSinhVien(sv);

                return sv;
            }
            return sv;
        }

        public SinhVien timKiemSv(int maSo)
        {
            var sinhVienSearch = _sinhVienRepository.getSinhVienById(maSo);
            return sinhVienSearch;
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

    }
}
