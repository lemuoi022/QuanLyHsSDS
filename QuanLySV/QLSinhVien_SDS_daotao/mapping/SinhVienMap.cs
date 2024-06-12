using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Mapping
{
    internal class SinhVienMap : ClassMap<SinhVien>
    {
        public SinhVienMap() {
            Table("SinhVien");
            Id(s => s.ID).Column("id").GeneratedBy.Identity();
            Map(s => s.Ten);
            Map(s => s.DiaChi);
            Map(s => s.NgaySinh);
            References(s => s.LHoc).Column("id_lophoc").Not.Nullable().Fetch.Join();
        }

    }
}
