using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.ServiceBlazor.Interface;
using QuanLySvGRPC.Protos;
//using QuanLySvGRPC.Services;

namespace BlazorQuanLySinhVien.ServiceBlazor
{
    public class LopHocServiceBlazor : ILopHocServiceBlazor
    {
        private readonly SinhVienRPC.SinhVienRPCClient _sinhVienClient;

        public LopHocServiceBlazor(SinhVienRPC.SinhVienRPCClient sinhVienClient)
        {
            _sinhVienClient = sinhVienClient;
        }
        public async Task<List<LopHocDTO>> getAllLopHocAsync()
        {
            var request = new LopHocRequest { Id = 1 };
            var response = await _sinhVienClient.GetAllLopHocAsync(request);
            int stt = 1;
            List<LopHocDTO> listLopHoc = response.LhReply.Select(lh =>
            {
                return new LopHocDTO() { Stt = stt++, ID = lh.ID, TenLop = lh.TenLop, MonHoc = lh.MonHoc, TenGiaoVien = lh.Gvien.Ten };
            }).ToList();
            return listLopHoc;
        }
    }
}
