using System.Text.Json;

namespace TravelBlogBlazorPages.Model
{
    public class TravelRepository
    {
        public IList<Travel> GetAll()
        {
            lock (this)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "travels.json");
                using var stream = File.OpenText(filePath);
                return JsonSerializer.Deserialize<IList<Travel>>(stream.ReadToEnd()) ?? new List<Travel>();
            }
        }

        public void Add(Travel newItem)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            lock (this)
            {
                IList<Travel> items;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "travels.json");
                using (var stream = File.OpenText(filePath))
                {
                    items = JsonSerializer.Deserialize<IList<Travel>>(stream.ReadToEnd()) ?? new List<Travel>();
                }
                items.Add(newItem);
                File.WriteAllText(filePath, JsonSerializer.Serialize(items, options));
            }
        }

        public void Save(IList<Travel> travels) 
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            lock(this)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "travels.json");
  
                File.WriteAllText(filePath, JsonSerializer.Serialize(travels, options));
            }
        }
    }
}
