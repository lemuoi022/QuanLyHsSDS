using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Repository.Interface
{
    public interface ILopHocRepository
    {
        public List<LopHoc> GetAllLopHoc();
        public LopHoc GetLopHocById(int id);
    }
}
