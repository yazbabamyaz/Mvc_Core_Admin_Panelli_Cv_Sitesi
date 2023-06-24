using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class SocialRepository : GenericRepository<TblSocial>, ISocialRepository
    {
        public SocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
