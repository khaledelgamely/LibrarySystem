namespace librarySystem.Models.Repository
{
    public interface ILiberaryRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find (int id);

        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
        public List<TEntity> Search(string term);
    }
}
