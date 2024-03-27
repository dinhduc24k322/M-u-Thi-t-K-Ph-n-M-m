using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
     class LegacyVideoPlayer
    {
        public void PlayLegacyVideo(string legacyVideoName)
        {
            Console.WriteLine($"Playing legacy video: {legacyVideoName}");
        }
    }
}
