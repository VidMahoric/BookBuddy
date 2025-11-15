using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookBuddy.Services;
using BookBuddy.Models;

namespace BookBuddy.Pages.Books
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Book NewBook { get; set; } = new Book(); 

        public void OnGet() {}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            
            NewBook.Id = DataStore.Knjige.Count + 1;

            DataStore.Knjige.Add(NewBook);

            return RedirectToPage("/Books/List");
        }
    }
}