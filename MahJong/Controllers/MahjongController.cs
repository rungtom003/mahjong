using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MahJong.Models;
using MahJong.Models.databases;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MahJong.Controllers
{
    public class MahjongController : Controller
    {
        private readonly mahjongContext _mahjongDBContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MahjongController(mahjongContext mahjongDBContext, IWebHostEnvironment hostEnvironment)
        {
            _mahjongDBContext = mahjongDBContext;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var store = _mahjongDBContext.Store;
            return View(await store.ToListAsync());
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
            var store_table = await _mahjongDBContext.Table.Where(t => t.SId == sid).ToListAsync();
            IList<Table> tables = store_table;

            if (store_table == null)
            {
                return NotFound();
            }

            ViewData["store_table"] = tables;
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

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var user = _mahjongDBContext.Customer.Where(s => s.CUsername == login.Username);
            if (await user.AnyAsync())
            {
                if (await user.Where(s => s.CPassword == login.Password).AnyAsync())
                {
                    var setuser = await _mahjongDBContext.Customer.Where(c => c.CUsername == login.Username && c.CPassword == login.Password).FirstOrDefaultAsync();
                    HttpContext.Session.SetInt32("cid", setuser.CId);
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

        [HttpPost]
        public IActionResult Loginfacebook(Login login)
        {
                if (login.Username != "" && login.Password != "")
                {
                    HttpContext.Session.SetString("username", login.Password);
                    HttpContext.Session.SetString("fname", login.Username);
                    HttpContext.Session.SetString("lname", login.Username);
                    return Json(new { status = true, message = "success" });
                }
                else
                {
                    return Json(new { status = false, message = "Password ไม่ถูกต้อง !" });
                }
        }

        [HttpGet]
        public async Task<IActionResult> Booktable(string sid,string tid)
        {
            var book = await _mahjongDBContext.Table.Include(b => b.S).FirstOrDefaultAsync(b => b.SId == sid && b.TName == tid);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Booktable(BookTable bookTable)
        {
            DateTime dt = DateTime.Now;
            string subdt = dt.ToString("dd/MM/yyyy HH:mm:ss");
            string[] ss = subdt.Split(new Char[] { '/', ':',' ' });
            string pk = string.Join("",ss);

            int cid = bookTable.c_id;
            double total = bookTable.b_priceTotal;
            int tid = bookTable.t_id;
            DateTime datenow = DateTime.Now;

            var book = new Book
            {
                BId = pk,
                CId = cid,
                BQuantity = 1,
                BPriceTotal = total,
                BDate = datenow
            };
            if (book != null)
            {
                _mahjongDBContext.Book.Add(book);
                await _mahjongDBContext.SaveChangesAsync();
                var bookdetail = new BookDetail
                {
                    BId = pk,
                    TId = tid,
                    BdStatus = "ค้างชำระ"
                };
                if (bookdetail != null)
                {
                    _mahjongDBContext.BookDetail.Add(bookdetail);
                    await _mahjongDBContext.SaveChangesAsync();
                }
                else
                {
                    return Json(new { message = "จองโต๊ะไม่สำเร็จ" });
                }
                
            }
            return Json(new { message = "จองโต๊ะสำเร็จ" });

        }

        [HttpGet]
        public IActionResult Payment()
        {
            int customerID = int.Parse(HttpContext.Session.GetInt32("cid").ToString());
            ViewBag.item = new SelectList(_mahjongDBContext.BookDetail.Include(b => b.B).Where(b => b.B.CId == customerID && b.BdStatus == "ค้างชำระ"), "BId", "BId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Payment(Images images)
        {
            int customerID = int.Parse(HttpContext.Session.GetInt32("cid").ToString());
            var filenameupload = await _mahjongDBContext.BookDetail.Include(b => b.B).FirstOrDefaultAsync(b => b.B.CId == customerID && b.BdStatus == "ค้างชำระ" && b.BId == images.Title);
            //Save image to wwwroot/image
            string wwwrootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(images.ImageFile.FileName);
            string extension = Path.Combine(images.ImageFile.FileName);
            images.ImageName = fileName = filenameupload.BId.ToString()+".jpg";
            string path = Path.Combine(wwwrootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await images.ImageFile.CopyToAsync(fileStream);

            }
            if (filenameupload != null)
            {
                filenameupload.BdStatus = "กำลังตรวจสอบ";
                await _mahjongDBContext.SaveChangesAsync();
            }
            
            return View();
        }

        public async Task<IActionResult> Myorder()
        {
            int customerID = int.Parse(HttpContext.Session.GetInt32("cid").ToString());       
                var myorder = await _mahjongDBContext.BookDetail
                    .Include(b => b.T)
                    .Include(b => b.T.S)
                    .Include(b => b.B.C)
                    .Where(b => b.B.CId == customerID)
                    .ToListAsync();                
            return View(myorder);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("fname");
            HttpContext.Session.Remove("lname");
            HttpContext.Session.Remove("tel");
            return RedirectToAction(nameof(Index));
        }
    }
}
