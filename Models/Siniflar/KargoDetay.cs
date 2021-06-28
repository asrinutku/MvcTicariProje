using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int Kargoid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]

        public string Aciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]

        public string TakipKodu { get; set; }
        public string Personel { get; set; }
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }

    }
}