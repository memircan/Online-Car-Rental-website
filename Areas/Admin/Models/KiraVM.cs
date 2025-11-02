namespace AracKiralama.Areas.Admin.Models
{
    public class KiraVM
    {
        public int Id { get; set; }
        public int ArabaId { get; set; }
        public int MusteriId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public int Tutar { get; set; }

        public virtual ArabaVM Araba { get; set; }
        public virtual MusteriVM Musteri { get; set; }
    }
}
