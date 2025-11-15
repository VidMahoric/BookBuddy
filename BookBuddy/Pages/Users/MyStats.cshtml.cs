using Microsoft.AspNetCore.Mvc.RazorPages;
using BookBuddy.Services;
using BookBuddy.Models;

namespace BookBuddy.Pages.Users
{
    public class MyStatsModel : PageModel
    {
        public int TotalBooks { get; set; }
        public double AverageRating { get; set; }

        public void OnGet()
        {
            var books = DataStore.Knjige;

            TotalBooks = books.Count;

            var ratedBooks = books.Where(k => k.Ocena.HasValue).ToList();

            if (ratedBooks.Any())
                AverageRating = ratedBooks.Average(k => k.Ocena!.Value);
            else
                AverageRating = 0;
        }
    }
}