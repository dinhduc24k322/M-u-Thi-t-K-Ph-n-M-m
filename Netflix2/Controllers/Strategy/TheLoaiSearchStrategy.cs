using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix2.Controllers.Strategy
{
    public class TheLoaiSearchStrategy : ISearchStrategy
    {
        public List<Phim> Search(string searchString, XemPhimEntities database)
        {
            return database.Phim.Where(p => p.TheLoai.Contains(searchString)).ToList();
        }

    }
}