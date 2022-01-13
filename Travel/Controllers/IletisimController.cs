using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sınıflar;

namespace Travel.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        Context c = new Context();
        public ActionResult Index()
        {

            return View();
        }
    }
}