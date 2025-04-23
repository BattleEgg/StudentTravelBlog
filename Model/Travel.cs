namespace TravelBlogBlazorPages.Model
{
    public class Travel
    {
        public Guid id { get; set; }
        public required string description { get; set; }
        public DateTime date { get; set; }
        public required string title { get; set; }
        public required string image { get; set; }
    }
}
