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

		public DateTime TodoCreatedOn { get; set; }

		public DateTime TodoUpdatedOn { get; set; }
	}
}

