using BlazorQuanLySinhVien.DTO;

namespace BlazorQuanLySinhVien.ServiceBlazor.Interface
{
    public interface IExcelServiceBlazor
    {
        MemoryStream CreateExcel(List<SinhVienDTO> listSinhVien);
    }
}