

namespace Library_Web.Models
{
	public interface ICategoriesRepository : IRepository<Categories> 
	{
		void Update(Categories category);
		void Save();
	}
}
