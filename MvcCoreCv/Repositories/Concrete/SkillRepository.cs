using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class SkillRepository : GenericRepository<TblSkill>, ISkillRepository
    {
        public SkillRepository(AppDbContext context) : base(context)
        {
        }
    }
}
