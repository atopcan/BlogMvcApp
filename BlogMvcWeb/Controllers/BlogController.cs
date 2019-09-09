using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcWeb.Models;

namespace BlogMvcWeb.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string AnahtarKelime)
        {
            var bloglar = db.Bloglar
               .Where(i => i.Onay == true )
               .Select(i => new BlogModel()
               {
                   Id = i.Id,
                   Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                   Aciklama = i.Aciklama,
                   EklenmeTarihi = i.EklenmeTarihi,
                   Resim = i.Resim,
                   Onay = i.Onay,
                   Anasayfa = i.Anasayfa,
                   KategoriId=i.KategoriId

               }).AsQueryable();

            if (string.IsNullOrEmpty(AnahtarKelime)==false)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(AnahtarKelime) || i.Aciklama.Contains(AnahtarKelime)); // başlığa yada açıklamaya göre filtreleme yapar
            }

            if (id!=null)
            {
                bloglar = bloglar.Where(i => i.KategoriId == id);
            }

            return View(bloglar.ToList());
        }

        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Kategori).OrderByDescending(i=> i.EklenmeTarihi); //en son eklenen kaydı listenin başına alıyoruz
            return View(bloglar.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,İcerik,KategoriId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.EklenmeTarihi = DateTime.Now;

                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.KategoriId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.KategoriId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,İcerik,Onay,Anasayfa,KategoriId")] Blog blog) // güncellenicek alanları burada tanımlıyoruz
        {
            //id ye göre blogtan gelen içerikleri güncelliyoruz
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity !=null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.İcerik = blog.İcerik;
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.KategoriId = blog.KategoriId;

                    db.SaveChanges();
                    TempData["Blog"] = entity; //tempdata:bilgi taşımak için

                    return RedirectToAction("Index");


                }
                //db.Entry(blog).State = EntityState.Modified;



            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.KategoriId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
