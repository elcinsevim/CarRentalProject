using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddControllers();
            services.AddSingleton<ICarService, CarManager>( );  //ref olu�tur arkada-i�inde data tutmuyorsa kullan�rs�n
            services.AddSingleton<ICarDal, EfCarDal>();

            services.AddSingleton<IBrandService, BrandManager>();  //ref olu�tur arkada-i�inde data tutmuyorsa kullan�rs�n
            services.AddSingleton<IBrandDal, EfBrandDal>();

            services.AddSingleton<IColorService, ColorManager>();  //ref olu�tur arkada-i�inde data tutmuyorsa kullan�rs�n
            services.AddSingleton<IColorDal, EfColorDal>();

            services.AddSingleton<ICustomerService, CustomerManager>();  //ref olu�tur arkada-i�inde data tutmuyorsa kullan�rs�n
            services.AddSingleton<ICustomerDal, EfCustomerDal>();

            services.AddSingleton<IRentalService, RentalManager>();  //ref olu�tur arkada-i�inde data tutmuyorsa kullan�rs�n
            services.AddSingleton<IRentalDal, EfRentalDal>();

            services.AddSingleton<IUserService, UserManager>();  //ref olu�tur arkada-i�inde data tutmuyorsa kullan�rs�n
            services.AddSingleton<IUserDal, EfUserDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
