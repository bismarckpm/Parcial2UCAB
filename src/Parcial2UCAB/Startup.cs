using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Parcial2UCAB.Persistence.DAOs.Implementations;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Persistence.Database;

namespace Parcial2UCAB
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
            /*services.AddDbContext<Parcial2DbContext>(options =>
            options.UseNpgsql(Configuration["DBConnectionString"], x => x.UseNetTopologySuite()));*/

            services.AddDbContext<Parcial2DbContext>(
              options => options.UseSqlServer(Configuration.GetConnectionString("cadenaRebeca")));
            services.AddTransient<IParcial2DbContext, Parcial2DbContext>();
            services.AddTransient<IActorDAO, ActorDAO>();
            services.AddTransient<IPeliculaDAO, PeliculaDAO>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Parcial2UCAB", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parcial2UCAB v1");
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
