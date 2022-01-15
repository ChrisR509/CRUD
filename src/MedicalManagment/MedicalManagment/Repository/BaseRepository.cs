using MedicalManagment.Abstracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace MedicalManagment.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public ValueTask<IQueryable<T>> All { get; set; }
        private string connString = ConfigurationManager.ConnectionStrings["MedicalConnection"].ToString();
        public BaseRepository(string query)
        {
            All = ReadAllRecord(query);
        }

        public async ValueTask<bool> CreateAsync(T entity, string query)
        {
            using var conn = new SqlConnection(connString);
            return await conn.ExecuteAsync(sql: query, param: entity, commandType: CommandType.StoredProcedure) > 0;
        }
        public async ValueTask<bool> CreateAsync(object entity, string query)
        {
            using var conn = new SqlConnection(connString);
            return await conn.ExecuteAsync(sql: query, param: entity, commandType: CommandType.StoredProcedure) > 0;
        }

        public async ValueTask<bool> CreateAsync( string query)
        {
            using var conn = new SqlConnection(connString);
            return await conn.ExecuteAsync(sql: query, commandType: CommandType.Text) > 0;
        }

        public async ValueTask<bool> DeleteAsync(T entity, string query)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<T> GetAsync(Func<T, bool> predicate, string query)
        {
            using var conn = new SqlConnection(connString);
            var entity = await conn.QueryAsync<T>(query);
            return entity.FirstOrDefault(predicate);
        }

        public async ValueTask<bool> UpdateAsync(T entity, string query)
        {
            throw new NotImplementedException();
        }
        private async ValueTask<IQueryable<T>> ReadAllRecord(string query)
        {
            using var conn = new SqlConnection(connString);
            var entity = await conn.QueryAsync<T>(query);
            return entity.AsQueryable();
        }

        //private async ValueTask<IQueryable<T>> MapToValueOfT(SqlDataReader reader)
        //{
        //    var result = new List<T>();
        //    var reading = reader;
        //    while (await reading.ReadAsync())
        //    {
        //        var item = Activator.CreateInstance<T>();
        //        foreach (var property in typeof(T).GetProperties())
        //        {
        //            if (!reading.IsDBNull(reading.GetOrdinal(property.Name)))
        //            {
        //                Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        //                property.SetValue(item, Convert.ChangeType(reading[property.Name], convertTo), null);
        //            }
        //        }
        //    }
        //    return result.AsQueryable();
        //}
    }
}
