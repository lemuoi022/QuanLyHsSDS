using System.Runtime.Serialization;
using System.ServiceModel;

namespace Shared
{




    [DataContract]
    public class SinhVien
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Ten { get; set; }

        [DataMember(Order = 3)]
        public DateTime NgaySinh { get; set; }

        [DataMember(Order = 4)]
        public string DiaChi { get; set; }

        [DataMember(Order = 5)]
        public LopHoc LopHoc { get; set; }
    }

    [DataContract]
    public class LopHoc
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string TenLop { get; set; }

        [DataMember(Order = 3)]
        public string MonHoc { get; set; }

        [DataMember(Order = 4)]
        public GiaoVien GiaoVien { get; set; }
    }

    [DataContract]
    public class GiaoVien
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Ten { get; set; }

        [DataMember(Order = 3)]
        public DateTime NgaySinh { get; set; }
    }

    [DataContract]
    public class SinhVienRequest
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }
    }

    [DataContract]
    public class SinhVienModelRequest
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Ten { get; set; }

        [DataMember(Order = 3)]
        public DateTime NgaySinh { get; set; }

        [DataMember(Order = 4)]
        public string DiaChi { get; set; }

        [DataMember(Order = 5)]
        public int IdLopHoc { get; set; }
    }

    [DataContract]
    public class SinhVienSearchRequest
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Ten { get; set; }

        [DataMember(Order = 3)]
        public DateTime NgayBatDau { get; set; }

        [DataMember(Order = 4)]
        public DateTime NgayKetThuc { get; set; }

        [DataMember(Order = 5)]
        public string DiaChi { get; set; }

        [DataMember(Order = 6)]
        public int IdLopHoc { get; set; }
    }

    [DataContract]
    public class PageSinhVienReply
    {
        [DataMember(Order = 1)]
        public List<SinhVien> SvReply { get; set; }

        [DataMember(Order = 2)]
        public int PageCount { get; set; }

        [DataMember(Order = 3)]
        public int PageSize { get; set; }

        [DataMember(Order = 4)]
        public int PageNumber { get; set; }
    }

    [DataContract]
    public class PageSinhVienRequest
    {
        [DataMember(Order = 1)]
        public int PageSize { get; set; }

        [DataMember(Order = 2)]
        public int PageNumber { get; set; }

        [DataMember(Order = 3)]
        public SinhVienSearchRequest SvSearch { get; set; }
    }

    [DataContract]
    public class LopHocRequest
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }
    }

    [DataContract]
    public class ListLopHocReply
    {
        [DataMember(Order = 1)]
        public List<LopHoc> LhReply { get; set; }
    }

    [DataContract]
    public class ListSinhVienReply
    {
        [DataMember(Order = 1)]
        public List<SinhVien> SvReply { get; set; }
    }

    [ServiceContract]
    public interface ISinhVienService
    {
        [OperationContract]
        Task<SinhVien> GetSinhVienDetail(SinhVienRequest request);

        [OperationContract]
        Task<ListSinhVienReply> GetAllSinhVien(SinhVienRequest request);

        [OperationContract]
        Task<SinhVien> UpdateSinhVien(SinhVienModelRequest request);

        [OperationContract]
        Task<bool> DeleteSinhVien(SinhVienRequest request);

        [OperationContract]
        Task<SinhVien> AddSinhVien(SinhVienModelRequest request);

        [OperationContract]
        Task<ListSinhVienReply> ArrangeSinhVien(SinhVienRequest request);

        [OperationContract]
        Task<PageSinhVienReply> GetPageSinhVien(PageSinhVienRequest request);
    }

    [ServiceContract]
    public interface ILopHocService
    {
        [OperationContract]
        Task<ListLopHocReply> GetAllLopHoc(LopHocRequest request);
    }
}



