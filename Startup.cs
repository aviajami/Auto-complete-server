using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auto_complete_server.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Auto_complete_server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:53135",
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            //services.AddDbContext<SandboxContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection") ?? 
            //                                      "Server=.//SQLEXPRESS;Database=SandBox;Integrated Security=true"));

            services.AddDbContext<SandboxContext>(opt => opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=SandBox;Integrated Security=true"));

            services.AddScoped<ICitiesContext, CitiesContext>();
            services.AddControllers();

            services.AddMvc(config =>
            {
                config.EnableEndpointRouting = false;
            });
            
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins
            //    (Configuration.GetSection("CrossOrigin").Get<string[]>())
            //    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            //});

            
            app.UseMvc();
        }
    }
}
