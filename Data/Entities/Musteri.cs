using System.ComponentModel.DataAnnotations.Schema;

namespace AracKiralama.Data.Entities
{
    [Table("Musteri")]
    public class Musteri
    {
        public int Id { get; set; }
        public string TCKimlikNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string EhliyetNo { get; set; }
        public string EhliyetTuru { get; set; }
    }
}
