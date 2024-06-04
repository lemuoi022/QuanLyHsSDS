using BlazorQuanLySinhVien.DTO;

namespace BlazorQuanLySinhVien.ServiceBlazor.Interface
{
    public interface ILopHocServiceBlazor
    {
        Task<List<LopHocDTO>> getAllLopHocAsync();
    }
}