using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Models;

namespace MvcCoreCv.ViewComponents
{
    public class HobbyViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public HobbyViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var hobbies=_context.TblHobbies.ToList();
            return View(hobbies);
        }
    }
}
