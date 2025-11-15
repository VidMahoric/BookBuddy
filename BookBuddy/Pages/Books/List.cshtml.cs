using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookBuddy.Services;
using BookBuddy.Models;

namespace BookBuddy.Pages.Books
{
    public class ListModel : PageModel
    {
        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = DataStore.Knjige;
        }

        public IActionResult OnPostDelete(int id)
        {
            var book = DataStore.Knjige.FirstOrDefault(k => k.Id == id);

            if (book != null)
                DataStore.Knjige.Remove(book);

            return RedirectToPage();
        }
    }
}