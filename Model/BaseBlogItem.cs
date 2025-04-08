namespace TravelBlogBlazorPages.Model
{
    public class BaseBlogItem
    {
        public required string description { get; set; }
        public DateTime date { get; set; }
        public required string title { get; set; }
        public required string image { get; set; }
    }
}
