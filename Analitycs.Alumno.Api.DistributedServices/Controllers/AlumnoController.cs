using Analitycs.Alumno.Application.Interfaces;
using Analitycs.Alumno.CrossCutting.Common;
using Analitycs.Alumno.CrossCutting.DTO;
using Analitycs.Alumno.CrossCutting.DTO.Main;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Analitycs.Alumno.Api.DistributedServices.Controllers
{
    [Route("api/Alumno")]
    [ApiController]
    public class AlumnoController : Controller
    {


        private readonly Lazy<IAlumnoApplication> _alumnoApplication;
        private readonly AppSettings _appSettings;
        private readonly ILogger<AlumnoController> _logger;

        public AlumnoController(ILogger<AlumnoController> logger, ILifetimeScope lifetimeScope, IOptions<AppSettings> appSettings)
        {
            _alumnoApplication = new Lazy<IAlumnoApplication>(() => lifetimeScope.Resolve<IAlumnoApplication>());
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        private IAlumnoApplication AlumnoApplication => _alumnoApplication.Value;

        [HttpGet("ListarAlumnos")]
        public async Task<JsonResult> GetAlumnos()
        {
            ResponseDto response;
            try
            {
                response = await AlumnoApplication.GetAlumnoAsync();
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex, JsonConvert.SerializeObject(_appSettings));
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex);
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = 400, Message = ex.Message };
                _logger.LogWarning(response.TransactionId, ex.Message, ex);
            }
            return new JsonResult(response);
        }

        [HttpPost("CrearAlumno")]
        public async Task<JsonResult> CreateAlumno([FromBody] AlumnoCreateDto alumnoCreateDto)
        {
            ResponseDto response;
            try
            {
                response = await AlumnoApplication.PostCrearAlumnoAsync(alumnoCreateDto);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex, JsonConvert.SerializeObject(_appSettings));
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex);
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = 400, Message = ex.Message };
                _logger.LogWarning(response.TransactionId, ex.Message, ex);
            }
            return new JsonResult(response);
        }

        [HttpGet("SearchAlumnoXId")]
        public async Task<JsonResult> BuscarAlumnoXId(int id)
        {
            ResponseDto response;
            try
            {
                response = await AlumnoApplication.BuscarAlumnoXIdAsync(id);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex, JsonConvert.SerializeObject(_appSettings));
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex);
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = 400, Message = ex.Message };
                _logger.LogWarning(response.TransactionId, ex.Message, ex);
            }
            return new JsonResult(response);
        }

        [HttpPut("UpdateAlumno")]
        public async Task<JsonResult> UpdateAlumnoXId(AlumnoUpdateDto alumno)
        {
            ResponseDto response;
            try
            {
                response = await AlumnoApplication.UpdateAlumnoAsync(alumno);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex, JsonConvert.SerializeObject(_appSettings));
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex);
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = 400, Message = ex.Message };
                _logger.LogWarning(response.TransactionId, ex.Message, ex);
            }
            return new JsonResult(response);
        }

        [HttpDelete("DeleteAlumno")]
        public async Task<JsonResult> DeleteAlumnoXId(int id)
        {
            ResponseDto response;
            try
            {
                response = await AlumnoApplication.DeleteAlumnoXId(id);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex, JsonConvert.SerializeObject(_appSettings));
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                _logger.LogWarning(ex.TransactionId, ex.Message, ex);
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = 400, Message = ex.Message };
                _logger.LogWarning(response.TransactionId, ex.Message, ex);
            }
            return new JsonResult(response);
        }

    }
}
