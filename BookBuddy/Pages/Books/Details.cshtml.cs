using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookBuddy.Models;
using BookBuddy.Services;

namespace BookBuddy.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public Book Book { get; set; }
        public List<Review> Reviews { get; set; }

        [BindProperty]
        public Review NewReview { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = DataStore.Knjige.FirstOrDefault(k => k.Id == id);
            if (Book == null)
                return NotFound();

            Reviews = DataStore.Reviews
                .Where(r => r.BookId == id)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Book = DataStore.Knjige.FirstOrDefault(k => k.Id == id);
            if (Book == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                Reviews = DataStore.Reviews
                    .Where(r => r.BookId == id)
                    .ToList();

                return Page();
            }

            NewReview.Id = DataStore.Reviews.Count + 1;
            NewReview.BookId = id;
            DataStore.Reviews.Add(NewReview);

            return RedirectToPage(new { id });
        }
    }
}