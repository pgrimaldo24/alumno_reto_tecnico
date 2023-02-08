namespace Analitycs.Alumno.CrossCutting.Common
{
    public class AppSettings
    {
        public ConnectionString ConnectionStrings { get; set; }

        public class ConnectionString
        {
            public string DefaultConnectionSQL { get; set; } 
        }

    }
}
