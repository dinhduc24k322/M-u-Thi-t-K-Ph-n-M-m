using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class VideoPlayerAdapter
    {
        private LegacyVideoPlayer _legacyVideoPlayer;

        public VideoPlayerAdapter(LegacyVideoPlayer legacyVideoPlayer)
        {
            _legacyVideoPlayer = legacyVideoPlayer;
        }

        public void PlayVideo(string videoName)
        {
            
            string legacyVideoName = ConvertToLegacyFormat(videoName);
            _legacyVideoPlayer.PlayLegacyVideo(legacyVideoName);
        }

        private string ConvertToLegacyFormat(string videoName)
        {
          
            return videoName + "_legacy";
        }
    }
}
