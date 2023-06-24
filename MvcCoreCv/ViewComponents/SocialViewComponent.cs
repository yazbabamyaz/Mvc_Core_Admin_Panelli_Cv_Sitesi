using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Models;

namespace MvcCoreCv.ViewComponents
{
    public class SocialViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public SocialViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var socialMedias = _context.TblSocials.Where(x=>x.Status==true).ToList();
            return View(socialMedias);
        }
    }
}
