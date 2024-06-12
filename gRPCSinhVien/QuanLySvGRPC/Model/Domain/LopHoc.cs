namespace QuanLySvGRPC.Model.Domain
{
    public class LopHoc
    {
        public virtual int ID { get; set; }
        public virtual string TenLop { get; set; }
        public virtual string MonHoc { get; set; }
        public virtual GiaoVien GVien { get; set; }

        public override string ToString()
        {
            return $"{ID} - {TenLop} - {MonHoc} - {GVien}";
        }
    }
}
