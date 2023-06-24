using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.DTOs;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{

    public class AboutController : Controller
    {        

        private readonly IAboutRepository _repo;
        private readonly IMapper _mapper;

        public AboutController(IAboutRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]		
		public IActionResult Index()
        {
            try
            {
                TblAbout value = _repo.GetById(1);//tek kişiye ait cv.
                return View(_mapper.Map<AboutDto>(value));
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
                       
        }
        [HttpPost]
        public IActionResult Index(AboutDto p)
        {
            try
            {
                //Gelen AboutDto tipindeki p yi TblAbout a maple.
                _repo.Update(_mapper.Map<TblAbout>(p));
                TempData["status"] = "Veriler Güncellendi.";
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
