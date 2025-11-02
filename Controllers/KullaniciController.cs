using AracKiralama.Data.Context;
using AracKiralama.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AracKiralama.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly AppDbContext _context;
        public KullaniciController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GirisYap(string? returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
                return Redirect(returnUrl ?? "/");
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(KullaniciVM model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = _context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);
                if (kullanici != null)
                {
                    List<Claim> userClaims = new();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, kullanici.KullaniciAdi));

                    if (kullanici.KullaniciAdi == "admin")
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.BeniHatirla
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    if (string.IsNullOrEmpty(TempData["returnUrl"] != null ? TempData["returnUrl"].ToString() : ""))
                        return RedirectToAction("Index", "Home");
                    return Redirect(TempData["returnUrl"].ToString());
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
