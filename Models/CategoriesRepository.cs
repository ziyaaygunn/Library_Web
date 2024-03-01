

using Library_Web.Utility;

namespace Library_Web.Models
{


	public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public CategoriesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}

		public void Update(Categories category)
		{
			_applicationDbContext.Update(category);
		}
	}
}

