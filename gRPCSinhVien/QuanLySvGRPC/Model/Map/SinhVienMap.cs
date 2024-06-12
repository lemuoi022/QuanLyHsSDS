using FluentNHibernate.Mapping;
using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Model.Map
{
    internal class SinhVienMap : ClassMap<SinhVien>
    {
        public SinhVienMap()
        {
            Table("SinhVien");
            Id(s => s.ID).Column("id").GeneratedBy.Identity();
            Map(s => s.Ten).Length(255).CustomSqlType("nvarchar"); ;
            Map(s => s.DiaChi).Length(255).CustomSqlType("nvarchar");
            Map(s => s.NgaySinh);
            Map(s => s.GioiTinh).Column("gioitinh");
            References(s => s.LHoc).Column("id_lophoc").Not.Nullable().Fetch.Join();
        }

    }
}
