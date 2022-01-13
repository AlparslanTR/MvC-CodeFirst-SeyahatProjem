﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sınıflar;

namespace Travel.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorumlar by = new BlogYorumlar();
        public ActionResult Index()
        {
            // var bloglar = c.Blogs.ToList();
            by.deger1 = c.Blogs.ToList();
            by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); // Son eklenen bloglara göre listeleme
            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {
            // var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar p)
        {
            c.Yorumlars.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        public ActionResult YorumGetir()
        {
            by.deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
    }
}