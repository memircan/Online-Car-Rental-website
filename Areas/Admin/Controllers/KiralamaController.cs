using AracKiralama.Areas.Admin.Models;
using AracKiralama.Data.Context;
using AracKiralama.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AracKiralama.Areas.Admin.Controllers
{
    public class KiralamaController : BaseController
    {
        private readonly AppDbContext _context;
        public KiralamaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kiradakiArabaIds = _context.Kiralamalar.Where(x => x.TeslimTarihi == null).Select(x => x.ArabaId).Distinct().ToArray();
            ViewData["UygunArabalar"] = _context.Arabalar.Where(x => !kiradakiArabaIds.Contains(x.Id)).Select(x => new ArabaVM()
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

            ViewData["KiradakiArabalar"] = _context.Kiralamalar.Where(x => x.TeslimTarihi == null).Select(x => new KiraVM()
            {
                BaslangicTarihi = x.BaslangicTarihi,
                BitisTarihi = x.BitisTarihi,
                Id = x.Id,
                Tutar = x.Tutar,
                Araba = _context.Arabalar.Where(i => i.Id == x.ArabaId).Select(i => new ArabaVM()
                {
                    CekisTipi = i.CekisTipi,
                    Id = i.Id,
                    KasaTipi = i.KasaTipi,
                    Kilometre = i.Kilometre,
                    Marka = i.Marka,
                    Model = i.Model,
                    Plaka = i.Plaka,
                    Renk = i.Renk,
                    Vites = i.Vites,
                    YakitTipi = i.YakitTipi,
                    Yil = i.Yil,
                }).First(),
                Musteri = _context.Musteriler.Where(i => i.Id == x.MusteriId).Select(i => new MusteriVM()
                {
                    Id = i.Id,
                    Adi = i.Adi,
                    Adres = i.Adres,
                    EhliyetNo = i.EhliyetNo,
                    EhliyetTuru = i.EhliyetTuru,
                    Email = i.Email,
                    Soyadi = i.Soyadi,
                    TCKimlikNo = i.TCKimlikNo,
                    TelNo = i.TelNo
                }).First()
            }).ToList();

            ViewData["TeslimEdilenArabalar"] = _context.Kiralamalar.Where(x => x.TeslimTarihi != null).Select(x => new KiraVM()
            {
                BaslangicTarihi = x.BaslangicTarihi,
                BitisTarihi = x.BitisTarihi,
                Id = x.Id,
                Tutar = x.Tutar,
                TeslimTarihi = x.TeslimTarihi,
                Araba = _context.Arabalar.Where(i => i.Id == x.ArabaId).Select(i => new ArabaVM()
                {
                    CekisTipi = i.CekisTipi,
                    Id = i.Id,
                    KasaTipi = i.KasaTipi,
                    Kilometre = i.Kilometre,
                    Marka = i.Marka,
                    Model = i.Model,
                    Plaka = i.Plaka,
                    Renk = i.Renk,
                    Vites = i.Vites,
                    YakitTipi = i.YakitTipi,
                    Yil = i.Yil,
                }).First(),
                Musteri = _context.Musteriler.Where(i => i.Id == x.MusteriId).Select(i => new MusteriVM()
                {
                    Id = i.Id,
                    Adi = i.Adi,
                    Adres = i.Adres,
                    EhliyetNo = i.EhliyetNo,
                    EhliyetTuru = i.EhliyetTuru,
                    Email = i.Email,
                    Soyadi = i.Soyadi,
                    TCKimlikNo = i.TCKimlikNo,
                    TelNo = i.TelNo
                }).First()
            }).ToList();

            ViewData["Musteriler"] = _context.Musteriler.Select(x => new MusteriVM()
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

            return View();
        }

        [HttpPost]
        public IActionResult Kirala(KiraVM model)
        {
            try
            {
                if (!ModelState.IsValid && model.Id == null)
                    return Json(new { isValid = false, errorMessage = "Eksik veya hatalı veri girişi yapıldı." });

                _context.Kiralamalar.Add(new Kiralama
                {
                    ArabaId = model.ArabaId,
                    MusteriId = model.MusteriId,
                    BaslangicTarihi = model.BaslangicTarihi,
                    BitisTarihi = model.BitisTarihi,
                    Tutar = model.Tutar,
                });
                _context.SaveChanges();

                return Json(new { isValid = true });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult TeslimAl(int id)
        {
            try
            {
                var kiraIslemi = _context.Kiralamalar.FirstOrDefault(x => x.Id == id);
                if (kiraIslemi == null)
                    return Json(new { isValid = false, errorMessage = "Bu ID değerine sahip bir işlem bulunamadı." });

                kiraIslemi.TeslimTarihi = DateTime.Now;
                _context.Kiralamalar.Update(kiraIslemi);
                _context.SaveChanges();

                return Json(new { isValid = true });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, errorMessage = ex.Message });
            }
        }
    }
}
