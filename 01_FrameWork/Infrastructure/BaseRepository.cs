using _01_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace _01_FrameWork.Infrastructure
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : DomainBase<TKey>
    {
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public void Creat(T entity)
        {
            context.Add<T>(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

     
    }
}
