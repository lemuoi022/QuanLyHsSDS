using QuanLySvGRPC.Controller;
using QuanLySvGRPC.Controller.Interface;
using QuanLySvGRPC.Repository;
using QuanLySvGRPC.Repository.Interface;
using QuanLySvGRPC.Services;

namespace QuanLySvGRPC
{

    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();

            builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();
            builder.Services.AddScoped<IGiaoVienRepository, GiaoVienRepository>();
            builder.Services.AddScoped<ILopHocRepository, LopHocRepository>();

            builder.Services.AddScoped<IQuanLySv, QuanLySv>();
            builder.Services.AddScoped<IQuanLyGv, QuanLyGv>();
            builder.Services.AddScoped<IQuanLyLh, QuanLyLh>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<SinhVienService>();
            
      
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}