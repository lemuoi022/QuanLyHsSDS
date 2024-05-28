using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.Implement.Interface
{
    internal interface IQuanLySv
    {
        public string layDsachSv(List<SinhVien> listSv);
        public Boolean themSv(List<SinhVien> listSv,List<LopHoc> listLh);
        public Boolean suaSv(int maSo, List<SinhVien> listSv, List<LopHoc> listLh);

        public Boolean xoaSv(int maSo, List<SinhVien> listSv);
        public string sapXepSinhVien(List<SinhVien> listSv);
        public string timKiemSv(int maSo, List<SinhVien> listSv);
    }
}
