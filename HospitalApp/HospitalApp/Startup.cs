using Hospital.Tools;
using HospitalApp.Areas.Identity.Pages.Account;
using HospitalApp.DataAccess;
using HospitalApp.DataAccess.Abstract;
using HospitalApp.DataAccess.Concrete;
using HospitalApp.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();


            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // �ki fakt�rl� kimlik do�rulama ve token ayarlar� burada yap�land�r�labilir.
                // Bu ayarlar� varsay�lan de�erlerde b�rakabilirsiniz.
                options.Tokens.EmailConfirmationTokenProvider = "Default";
                options.Tokens.PasswordResetTokenProvider = "Default";
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); // Varsay�lan token sa�lay�c�lar�n� ekleyin.

            services.AddControllersWithViews();
            services.AddRazorPages();



            // Kendi servislerinizi ekleyin.
            services.AddTransient<IHospitalInfoRepository, HospitalInfoRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IApplicationUserRepository,ApplicationUserRepository>(); 
            services.AddTransient<IAppointmentRepository,AppointmentRepository>();  
            services.AddScoped<IEmailSender, EmailSender>();    
            services.AddScoped<ISeedData, SeedData>();
            services.AddScoped<PatientRegisterModel, PatientRegisterModel>();   
            

            // MVC ile Razor Pages'i birlikte kullanmak yerine sadece Razor Pages kullanmak yeterli olabilir
            // services.AddMvc(); // Yorum sat�r� olarak b�rakabilirsiniz.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // G�venli HTTP kullan�m� i�in
            }

            app.UseHttpsRedirection(); // HTTPS y�nlendirmesi
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Kimlik do�rulama i�lemleri
            app.UseAuthorization();  // Yetkilendirme i�lemleri

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area=Admin}/{controller=Hospitals}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            // Veritaban� ba�lang�� verilerini ekleyin
            DataSeeding(app);
        }

        // Veritaban� ba�lang�� verilerini eklemek i�in metod
        private void DataSeeding(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ISeedData>();
                db.Initialize();
            }
        }
    }

}