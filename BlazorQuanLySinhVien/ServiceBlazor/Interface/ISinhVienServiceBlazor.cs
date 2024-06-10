using BlazorQuanLySinhVien.DTO;

namespace BlazorQuanLySinhVien.ServiceBlazor.Interface
{
    public interface ISinhVienServiceBlazor
    {
        Task<bool> AddSinhVienAsync(SinhVienDTO sinhVienDTO);
        Task<bool> DelSinhVienAsync(SinhVienDTO sinhVienDTO);
        //Task<List<SinhVienDTO>> getAllSinhVienAsync(List<SinhVienDTO> listSinhVien);
        Task<PageViewDTO<SinhVienDTO>> GetPageSinhVien(int pageNumber, int pageSize, SinhVienSearchDTO svSearch);
        Task<SinhVienDTO> GetSinhVienByIdAsync(SinhVienDTO sinhVienDTO);
        Task<bool> UpdateSinhVienAsync(SinhVienDTO sinhVienDTO);
    }
}