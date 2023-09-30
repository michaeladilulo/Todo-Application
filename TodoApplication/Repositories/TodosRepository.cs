using System;
using System.Data;
using Dapper;
using TodoApplication.Models;

namespace TodoApplication.Repositories
{
	public class TodosRepository
	{
		private readonly IDbConnection _db;

		public TodosRepository(IDbConnection db)
		{
			_db = db;
		}

		internal IEnumerable<Todo> GetAllTodos()
		{
			string sql = "SELECT * FROM todos";
			return _db.Query<Todo>(sql);
		}

		internal Todo GetById(int TodoId)
		{
			string sql = "SELECT * FROM todos WHERE TodoId = @TodoId";
			return _db.QueryFirstOrDefault<Todo>(sql, new { TodoId });
		}
	}
}

