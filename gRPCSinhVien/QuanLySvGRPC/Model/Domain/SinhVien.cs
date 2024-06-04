namespace QuanLySvGRPC.Model.Domain
{
    public class SinhVien
    {
        public virtual int ID { get; set; }
        public virtual string Ten { get; set; }
        public virtual DateTime NgaySinh { get; set; }
        public virtual string DiaChi { get; set; }
        public virtual LopHoc LHoc { get; set; }

        public override string ToString()
        {
            return $"Ma so {this.ID}, Ten {this.Ten}," +
                $" Ngay sinh: {this.NgaySinh.ToString("dd/MM/yyyy")}, DiaChi: {DiaChi}, Lop: {this.LHoc.TenLop} ";
        }
    }
}
