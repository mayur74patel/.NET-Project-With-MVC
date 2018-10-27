using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9.Models
{
	public class State
	{
		[Key]
		public int StateId { get; set; }
		public string StateName { get; set; }
		[ForeignKey("Election")]
		public int ElectionId { get; set; }
		public string ElectionDate { get; set; }
		public string ResultDate { get; set; }
		public int Seats { get; set; }

		public virtual ICollection<Election> Election { get; set; }
		public virtual ICollection<Politics> Politics { get; set; }

	}
}