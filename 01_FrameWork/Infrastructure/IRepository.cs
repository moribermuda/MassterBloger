using _01_FrameWork.Domain;
using System.Linq.Expressions;

namespace _01_FrameWork.Infrastructure
{
    public interface IRepository<TKey,T> where T : DomainBase<TKey>
    {
        List<T> GetAll();
        void Creat(T entity);
        T Get(TKey id);
        bool Exist(Expression<Func<T,bool>> expression);
    }
}
