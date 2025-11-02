using AracKiralama.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace AracKiralama.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["ArabaSayisi"] = _context.Arabalar.ToList().Count;
            ViewData["MusteriSayisi"] = _context.Musteriler.ToList().Count;
            ViewData["KiradakiAraba"] = _context.Kiralamalar.Where(x => x.TeslimTarihi == null).Count();
            return View();
        }
    }
}
