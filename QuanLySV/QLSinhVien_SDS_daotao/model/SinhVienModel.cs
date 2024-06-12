using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Model
{
    internal class SinhVienModel
    {
        public  int ID { get; set; }
        public  string Ten { get; set; }
        public  DateTime NgaySinh { get; set; }
        public  string DiaChi { get; set; }
        public  int idLHoc { get; set; }
    }
}
