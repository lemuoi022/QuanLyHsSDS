using AntDesign;
using BlazorQuanLySinhVien.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
//using QuanLySvGRPC.Services;

namespace BlazorQuanLySinhVien.Pages.SinhVien
{
    partial class PopupSinhVien
    {

        public SinhVienDTO sinhVienDTO = new SinhVienDTO()
        {
            NgaySinh = DateTime.Now
        };
        [Parameter]
        public Action Clear { get; set; }
        private bool visible = false;
        private string title;
        public List<LopHocDTO> listLopHoc = new List<LopHocDTO>();

        [Parameter]
        public EventCallback OnAddSinhVien { get; set; }


        public EditForm editForm { get; set; }
        [Parameter]
        public bool IsCreate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadLopHocAsync();
        }
        private async Task LoadLopHocAsync()
        {
            listLopHoc = await _lopHocService.GetAllLopHocAsync();
        }
        async Task SubmitAsync()
        {
            if (visible)
            {
                bool success;
                if (IsCreate)
                {
                    if (!sinhVienDTO.IdLopHoc.HasValue)
                    {
                        sinhVienDTO.IdLopHoc = listLopHoc.First().ID;
                    }
                    success = await _sinhVienService.AddSinhVienAsync(sinhVienDTO);
                }
                else
                {
                    success = await _sinhVienService.UpdateSinhVienAsync(sinhVienDTO);
                }
                if (success)
                {
                    OnAddSinhVien.InvokeAsync();
                    close();
                    await Success();

                }
                else
                {
                    Error();
                }


            }
        }
        public void open()
        {
            title = (IsCreate) ? "Thêm sinh viên" : "Sửa sinh viên";

            this.visible = true;
        }

        public void close()
        {
            Clear?.Invoke();
            this.visible = false;
        }

        private void SubmitFalse()
        {

        }
        private async Task Success()
        {
            await _notice.Success(new NotificationConfig()
            {
                Message = "Successful",
                Description = "Thao tác thành công"
            });
        }
        private async Task Error()
        {
            await _notice.Error(new NotificationConfig()
            {
                Message = "Error",
                Description = "Thao tác không thành công"
            });
        }
    }
}
