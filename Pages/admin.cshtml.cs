using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelBlogBlazorPages.Model;

namespace TravelBlogBlazorPages.Pages
{
    public class adminModel : PageModel
    {
        public TravelRepository TravelsList { get; } = new();
        public TourRepository ToursList { get; } = new();
        public CountryRepository CountriesList { get; } = new();


        public required IFormFile Image { get; set; } // Связываем файл с моделью

        public required string UploadedFilePath { get; set; } // Путь к загруженному файлу


        public void OnGet()
        {
        }

        public ActionResult OnPost(string type, string title, string description)
        {
            ArgumentNullException.ThrowIfNull(title);
            ArgumentNullException.ThrowIfNull(description);

            CopyFileToServer();

            switch (type)
            {
                case "travels":
                    TravelsList.Add(new Travel
                    {
                        id = Guid.NewGuid(),
                        title = title,
                        description = description,
                        image = UploadedFilePath,
                        date = DateTime.Now
                    });
                    break;
                case "tours":
                    ToursList.Add(new Tour
                    {
                        id = Guid.NewGuid(),
                        title = title,
                        description = description,
                        image = UploadedFilePath,
                        date = DateTime.Now
                    });
                    break;
                case "countries":
                    CountriesList.Add(new Country
                    {
                        id = Guid.NewGuid(),
                        title = title,
                        description = description,
                        image = UploadedFilePath,
                        date = DateTime.Now
                    });
                    break;
            }
            return RedirectToPage();
        }


        private void CopyFileToServer()
        {
            if (Image != null && Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data/Images"); // Папка для загрузки

                var filePath = Path.Combine(uploadsFolder, Image.FileName); // Полный путь к файлу

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }

                UploadedFilePath = Path.Combine("Data/Images", Image.FileName); // Сохраняем относительный путь к загруженному файлу
            }
        }

    }
}
