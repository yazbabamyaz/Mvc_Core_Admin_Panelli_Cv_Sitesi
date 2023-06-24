using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories;
using System.Security.Claims;

namespace MvcCoreCv.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly IRepository<TblAdmin> _repo;

        public LoginController(IRepository<TblAdmin> repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[AllowAnonymous]
        [HttpPost]
		public async Task<IActionResult> Index(TblAdmin p)
		{

			try
			{
                //var user = _context.TblAdmins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
                var user = _repo.GetAll().FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
                if (user != null)
                {

                    HttpContext.Session.SetString("userid", user.Id.ToString());
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserName),
                    new Claim(ClaimTypes.Role,"Admin"),
                    //new Claim(ClaimTypes.Role,user.Role),
					new Claim(ClaimTypes.Email,p.Password)
                };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                   
                    HttpContext.Session.SetString("UserName", p.UserName);
                    return RedirectToAction("index", "About");

                }
                return View(p);
            }
			catch (Exception ex)
			{
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
			
		}
		public async Task<IActionResult> LogOut() 
		{
			await HttpContext.SignOutAsync();

			return RedirectToAction("Index");
		}


	}

	}

