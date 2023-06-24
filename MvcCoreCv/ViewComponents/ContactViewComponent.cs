using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Models;

namespace MvcCoreCv.ViewComponents
{
    public class ContactViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ContactViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            //var contacts = _context.TblContacts.ToList();
            //return View(contacts);
            return View();
        }
        
    }
}
