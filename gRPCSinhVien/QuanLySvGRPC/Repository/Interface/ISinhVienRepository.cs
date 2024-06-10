using QuanLySvGRPC.Model;
using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Repository.Interface
{
    public interface ISinhVienRepository
    {
        public List<SinhVien> GetAllSinhVien();
        public SinhVien InsertOrUpadateSinhVien(SinhVien sv);
        public Boolean DeleteSinhVien(SinhVien sv);
        public SinhVien GetSinhVienById(int id);
        Task<PageView<SinhVien>> GetPageDataAsync(int pageNumber, int pageSize, SinhVienSearch sinhVienSearch);
    }
}
