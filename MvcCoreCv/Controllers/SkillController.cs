using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
   
    public class SkillController : Controller
    {
        private readonly ISkillRepository _repo;

        public SkillController(ISkillRepository repo)
        {
            _repo = repo;
        }
        
        public IActionResult Index()
        {
            return View(_repo.GetAll());
            
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(TblSkill p)
        {
            _repo.Create(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id) 
        {
            try
            {
                var deletedValue = _repo.GetById(id);
                _repo.Delete(deletedValue);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }  
            
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
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
        public IActionResult UpdateSkill(TblSkill p)
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
    }
}
