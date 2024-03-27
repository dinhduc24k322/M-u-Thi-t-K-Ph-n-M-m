using System;

namespace Adapter
{
    internal class ChuyenDoiDinhDangVideo
    {
        static void Main(string[] args)
        {
            
        var legacyVideoPlayer = new LegacyVideoPlayer();

            
            var videoPlayerAdapter = new VideoPlayerAdapter(legacyVideoPlayer);

            
            videoPlayerAdapter.PlayVideo("ModernMovie.mp4");

            Console.ReadLine();
        }
    }
}
