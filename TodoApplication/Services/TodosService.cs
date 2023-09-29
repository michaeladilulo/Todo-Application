using System;
using TodoApplication.Models;
using TodoApplication.Repositories;

namespace TodoApplication.Controllers
{
	public class TodosService
	{
		private readonly TodosRepository _repo;

		public TodosService(TodosRepository repo)
		{
			_repo = repo;
		}

		internal IEnumerable<Todo> GetAllTodos()
		{
			return _repo.GetAllTodos();
		}
	}
}

