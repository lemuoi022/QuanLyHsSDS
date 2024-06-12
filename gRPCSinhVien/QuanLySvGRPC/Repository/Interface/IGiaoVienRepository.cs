using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Repository.Interface
{
    public interface IGiaoVienRepository
    {
        public List<GiaoVien> GetAllGiaoVien();
        public GiaoVien GetGiaoVienById(int id);
    };
}
