using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.ServiceBlazor.Interface;
using Grpc.Core;
using QuanLySvGRPC.Protos;

namespace BlazorQuanLySinhVien.Service
{
    public class SinhVienServiceBlazor : ISinhVienServiceBlazor
    {
        private readonly SinhVienRPC.SinhVienRPCClient _sinhVienClient;

        public SinhVienServiceBlazor(SinhVienRPC.SinhVienRPCClient sinhVienClient)
        {
            _sinhVienClient = sinhVienClient;
        }
        public async Task<List<SinhVienDTO>> getAllSinhVienAsync(List<SinhVienDTO> listSinhVien)
        {
            var request = new SinhVienRequest { Id = 1 };
            var response = await _sinhVienClient.GetAllSinhVienAsync(request);
            int stt = 1;
            listSinhVien = response.SvReply.Select(sv =>
            {
                var ngaySinh = new DateTime(sv.Ngaysinh.Year, sv.Ngaysinh.Month, sv.Ngaysinh.Day);
                return new SinhVienDTO() { Stt = stt++, ID = sv.ID, Ten = sv.Ten, DiaChi = sv.DiaChi, NgaySinh = ngaySinh, TenLop = sv.LopHoc.TenLop, IdLopHoc = sv.LopHoc.ID };
            }).ToList();
            return listSinhVien;
        }
        public async Task<bool> delSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var request = new SinhVienRequest { Id = sinhVienDTO.ID };
            var response = await _sinhVienClient.DeleteSinhVienAsync(request);
            return response.Value;
        }
        public async Task<SinhVienDTO> getSinhVienByIdAsync(SinhVienDTO sinhVienDTO)
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
                        NgaySinh = new DateTime(response.Ngaysinh.Year, response.Ngaysinh.Month, response.Ngaysinh.Day),
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
        public async Task<bool> addSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var request = new SinhVienModelRequest
            {
                ID = sinhVienDTO.ID,
                Ten = sinhVienDTO.Ten,
                Ngaysinh = new Birthday
                {
                    Day = sinhVienDTO.NgaySinh.Day,
                    Month = sinhVienDTO.NgaySinh.Month,
                    Year = sinhVienDTO.NgaySinh.Year
                },
                DiaChi = sinhVienDTO.DiaChi,
                IdLopHoc = sinhVienDTO.IdLopHoc
            };

            var response = await _sinhVienClient.AddSinhVienAsync(request);
            return response != null;
        }
        public async Task<bool> updateSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var request = new SinhVienModelRequest
            {
                ID = sinhVienDTO.ID,
                Ten = sinhVienDTO.Ten,
                Ngaysinh = new Birthday
                {
                    Day = sinhVienDTO.NgaySinh.Day,
                    Month = sinhVienDTO.NgaySinh.Month,
                    Year = sinhVienDTO.NgaySinh.Year
                },
                DiaChi = sinhVienDTO.DiaChi,
                IdLopHoc = sinhVienDTO.IdLopHoc
            };

            var response = await _sinhVienClient.UpdateSinhVienAsync(request);
            return response != null;
        }
        //public List
    }
}
