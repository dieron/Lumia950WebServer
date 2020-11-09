using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDGriphe.Experiments.Lumia950.WebHost.Core.Data
{
	[Table( "Visit", Schema = "dbo")]
	public class Visit
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public DateTime Created { get; set; }

		[MaxLength(15) ]
		public string IP { get; set; }

		public string VisitorId { get; set; }
		public string Query { get; set; }
		public string Path { get; set; }
		public string Headers { get; set; }
	}
}