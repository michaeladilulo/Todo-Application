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

		public Todo GetById(int TodoId)
		{
			Todo foundTodo = _repo.GetById(TodoId) ?? throw new Exception("Invalid Id");
            return foundTodo;
		}

		internal Todo CreateTodo(Todo newTodo)
		{
			return _repo.CreateTodo(newTodo);
		}

		internal Todo EditTodo(Todo todoToUpdate, int TodoId)
		{
			Todo foundTodo = GetById(todoToUpdate.TodoId);

			_repo.EditTodo(todoToUpdate, TodoId);

			return todoToUpdate;
		}

		internal string DeleteTodo(int TodoId)
		{
			Todo foundTodo = GetById(TodoId);

			_repo.DeleteTodo(foundTodo.TodoId);

			return "Successfully Deleted Todo";
		}
	}
}

