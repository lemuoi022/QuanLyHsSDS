using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;

namespace QuanLySvGRPC.Controller
{
    public class QuanLyLh : IQuanLyLh
    {

        private readonly ILopHocRepository _lopHocRepository;
        //private readonly ILopHocRepository _lopHocRepository;
        public QuanLyLh(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository ?? throw new ArgumentNullException(nameof(lopHocRepository));
        }
        public string danhSachLopHoc()
        {
            List<LopHoc> listLh = _lopHocRepository.getAllLopHoc();
            string str = "";
            listLh.ForEach(lh => { str += $"{lh.ID}:{lh.TenLop}  "; });
            //listLh.ForEach(lh => { Console.WriteLine(lh); });
            return str;
        }
        public List<LopHoc> listLopHoc()
        {
            return _lopHocRepository.getAllLopHoc();
        }
        public LopHoc lopHocDetailById(int id)
        {
            return _lopHocRepository.getLopHocById(id);
        }
        
    }
}
