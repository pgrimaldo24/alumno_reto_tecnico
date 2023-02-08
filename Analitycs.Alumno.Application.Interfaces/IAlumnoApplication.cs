using Analitycs.Alumno.CrossCutting.DTO;
using Analitycs.Alumno.CrossCutting.DTO.Main;

namespace Analitycs.Alumno.Application.Interfaces
{
    public interface IAlumnoApplication
    {
        Task<ResponseDto> GetAlumnoAsync();
        Task<ResponseDto> PostCrearAlumnoAsync(AlumnoCreateDto alumnoCreateDto);
        Task<ResponseDto> BuscarAlumnoXIdAsync(int id);
        Task<ResponseDto> UpdateAlumnoAsync(AlumnoUpdateDto alumno);
        Task<ResponseDto> DeleteAlumnoXId(int id);

    }
}
