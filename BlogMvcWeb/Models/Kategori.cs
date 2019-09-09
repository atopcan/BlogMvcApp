using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcWeb.Models
{
    public class Kategori
    {
        
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        //her bir kategoriye ait birden fazla blog olacak
        public List<Blog> Bloglar{ get; set; }
    }
}