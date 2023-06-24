using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.DTOs;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
   
    public class AwardController : Controller
    {
        private readonly IAwardRepository _repo;
        private readonly IMapper _mapper;

        public AwardController(IAwardRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                var value = _repo.GetAll();
                return View(_mapper.Map<List<AwardDto>>(value));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public IActionResult AddAward()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAward(AwardDto p)
        {
            try
            {
                //gelen dto gerçek modele çevirdik.
                //Kısaca view e entity clasımızı göndermiyoruz.            
                _repo.Create(_mapper.Map<TblAward>(p));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");                
            }
            
        }
        [HttpGet]
        public IActionResult UpdateAward(int id)
        {
            try
            {
                var values = _repo.GetById(id);
                return View(_mapper.Map<AwardDto>(values));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult UpdateAward(AwardDto p)
        {
            try
            {
                //Gelen Dto yu Entity classına mapledim.
                _repo.Update(_mapper.Map<TblAward>(p));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        public IActionResult DeleteAward(int id)
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
    }
}
