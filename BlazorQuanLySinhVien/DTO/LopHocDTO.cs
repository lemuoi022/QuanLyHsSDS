//using QuanLySvGRPC.Model.Domain;

using System.ComponentModel.DataAnnotations;

namespace BlazorQuanLySinhVien.DTO
{
    public class LopHocDTO
    {
        public int Stt { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public string TenLop { get; set; }
        public  string MonHoc { get; set; }
        public  string TenGiaoVien { get; set; }
    }
}
