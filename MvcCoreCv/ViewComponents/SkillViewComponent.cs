using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Models;

namespace MvcCoreCv.ViewComponents
{
    public class SkillViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public SkillViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skills = _context.TblSkills.ToList();
            return View(skills);

        }
    }
}
