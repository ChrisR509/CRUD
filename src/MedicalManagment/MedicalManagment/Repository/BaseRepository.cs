using MedicalManagment.Abstracts;
using MedicalManagment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Repository
{
    public class BaseRepository<T> : IRepository<T>, IConnection where T : class
    {
        public ValueTask<IQueryable<T>> All { get; set; }

        private static readonly MedicalManagmentContext _context = new MedicalManagmentContext();
        private readonly SqlConnection _connection = new SqlConnection(connectionString: _context.ConnectionString);
        public BaseRepository(string query)
        {
            All = ReadAllRecord(query);
        }
        public async Task CloseConnection() => await _connection.CloseAsync();

        public async ValueTask<bool> CreateAsync(T entity, string query)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> DeleteAsync(T entity, string query)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IQueryable<T>> GetAsync(Expression<Func<T, bool>> predicate, string query)
        {
            using var command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            var reader = command.ExecuteReaderAsync();
            var mapT = await MapToValueOfT(reader);
            return mapT.Where(predicate);
        }

        public async Task OpenConnection() => await _connection.OpenAsync();

        public async ValueTask<bool> UpdateAsync(T entity, string query)
        {
            throw new NotImplementedException();
        }
        private ValueTask<IQueryable<T>> ReadAllRecord(string query)
        {
            using var command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            var reader = command.ExecuteReaderAsync();
            return MapToValueOfT(reader);
        }

        private async ValueTask<IQueryable<T>> MapToValueOfT(Task<SqlDataReader> reader)
        {
            var result = new List<T>();
            var reading = await reader;
            while (await reading.ReadAsync())
            {
                var item = Activator.CreateInstance<T>();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!reading.IsDBNull(reading.GetOrdinal(property.Name)))
                    {
                        Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        property.SetValue(item, Convert.ChangeType(reading[property.Name], convertTo), null);
                    }
                }
            }
            return result.AsQueryable();
        }
    }
}
