using System.ComponentModel.DataAnnotations;

namespace vscode_booklistrazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string ISBN { get; set; }
        public string Author { get; set; }
    }
}