using Grpc.Core;
using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Protos;

namespace QuanLySvGRPC.Services
{
    public class LopHocService : SinhVienRPC.SinhVienRPCBase
    {
        private readonly ILogger<LopHocService> _logger;
        private readonly IQuanLyLh _quanLyLh;
        private readonly IQuanLyGv _quanLyGv;
        public LopHocService(ILogger<LopHocService> logger,
            IQuanLyGv quanLyGv, IQuanLyLh quanLyLh)
        {
            _logger = logger;
            _quanLyGv = quanLyGv;
            _quanLyLh = quanLyLh;
        }

        
    }
}
