using Microsoft.EntityFrameworkCore;

namespace Analitycs.Alumno.Infraestructure.Repository.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
        void Dispose(bool disposing);
        T Repository<T>() where T : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbContext Get();
        Task BeginTransaction();
        Task SaveChangeTransaction();
        Task Rollback();
        void Entry(Object obj);
    }
}
