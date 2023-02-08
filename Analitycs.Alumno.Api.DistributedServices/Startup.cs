using Analitycs.Alumno.CrossCutting.Common;
using Analitycs.Alumno.CrossCutting.Extensions;
using Analitycs.Alumno.CrossCutting.IOC;
using Analitycs.Alumno.Infraestructure.Repository.Implementation.Data;
using Analitycs.Alumno.Infraestructure.Repository.Interfaces.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Analitycs.Alumno.Api.DistributedServices
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IServiceCollection Services { get; private set; }

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }


        public IServiceProvider ConfigureServices(IServiceCollection serviceDescriptors)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            serviceDescriptors.AddControllers()
          .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

            serviceDescriptors.AddAppSettingExtesion(Configuration, appSettingsSection.Get<AppSettings>());
            serviceDescriptors.Configure<AppSettings>(appSettingsSection);
            serviceDescriptors.AddSingleton(x => x.GetService<IOptions<AppSettings>>().Value);

            var builder = new ContainerBuilder();

            serviceDescriptors.AddSwaggerExtesion("RetoTecnicoApiAlumnos");
             
            serviceDescriptors.AddTransient<IUnitOfWork, UnitOfWork>(); 
             
            serviceDescriptors.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceDescriptors.AddMemoryCache();
              
            serviceDescriptors.AddSwaggerGen(cfg =>
            {
                cfg.CustomSchemaIds(type => type.ToString()); 
            });


            var autofac = IocAutofacContainer.Initialize(serviceDescriptors);
            return new AutofacServiceProvider(autofac);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
            );
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Portal Finanzas Api v1");
                x.InjectStylesheet("/wwwroot/swagger/header.css");
                x.DocumentTitle = "RetoTecnicoApiAlumnos";
            });
        }
    }
}
