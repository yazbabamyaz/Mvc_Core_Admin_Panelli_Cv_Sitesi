using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Models;

namespace MvcCoreCv.ViewComponents
{
    public class EducationViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public EducationViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            
            var educations = _context.TblEducations.ToList();
            return View(educations);

        }
    }
}
