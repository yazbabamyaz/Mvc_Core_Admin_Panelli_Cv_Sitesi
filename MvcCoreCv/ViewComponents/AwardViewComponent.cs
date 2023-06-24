using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Models;

namespace MvcCoreCv.ViewComponents
{
    public class AwardViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public AwardViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var awards = _context.TblAwards.ToList();
            return View(awards);
        }
    }
}
