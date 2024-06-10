using System.ComponentModel.DataAnnotations;

namespace BlazorQuanLySinhVien.DTO
{
    public class SinhVienDTO
    {
        public int Stt { get; set; }
        public int ID { get; set; }
        [Required]
        [MinLength(2)]
        public string Ten { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        [MinLength(2)]
        public string DiaChi { get; set; }
        
        public int? IdLopHoc { get; set; }
        public string TenLop { get; set; }
    }
}
