using Lotter.Infrastructurey.Data.Module;
using Lottery.Domain.UseCases;
using Lottery.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Reflection;
using FluentValidation.AspNetCore;

namespace Lottery.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lottery.Api", Version = "v1" });
            });
            services.AddDbContext<LotteryContext>(opts =>
            {
                var connectionString = Configuration.GetConnectionString("Lottery");
                opts.UseSqlServer(connectionString);
            });
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDataModule();
            services.AddTransient<ManageCampaign>();

            var assembly = Assembly.GetAssembly(this.GetType());

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddMaps(assembly));
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(assembly));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lottery.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LotteryContext>();

                context?.Database.Migrate();
            }
        }
    }
}
