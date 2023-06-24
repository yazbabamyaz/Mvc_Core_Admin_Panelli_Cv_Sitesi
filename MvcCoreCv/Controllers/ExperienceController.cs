using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
    
    public class ExperienceController : Controller
    {


        private readonly IExperienceRepository _repo;

        public ExperienceController(IExperienceRepository repo)
        {
            _repo = repo;
        }
        
        public IActionResult Index()
        {
            try
            {
                var values = _repo.GetAll();
                return View(values);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }


        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(TblExperince p)
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
        public IActionResult DeleteExperience(int id) 
        {
            try
            {
                //Find metodunu genericrepository e sonradan ekledim. Aslında gerek yoktu bizim Getbyid var
                var deletedValue = _repo.GetById(id);
                //var deletedValue = _repo.Find(x=>x.Id==id);
                if (deletedValue != null)
                {
                    _repo.Delete(deletedValue);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id) 
        {
            try
            {
                var updatedValue = _repo.GetById(id);
                return View(updatedValue);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult UpdateExperience(TblExperince p)
        {
            try
            {                
                _repo.Update(p);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
    }
}
