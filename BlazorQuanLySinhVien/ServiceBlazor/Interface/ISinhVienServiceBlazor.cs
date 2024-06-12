using BlazorQuanLySinhVien.DTO;

namespace BlazorQuanLySinhVien.ServiceBlazor.Interface
{
    public interface ISinhVienServiceBlazor
    {
        Task<bool> AddSinhVienAsync(SinhVienDTO sinhVienDTO);
        Task<bool> DelSinhVienAsync(SinhVienDTO sinhVienDTO);
        Task<List<SinhVienDTO>> GetAllSinhVienAsync(List<SinhVienDTO> listSinhVien);
        Task<PageViewDTO<SinhVienDTO>> GetPageSinhVien(int pageNumber, int pageSize, SinhVienSearchDTO svSearch);
        Task<SinhVienDTO> GetSinhVienByIdAsync(SinhVienDTO sinhVienDTO);
        Task<List<SinhVienTheoLopDTO>> ThongKeSinhVienTheoLop(int gender);
        Task<bool> UpdateSinhVienAsync(SinhVienDTO sinhVienDTO);
    }
}