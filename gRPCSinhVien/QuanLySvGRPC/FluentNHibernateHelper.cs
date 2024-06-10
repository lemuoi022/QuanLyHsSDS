using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using QuanLySvGRPC.Model.Domain;
using NHibernate.Tool.hbm2ddl;

namespace QuanLySvGRPC
{
    public class FluentNHibernateHelper
    {
        public static NHibernate.ISession OpenSession()

        {

            string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=SINHVIEN;Integrated Security=True";

            ISessionFactory sessionFactory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012

                 .ConnectionString(connectionString))

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SinhVien>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GiaoVien>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LopHoc>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(false, false))

                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }

    }
}
