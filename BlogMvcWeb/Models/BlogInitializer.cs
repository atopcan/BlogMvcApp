using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcWeb.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext> // BlogInitializer:Veritabanındaki değişiklikleri uyarlar ve test verilerini otamatik olarak ekler,DropCreateDatabaseIfModelChanges ise modelde değişiklik olduğunda db yi siler ve yeniden oluşturur
    {
        protected override void Seed(BlogContext context) // Seed metodu test verilerini eklememizi sağlar
        {
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori() { KategoriAdi = "C#" },
                new Kategori() { KategoriAdi = "Windows Form" },
                new Kategori() { KategoriAdi = "ASP.NET MVC" },
                new Kategori() { KategoriAdi = "ASP.NET WebForm" }
            };

            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();

            List<Blog> bloglar = new List<Blog>()
            {
                new Blog() {Baslik = "C# dili hakkında bilinmesi gerekenler", Aciklama = "C# dili hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=false, Onay=true,KategoriId=1 },
                new Blog() {Baslik = "C# dili hakkında bilinmesi gerekenler", Aciklama = "C# dili hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=true, Onay=false,KategoriId=1 },
                new Blog() {Baslik = "Windows Form hakkında bilinmesi gerekenler", Aciklama = "Windows Form hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-5), Anasayfa=true, Onay=true,KategoriId=2 },
                new Blog() {Baslik = "Windows Form hakkında bilinmesi gerekenler", Aciklama = "Windows Form hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-5), Anasayfa=true, Onay=false,KategoriId=2 },
                new Blog() {Baslik = "ASP.NET MVC hakkında bilinmesi gerekenler", Aciklama = "ASP.NET MVC hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-3), Anasayfa=false, Onay=true,KategoriId=3 },
                new Blog() {Baslik = "ASP.NET MVC hakkında bilinmesi gerekenler", Aciklama = "ASP.NET MVC hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-3), Anasayfa=true, Onay=true,KategoriId=3 },
                new Blog() {Baslik = "ASP.NET WebForm hakkında bilinmesi gerekenler", Aciklama = "ASP.NET WebForm hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-1), Anasayfa=false, Onay=false,KategoriId=4 },
                new Blog() {Baslik = "ASP.NET WebForm hakkında bilinmesi gerekenler", Aciklama = "ASP.NET WebForm hakkında açıklama",Resim = "resim.jpg",İcerik = "C# dili hakkında içerik",EklenmeTarihi = DateTime.Now.AddDays(-1), Anasayfa=true, Onay=true,KategoriId=4 }
            };
            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}