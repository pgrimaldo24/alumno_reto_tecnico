using Analitycs.Alumno.Domain.Main;
using Analitycs.Alumno.Infraestructure.Repository.Implementation.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Analitycs.Alumno.Infraestructure.Repository.Implementation.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AlumnoConfiguration()); 
        }

        public DbSet<AlumnoEntity> Alumnos { get; set; } 
    }
 
}
