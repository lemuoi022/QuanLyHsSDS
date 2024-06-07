using AntDesign;
using AntDesign.TableModels;
using BlazorQuanLySinhVien.DTO;
using BlazorQuanLySinhVien.Shared;
using BlazorQuanLySinhVien.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using NHibernate.Util;
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
        protected override async Task OnInitializedAsync()
        {
            await loadPageSinhVienAsync();
            await loadLopHocAsync();
           
        }
        private async Task loadLopHocAsync()
        {
            listLH = await _lopHocService.getAllLopHocAsync();
        }
        private async Task loadPageSinhVienAsync()
        {
           
            var page = await _sinhVienService.getPageSinhVien(pageNumber, pageSize, svSearch);
            listSinhVien = page.Data;
            total = page.PageCount*page.PageSize;
            StateHasChanged();
        }
        private async Task ResetSearch()
        {
            svSearch.ID = 0; 
            await loadPageSinhVienAsync();
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
            await loadPageSinhVienAsync();
            
        }
       
        private async Task DeleteSinhVien(SinhVienDTO sinhVienDTO)
        {
            var del = await _sinhVienService.delSinhVienAsync(sinhVienDTO);
            if (del)
            {
                loadPageSinhVienAsync();
      
            }
            
        }
        private async Task HandleTableChange(QueryModel<SinhVienDTO> queryModel)
        {
            pageNumber = queryModel.PageIndex;
            pageSize = queryModel.PageSize;
            await loadPageSinhVienAsync();
        }

        async void OnFinishSearchAsync(EditContext editContext)
        {
            pageNumber = 1;
            await loadPageSinhVienAsync();
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
        MemoryStream excelStream;

        /// <summary>
        /// Create and download the Excel document.
        /// </summary>
        protected async void CreateDocument()
        {
            await loadPageSinhVienAsync();
            excelStream = _excelService.CreateExcel(listSinhVien);
            await JS.SaveAs("SinhVien.xlsx", excelStream.ToArray());
        }
        //void OnChange()
        //{
        //    pageNumber++;
        //}
    }
}
