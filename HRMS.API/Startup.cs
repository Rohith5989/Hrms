using HRMS.Business;
using HRMS.Business.Interfaces;
using HRMS.Repository;
using HRMS.Repository.Interfaces;
using HRMS.Repository.Models;
using HRMS.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API
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
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<HrmsDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));

            services.AddControllers();

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    opt.Lockout.MaxFailedAccessAttempts = 3;

                });


            services.AddTransient<IEmployeeBusiness, EmployeeBusiness >();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentBusiness, DepartmentBusiness>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IAccountsBusiness, AccountsBusiness>();
            services.AddTransient<IAccountsRepository, AccountsRepository>();

            services.AddAutoMapper(typeof(AutoMapperConfig));
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMS.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
