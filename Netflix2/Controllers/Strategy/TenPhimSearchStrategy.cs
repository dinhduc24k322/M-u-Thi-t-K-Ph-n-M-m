using Netflix2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Netflix2.Controllers.Strategy
{
    public class TenPhimSearchStrategy : ISearchStrategy
    {
        public List<Phim> Search(string searchString, XemPhimEntities database)
        {
            return database.Phim.Where(p => p.TenPhim.Contains(searchString)).ToList();
        }
    }


    // Các chiến lược tìm kiếm khác có thể được triển khai tại đây

}