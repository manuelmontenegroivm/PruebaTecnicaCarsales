using RickAndMortyBackend.Implementaciones;
using RickAndMortyBackend.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RickAndMortyBackend.Implementation;

namespace RickAndMortyBackend
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

            services.AddHttpClient("RickAndMortyBackend", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:RickAndMortyBackend"]);
            });

            services.AddScoped<ICharacterService, CharacterImplementation>();
            services.AddScoped<ILocationService, LocationImplementation>();
            services.AddScoped<IEpisodeService, EpisodeImplementation>();

            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins(Configuration["Cors"])
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .SetIsOriginAllowed((host) => true)
                                        .AllowCredentials());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RickAndMortyBackend V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"RickAndMortyBackend {groupName}",
                    Version = groupName,
                    Description = "RickAndMortyBackend v1",
                    Contact = new OpenApiContact()
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }
    }
}
