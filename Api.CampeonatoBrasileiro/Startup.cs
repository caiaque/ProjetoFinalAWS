
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Infra.Context;
using CampeonatoBrasileiro.Infra.Repositories;
using CampeonatoBrasileiro.Mensageiro;
using CampeonatoBrasileiro.Mensageiro.Interfaces;
using CampeonatoBrasileiro.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiro.App
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
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Meu Swagger", Version = "v1" });
            });

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddDbContext<CampeonatoBrasileiroContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IPartidaRepository), typeof(PartidaRepository));
            services.AddScoped(typeof(ITorneioRepository), typeof(TorneioRepository));
            services.AddScoped<ISend, Send>();
            services.AddMemoryCache();
            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<IJogadorRepository, JogadorRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
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
