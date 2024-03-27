using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix2.Controllers.Strategy
{
    public interface ISearchStrategy
    {
        List<Phim> Search(string searchString, XemPhimEntities database);
    }
    public class TenPhimSearchStrategy : ISearchStrategy
    {
        public List<Phim> Search(string searchString, XemPhimEntities database)
        {
            return database.Phim.Where(p => p.TenPhim.Contains(searchString)).ToList();
        }


    }
}
