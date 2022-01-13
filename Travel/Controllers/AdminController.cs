using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sınıflar;
namespace Travel.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var listele = c.Blogs.ToList();
            return View(listele);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blog = c.Blogs.Find(b.ID);
            blog.Aciklama = b.Aciklama;
            blog.Baslik = b.Baslik;
            blog.BlogImage = b.BlogImage;
            blog.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumGetir()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var yorumsil = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yorumsil);
            c.SaveChanges();
            return RedirectToAction("YorumGetir");
        }
        public ActionResult Hakkimizda()
        {
            var hakkım = c.Hakkimizdas.ToList();
            return View(hakkım);
        }
        public ActionResult HakkimizdaGetir(int id)
        {
            var hak = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hak);
        }
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hak = c.Hakkimizdas.Find(h.ID);
            hak.FotoUrl = h.FotoUrl;
            hak.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    } 
}