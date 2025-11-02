using System.ComponentModel.DataAnnotations.Schema;

namespace AracKiralama.Data.Entities
{
    [Table("Kiralama")]
    public class Kiralama
    {
        public int Id { get; set; }
        public int ArabaId { get; set; }
        public int MusteriId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public int Tutar { get; set; }

        [ForeignKey("ArabaId")]
        public virtual Araba Araba { get; set; }
        [ForeignKey("MusteriId")]
        public virtual Musteri Musteri { get; set; }
    }
}
