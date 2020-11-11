using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahJong.Models;
using MahJong.Models.databases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahJong.Controllers
{
    public class MahjongController : Controller
    {
        private readonly mahjongContext _mahjongDBContext;

        public MahjongController(mahjongContext mahjongDBContext)
        {
            _mahjongDBContext = mahjongDBContext;
        }

        public async Task<IActionResult> Index()
        {
            var store = await _mahjongDBContext.Store.ToListAsync();
            return View(store);
        }

        [HttpGet]
        public async Task<IActionResult> Storedetail(string sid)
        {
            if (sid == null)
            {
                return NotFound();
            }

            var store = await _mahjongDBContext.Store.FirstOrDefaultAsync(s => s.SId == sid);

            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }
        public IActionResult Contact() {
            return View();
        }
        public async Task<IActionResult> Store()
        {
            var store = await _mahjongDBContext.Store.ToListAsync();
            return View(store);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _mahjongDBContext.Add(customer);
                await _mahjongDBContext.SaveChangesAsync();
                ViewBag.JavaScriptFunction = "Showsuccess()";
                ModelState.Clear();
            }
            return View();
        }

        public async Task<IActionResult> Login(Login login)
        {
            var user = _mahjongDBContext.Customer.Where(s => s.CUsername == login.Username);
            if (await user.AnyAsync())
            {
                if (await user.Where(s => s.CPassword == login.Password).AnyAsync())
                {
                    var setuser = await _mahjongDBContext.Customer.Where(c => c.CUsername == login.Username && c.CPassword == login.Password).FirstOrDefaultAsync();
                    HttpContext.Session.SetString("username", setuser.CUsername);
                    HttpContext.Session.SetString("fname", setuser.CFname);
                    HttpContext.Session.SetString("lname", setuser.CLname);
                    HttpContext.Session.SetString("tel", setuser.CTel);
                    return Json(new { status = true, message = "success" });
                }
                else
                {
                    return Json(new { status = false, message = "Password ไม่ถูกต้อง !" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Username ไม่ถูกต้อง !" });
            }          
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
