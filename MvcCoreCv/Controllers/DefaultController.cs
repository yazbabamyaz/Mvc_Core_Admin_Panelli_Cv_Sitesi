using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Models;

namespace MvcCoreCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly AppDbContext _context;

        public DefaultController(AppDbContext context)
        {
            _context = context;
        }
        //code first-Migration- repository- -viewmodel vs.
        public IActionResult Index()
        {
            //Component yapısı kullanacağım.
            try
            {
                var about = _context.TblAbouts.ToList();
                return View(about);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult iletisim(TblContact contact)
        {
            try
            {
                //Contact componentindeki verilerin kaydı
                _context.TblContacts.Add(contact);
                contact.Date = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        
    }
}
