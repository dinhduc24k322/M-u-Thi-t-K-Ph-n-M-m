using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix2.Controllers.Factory_Method
{
    public interface IPhimFactory
    {
        Phim CreatePhim(Phim phim);

    }
}
