using Analitycs.Alumno.Domain.Main;

namespace Analitycs.Alumno.Infraestructure.Repository.Interfaces
{
    public interface IAlumnoRepository
    {
        Task<List<AlumnoEntity>> GetAllAsync();
        Task<AlumnoEntity> SearchXIdAsync(int id); 
    }
}
