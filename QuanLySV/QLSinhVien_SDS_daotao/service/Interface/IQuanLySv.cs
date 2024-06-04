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
        public string layDsachSv();
        public Boolean themSv();
        public Boolean suaSv(int maSo);

        public Boolean xoaSv(int maSo);
        public string sapXepSinhVien();
        public string timKiemSv(int maSo);
    }
}
