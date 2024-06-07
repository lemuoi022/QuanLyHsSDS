using System.ComponentModel.DataAnnotations;

namespace BlazorQuanLySinhVien.DTO
{
    public class SinhVienSearchDTO
    {
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "The field must be a positive integer greater than 0.")]
        public int ID { get; set; } = -1;
        public string Ten { get; set; } = ""; 
        public string DiaChi { get; set; } = "";
        public DateTime? NgayBatDau { get; set; } = null;
        public DateTime? NgayKetThuc { get; set; } = null;
        public int idLopHoc { get; set; } = -1;
    }
}
