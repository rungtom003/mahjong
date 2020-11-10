using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorMonitoring.Models;

namespace MahJong.Controllers
{
    public class MahjongController : Controller
    {
        private readonly MahjongDBContext _mahjongDBContext;

        public MahjongController(MahjongDBContext mahjongDBContext)
        {
            _mahjongDBContext = mahjongDBContext;
        }

        public async Task<IActionResult> Index()
        {
            var store = await _mahjongDBContext.Stores.ToListAsync();
            return View(store);
        }

        [HttpGet]
        public async Task<IActionResult> Storedetail(string sid)
        {
            if (sid == null)
            {
                return NotFound();
            }

            var store = await _mahjongDBContext.Stores.FirstOrDefaultAsync(s => s.s_id == sid);

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
            var store = await _mahjongDBContext.Stores.ToListAsync();
            return View(store);
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
