using NHibernate;
using NHibernate.Linq;
using QuanLySvGRPC.Model;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Repository.Interface;
using System.Drawing.Printing;
using System.Net.WebSockets;

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
        private IQueryable<SinhVien>? Filter(IQueryable<SinhVien> query, SinhVienSearch sinhVienSearch)
        {
            if (sinhVienSearch != null)
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
                    DateTime ngayBatDau = sinhVienSearch.NgayBatDau.Value;
                    if (ngayBatDau >= (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue && ngayBatDau <= (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                    {
                        query = query.Where(s => s.NgaySinh.Value.Date >= ngayBatDau.Date);
                        
                    }
                }
                if (sinhVienSearch.NgayKetThuc.HasValue)
                {
                    DateTime ngayKetThuc = sinhVienSearch.NgayKetThuc.Value;
                    if (ngayKetThuc >= (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue && ngayKetThuc <= (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                    {
                        query = query.Where(s => s.NgaySinh.Value.Date <= ngayKetThuc.Date);
                       
                    }
                }
                if (sinhVienSearch.idLopHoc != -1)
                {
                    query = query.Where(s => s.LHoc.ID == sinhVienSearch.idLopHoc);
                    
                }
                if (sinhVienSearch.ID != -1)
                {
                    query = query.Where(s => s.ID == sinhVienSearch.ID);
                   
                }
            }
            return query;
        }


        public async Task<PageView<SinhVien>> getPageData(int pageNumber, int pageSize, SinhVienSearch sinhVienSearch)
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
                        PageCount = (int)Math.Ceiling((double)total / pageSize) 
                    };

                }
            }
            
        }
    }
}
