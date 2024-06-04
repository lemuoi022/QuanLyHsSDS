using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Controller.Interface
{
    public interface IQuanLyGv
    {
        public string danhSachGiaoVien();
        public List<GiaoVien> listGiaoVien();
        public GiaoVien giaoVienDetailById(int id);
    }
}
