using AracKiralama.Areas.Admin.Models;
using AracKiralama.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace AracKiralama.Areas.Admin.Controllers
{
    public class ArabaController : BaseController
    {
        private readonly AppDbContext _context;
        public ArabaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Arabalar.Select(x => new ArabaVM()
            {
                CekisTipi = x.CekisTipi,
                Id = x.Id,
                KasaTipi = x.KasaTipi,
                Kilometre = x.Kilometre,
                Marka = x.Marka,
                Model = x.Model,
                Plaka = x.Plaka,
                Renk = x.Renk,
                Vites = x.Vites,
                YakitTipi = x.YakitTipi,
                Yil = x.Yil,
            }).ToList();
            return View(model);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(ArabaVM araba)
        {
            if (ModelState.IsValid)
            {
                _context.Arabalar.Add(new()
                {
                    Marka = araba.Marka,
                    Model = araba.Model,
                    CekisTipi = araba.CekisTipi,
                    KasaTipi = araba.KasaTipi,
                    Kilometre = araba.Kilometre,
                    Plaka = araba.Plaka,
                    Renk = araba.Renk,
                    Vites = araba.Vites,
                    YakitTipi = araba.YakitTipi,
                    Yil = araba.Yil,
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Duzenle(int id)
        {
            var model = _context.Arabalar.Where(x => x.Id == id).Select(x => new ArabaVM()
            {
                CekisTipi = x.CekisTipi,
                Id = x.Id,
                KasaTipi = x.KasaTipi,
                Kilometre = x.Kilometre,
                Marka = x.Marka,
                Model = x.Model,
                Plaka = x.Plaka,
                Renk = x.Renk,
                Vites = x.Vites,
                YakitTipi = x.YakitTipi,
                Yil = x.Yil,
            }).First();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public IActionResult Duzenle(ArabaVM araba)
        {
            var data = _context.Arabalar.FirstOrDefault(x => x.Id == araba.Id);
            if (data == null)
                ModelState.AddModelError("", "Bu ID değerine sahip bir araba bulunamadı.");
            if (ModelState.IsValid)
            {
                data.CekisTipi = araba.CekisTipi;
                data.KasaTipi = araba.KasaTipi;
                data.Kilometre = araba.Kilometre;
                data.Marka = araba.Marka;
                data.Model = araba.Model;
                data.Plaka = araba.Plaka;
                data.Renk = araba.Renk;
                data.Vites = araba.Vites;
                data.YakitTipi = araba.YakitTipi;
                data.Yil = araba.Yil;
                _context.Arabalar.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(araba);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var araba = _context.Arabalar.FirstOrDefault(x => x.Id == id);
            if (araba == null)
                return Json(new { isValid = false, errorMessage = "Bu ID değerine sahip bir araba bulunamadı." });
            _context.Remove(araba);
            _context.SaveChanges();
            return Json(new { isValid = true });
        }
    }
}
