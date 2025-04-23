using System.Text.Json;

namespace TravelBlogBlazorPages.Model
{
    public class TourRepository
    {
        public IList<Tour> GetAll()
        {
            lock (this)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "tours.json");
                using var stream = File.OpenText(filePath);
                return JsonSerializer.Deserialize<IList<Tour>>(stream.ReadToEnd()) ?? new List<Tour>();
            }
        }

        public void Add(Tour newItem)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            lock (this)
            {
                IList<Tour> items;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "tours.json");
                using (var stream = File.OpenText(filePath))
                {
                    items = JsonSerializer.Deserialize<IList<Tour>>(stream.ReadToEnd()) ?? new List<Tour>();
                }
                items.Add(newItem);
                File.WriteAllText(filePath, JsonSerializer.Serialize(items, options));
            }
        }
        public void Save(IList<Tour> tours)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            lock (this)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "tours.json");

                File.WriteAllText(filePath, JsonSerializer.Serialize(tours, options));
            }
        }
    }
}
