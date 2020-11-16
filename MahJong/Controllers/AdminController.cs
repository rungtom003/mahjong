using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahJong.Models.databases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahJong.Controllers
{
    public class AdminController : Controller
    {

        private readonly mahjongContext _mahjongDBContext;
       
        public AdminController(mahjongContext mahjongDBContext)
        {
            _mahjongDBContext = mahjongDBContext;          
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Order()
        {
            var myorder = await _mahjongDBContext.BookDetail
                    .Include(b => b.T)
                    .Include(b => b.T.S)
                    .Include(b => b.B.C)
                    .Where(b => b.BdStatus == "กำลังตรวจสอบ")
                    .ToListAsync();
            return View(myorder);         
        }
    }
}
