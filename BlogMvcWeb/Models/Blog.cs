using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcWeb.Models
{
    public class Blog
    {
        
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string İcerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Onay { get; set; }
        public bool Anasayfa { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}