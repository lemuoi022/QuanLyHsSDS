using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;

namespace QuanLySvGRPC.Repository
{
    public class LopHocRepository : ILopHocRepository
    {
        public List<LopHoc> getAllLopHoc()
        {
            List<LopHoc> listLH;
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    listLH = (List<LopHoc>)session.CreateCriteria<LopHoc>().List<LopHoc>();
                    tx.Commit();
                }
            }
            return listLH;
        }

        public LopHoc getLopHocById(int id)
        {
            LopHoc lopHoc;
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    lopHoc = session.Get<LopHoc>(id);
                    tx.Commit();
                }

            }
            return lopHoc;
        }
    }
}
