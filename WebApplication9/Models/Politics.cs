using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9.Models
{
	public class Politics
	{
		[Key]
		public int PoliticsId { get; set; }
		[ForeignKey("State")]
		public int StateId { get; set; }
		public int VordId { get; set; }
		public string VordName { get; set; }
		public string PolitianName1 { get; set; }
		public string PolitianParty1 { get; set; }
		public string PolitianName2 { get; set; }
		public string PolitianParty2 { get; set; }
		public string PolitianResult { get; set; }

		public virtual ICollection<State> State { get; set; }
	}
}