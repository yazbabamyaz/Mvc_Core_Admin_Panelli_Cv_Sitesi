using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using System.Collections;

namespace MvcCoreCv.Components
{
    public class ExperienceViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ExperienceViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            //IEnumerable<TblExperince> experiences = _context.TblExperiences.ToList();
            var experiences = _context.TblExperiences.ToList();
            return View(experiences);

        }
    }
}
