using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
	public class Election
	{
		[Key]
		public int ElectionId { get; set; }
		public string ElectionType { get; set; }

		public virtual ICollection<State> State { get; set; }
	}
}