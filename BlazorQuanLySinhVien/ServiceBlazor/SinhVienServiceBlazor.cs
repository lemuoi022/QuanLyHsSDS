using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.ServiceBlazor.Interface;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using QuanLySvGRPC.Protos;

namespace BlazorQuanLySinhVien.ServiceBlazor
{
    public class SinhVienServiceBlazor : ISinhVienServiceBlazor
    {
        private readonly SinhVienRPC.SinhVienRPCClient _sinhVienClient;

        public SinhVienServiceBlazor(SinhVienRPC.SinhVienRPCClient sinhVienClient)
        {
            _sinhVienClient = sinhVienClient;
        }
        public async Task<List<SinhVienDTO>> GetAllSinhVienAsync(List<SinhVienDTO> listSinhVien)
        {
            var request = new SinhVienRequest { Id = 1 };
            var response = await _sinhVienClient.GetAllSinhVienAsync(request);
            int stt = 1;
            listSinhVien = response.SvReply.Select(sv =>
            {

                return new SinhVienDTO() { Stt = stt++, ID = sv.ID, Ten = sv.Ten, DiaChi = sv.DiaChi, NgaySinh = sv.Ngaysinh.ToDateTime(), TenLop = sv.LopHoc.TenLop, IdLopHoc = sv.LopHoc.ID };
            }).ToList();
            return listSinhVien;
        }
        public async Task<bool> DelSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var request = new SinhVienRequest { Id = sinhVienDTO.ID };
            var response = await _sinhVienClient.DeleteSinhVienAsync(request);
            return response.Value;
        }
        public async Task<SinhVienDTO> GetSinhVienByIdAsync(SinhVienDTO sinhVienDTO)
        {
            try
            {
                var request = new SinhVienRequest { Id = sinhVienDTO.ID };
                var response = await _sinhVienClient.GetSinhVienDetailAsync(request);

                if (response != null && response.ID != 0)
                {
                    return new SinhVienDTO
                    {
                        ID = response.ID,
                        Ten = response.Ten,
                        IdLopHoc = response.LopHoc.ID,
                        TenLop = response.LopHoc.TenLop,
                        NgaySinh = response.Ngaysinh.ToDateTime(),
                        DiaChi = response.DiaChi
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (RpcException ex)
            {

                Console.WriteLine($"Lỗi RPC: {ex.Status.Detail}");
                return null;
            }


        }
        public async Task<bool> AddSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var request = new SinhVienModelRequest
            {
                ID = sinhVienDTO.ID,
                Ten = sinhVienDTO.Ten,
                Ngaysinh = sinhVienDTO.NgaySinh.ToUniversalTime().ToTimestamp(),
                DiaChi = sinhVienDTO.DiaChi,
                IdLopHoc = (int)sinhVienDTO.IdLopHoc
            };

            var response = await _sinhVienClient.AddSinhVienAsync(request);
            return response != null;
        }
        public async Task<bool> UpdateSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var request = new SinhVienModelRequest
            {
                ID = sinhVienDTO.ID,
                Ten = sinhVienDTO.Ten,
                Ngaysinh = sinhVienDTO.NgaySinh.ToUniversalTime().ToTimestamp(),
                DiaChi = sinhVienDTO.DiaChi,
                IdLopHoc = (int)sinhVienDTO.IdLopHoc
            };

            var response = await _sinhVienClient.UpdateSinhVienAsync(request);
            return response != null;
        }
        public async Task<PageViewDTO<SinhVienDTO>> GetPageSinhVien(int pageNumber, int pageSize, SinhVienSearchDTO svSearch)
        {
            var request = new PageSinhVienRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SvSearch = new SinhVienSearchRequest()
                {
                    ID = svSearch.ID ?? 0,
                    Ten = svSearch.Ten ?? "",
                    DiaChi = svSearch.DiaChi ?? "",
                    NgayBatDau = svSearch.NgayBatDau?.ToUniversalTime().ToTimestamp(),
                    NgayKetThuc = svSearch.NgayKetThuc?.ToUniversalTime().ToTimestamp(),
                    IdLopHoc = svSearch.idLopHoc ?? 0
                }
            };

            var response = await _sinhVienClient.GetPageSinhVienAsync(request);
            int stt = pageNumber == 1 ? 1 : (pageSize * (pageNumber - 1) + 1);
            return new PageViewDTO<SinhVienDTO>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = response.PageCount,
                Data = response.SvReply.Select(sv =>
                {
                    return new SinhVienDTO()
                    {
                        Stt = stt++,
                        ID = sv.ID,
                        Ten = sv.Ten,
                        DiaChi = sv.DiaChi,
                        NgaySinh = sv.Ngaysinh.ToDateTime(),
                        TenLop = sv.LopHoc.TenLop,
                        IdLopHoc = sv.LopHoc.ID
                    };
                }).ToList()
            };
        }
        public async Task<List<SinhVienTheoLopDTO>> ThongKeSinhVienTheoLop(int gender)
        {
            var request = new SinhVienTheoLopRequest { Gioitinh = gender };
            var response = await _sinhVienClient.ThongKeSinhVienTheoLopAsync(request);
            var listSv = response.SvTheoLop.Select(sv => new SinhVienTheoLopDTO
                    {
                        TenLop = sv.TenLop,
                        SoSinhVien = sv.SoSinhVien
                    })
                    .ToList();
            return listSv;
        }

    }
}
