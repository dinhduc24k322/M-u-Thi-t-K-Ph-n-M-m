using System;

namespace Proxy_Trình_chiếu_xem_phim
{
    public class TrinhChieuXemPhim
    {
        static void Main(string[] args)
        {
            // Creating proxy
            var moviePlayerProxy = new MoviePlayerProxy("username", "password");

            // Play movie using proxy
            moviePlayerProxy.PlayMovie("The Matrix");

            Console.ReadLine();
        }
    }
}
