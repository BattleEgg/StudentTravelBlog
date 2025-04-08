using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TravelBlogBlazorPages.Model;

namespace TravelBlogBlazorPages.Pages;

public class IndexModel : PageModel
{
    public List<Travel> TravelsList { get; private set; } = new();
    public List<Tour> ToursList { get; private set; } = new();
    public List<Country> CountriesList { get; private set; } = new();

    public void OnGet()
    {
        var travelsJson = ReadJsonFile("travels.json");
        if (travelsJson != null)
        {
            TravelsList = JsonSerializer.Deserialize<List<Travel>>(travelsJson) ?? new List<Travel>();
        }

        var countriesJson = ReadJsonFile("countries.json");
        if (countriesJson != null)
        {
            CountriesList = JsonSerializer.Deserialize<List<Country>>(countriesJson) ?? new List<Country>();
        }

        var toursJson = ReadJsonFile("tours.json");
        if (toursJson != null)
        {
            ToursList = JsonSerializer.Deserialize<List<Tour>>(toursJson) ?? new List<Tour>();
        }
    }


    private string? ReadJsonFile(string name) 
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", name);

        if (System.IO.File.Exists(filePath))
        {
            return System.IO.File.ReadAllText(filePath);
        }
        else
        {
            return null;
        }
    }
}
