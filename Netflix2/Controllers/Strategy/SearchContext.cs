using Netflix2.Models;
using System.Collections.Generic;

namespace Netflix2.Controllers.Strategy
{
    public class SearchContext
    {
        private ISearchStrategy _searchStrategy;

        public SearchContext(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public void SetSearchStrategy(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public List<Phim> Search(string searchString, XemPhimEntities database)
        {
            return _searchStrategy.Search(searchString, database);
        }
    }

}