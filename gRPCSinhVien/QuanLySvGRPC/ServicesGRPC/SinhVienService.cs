using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Model;
using QuanLySvGRPC.Model.Domain;
using QuanLySvGRPC.Protos;

namespace QuanLySvGRPC.Services
{
    //public class SinhVienService : ISinhVienService
    //
    //
    
    public class SinhVienService : SinhVienRPC.SinhVienRPCBase
    {
        private readonly ILogger<SinhVienService> _logger;
        private readonly IQuanLySv _quanLySv;
        private readonly IQuanLyLh _quanLyLh;
        private readonly IQuanLyGv _quanLyGv;

        public SinhVienService(ILogger<SinhVienService> logger, IQuanLySv quanLySv,
            IQuanLyGv quanLyGv, IQuanLyLh quanLyLh)
        {
            _logger = logger;
            _quanLySv = quanLySv;
            _quanLyGv = quanLyGv;
            _quanLyLh = quanLyLh;
        }
        public SinhVienReply ModelSinhvien(int idSinhVien)
        {
            var sv = _quanLySv.timKiemSv(idSinhVien);
            if (sv != null)
            {
                var lh = _quanLyLh.lopHocDetailById(sv.LHoc.ID);
                var gv = _quanLyGv.giaoVienDetailById(lh.GVien.ID);
                return new SinhVienReply()
                {
                    ID = sv.ID,
                    Ten = sv.Ten,
                    Ngaysinh = sv.NgaySinh.HasValue ? sv.NgaySinh.Value.ToUniversalTime().ToTimestamp() : null,
                    DiaChi = sv.DiaChi,
                    LopHoc = new LHoc()
                    {
                        ID = lh.ID,
                        TenLop = lh.TenLop,
                        MonHoc = lh.MonHoc,
                        Gvien = new GVien()
                        {
                            ID = gv.ID,
                            Ten = gv.Ten,
                            Ngaysinh = gv.NgaySinh.ToUniversalTime().ToTimestamp()
                        }
                    }
                };
            }
            return new SinhVienReply();
        }

        public override Task<SinhVienReply> GetSinhVienDetail(SinhVienRequest request, ServerCallContext context)
        {
            if (ModelSinhvien(request.Id) != null)
            {
                return Task.FromResult(ModelSinhvien(request.Id));
            }
            else return Task.FromResult(new SinhVienReply());
        }
        public override Task<ListSinhVienReply> GetAllSinhVien(SinhVienRequest request, ServerCallContext context)
        {
            var listSv = _quanLySv.layDsachSv();
            List<SinhVienReply> listSinhVien = new List<SinhVienReply>();
            foreach (var sv in listSv)
            {
                listSinhVien.Add(ModelSinhvien(sv.ID));
            }

            return Task.FromResult(new ListSinhVienReply()
            {
                SvReply = { listSinhVien }
            });
        }
        

        public override Task<SinhVienReply> UpdateSinhVien(SinhVienModelRequest request, ServerCallContext context)
        {
            var sv = new SinhVien()
            {
                ID = request.ID,
                Ten = request.Ten,
                NgaySinh = request.Ngaysinh.ToDateTime(),
                DiaChi = request.DiaChi,
                LHoc = _quanLyLh.lopHocDetailById(request.IdLopHoc)
            };
            var sinhvien = _quanLySv.themHoacSuaSv(sv);
            return Task.FromResult(ModelSinhvien(sinhvien.ID));
        }
        public override Task<SinhVienReply> AddSinhVien(SinhVienModelRequest request, ServerCallContext context)
        {
            var sv = new SinhVien()
            {
                Ten = request.Ten,
                NgaySinh = request.Ngaysinh.ToDateTime(),
                DiaChi = request.DiaChi,
                LHoc = _quanLyLh.lopHocDetailById(request.IdLopHoc)

            };
            var sinhvien = _quanLySv.themHoacSuaSv(sv);
            return Task.FromResult(ModelSinhvien(sinhvien.ID));
        }
        public override Task<BoolValue> DeleteSinhVien(SinhVienRequest request, ServerCallContext context)
        {
            var result = _quanLySv.xoaSv(request.Id);
            var response = new BoolValue { Value = result };
            return Task.FromResult(response);
        }

        public override Task<ListSinhVienReply> ArrangeSinhVien(SinhVienRequest request, ServerCallContext context)
        {
            var listSv = _quanLySv.sapXepSinhVien();
            List<SinhVienReply> listSinhVien = new List<SinhVienReply>();
            foreach (var sv in listSv)
            {
                listSinhVien.Add(ModelSinhvien(sv.ID));
            }

            return Task.FromResult(new ListSinhVienReply()
            {
                SvReply = { listSinhVien }
            });
        }
        public LHoc ModelLopHoc(int idLopHoc)
        {

            var lh = _quanLyLh.lopHocDetailById(idLopHoc);
            var gv = _quanLyGv.giaoVienDetailById(lh.GVien.ID);
            return new LHoc()
            {
                ID = lh.ID,
                TenLop = lh.TenLop,
                MonHoc = lh.MonHoc,
                Gvien = new GVien()
                {
                    ID = gv.ID,
                    Ten = gv.Ten,
                    Ngaysinh = gv.NgaySinh.ToUniversalTime().ToTimestamp()
                    
                }

            };

        }
        public override Task<ListLopHocReply> GetAllLopHoc(LopHocRequest request, ServerCallContext context)
        {
            var listLh = _quanLyLh.listLopHoc();
            List<LHoc> listLopHoc = new List<LHoc>();
            foreach (var lh in listLh)
            {
                listLopHoc.Add(ModelLopHoc(lh.ID));
            }

            return Task.FromResult(new ListLopHocReply()
            {
                LhReply = { listLopHoc }
            });
        }
        public override Task<PageSinhVienReply> GetPageSinhVien(PageSinhVienRequest request, ServerCallContext context)
        {
            
            int pageNumber = request.PageNumber > 0 ? request.PageNumber : 1;
            int pageSize = request.PageSize > 0 ? request.PageSize : 10;

            SinhVienSearch svSearch = new SinhVienSearch()
            {
                ID = request.SvSearch.ID,
                Ten = request.SvSearch.Ten ?? "",
                DiaChi = request.SvSearch.DiaChi ?? "",
                NgayBatDau = request.SvSearch.NgayBatDau?.ToDateTime(),
                NgayKetThuc = request.SvSearch.NgayKetThuc?.ToDateTime(),
                idLopHoc = request.SvSearch.IdLopHoc
            };

            var pageData = _quanLySv.GetPageData(pageNumber, pageSize, svSearch).Result;

            var pageReply = new PageSinhVienReply
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                PageCount = pageData.PageCount
            };

            pageReply.SvReply.AddRange(pageData.Data.Select(sv => ModelSinhvien(sv.ID)));

            return Task.FromResult(pageReply);
        }

    }

}

