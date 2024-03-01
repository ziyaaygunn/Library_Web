namespace Library_Web.Models
{
    public interface IHireRepository : IRepository<Hire> 
    {
        void Update(Hire hire);
        void Save();
    }
}
