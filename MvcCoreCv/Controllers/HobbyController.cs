using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
    
    public class HobbyController : Controller
    {
        private readonly IHobbyRepository _repo;

        public HobbyController(IHobbyRepository repo)
        {
            _repo = repo;
        }
       

        public IActionResult Index()
        {
            try
            {
                return View(_repo.GetAll());
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");               
            }
            
        }
        public IActionResult DeleteHobby(int id) 
        {
            try
            {
                var deletedValue = _repo.GetById(id);
                _repo.Delete(deletedValue);
                TempData["status"] = "Veri silme başarılı";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        
        [HttpGet]
        public IActionResult UpdateHobby(int id)
        {
            return View(_repo.GetById(id));

        }
        [HttpPost]
        public IActionResult UpdateHobby(TblHobby p)
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
        public IActionResult AddHobby()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHobby(TblHobby p)
        {
            try
            {
                _repo.Create(p);
                TempData["status"] = "Ekleme işlemi Başarılı...";
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
