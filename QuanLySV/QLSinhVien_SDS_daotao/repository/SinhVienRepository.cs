using QLSinhVien_SDS_daotao.Model;
using QLSinhVien_SDS_daotao.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.repository
{
    internal class SinhVienRepository : ISinhVienRepository
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

        public Boolean insertSinhVien(SinhVien sv)
        {
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    var sinhVien = sv;
                    if (sinhVien != null)
                    {
                        session.SaveOrUpdate(sinhVien);
                        tx.Commit();
                        return true;
                    }

                }
            }
            return false;
        }

        public Boolean updateSinhVien(SinhVien sv)
        {
            using (var session = FluentNHibernateHelper.OpenSession())

            {
                using (var tx = session.BeginTransaction())
                {
                    var sinhVien = sv;
                    if (sinhVien != null)
                    {
                        session.SaveOrUpdate(sinhVien);
                        tx.Commit();
                        return true;
                    }

                }
            }
            return false;
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
