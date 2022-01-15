using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Abstracts
{
    public interface IRepository<T> where T : class
    {
        public ValueTask<IQueryable<T>> All { get; set; }
        public ValueTask<T> GetAsync(Func<T, bool> predicate, string query);
        public ValueTask<bool> CreateAsync(T entity, string query);
        public ValueTask<bool> CreateAsync(object entity, string query);
        public ValueTask<bool> CreateAsync(string query);
        public ValueTask<bool> UpdateAsync(T entity, string query);
        public ValueTask<bool> DeleteAsync(T entity, string query);
    }
}
