using System.Linq.Expressions;

namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);

        void Remove(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter= null, Func<IQueryable<T>, IOrderedQueryable<T>>
         orderBy = null, string includeProperties = null);  //Category,CoverType
        void RemoveRange (IEnumerable<T> entity);

        T Get(int id);

        T FirstOrDefault(
            Expression<Func<T, bool>> filter=null,
            string includeProperties = null);
            
    }
}
