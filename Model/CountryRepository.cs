using System.Text.Json;

namespace TravelBlogBlazorPages.Model
{
    public class CountryRepository
    {

        public IList<Country> GetAll()
        {
            lock (this)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "countries.json");
                using var stream = File.OpenText(filePath);
                return JsonSerializer.Deserialize<IList<Country>>(stream.ReadToEnd()) ?? new List<Country>();
            }
        }

        public void Add(Country newItem)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            lock (this)
            {
                IList<Country> items;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "countries.json");
                using (var stream = File.OpenText(filePath))
                {
                    items = JsonSerializer.Deserialize<IList<Country>>(stream.ReadToEnd()) ?? new List<Country>();
                }
                items.Add(newItem);
                File.WriteAllText(filePath, JsonSerializer.Serialize(items, options));
            }
        }
        public void Save(IList<Country> countries)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            lock (this)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "countries.json");

                File.WriteAllText(filePath, JsonSerializer.Serialize(countries, options));
            }
        }
    }
}
