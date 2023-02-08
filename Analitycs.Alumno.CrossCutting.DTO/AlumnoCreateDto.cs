namespace Analitycs.Alumno.CrossCutting.DTO
{
    public class AlumnoCreateDto
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nivel_educativo { get; set; }
        public string correo_electronico { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public int? tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string domicilio { get; set; }
        public string nacionalidad { get; set; }
        public string lugar_nacimiento { get; set; }
        public string tipo_sangre { get; set; } 
    }

    public class AlumnoUpdateDto
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nivel_educativo { get; set; }
        public string correo_electronico { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public int? tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string domicilio { get; set; }
        public string nacionalidad { get; set; }
        public string lugar_nacimiento { get; set; }
        public string tipo_sangre { get; set; }
    }
}
