using Microsoft.EntityFrameworkCore;
using vscode_booklistrazor.Model;

namespace vscode_booklistrazor.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}