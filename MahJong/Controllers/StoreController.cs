﻿using System;
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
    public class StoreController : Controller
    {
        private readonly mahjongContext _mahjongDBContext;

        public StoreController(mahjongContext mahjongDBContext)
        {
            _mahjongDBContext = mahjongDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Order()
        {
            if (HttpContext.Session.GetString("store_username") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var orderitem = await _mahjongDBContext.BookDetail
                .Include(o => o.B.C)
                .Include(o => o.T)
                .ToListAsync();
            return View(orderitem);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var user = _mahjongDBContext.AdminStore.Where(s => s.AsUsername == login.Password);
            if (await user.AnyAsync())
            {
                if (await user.Where(s => s.AsPassword == login.Password).AnyAsync())
                {
                    var setuser = await _mahjongDBContext.AdminStore.Where(c => c.AsUsername == login.Username && c.AsPassword == login.Password).FirstOrDefaultAsync();
                    HttpContext.Session.SetString("store_username", setuser.AsUsername);
                    HttpContext.Session.SetString("store_fname", setuser.AsName);
                    HttpContext.Session.SetString("store_lname", setuser.AsLname);
                    HttpContext.Session.SetString("store_tel", setuser.AsTel);
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
    }
}
