using Analitycs.Alumno.CrossCutting.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Analitycs.Alumno.CrossCutting.Extensions
{
    public static class AppSettingExtesion
    {
        public static void AddAppSettingExtesion(this IServiceCollection services, IConfiguration configuration, AppSettings _appSetting)
        {
            services.AddSingleton(x => x.GetService<IOptions<AppSettings>>().Value);
        }
    }
}
