using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Model;
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
        public DateTime SetDate(string dobString)
        {
            return DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public List<SinhVien> LayDsachSv()
        {
            List<SinhVien> listSinhVien = _sinhVienRepository.GetAllSinhVien();
          
            return listSinhVien;
        }

        public List<SinhVien> SapXepSinhVien()
        {
            List<SinhVien> listSinhVienSort = _sinhVienRepository.GetAllSinhVien();
            listSinhVienSort.Sort((sv1, sv2) => sv1.Ten.Split(' ').Last().CompareTo(sv2.Ten.Split(' ').Last()));
            
            return listSinhVienSort;
        }

        public SinhVien ThemHoacSuaSv(SinhVien sv)
        {
            if (sv != null)
            {
                sv = _sinhVienRepository.InsertOrUpadateSinhVien(sv);

                return sv;
            }
            return sv;
        }

        public SinhVien TimKiemSv(int maSo)
        {
            var sinhVienSearch = _sinhVienRepository.GetSinhVienById(maSo);
            return sinhVienSearch;
        }

        public Boolean XoaSv(int maSo)
        {
            var sinhVienToRemove = _sinhVienRepository.GetSinhVienById(maSo);
            if (sinhVienToRemove != null)
            {
                _sinhVienRepository.DeleteSinhVien(sinhVienToRemove);
                return true;
            }
            return false;
        }
        public Task<PageView<SinhVien>> GetPageData (int pageNumber, int pageSize, SinhVienSearch sinhVienSearch)
        {
            return _sinhVienRepository.GetPageDataAsync(pageNumber,pageSize,sinhVienSearch);
        }

    }
}
