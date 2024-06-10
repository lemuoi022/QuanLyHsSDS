using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using QLSinhVien_SDS_daotao.Model;
using NHibernate.Tool.hbm2ddl;

namespace QLSinhVien_SDS_daotao
{
    public static class FluentNHibernateHelper

    {

        public static ISession OpenSession()

        {

            string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=SINHVIEN;Integrated Security=True";

            ISessionFactory sessionFactory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012

                 .ConnectionString(connectionString))

                .Mappings(m => m.FluentMappings .AddFromAssemblyOf<SinhVien>())
                .Mappings(m => m.FluentMappings .AddFromAssemblyOf<GiaoVien>())
                .Mappings(m => m.FluentMappings .AddFromAssemblyOf<LopHoc>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(false, false))

                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }

    }
}
