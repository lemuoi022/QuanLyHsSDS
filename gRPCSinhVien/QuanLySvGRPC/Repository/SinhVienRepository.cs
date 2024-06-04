using NHibernate;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;

namespace QuanLySvGRPC.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        public SinhVien getSinhVienById(int id)
        {
            SinhVien sinhVien;
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    sinhVien = session.Get<SinhVien>(id);
                    tx.Commit();
                }

            }
            return sinhVien;
        }

        public List<SinhVien> getAllSinhVien()
        {
            List<SinhVien> listSV;
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    listSV = (List<SinhVien>)session.CreateCriteria<SinhVien>().List<SinhVien>();
                    tx.Commit();
                }
            }
            return listSV;
        }

        public SinhVien insertOrUpadateSinhVien(SinhVien sv)
        {
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    
                    if (sv != null)
                    {
                            session.SaveOrUpdate(sv);
                        tx.Commit();
                        session.Refresh(sv);
                        return sv;
                    }

                }
            }
            return null;
        }

        
        public Boolean deleteSinhVien(SinhVien sv)
        {
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(sv);
                    tx.Commit();
                    return true;
                }
            }
            return false;
        }
    }
}
