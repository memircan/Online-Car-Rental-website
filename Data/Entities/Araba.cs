using System.ComponentModel.DataAnnotations.Schema;

namespace AracKiralama.Data.Entities
{
    [Table("Araba")]
    public class Araba
    {
        public int Id { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
        public int YakitTipi { get; set; } //0-Benzinli 2-Dizel 3-LPG 4-Hybrid 5-Elektrik
        public int Vites { get; set; } //0-Manuel 1-Yarı Otomatik 2-Otomatik
        public int Kilometre { get; set; }
        public int KasaTipi { get; set; } //0-Cabrio 1-Coupe 2-Hatchback 3-Sedan 4-Station Wagon
        public int CekisTipi { get; set; } //0-Önden Çekiş 1-Arkadan İtiş 3-4WD
        public int Renk { get; set; } //0-Bej 1-Beyaz 2-Bordo 3-Füme 4-Gri 5-Gümüş Gri 6-Kahverengi 7-Kırmızı 8-Lacivert 9-Mavi 10-Mor 11-Pembe 12-Sarı 13-Siyah 14-Turkuaz 15-Turuncu 16-Yeşil
    }
}
