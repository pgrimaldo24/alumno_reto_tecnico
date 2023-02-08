using Analitycs.Alumno.CrossCutting.Common;
using Analitycs.Alumno.Domain.Main;
using Analitycs.Alumno.Infraestructure.Repository.Implementation.Base;
using Analitycs.Alumno.Infraestructure.Repository.Implementation.Data;
using Analitycs.Alumno.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Analitycs.Alumno.Infraestructure.Repository.Implementation
{
    public class AlumnoRepository : BaseRepository<DataContext, AlumnoEntity>, IAlumnoRepository
    {
        private readonly AppSettings _settings;
        private readonly DataContext _dbcontext;
        public AlumnoRepository(DataContext context, IOptions<AppSettings> settings) : base(context)
        {
            _settings = settings.Value;
            _dbcontext = context;
        }

        public async Task<List<AlumnoEntity>> GetAllAsync()
        {
            var response = await _dbcontext.Alumnos.Where(x => x.Estado == 1).ToListAsync(); 
            return response;
        }

        public async Task<AlumnoEntity> SearchXIdAsync(int id)
        {
            var query = await _dbcontext.Alumnos.Where(x => x.Id == id).FirstOrDefaultAsync(); 
            return query;
        }
    }
}
