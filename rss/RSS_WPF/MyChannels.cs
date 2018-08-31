using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows;
using System.Xml;

namespace RSS_WPF
{
    class Channel
    {       
        public List<Post> Posts
        {
            get
            {
                List<Post> result = new List<Post>();            
                XmlReader rssReader = XmlReader.Create(this.LinkRSS);                
                Rss20FeedFormatter feedFormatter = new Rss20FeedFormatter();
                if (feedFormatter.CanRead(rssReader))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(rssReader);
                    foreach (SyndicationItem item in feed.Items)
                    {
                        result.Add(new Post(item.Title.Text, item.Id, item.PublishDate.ToString(), item.Summary.Text));                        
                    }
                    
                    rssReader.Close();
                }
                else MessageBox.Show("Нет возможности прочитать RSS.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);          
                return result;
            }
            set{ }
        }       

        public string NameChannel { get; set; }
        public string LinkRSS { get; set; }        

        public Channel(string NameChannel, string LinkRSS)
        {
            this.NameChannel = NameChannel;
            this.LinkRSS = LinkRSS;
        }
        //Конструктор по-умолчанию для вставки.
        public Channel() { }                

    }
}
