using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vscode_booklistrazor.Data;
using vscode_booklistrazor.Model;

namespace vscode_booklistrazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly DataContext _db;

        [TempData]
        public string Message { get; set; }

        public EditModel(DataContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Books.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();
                Message = "Book has been updated successfully";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}