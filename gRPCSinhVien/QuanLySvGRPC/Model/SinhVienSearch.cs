﻿namespace QuanLySvGRPC.Model
{
    public class SinhVienSearch
    {
        public int Stt { get; set; }
        public int ID { get; set; } = -1;
        public string Ten { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public DateTime? NgayBatDau { get; set; } = null;
        public DateTime? NgayKetThuc { get; set; } = null;
        public int idLopHoc { get; set; } = -1;
    }
}

