using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.repository.Interface
{
    internal interface ILopHocRepository
    {
        public List<LopHoc> getAllLopHoc();
        public LopHoc getLopHocById(int id);
    }
}
