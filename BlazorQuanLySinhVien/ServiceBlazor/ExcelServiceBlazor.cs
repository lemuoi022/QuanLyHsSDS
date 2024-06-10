using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.ServiceBlazor.Interface;
using Syncfusion.XlsIO;
using System.Data;

namespace BlazorQuanLySinhVien.ServiceBlazor
{
    public class ExcelServiceBlazor : IExcelServiceBlazor
    {
        public MemoryStream CreateExcel(List<SinhVienDTO> listSinhVien)
        {
            //Create an instance of ExcelEngine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook.
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                //Export data from DataTable to Excel worksheet.
                worksheet.ImportData(listSinhVien, 1, 1, true);

                worksheet.UsedRange.AutofitColumns();

                //Save the document as a stream and return the stream.
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
            return null;
        }
    }
}
