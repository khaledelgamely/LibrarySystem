using Microsoft.EntityFrameworkCore;


//responible for displayind data in view **
namespace librarySystem.Models.Repository
{
    public class BookDBRepo : ILiberaryRepository<Book>
    {
        LibrarySystemDbContext db;

        public BookDBRepo(LibrarySystemDbContext _db)
        {
           db = _db;
        }
        public void Add(Book entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();

        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(x => x.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return db.Books.Include(a=>a.Author).ToList();
        }

        public void Update(int id, Book newBook)
        {
            db.Update(newBook);
            db.SaveChanges();

        }

        public List<Book> Search(string term)
        {
            var result = db.Books.Include(a=>a.Author)
                .Where(b => b.Title.Contains(term)
            || b.Description.Contains(term)
            || b.Author.Name.Contains(term)).ToList();
            return result;
        }
    }
}