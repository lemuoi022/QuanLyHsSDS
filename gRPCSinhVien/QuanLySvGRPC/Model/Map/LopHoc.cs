using FluentNHibernate.Mapping;
using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Model.Map
{
    internal class LopHocMap : ClassMap<LopHoc>
    {
        public LopHocMap()
        {
            Table("LopHoc");
            Id(s => s.ID).Column("id");
            Map(s => s.TenLop).Length(255).CustomSqlType("nvarchar"); ;
            Map(s => s.MonHoc).Length(255).CustomSqlType("nvarchar"); ;
            References(s => s.GVien)
                .Column("id_giaovien")
                .Not.Nullable();
        }
    }
}
