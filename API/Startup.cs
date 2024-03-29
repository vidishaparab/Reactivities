using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using MediatR;
using Application.Activities;
using API.Middlewares;

namespace API
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
                services.AddDbContext<DataContext>(opt => 
                
                {
                    opt.UseSqlite(Configuration.GetConnectionString("default"));
                });
                services.AddCors(opt =>{
                            opt.AddPolicy("CORS",policy =>{
                                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                                });
                });
                services.AddMediatR(typeof(List.QueryHandler).Assembly);
                services.AddControllers();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
               
               app.UseMiddleware<ExceptionHandler>();
            
              

                //app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();
                app.UseCors("CORS");
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
