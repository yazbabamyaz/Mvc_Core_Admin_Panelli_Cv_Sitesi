using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class EducationRepository : GenericRepository<TblEducation>, IEducationRepository
    {
        public EducationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
