using AntDesign;
using AntDesign.Charts;
using Title = AntDesign.Charts.Title;
namespace BlazorQuanLySinhVien.Pages.SinhVien
{
    partial class ChartSinhVien
    {
        #region 示例1

        object[] data1 =
    {
        new
        {
            type = "家具家电",
            sales = 38
        },
        new
        {
            type = "粮油副食",
            sales = 52
        },
        new
        {
            type = "生鲜水果",
            sales = 61
        },
        new
        {
            type = "美容洗护",
            sales = 145
        },
        new
        {
            type = "母婴用品",
            sales = 48
        },
        new
        {
            type = "进口食品",
            sales = 38
        },
        new
        {
            type = "食品饮料",
            sales = 38
        },
        new
        {
            type = "家庭清洁",
            sales = 38
        }
    };

        ColumnConfig config1 = new ColumnConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "基础柱状图"
            },
            ForceFit = true,
            Padding = "auto",
            XField = "type",
            YField = "sales",
            Meta = new
            {
                Type = new
                {
                    Alias = "类别"
                },
                Sales = new
                {
                    Alias = "销售额(万)"
                }
            }
        };

        #endregion 示例1



        #region 示例2

        readonly object[] data2 =
        {
        new {value = 1.2},
        new {value = 3.4},
        new {value = 3.7},
        new {value = 4.3},
        new {value = 5.2},
        new {value = 5.8},
        new {value = 6.1},
        new {value = 6.5},
        new {value = 6.8},
        new {value = 7.1},
        new {value = 7.3},
        new {value = 7.7},
        new {value = 8.3},
        new {value = 8.6},
        new {value = 8.8},
        new {value = 9.1},
        new {value = 9.2},
        new {value = 9.4},
        new {value = 9.5},
        new {value = 9.7},
        new {value = 10.5},
        new {value = 10.7},
        new {value = 10.8},
        new {value = 11.0},
        new {value = 11.0},
        new {value = 11.1},
        new {value = 11.2},
        new {value = 11.3},
        new {value = 11.4},
        new {value = 11.4},
        new {value = 11.7},
        new {value = 12.0},
        new {value = 12.9},
        new {value = 12.9},
        new {value = 13.3},
        new {value = 13.7},
        new {value = 13.8},
        new {value = 13.9},
        new {value = 14.0},
        new {value = 14.2},
        new {value = 14.5},
        new {value = 15},
        new {value = 15.2},
        new {value = 15.6},
        new {value = 16.0},
        new {value = 16.3},
        new {value = 17.3},
        new {value = 17.5},
        new {value = 17.9},
        new {value = 18.0},
        new {value = 18.0},
        new {value = 20.6},
        new {value = 21},
        new {value = 23.4}
    };

        readonly HistogramConfig config2 = new HistogramConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "直方图"
            },
            Description = new Description
            {
                Visible = true,
                Text = "通过设置binWidth进行分箱，binWidth决定直方图分箱的数量。"
            },
            ForceFit = true,
            Padding = "auto",
            BinField = "value",
            BinWidth = 2,
            Color = "#1079a0"
        };

        #endregion 示例2
    }
}
