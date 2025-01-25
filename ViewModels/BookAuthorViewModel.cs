using librarySystem.Models;
using System.ComponentModel.DataAnnotations;


namespace librarySystem.ViewModels

{
    public class BookAuthorViewModel
    {
        public int Id { get; set; }

        //[Required]
        //[MaxLength(20)]
        //[MinLength(3)]

        public string Title { get; set; }

        //[Required]
        //[StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public List<Author> authors { get; set; }
    }
}
