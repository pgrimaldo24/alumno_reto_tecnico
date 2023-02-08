using Analitycs.Alumno.Domain.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analitycs.Alumno.Infraestructure.Repository.Implementation.Configuration
{
    public class AlumnoConfiguration : IEntityTypeConfiguration<AlumnoEntity>
    {
        public void Configure(EntityTypeBuilder<AlumnoEntity> entity)
        {
            entity.ToTable("Alumno");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");

            entity.Property(e => e.Domicilio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOMICILIO");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NACIMIENTO");

            entity.Property(e => e.LugarNacimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LUGAR_NACIMIENTO");

            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NACIONALIDAD");

            entity.Property(e => e.NivelEducativo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NIVEL_EDUCATIVO");

            entity.Property(e => e.Nombres)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO_DOCUMENTO");

            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEXO");

            entity.Property(e => e.TipoDocumento).HasColumnName("TIPO_DOCUMENTO");

            entity.Property(e => e.TipoSangre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TIPO_SANGRE");

            entity.Property(e => e.Estado)
                  .HasColumnName("ESTADO")
                  .HasDefaultValueSql("((1))");
        }
    }
}
