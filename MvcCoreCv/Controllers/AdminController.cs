using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCv.Entities;
using MvcCoreCv.Repositories;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Controllers
{
    
    public class AdminController : Controller
	{
		private readonly IAdminRepository _repo;

		public AdminController(IAdminRepository repo)
		{
			_repo = repo;
		}		
        public IActionResult Index()
		{
			try
			{
                return View(_repo.GetAll().ToList());
            }
			catch (Exception ex)
			{

                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
			
		}
		[HttpGet]
		public IActionResult DeleteAdmin(int id) 
		{
			try
			{
                _repo.Delete(_repo.GetById(id));
                TempData["status"] = "Veri Silme Başarı...";
                return RedirectToAction("Index");
            }
			catch (Exception ex)
			{
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");                
			}
			
		}
		[HttpGet]
		public IActionResult UpdateAdmin(int id)
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
		public IActionResult UpdateAdmin(TblAdmin p) 
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
		public IActionResult AddAdmin()
		{
			return View();
		}
		[HttpPost]
        public IActionResult AddAdmin(TblAdmin p)
        {
			try
			{
                _repo.Create(p);
				TempData["status"] = "Veri Ekleme Başarılı...";
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
