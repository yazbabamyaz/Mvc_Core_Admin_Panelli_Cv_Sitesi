using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace MvcCoreCv.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {


        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }        
        public void Create(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
        }
        public void Delete(TEntity item)
        {
            //_context.Remove<TEntity>(item);bu şekilde de kullanılır
            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            _context.SaveChanges();
        }
    }
}
