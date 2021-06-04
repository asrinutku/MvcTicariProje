using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int Cariid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="en fazla 30 karakter yazılabilir")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="bu alanı boş geçemezsin")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariMail { get; set; }
        

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}