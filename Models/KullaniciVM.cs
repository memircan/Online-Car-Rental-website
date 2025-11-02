using System.ComponentModel.DataAnnotations;

namespace AracKiralama.Models
{
    public class KullaniciVM
    {
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [StringLength(16, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool BeniHatirla { get; set; }
    }
}
