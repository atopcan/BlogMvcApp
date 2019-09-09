using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcWeb.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("blogDb")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        //veritabanına 2 tabloyu ekliyoruz
        //DbSet BlogContext içerindeki sınıfları temsil ediyor
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}