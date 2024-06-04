using FluentNHibernate.Mapping;
using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Model.Map
{
    internal class GiaoVienMap : ClassMap<GiaoVien>
    {
        public GiaoVienMap()
        {
            Table("GiaoVien");
            Id(s => s.ID).Column("id");
            Map(s => s.Ten);
            Map(s => s.NgaySinh);
        }
    }
}
