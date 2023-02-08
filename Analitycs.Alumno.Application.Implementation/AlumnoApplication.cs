using Analitycs.Alumno.Application.Interfaces;
using Analitycs.Alumno.CrossCutting.Common;
using Analitycs.Alumno.CrossCutting.DTO;
using Analitycs.Alumno.CrossCutting.DTO.Main;
using Analitycs.Alumno.Domain.Main;
using Analitycs.Alumno.Infraestructure.Repository.Interfaces;
using Analitycs.Alumno.Infraestructure.Repository.Interfaces.Data;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Analitycs.Alumno.Application.Implementation
{
    public class AlumnoApplication : IAlumnoApplication
    { 
        private readonly AppSettings _settings;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IHttpContextAccessor> _httpContext; 

        public AlumnoApplication(IOptions<AppSettings> settings, ILifetimeScope lifetimeScope)
        {
            _settings = settings.Value;
            _httpContext = new Lazy<IHttpContextAccessor>(() => lifetimeScope.Resolve<IHttpContextAccessor>());
            _unitOfWork = new Lazy<IUnitOfWork>(() => lifetimeScope.Resolve<IUnitOfWork>()); 
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value; 

        private IAlumnoRepository AlumnoRepository => UnitOfWork.Repository<IAlumnoRepository>();

        public async Task<ResponseDto> BuscarAlumnoXIdAsync(int id)
        {
            var response = new ResponseDto(); 
            var alumno_search = await AlumnoRepository.SearchXIdAsync(id);
            response.Status = 200;
            response.Data = alumno_search;
            return response;
        }

        public async Task<ResponseDto> DeleteAlumnoXId(int id)
        {
            var response = new ResponseDto();
            var alumnoEntity = await AlumnoRepository.SearchXIdAsync(id);

            if (ReferenceEquals(null, alumnoEntity))
                return new ResponseDto
                {
                    Status = 400,
                    Message = "El alumno no existe, intentelo nuevamente."
                };

            UnitOfWork.Set<AlumnoEntity>().Attach(alumnoEntity);
            UnitOfWork.Set<AlumnoEntity>().Remove(alumnoEntity);
            UnitOfWork.SaveChanges();

            response.Status = 200;
            response.Message = "El alumno fue eliminado correctamente.";

            return response;
        }

        public async Task<ResponseDto> GetAlumnoAsync()
        {
            var response = new ResponseDto();
            var alumnos = await AlumnoRepository.GetAllAsync();

            if (ReferenceEquals(null, alumnos))
                return new ResponseDto
                {
                    Status = 400,
                    Message = "Hubo un error al listar todo los alumnos."
                };


            var list_alumnos = new List<AlumnoListaDto>();

            alumnos.ForEach(x => {
                var alumnodto = new AlumnoListaDto
                {
                    nombres = x.Nombres,
                    apellidos = x.Apellidos,
                    nacionalidad = x.Nacionalidad,
                    nivel_educativo = x.NivelEducativo,
                    numero_documento = x.NumeroDocumento,
                    sexo = x.Sexo,
                    tipo_documento = (int)x.TipoDocumento
                };

                list_alumnos.Add(alumnodto);
            });

            response.Status = 200;
            response.Data = list_alumnos;
            return response;
        }

        public async Task<ResponseDto> PostCrearAlumnoAsync(AlumnoCreateDto alumnoCreateDto)
        {
            var response = new ResponseDto();

            if (ReferenceEquals(null, alumnoCreateDto))
                return new ResponseDto
                {
                    Status = 400,
                    Message = "El objecto alumno se encuentra vacío, intentelo de nuevo"
                };

            var alumnotEntity = new AlumnoEntity
            {
                Nombres = alumnoCreateDto.nombres,
                Apellidos = alumnoCreateDto.apellidos,
                NivelEducativo = alumnoCreateDto.nivel_educativo,
                Email = alumnoCreateDto.correo_electronico,
                FechaNacimiento = alumnoCreateDto.fecha_nacimiento,
                Sexo = alumnoCreateDto.sexo,
                TipoDocumento = (int)alumnoCreateDto.tipo_documento,
                NumeroDocumento = alumnoCreateDto.numero_documento,
                Domicilio = alumnoCreateDto.domicilio,
                Nacionalidad = alumnoCreateDto.nacionalidad,
                LugarNacimiento = alumnoCreateDto.lugar_nacimiento,
                TipoSangre = alumnoCreateDto.tipo_sangre
            };

            UnitOfWork.Set<AlumnoEntity>().Add(alumnotEntity);
            UnitOfWork.SaveChanges();

            response.Message = "El alumno se registró corretamente";
            return response;
        }

        public async Task<ResponseDto> UpdateAlumnoAsync(AlumnoUpdateDto alumno)
        {
            var response = new ResponseDto(); 
            var alumnoEntity = await AlumnoRepository.SearchXIdAsync(alumno.id); 
            alumnoEntity.Nombres = alumno.nombres;
            alumnoEntity.Apellidos = alumno.apellidos;
            alumnoEntity.NivelEducativo = alumno.nivel_educativo;
            alumnoEntity.Email = alumno.correo_electronico;
            alumnoEntity.FechaNacimiento = alumno.fecha_nacimiento;
            alumnoEntity.Sexo = alumno.sexo;
            alumnoEntity.TipoDocumento = alumno.tipo_documento;
            alumnoEntity.NumeroDocumento = alumno.numero_documento;
            alumnoEntity.Domicilio = alumno.domicilio;
            alumnoEntity.Nacionalidad = alumno.nacionalidad;
            alumnoEntity.LugarNacimiento = alumno.lugar_nacimiento;
            alumnoEntity.TipoSangre = alumno.tipo_sangre;
            UnitOfWork.SaveChanges();
            response.Message = "El alumno se actualizó correctamente.";
            return response;
        }
    }
}
