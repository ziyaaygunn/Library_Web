using Library_Web.Utility;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library_Web.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _applicationDbContext;
		internal DbSet<T> dbSet; 
		public Repository(ApplicationDbContext applicationDbContext) 
		{
			_applicationDbContext = applicationDbContext; 
			this.dbSet = applicationDbContext.Set<T>(); 
			_applicationDbContext.Books.Include(k => k.Categories).Include(k => k.CategoriesId); 											
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);  
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);  
		}

		public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null) 
		{
			IQueryable<T> sorgu = dbSet;
			sorgu = sorgu.Where(filtre);
			if (!string.IsNullOrEmpty(includeProps)) 
			{
				foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
				{
					sorgu = sorgu.Include(includeProp);
				}
			}


			return sorgu.FirstOrDefault(); 
		}

		public IEnumerable<T> GetAll(string? includeProps = null) 
		{
			IQueryable<T> sorgu = dbSet;
			if (!string.IsNullOrEmpty(includeProps)) 
			{
				foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) // çektiğimiz property'leri ekliyoruz
				{
					sorgu = sorgu.Include(includeProp);
				}
			}

			return sorgu.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity); 

		}
	}

}
