using FluentNHibernate.Mapping;
using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Mapping
{
    internal class LopHocMap: ClassMap<LopHoc>
    {
        public LopHocMap()
        {
            Table("LopHoc");
            Id(s => s.ID).Column("id");
            Map(s => s.TenLop);
            Map(s => s.MonHoc);
            References(s => s.GVien)
                .Column("id_giaovien")
                .Not.Nullable();
        }
    }
}
