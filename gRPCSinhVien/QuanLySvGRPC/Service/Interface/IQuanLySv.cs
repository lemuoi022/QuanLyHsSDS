using QuanLySvGRPC.Model;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Protos;

namespace QuanLySvGRPC.Controller.Interface
{
    public interface IQuanLySv
    {
        public List<SinhVien> LayDsachSv();
        public SinhVien ThemHoacSuaSv(SinhVien sv);
        public Boolean XoaSv(int maSo);
        public List<SinhVien> SapXepSinhVien();
        public SinhVien TimKiemSv(int maSo);
        Task<PageView<SinhVien>> GetPageData(int pageNumber, int pageSize, SinhVienSearch sinhVienSearch);
        List<SinhVienTheoLopDTO> ThongKeSinhVienTheoLop(bool? gioiTinh);
    }
}
