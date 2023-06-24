using Microsoft.EntityFrameworkCore;
using MvcCoreCv.Entities;
using System.Linq.Expressions;

namespace MvcCoreCv.Repositories
{
    public interface IRepository<TEntity> where TEntity :class,IEntity
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity item);
        void Delete(TEntity item);
        
        void Update(TEntity item);
        TEntity Find(Expression<Func<TEntity,bool>> filter);//şarta göre döndür id -isim vs
        
    }
}
