using Analitycs.Alumno.Api.DistributedServices; 
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore; 

public static class Program
{
    public static void Main(string[] args)
    { 
        CreateHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateHostBuilder(string[] args)
                  => WebHost.CreateDefaultBuilder(args)
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .ConfigureServices(services => services.AddAutofac());
}