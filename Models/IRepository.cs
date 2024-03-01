using System.Linq.Expressions;

namespace Library_Web.Models
{
	public interface IRepository<T> where T : class
	{
		

		IEnumerable<T> GetAll(string? includeProps = null);
		T Get(Expression<Func<T, bool>> filtre, string? includeProps = null); 
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity);

	
	}
}
