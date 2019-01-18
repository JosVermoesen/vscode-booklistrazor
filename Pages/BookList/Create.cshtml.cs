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
    public class CreateModel : PageModel
    {
        private readonly DataContext _db;
        public CreateModel(DataContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet() { }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Book has been created succesfully";
            return RedirectToPage("Index");
        }
    }
}