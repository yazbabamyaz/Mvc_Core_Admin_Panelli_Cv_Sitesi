using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class AwardRepository : GenericRepository<TblAward>,IAwardRepository
    {
        public AwardRepository(AppDbContext context) : base(context)
        {
        }
    }
}
