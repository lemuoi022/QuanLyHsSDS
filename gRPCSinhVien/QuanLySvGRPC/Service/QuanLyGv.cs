using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository;
using QuanLySvGRPC.Repository.Interface;

namespace QuanLySvGRPC.Controller
{
    public class QuanLyGv : IQuanLyGv
    {
        private readonly IGiaoVienRepository _giaovienRepository;
        public QuanLyGv(IGiaoVienRepository giaoVienRepository)
        {
            _giaovienRepository = giaoVienRepository ?? throw new ArgumentNullException(nameof(giaoVienRepository));
        }
        public string danhSachGiaoVien()
        {
            List<GiaoVien> listLh = _giaovienRepository.GetAllGiaoVien();
            string str = "";
            listLh.ForEach(gv => { str += $"{gv.ID}:{gv.Ten}  "; });
            //listLh.ForEach(lh => { Console.WriteLine(lh); });
            return str;
        }

        public GiaoVien giaoVienDetailById(int id)
        {
            return _giaovienRepository.GetGiaoVienById(id);
        }

        public List<GiaoVien> listGiaoVien()
        {
            return _giaovienRepository.GetAllGiaoVien();
        }
    }
}
