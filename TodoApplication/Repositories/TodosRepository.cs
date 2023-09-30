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

		internal Todo CreateTodo(Todo newTodo)
		{
			string sql = "INSERT INTO todos (TodoTitle, TodoDescription) VALUES (@TodoTitle, @TodoDescription); SELECT LAST_INSERT_ID()";
			newTodo.TodoId = _db.ExecuteScalar<int>(sql, newTodo);
			return newTodo;
		}

		internal Todo EditTodo(Todo todoToUpdate, int TodoId)
		{
			todoToUpdate.TodoId = TodoId;

			string sql = "UPDATE todos SET TodoTitle = @TodoTitle, TodoDescription = @TodoDescription WHERE TodoId = @TodoId";
			todoToUpdate.TodoId = _db.Execute(sql, todoToUpdate);
			return todoToUpdate;
		}
	}
}

