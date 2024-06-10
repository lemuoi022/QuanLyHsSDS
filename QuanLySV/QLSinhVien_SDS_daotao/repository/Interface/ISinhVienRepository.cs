using QLSinhVien_SDS_daotao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.repository.Interface
{
    internal interface ISinhVienRepository
    {
        public List<SinhVien> getAllSinhVien();
        public Boolean insertSinhVien(SinhVien sv);
        public Boolean updateSinhVien(SinhVien sv);
        public Boolean deleteSinhVien(SinhVien sv);
        public SinhVien getSinhVienById(int id);
    }
}
