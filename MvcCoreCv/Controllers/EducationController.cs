using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.DTOs;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
    
    public class EducationController : Controller
    {
        private readonly IEducationRepository _repo;
        private readonly IMapper _mapper;

        public EducationController(IEducationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                var values = _repo.GetAll();               
                return View(_mapper.Map<List<EducationDto>>(values));
            }
            catch (Exception ex)//fırlatılacak hatanın türü.
            {

                //ModelState.AddModelError(string.Empty, "Hata. hata");
                TempData["error"]= ex.Message;
                return RedirectToAction("Index");
            }
            
            
        }
        [HttpGet]
        public IActionResult AddEducation()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddEducation(EducationDto p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(p);
                }
                _repo.Create(_mapper.Map<TblEducation>(p));
                TempData["status"] = "Eğitim Bilgileri Başarıyla Eklendi...";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Hata. hata");
                TempData["hata"] = ex.Message;
            }
            
            return View(p);
        }
        public IActionResult DeleteEducation(int id) 
        {
            try
            {
                var deletedValue = _repo.GetById(id);
                _repo.Delete(deletedValue);
                TempData["status"] = "Eğitim Bilgileri Başarıyla Silindi...";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");                
            }
           
        }
        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            try
            {
                var values = _repo.GetById(id);
                return View(_mapper.Map<EducationDto>(values));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");                
            }
            
        }
        [HttpPost]
        public IActionResult UpdateEducation(EducationDto p)
        {
            try
            {
                _repo.Update(_mapper.Map<TblEducation>(p));
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
