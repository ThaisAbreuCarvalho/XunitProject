using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApiDomain;
using WebApiDomain.Automapper;
using WebApiDomain.Interface.Repository;
using WebApiDomain.Interfaces.Logic;
using WebApiDomain.Interfaces.Repository;
using WebApiDomain.Interfaces.Services;
using WebApiDomain.Utilities;
using WebApiRepository;

namespace WebApi
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

            services.AddAutoMapper(typeof(AccessTokenAutomapper));

            services.AddMvc();
            
            //logic
            services.AddScoped<ILoginLogic, LoginLogic>();

            //repository
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IAppConfiguration, AppConfiguration>();
            services.AddSingleton<ITokenGenerator, TokenGenerator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
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
