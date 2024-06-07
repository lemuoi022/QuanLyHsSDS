using BlazorQuanLySinhVien.DTO;

namespace BlazorQuanLySinhVien.ServiceBlazor.Interface
{
    public interface ISinhVienServiceBlazor
    {
        Task<bool> addSinhVienAsync(SinhVienDTO sinhVienDTO);
        Task<bool> delSinhVienAsync(SinhVienDTO sinhVienDTO);
        //Task<List<SinhVienDTO>> getAllSinhVienAsync(List<SinhVienDTO> listSinhVien);
        Task<PageViewDTO<SinhVienDTO>> getPageSinhVien(int pageNumber, int pageSize, SinhVienSearchDTO svSearch);
        Task<SinhVienDTO> getSinhVienByIdAsync(SinhVienDTO sinhVienDTO);
        Task<bool> updateSinhVienAsync(SinhVienDTO sinhVienDTO);
    }
}