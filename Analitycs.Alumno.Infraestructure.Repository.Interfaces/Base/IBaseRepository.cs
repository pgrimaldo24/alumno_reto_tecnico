using System.Linq.Expressions;

namespace Analitycs.Alumno.Infraestructure.Repository.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task Insert(T entity);
        void Update(T entity, bool activarDeteccion = false);
        void Remove(T entity);
        Task Delete(object id);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    }
}
