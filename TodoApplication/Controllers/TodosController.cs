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
			try
			{
				return Ok(_ts.GetAllTodos());
			}
			catch
			{
				throw;
			}
		}
	}
}

