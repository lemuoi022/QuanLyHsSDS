using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Controller.Interface
{
    public interface IQuanLyLh
    {
        public string danhSachLopHoc();
        public List<LopHoc> listLopHoc();

        public LopHoc lopHocDetailById(int id);
    }
}
