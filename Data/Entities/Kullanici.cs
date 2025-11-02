using System.ComponentModel.DataAnnotations.Schema;

namespace AracKiralama.Data.Entities
{
    [Table("Kullanici")]
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
