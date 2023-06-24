using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
	
	public class SocialController : Controller
    {
        private readonly ISocialRepository _repo;

        public SocialController(ISocialRepository repo)
        {
            _repo = repo;
        }
       
        public IActionResult Index()
        {
            try
            {
                return View(_repo.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public IActionResult DeleteSocial(int id)
        {
            try
            {
                _repo.Delete(_repo.GetById(id));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }               
           
        }
        [HttpGet]
        public IActionResult UpdateSocial(int id)
        {
            try
            {
                return View(_repo.GetById(id));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult UpdateSocial(TblSocial p)
        {
            try
            {
                _repo.Update(p);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public IActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocial(TblSocial p)
        {
            try
            {
                _repo.Create(p);
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
