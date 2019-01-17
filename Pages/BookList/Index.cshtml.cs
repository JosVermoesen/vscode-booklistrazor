using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vscode_booklistrazor.Data;
using vscode_booklistrazor.Model;

namespace vscode_booklistrazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _db;

        public IndexModel(DataContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }
    }
}