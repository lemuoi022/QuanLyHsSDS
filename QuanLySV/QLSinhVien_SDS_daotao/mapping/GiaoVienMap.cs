using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Mapping
{
    internal class GiaoVienMap:ClassMap<GiaoVien>
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
