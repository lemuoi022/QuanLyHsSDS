using AntDesign;
using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NHibernate.Util;
using QuanLySvGRPC.Protos;

namespace BlazorQuanLySinhVien.Pages.SinhVien
{
    public partial class DanhSachSinhVien
    {

        public List<SinhVienDTO> listSinhVien = new List<SinhVienDTO>();
        PopupSinhVien popupSinhVien;
        
        public bool isCreate { get; set; }= true;
        private string txtValue { get; set; } 
        private bool loading;
        protected override async Task OnInitializedAsync()
        {
            await loadData();
            
        }
        private async Task loadData()
        {
            
            listSinhVien = await _sinhVienService.getAllSinhVienAsync(listSinhVien);
            StateHasChanged();
        }
        private async void DetailUpdateSinhVien(SinhVienDTO sinhVienDTO)
        {  
            popupSinhVien.sinhVienDTO = sinhVienDTO;
            isCreate = false;
            popupSinhVien.IsCreate = false;
            popupSinhVien.open();
        }
        private async void HandleAddSinhVien()
        {
            await loadData();
            StateHasChanged();
        }
        private async void DeleteSinhVien(SinhVienDTO sinhVienDTO)
        {
            var del = await _sinhVienService.delSinhVienAsync(sinhVienDTO);
            loadData();
        }
        
        public async Task searchSinhVienAsync()
        {
            await _message.Loading($"searching {txtValue}", 2);
            if (txtValue!=null)
            {
                SinhVienDTO sinhVienDTO = new SinhVienDTO() { ID = int.Parse(txtValue) };
                var search = await _sinhVienService.getSinhVienByIdAsync(sinhVienDTO);
                if (search != null)
                {
                    listSinhVien.Clear();
                    listSinhVien.Add(search);
                }
                else
                {
                    loadData();
                }
            }
           else { loadData(); }
            
        }

        public void Clear()
        {
            popupSinhVien.sinhVienDTO = new SinhVienDTO()
            {
                NgaySinh = DateTime.Now
            }; ;
            popupSinhVien.IsCreate = true;
            isCreate = true;
        }
    }
}
