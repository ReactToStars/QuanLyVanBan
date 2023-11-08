using System.Collections.Generic;

namespace QuanLyVanBan.Repositories
{
	public interface IBaseRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T Get(string id);
		void Add(T entity);
		void Update(T entity);
		void Delete(string condition);
		IEnumerable<T> Find(string filter);
	}
}
