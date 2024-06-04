using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.service.Interface
{
    internal interface IQuanLyLh
    {
        public string danhSachLopHoc();
        public List<LopHoc> listLopHoc();
    }
}
