using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Protos;

namespace QuanLySvGRPC.Controller.Interface
{
    public interface IQuanLySv
    {
        public List<SinhVien> layDsachSv();
        public SinhVien themHoacSuaSv(SinhVien sv);
        public Boolean xoaSv(int maSo);
        public List<SinhVien> sapXepSinhVien();
        public SinhVien timKiemSv(int maSo);
    }
}
