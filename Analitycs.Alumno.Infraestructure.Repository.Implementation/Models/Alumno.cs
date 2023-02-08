using System;
using System.Collections.Generic;

namespace Analitycs.Alumno.Infraestructure.Repository.Implementation.Models
{
    public partial class Alumno
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? NivelEducativo { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public int? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Domicilio { get; set; }
        public string? Nacionalidad { get; set; }
        public string? LugarNacimiento { get; set; }
        public string? TipoSangre { get; set; }
        public int Estado { get; set; }
    }
}
