﻿using QuanLySvGRPC.Model;
using QuanLySvGRPC.Model.Domain;

namespace QuanLySvGRPC.Repository.Interface
{
    public interface ISinhVienRepository
    {
        public List<SinhVien> getAllSinhVien();
        public SinhVien insertOrUpadateSinhVien(SinhVien sv);
        public Boolean deleteSinhVien(SinhVien sv);
        public SinhVien getSinhVienById(int id);
        Task<PageView<SinhVien>> getPageData(int pageNumber, int pageSize, SinhVienSearch sinhVienSearch);
    }
}