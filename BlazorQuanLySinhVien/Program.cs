using BlazorQuanLySinhVien.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QuanLySvGRPC;
using QuanLySvGRPC.Protos;
using QuanLySvGRPC.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using BlazorQuanLySinhVien.Service;
using BlazorQuanLySinhVien.ServiceBlazor.Interface;
using BlazorQuanLySinhVien.ServiceBlazor;

namespace BlazorQuanLySinhVien
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddAntDesign();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<ISinhVienServiceBlazor,SinhVienServiceBlazor>();
            builder.Services.AddScoped<ILopHocServiceBlazor, LopHocServiceBlazor>();
            builder.Services.AddGrpcClient<SinhVienRPC.SinhVienRPCClient>(options =>
            {
                options.Address = new Uri("http://localhost:5015");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
          
        }
        
    }
}