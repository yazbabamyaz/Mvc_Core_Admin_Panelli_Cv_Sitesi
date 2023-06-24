using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class HobbyRepository : GenericRepository<TblHobby>, IHobbyRepository
    {
        public HobbyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
