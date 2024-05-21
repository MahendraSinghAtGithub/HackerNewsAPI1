namespace HackerNewsAPI.Modal
{
    public class Story :BaseEntity 
    {
        public string By { get; set; }
        public int descendants{ get; set; }
        public int score { get; set; }
        public int time { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}
