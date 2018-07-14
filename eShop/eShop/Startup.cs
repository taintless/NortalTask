using AutoMapper;
using eShop.Data;
using eShop.Data.Entities;
using eShop.Data.Repositories;
using eShop.DataContracts;
using eShop.DataContracts.Dtos;
using eShop.ServiceContracts;
using eShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Product, ProductDto>();
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EShopConnection")));
            
            services.AddScoped<IOsesRepository, OsesRepository>();
            services.AddScoped<IManufacturersRepository, ManufacturersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IFiltersService, FiltersService>();
            services.AddScoped<IProductsService, ProductsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
