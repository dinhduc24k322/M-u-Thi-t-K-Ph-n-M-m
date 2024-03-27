using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Trình_chiếu_xem_phim
{
    class RealMoviePlayer : IMoviePlayer
    {
        public void PlayMovie(string movieName)
        {
            Console.WriteLine($"Playing movie: {movieName}");
        }
    }
}
