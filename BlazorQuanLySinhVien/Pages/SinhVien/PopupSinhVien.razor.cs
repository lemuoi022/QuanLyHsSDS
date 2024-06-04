using BlazorQuanLySinhVien.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;
using QuanLySvGRPC.Protos;
using QuanLySvGRPC.Services;

namespace BlazorQuanLySinhVien.Pages.SinhVien
{
    partial class PopupSinhVien
    {

        public SinhVienDTO? sinhVienDTO = new SinhVienDTO()
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

        protected override void OnInitialized()
        {
            loadLopHoc();
            
         
            base.MemberwiseClone();
        }
        async Task SubmitAsync()
        {
            if (visible)
            {
                bool success;
                if (IsCreate)
                {
                    success = await _sinhVienService.addSinhVienAsync(sinhVienDTO); 
                }
                else
                {
                    success = await _sinhVienService.updateSinhVienAsync(sinhVienDTO);
                }
               if (success)
                    {
                        OnAddSinhVien.InvokeAsync();
                        close();
                        Success();
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
            loadLopHoc();
            this.visible = true;
        }

        public void close()
        {
            Clear?.Invoke();
            this.visible = false;
        }
        private async Task loadLopHoc()
        {
           listLopHoc = await _lopHocService.getAllLopHocAsync();
        }
        private void Error()
        {
            _message.Error("Có lỗi xảy ra");
        }
        private void Success()
        {
            _message.Success("thực hiện thành công");
        }
        private void SubmitFalse()
        {
            Error();
        }
    }
}
