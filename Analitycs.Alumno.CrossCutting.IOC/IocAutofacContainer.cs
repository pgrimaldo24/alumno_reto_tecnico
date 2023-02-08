using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Analitycs.Alumno.CrossCutting.IOC
{
    public class IocAutofacContainer
    {
        private static IContainer container;

        protected static readonly Lazy<IocAutofacContainer> instance = new Lazy<IocAutofacContainer>(() => new IocAutofacContainer(), true);

        public static IocAutofacContainer Current
        {
            get { return instance.Value; }
        }

        public static IContainer Initialize(IServiceCollection services)
        {

            ContainerBuilder builder;
            try
            {
                builder = new ContainerBuilder();
                builder.Populate(services);


                string[] assemblyScanerPattern = new[] {
                    "Analitycs.Alumno.Application.*.dll",
                    "Analitycs.Alumno.Infraestructure.Repository.*.dll"
                };

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                List<Assembly> assemblies = new List<Assembly>();
                assemblies.AddRange(
                    Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
                             .Where(filename => assemblyScanerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                             .Select(Assembly.LoadFrom)
                    );

                foreach (var assembly in assemblies)
                    builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

                container = builder.Build();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            return container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        public T Resolve<T>(string name, object value)
        {
            return container.Resolve<T>(new NamedParameter(name, value));
        }

    }
}
