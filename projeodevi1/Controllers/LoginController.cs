using Microsoft.AspNetCore.Mvc;
using projeodevi1.Data;
using projeodevi1.Models;

namespace projeodevi1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login
        [HttpPost]
        public IActionResult Index(string email, string sifre)
        {
            var kullanici = _context.Kullanicilar
                .FirstOrDefault(k => k.Email == email && k.Sifre == sifre);

            if (kullanici != null)
            {
                // Session'a kullanıcı bilgilerini kaydet
                HttpContext.Session.SetString("Email", kullanici.Email);
                HttpContext.Session.SetString("Rol", kullanici.Rol);

                // Rolüne göre yönlendir
                if (kullanici.Rol == "admin")
                    return RedirectToAction("AdminPanel", "Home");
                else
                    return RedirectToAction("ClientPanel", "Home");
            }

            ViewBag.Hata = "E-posta veya şifre yanlış!";
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}

