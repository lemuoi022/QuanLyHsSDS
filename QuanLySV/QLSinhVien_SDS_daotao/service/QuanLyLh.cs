using QLSinhVien_SDS_daotao.Model;
using QLSinhVien_SDS_daotao.repository.Interface;
using QLSinhVien_SDS_daotao.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_SDS_daotao.service
{

    internal class QuanLyLh : IQuanLyLh
    {
        private readonly ILopHocRepository _lopHocRepository;
        //private readonly ILopHocRepository _lopHocRepository;
        public QuanLyLh(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository ?? throw new ArgumentNullException(nameof(lopHocRepository));
        }
        public string danhSachLopHoc()
        {
            List<LopHoc> listLh = _lopHocRepository.getAllLopHoc();
            string str = "";
            listLh.ForEach(lh => { str += $"{lh.ID}:{lh.TenLop}  "; });
            //listLh.ForEach(lh => { Console.WriteLine(lh); });
            return str ;
        }
        public List<LopHoc> listLopHoc()
        {
            return _lopHocRepository.getAllLopHoc();
        }
    }
}
