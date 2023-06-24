using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class ExperienceRepository : GenericRepository<TblExperince>, IExperienceRepository
    {
        public ExperienceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
