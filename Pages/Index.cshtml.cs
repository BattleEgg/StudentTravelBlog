using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TravelBlogBlazorPages.Model;

namespace TravelBlogBlazorPages.Pages;

public class IndexModel : PageModel
{
    public TravelRepository TravelsList { get; private set; } = new();
    public TourRepository ToursList { get; private set; } = new();
    public CountryRepository CountriesList { get; private set; } = new();

    public void OnGet()
    {
        
    }

    public IActionResult OnPostDelete(Guid id, string type)
    {
        switch (type)
        {
            case "travels":
                var travels = TravelsList.GetAll();
                var travel = travels.SingleOrDefault(i => i.id == id);
                if (travel != null)
                {
                    travels.Remove(travel);
                    TravelsList.Save(travels);
                    return RedirectToPage(); // Перенаправляем обратно на страницу
                }
                break;
            case "tours":
                var tours = ToursList.GetAll();
                var tour = tours.SingleOrDefault(i => i.id == id);
                if (tour != null)
                {
                    tours.Remove(tour);
                    ToursList.Save(tours);
                    return RedirectToPage(); // Перенаправляем обратно на страницу
                }
                break;
            case "countries":
                var countries = CountriesList.GetAll();
                var country = countries.SingleOrDefault(i => i.id == id);
                if (country != null)
                {
                    countries.Remove(country);
                    CountriesList.Save(countries);
                    return RedirectToPage(); // Перенаправляем обратно на страницу
                }
                break;
        }
        return NotFound(); // Возвращаем ошибку, если элемент не найден
    }
}
