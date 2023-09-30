using System;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Models;

namespace TodoApplication.Controllers
{

	[ApiController]
	[Route("api/[controller]")]

	public class TodosController : ControllerBase
	{
		private readonly TodosService _ts;

		public TodosController(TodosService ts)
		{
			_ts = ts;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Todo>> GetAllTodos()
		{
			try // THIS CAN BE CLEANED UP AND REFACTORED
			{
				return Ok(_ts.GetAllTodos());
			}
			catch
			{
				throw;
			}
		}

		[HttpGet("{TodoId}")]

		public ActionResult<Todo> GetById(int TodoId)
		{
			try
			{
				return Ok(_ts.GetById(TodoId));
			}
			catch (System.Exception error)
			{
				return BadRequest(error.Message);
			}
		}

		[HttpPost]
		public ActionResult<Todo> CreateTodo(Todo newTodo)
		{
			try
			{
				return Ok(_ts.CreateTodo(newTodo));
			}
			catch (System.Exception error)
			{
				return BadRequest(error.Message);
			}
		}
	}
}

