
namespace librarySystem.Models.Repository
{
    public class AuthorDBRepo : ILiberaryRepository<Author>
    {
        LibrarySystemDbContext db;

        public AuthorDBRepo(LibrarySystemDbContext _db)
        {
            
            db = _db;
        }
        public void Add(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var Author = Find(id);
            db.Authors.Remove(Author);
            db.SaveChanges();

        }

        public Author Find(int id)
        {
            var Author = db.Authors.SingleOrDefault(x => x.Id == id);
            return Author;
        }

        public IList<Author> List()
        {
            return db.Authors.ToList();
        }

        public List<Author> Search(string term)
        {
            return db.Authors.Where(a => a.Name.Contains(term)).ToList();

        }

        public void Update(int id, Author newAuthor)
        {
           db.Update(newAuthor);
            db.SaveChanges();
        }
    }
}
