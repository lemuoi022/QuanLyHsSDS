using NHibernate.Linq;
using QuanLySvGRPC.Model;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;

namespace QuanLySvGRPC.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        public SinhVien GetSinhVienById(int id)
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

        public List<SinhVien> GetAllSinhVien()
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

        public SinhVien InsertOrUpadateSinhVien(SinhVien sv)
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


        public Boolean DeleteSinhVien(SinhVien sv)
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
        private IQueryable<SinhVien>? Filter(IQueryable<SinhVien> query, SinhVienSearch sinhVienSearch)
        {

            if (!string.IsNullOrEmpty(sinhVienSearch.Ten))
            {
                query = query.Where(c => c.Ten.Contains(sinhVienSearch.Ten));

            }
            if (!string.IsNullOrEmpty(sinhVienSearch.DiaChi))
            {
                query = query.Where(c => c.DiaChi.Contains(sinhVienSearch.DiaChi));

            }
            if (sinhVienSearch.NgayBatDau.HasValue)
            {
                //DateTime ngayBatDau = sinhVienSearch.NgayBatDau.Value;
                //if (ngayBatDau >= (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue && ngayBatDau <= (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                //{
                    query = query.Where(s => s.NgaySinh.Value.Date >= sinhVienSearch.NgayBatDau.Value.Date);

                //}
            }
            if (sinhVienSearch.NgayKetThuc.HasValue)
            {
                //DateTime ngayKetThuc = sinhVienSearch.NgayKetThuc.Value;
                //if (ngayKetThuc >= (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue && ngayKetThuc <= (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                //{
                    query = query.Where(s => s.NgaySinh.Value.Date <= sinhVienSearch.NgayKetThuc.Value.Date);

                //}
            }
            if (sinhVienSearch.idLopHoc.HasValue)
            {
                query = query.Where(s => s.LHoc.ID == sinhVienSearch.idLopHoc);

            }
            if (sinhVienSearch.ID.HasValue)
            {
                query = query.Where(s => s.ID == sinhVienSearch.ID);
                Console.WriteLine(query);
            }

            return query;
        }


        public async Task<PageView<SinhVien>> GetPageDataAsync(int pageNumber, int pageSize, SinhVienSearch sinhVienSearch)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var query = session.Query<SinhVien>();
                    query = Filter(query, sinhVienSearch);

                    var total = await query.CountAsync();
                    var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                    return new PageView<SinhVien>
                    {
                        Data = data,
                        PageCount = total
                    };
                }
            }
        }

    }
}
