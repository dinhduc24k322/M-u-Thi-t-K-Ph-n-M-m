using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix2.Controllers.Factory_Method
{
    public class PhimFactory : IPhimFactory
    {
        public Phim CreatePhim(Phim phim)
        {
            return phim;
        }
    }
}