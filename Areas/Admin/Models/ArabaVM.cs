using System.ComponentModel.DataAnnotations;

namespace AracKiralama.Areas.Admin.Models
{
    public class ArabaVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Plaka { get; set; }
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Model { get; set; }
        [Display(Name = "Yıl")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int Yil { get; set; }
        [Display(Name = "Yakıt Tipi")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int YakitTipi { get; set; } //0-Benzinli 1-Dizel 2-LPG 3-Hybrid 4-Elektrik
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int Vites { get; set; } //0-Manuel 1-Yarı Otomatik 2-Otomatik
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int Kilometre { get; set; }
        [Display(Name = "Kasa Tipi")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int KasaTipi { get; set; } //0-Cabrio 1-Coupe 2-Hatchback 3-Sedan 4-Station Wagon
        [Display(Name = "Çekiş Tipi")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int CekisTipi { get; set; } //0-Önden Çekiş 1-Arkadan İtiş 2-4WD
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int Renk { get; set; } //0-Bej 1-Beyaz 2-Bordo 3-Füme 4-Gri 5-Gümüş Gri 6-Kahverengi 7-Kırmızı 8-Lacivert 9-Mavi 10-Mor 11-Pembe 12-Sarı 13-Siyah 14-Turkuaz 15-Turuncu 16-Yeşil
    }
}
