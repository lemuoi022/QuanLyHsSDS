using AntDesign;
using AntDesign.Charts;
using BlazorQuanLySinhVien.DTO;
using Title = AntDesign.Charts.Title;

namespace BlazorQuanLySinhVien.Pages.SinhVien
{
    partial class ChartSinhVien
    {
        private int value = 0;
        public List<SinhVienTheoLopDTO> sv1 = new List<SinhVienTheoLopDTO>();
        object[] data1 = new object[0];
        object[] data2 = new object[0];
        IChartComponent barChart;
        IChartComponent pieChart;

        protected override async Task OnInitializedAsync()
        {
            pieChart = new Pie();
            ThongKeAsync();
           
        }
        public async Task ThongKeAsync()
        {
            sv1 = await _sinhVienService.ThongKeSinhVienTheoLop(value);
            data1 = sv1.Select(item => new { tenlop = item.TenLop, sosinhvien = item.SoSinhVien }).ToArray();
            int tongSoSinhVien = sv1.Sum(item => item.SoSinhVien);
            foreach (var item in sv1) 
            { 
                item.PhanTram = (double)item.SoSinhVien / tongSoSinhVien * 100;
            }
            data2 = sv1.Select(item => new { tenlop = item.TenLop, phantram = item.PhanTram }).ToArray();
            await barChart.ChangeData(data1);
           await pieChart.ChangeData(data2);
        }
        private async Task HandleRadioChangeAsync(int selectedValue)
        {
            ThongKeAsync();
        }
        ColumnConfig config1 = new ColumnConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "Thống kê sinh viên theo lớp"
            },
            ForceFit = true,
            Padding = "auto",
            XField = "tenlop",
            YField = "sosinhvien",
            Meta = new
            {

                tenlop = new
                {
                    Alias = "Lớp"
                },
                sosinhvien = new
                {
                    Alias ="số sinh viên"
                }
            }
        };
         PieConfig config2 = new PieConfig
        {
            ForceFit = true,
            Title = new Title
            {
                Visible = true,
                Text = "phần trăm sinh viên trên tổng"
            },
            Description = new Description
            {
                Visible = true,
                Text = ""
            },
            Radius = 0.8,
            AngleField = "phantram",
            ColorField = "tenlop",
            Label = new PieLabelConfig
            {
                Visible = true,
                Type = "inner"
            }
        };
    }
}
