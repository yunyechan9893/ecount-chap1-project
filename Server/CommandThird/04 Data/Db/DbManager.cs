using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Data.Db
{
	public class DbManager
	{
		private const string _connectionString = Conf.DB_URL;

		public DbManager()
		{

        }

		public int Execute(string sql, Dictionary<string, object> parameters)
		{
			using (var conn = new NpgsqlConnection(_connectionString)) {
				conn.Open();

				using (var cmd = conn.CreateCommand()) {
					cmd.CommandText = sql;
					
					foreach (var param in parameters) {
						cmd.Parameters.Add(new NpgsqlParameter(param.Key, param.Value));
					}

					return cmd.ExecuteNonQuery();
				}
			}
		}

		public List<T> Query<T>(string sql, Dictionary<string, object> parameters, Action<DbDataReader, T> mapper)
			where T : new()
		{
			using (var conn = new NpgsqlConnection(_connectionString)) {
				conn.Open();

				using (var cmd = conn.CreateCommand()) {
					cmd.CommandText = sql;

					foreach (var param in parameters) {
						cmd.Parameters.Add(new NpgsqlParameter(param.Key, param.Value));
					}

					var result = new List<T>();
					using (var reader = cmd.ExecuteReader()) {
						while (reader.Read()) {
							var data = new T();
							mapper(reader, data);

							result.Add(data);
						}
					}

					return result;
				}
			}
		}
    }
}
