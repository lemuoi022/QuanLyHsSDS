namespace QLSinhVien_SDS_daotao.Model
{
    internal class LopHoc
    {
        public virtual int ID { get; set; }
        public virtual string TenLop { get ; set; }
        public virtual string MonHoc { get; set; }
        public virtual GiaoVien GVien { get; set; }
    }
}