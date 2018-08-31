using System;
using System.Collections.Generic;

namespace RSS_WPF
{
    class Session
    {
        public Settings _settings = new Settings();
        public List<Channel> channels;        

        public void OutputChannels()
        {
            ProgressChanged(10);
            int progress = 0;     
            channels = _settings.GetChannelList();
            foreach (Channel channel in channels)
            {                        
                channel.Posts = channel.Posts;
                progress = ((progress + 1) * 90 / channels.Count) + 10;
                ProgressChanged(progress);
            }            
            OutputData(true);
        }

        public event Action<int> ProgressChanged;
        public event Action<bool> OutputData;
    }
}
