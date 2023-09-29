using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models
{
	public class Todo
	{
		public int TodoId { get; set; }

		[Required]
		public string TodoTitle { get; set; }

		[Required]
		public string TodoDescription { get; set; }

		public DateOnly TodoCreatedOn { get; set; }

		public DateOnly TodoUpdatedOn { get; set; }
	}
}

