using AracKiralama.Areas.Admin.Models;
using AracKiralama.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace AracKiralama.Areas.Admin.Controllers
{
    public class MusteriController : BaseController
    {
        private readonly AppDbContext _context;
        public MusteriController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Musteriler.Select(x => new MusteriVM()
            {
                Id = x.Id,
                Adi = x.Adi,
                Adres = x.Adres,
                EhliyetNo = x.EhliyetNo,
                EhliyetTuru = x.EhliyetTuru,
                Email = x.Email,
                Soyadi = x.Soyadi,
                TCKimlikNo = x.TCKimlikNo,
                TelNo = x.TelNo   
            }).ToList();
            return View(model);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(MusteriVM musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Musteriler.Add(new()
                {
                    Adi = musteri.Adi,
                    Adres = musteri.Adres,
                    EhliyetNo =musteri.EhliyetNo,
                    EhliyetTuru = musteri.EhliyetTuru,
                    Email = musteri.Email,
                    Soyadi = musteri.Soyadi,
                    TCKimlikNo = musteri.TCKimlikNo,
                    TelNo = musteri.TelNo
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Duzenle(int id)
        {
            var model = _context.Musteriler.Where(x => x.Id == id).Select(x => new MusteriVM()
            {
                Id = x.Id,
                Adi = x.Adi,
                Adres = x.Adres,
                EhliyetNo = x.EhliyetNo,
                EhliyetTuru = x.EhliyetTuru,
                Email = x.Email,
                Soyadi = x.Soyadi,
                TCKimlikNo = x.TCKimlikNo,
                TelNo = x.TelNo
            }).First();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public IActionResult Duzenle(MusteriVM musteri)
        {
            var data = _context.Musteriler.FirstOrDefault(x => x.Id == musteri.Id);
            if (data == null)
                ModelState.AddModelError("", "Bu ID değerine sahip bir müşteri bulunamadı.");
            if (ModelState.IsValid)
            {
                data.Adi = musteri.Adi;
                data.Adres = musteri.Adres;
                data.EhliyetNo = musteri.EhliyetNo;
                data.EhliyetTuru = musteri.EhliyetTuru;
                data.Email = musteri.Email;
                data.Soyadi = musteri.Soyadi;
                data.TCKimlikNo = musteri.TCKimlikNo;
                data.TelNo = musteri.TelNo;
                _context.Musteriler.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var muster = _context.Musteriler.FirstOrDefault(x => x.Id == id);
            if (muster == null)
                return Json(new { isValid = false, errorMessage = "Bu ID değerine sahip bir müşteri bulunamadı." });
            _context.Remove(muster);
            _context.SaveChanges();
            return Json(new { isValid = true });
        }
    }
}
