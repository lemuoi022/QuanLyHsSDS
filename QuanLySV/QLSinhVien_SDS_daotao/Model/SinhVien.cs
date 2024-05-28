using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Model
{
    internal class SinhVien
    {
        public virtual int ID { get; set; }
        public virtual string Ten { get ; set ; }
        public virtual DateTime NgaySinh { get ; set; }
        public virtual string DiaChi { get; set; }
        public virtual LopHoc LHoc { get ; set ; }

        public virtual string displaySv()
        {
            return "\nMa so: " + this.ID + " ,Tên: " + this.Ten
                + " ,Ngay sinh: " + this.NgaySinh + " ,Dia chi: " + this.DiaChi + " ,Lop hoc: " + this.LHoc.TenLop;
        }
    }
}
