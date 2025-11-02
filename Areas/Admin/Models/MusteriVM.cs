using System.ComponentModel.DataAnnotations;

namespace AracKiralama.Areas.Admin.Models
{
    public class MusteriVM
    {
        public int? Id { get; set; }
        [Display(Name = "T.C. Kimlik Numarası")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string TCKimlikNo { get; set; }
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Adi { get; set; }
        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Soyadi { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string TelNo { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }
        public string Adres { get; set; }
        [Display(Name = "Ehliyet Numarası")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string EhliyetNo { get; set; }
        [Display(Name = "Ehliyet Türü")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string EhliyetTuru { get; set; }
    }
}
