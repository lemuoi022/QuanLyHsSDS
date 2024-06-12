using QLSinhVien_SDS_daotao.Model;
using QLSinhVien_SDS_daotao.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.repository
{
    internal class LopHocRepository : ILopHocRepository
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
