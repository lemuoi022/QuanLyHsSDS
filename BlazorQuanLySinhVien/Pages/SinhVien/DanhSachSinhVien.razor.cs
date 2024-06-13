using AntDesign;
using AntDesign.TableModels;
using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.Shared;
using BlazorQuanLySinhVien.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using NHibernate.Util;
using OneOf.Types;
using QuanLySvGRPC.Protos;
using System.Drawing.Printing;



namespace BlazorQuanLySinhVien.Pages.SinhVien
{
    public partial class DanhSachSinhVien
    {
       
        public List<SinhVienDTO> listSinhVien = new List<SinhVienDTO>();
        PopupSinhVien popupSinhVien;
        protected SinhVienSearchDTO svSearch = new SinhVienSearchDTO() { };
        public List<LopHocDTO> listLH = new List<LopHocDTO>();
        //private EditForm formSearch;
        public bool isCreate { get; set; }= true;
        public int total; 
        private int pageNumber = 1;
        private int pageSize = 5;
        private Table<SinhVienDTO> tableSV;
        private MemoryStream excelStream;
        private Popconfirm popconfirm;
        protected override async Task OnInitializedAsync()
        {
            await LoadPageSinhVienAsync();
            await LoadLopHocAsync();
           
        }
        private async Task LoadLopHocAsync()
        {
            listLH = await _lopHocService.GetAllLopHocAsync();
        }
        private async Task LoadPageSinhVienAsync()
        {
           
            var page = await _sinhVienService.GetPageSinhVien(pageNumber, pageSize, svSearch);
            listSinhVien = page.Data;
            total = page.PageCount;
            StateHasChanged();
        }
        private async Task ResetSearchAsync()
        {
            svSearch.ID = 0; 
            await LoadPageSinhVienAsync();
            StateHasChanged();
        }
        private async void DetailUpdateSinhVienAsync(SinhVienDTO sinhVienDTO)
        {  
            popupSinhVien.sinhVienDTO = sinhVienDTO;
            isCreate = false;
            popupSinhVien.IsCreate = false;
            popupSinhVien.open();
        }
        private async void HandleAddSinhVienAsync()
        {
            
            await LoadPageSinhVienAsync();

            
        }
       
        private async Task DeleteSinhVienAsync(SinhVienDTO sinhVienDTO)
        {
            var del = await _sinhVienService.DelSinhVienAsync(sinhVienDTO);
            if (del)
            {
                //await LoadPageSinhVienAsync();
                //await SuccessAsync();
                Task loadPage = LoadPageSinhVienAsync();
                Task succsess = SuccessAsync();
                await Task.WhenAll(loadPage, succsess);
            }
            
        }
        private async Task HandleTableChangeAsync(QueryModel<SinhVienDTO> queryModel)
        {
            pageNumber = queryModel.PageIndex;
            pageSize = queryModel.PageSize;
            await LoadPageSinhVienAsync();
        }

        async void OnFinishSearchAsync(EditContext editContext)
        {
            pageNumber = 1;
            await LoadPageSinhVienAsync();
        }
         void OnFinishFailedSearch(EditContext editContext)
        {
            svSearch = new SinhVienSearchDTO();
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
        public void ClearSearch()
        {
            SinhVienSearchDTO svSearch = new SinhVienSearchDTO()
            {  
            };
        }
        private async Task SuccessAsync()
        {
            await _notice.Success(new NotificationConfig()
            {
                Message = "Successful",
                Description = "Thao tác thành công"
            });
        }
        private async Task ErrorAsync()
        {
            await _notice.Error(new NotificationConfig()
            {
                Message = "Error",
                Description = "Thao tác không thành công"
            });
        }
        
        protected async void CreateDocumentAsync()
        {
            List<SinhVienDTO> listAllSinhVien = new List<SinhVienDTO>();
            var listExport = await _sinhVienService.GetAllSinhVienAsync(listAllSinhVien);
            excelStream = _excelService.CreateExcel(listExport);
            await JS.SaveAs("SinhVien.xlsx", excelStream.ToArray());
        }
    }
     
    
}
