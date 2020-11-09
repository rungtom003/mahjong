using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MahJong.Controllers
{
    public class MahjongController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Storedetail()
        {
            return View();
        }
        public IActionResult Contact() {
            return View();
        }
        public IActionResult Store()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
