using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class AdminRepository : GenericRepository<TblAdmin>, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }
    }
}
