using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        //To Add and Save changes in Database
        public void Add(T entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {

            // create a queryable object from the database set
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                // split the comma-separated list of property names
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.
                    RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            // return the first item from the query, or null if it is empty
            return query.FirstOrDefault();
        }

        //
        public T Get(int id)
        {
            return dbSet.Find(id);
        }
                                         
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            //Expression
            if (filter != null)
                query = query.Where(filter);

            //Multiple Tables
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            //Sorting

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges(); 
        }

        // To find and Remove with the help of id
        public void Remove(int id)
        {
            var getId = dbSet.Find(id);
            Remove(getId);
            _context.SaveChanges();
        }

        //To remove List
        public void RemoveRange(IEnumerable<T> entity)
        {
           dbSet.RemoveRange(entity);
            _context.SaveChanges();
        }
    }
}
