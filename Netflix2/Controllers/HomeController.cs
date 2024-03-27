using Netflix2.Controllers.Strategy;
using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers
{
    public class HomeController : Controller
    {
        private readonly XemPhimEntities _database;
        private readonly SearchContext _searchContext;
        XemPhimEntities database = new XemPhimEntities();
        public HomeController()
        {
            _database = new XemPhimEntities();
            _searchContext = new SearchContext(new TenPhimSearchStrategy());
        }
        public ActionResult TrangChu()
        {
            using (var dbContext = new XemPhimEntities())
            {
                var items = dbContext.Phim.ToList();

                return View(items);
            }
        }


        public ActionResult TvShow()
        {
            return View();
        }

        public ActionResult Movie()
        {
            return View();
        }
        public ActionResult NewPopular()
        {
            return View();
        }
        public ActionResult MyList()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ChiTietPhim(int Id)
        {
            var Phim = database.Phim.FirstOrDefault(s => s.IdPhim == Id);
            return View(Phim);
        }
        public ActionResult XemPhim(int Id)
        {
            var Phim = database.Phim.FirstOrDefault(s => s.IdPhim == Id);
            return View(Phim);
        }
        public ActionResult TimKiem(string searchString)
        {
            List<Phim> searchResults = _searchContext.Search(searchString, _database);
            return View(searchResults);
            //return View(database.Phim.Where(x => x.TenPhim.Contains(searching) || searching == null).ToList());
        }
    }
}