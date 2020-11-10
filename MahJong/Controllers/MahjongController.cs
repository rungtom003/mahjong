using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahJong.Models.databases;
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
    }
}
