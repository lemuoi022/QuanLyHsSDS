using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Repository.Interface
{
    public interface ILopHocRepository
    {
        public List<LopHoc> getAllLopHoc();
        public LopHoc getLopHocById(int id);
    }
}
