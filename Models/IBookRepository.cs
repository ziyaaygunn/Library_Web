namespace Library_Web.Models
{
    public interface IBookRepository : IRepository<Book> 
    {
        void Update(Book book);
        void Save();
    }
}
