using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Trình_chiếu_xem_phim
{
    internal class MoviePlayerProxy
    {
        private RealMoviePlayer _realMoviePlayer;
        private string _username;
        private string _password;

        public MoviePlayerProxy(string username, string password)
        {
            _realMoviePlayer = new RealMoviePlayer();
            _username = username;
            _password = password;
        }

        public void PlayMovie(string movieName)
        {
            if (CheckAccess())
            {
                _realMoviePlayer.PlayMovie(movieName);
            }
            else
            {
                Console.WriteLine("Access denied. Please login with valid credentials.");
            }
        }

        private bool CheckAccess()
        {
           
            return true;
        }
    }
}
