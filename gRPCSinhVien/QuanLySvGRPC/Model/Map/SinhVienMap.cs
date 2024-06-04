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
            Map(s => s.Ten);
            Map(s => s.DiaChi);
            Map(s => s.NgaySinh);
            References(s => s.LHoc).Column("id_lophoc").Not.Nullable().Fetch.Join();
        }

    }
}
