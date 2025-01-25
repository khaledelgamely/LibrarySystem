namespace librarySystem.Models.Repository
{
    public class AuthorRepo : ILiberaryRepository<Author>
    {
        List<Author> Authors;

        public AuthorRepo()
        {
            Authors = new List<Author>()
            {
                new Author{Id = 1, Name = "ali"},
                new Author{Id = 2, Name = "malek"},
                new Author{Id = 3,Name = "omar"}
            };
        }
        public void Add(Author entity)
        {
            Authors.Add(entity);
        }

        public void Delete(int id)
        {
            var Author = Find(id);
            Authors.Remove(Author);
        }

        public Author Find(int id)
        {
            var Author = Authors.SingleOrDefault(x => x.Id == id);
            return Author;
        }

        public IList<Author> List()
        {
            return Authors;
        }

        public List<Author> Search(string term)
        {
            return Authors.Where(a => a.Name.Contains(term)).ToList();

        }

        public void Update(int id, Author newAuthor)
        {
            var Author = Find(id);
            Author.Name = newAuthor.Name;
        }
    }
}
