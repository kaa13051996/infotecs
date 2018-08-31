namespace RSS_WPF
{
    class Post
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public Post(string Name, string Link, string Date, string Description)
        {
            this.Name = Name;
            this.Link = Link;
            this.Date = Date;
            this.Description = Description;
        }        
    }
}
