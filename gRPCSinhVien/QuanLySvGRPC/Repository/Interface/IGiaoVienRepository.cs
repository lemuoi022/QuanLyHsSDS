using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Repository.Interface
{
    public interface IGiaoVienRepository
    {
        public List<GiaoVien> getAllGiaoVien();
        public GiaoVien getGiaoVienById(int id);
    };
}
