﻿using FluentNHibernate.Mapping;
using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Model.Map
{
    internal class LopHocMap : ClassMap<LopHoc>
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
