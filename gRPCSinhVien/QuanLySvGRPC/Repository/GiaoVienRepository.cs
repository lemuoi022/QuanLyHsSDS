using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;

namespace QuanLySvGRPC.Repository
{
    public class GiaoVienRepository : IGiaoVienRepository
    {
        public List<GiaoVien> getAllGiaoVien()
        {
            List<GiaoVien> listGv;
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    listGv = (List<GiaoVien>)session.CreateCriteria<GiaoVien>().List<GiaoVien>();
                    tx.Commit();
                }
            }
            return listGv;
        }

        public GiaoVien getGiaoVienById(int id)
        {
            GiaoVien giaoVien;
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    giaoVien = session.Get<GiaoVien>(id);
                    tx.Commit();
                }

            }
            return giaoVien;
        }
    }
}
