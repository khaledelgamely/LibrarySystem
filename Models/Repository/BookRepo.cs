
namespace librarySystem.Models.Repository
{
    public class BookRepo : ILiberaryRepository<Book>
    {
        List<Book> books;

        public BookRepo()
        {
            books = new List<Book>()
            {
                new Book{Id = 1, Title = "title 1", Description = "desc 1"},
                new Book{Id = 2, Title = "title 2", Description = "desc 2"},
                new Book{Id = 3, Title = "title 3", Description = "desc 3"}
            };
        }
        public void Add(Book entity)
        {
           entity.Id = books.Max(x => x.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(x => x.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public List<Book> Search(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void Update(int id, Book newBook)
        {
            var book = Find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
        }
    }
}
