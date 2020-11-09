using Microsoft.EntityFrameworkCore;

namespace MDGriphe.Experiments.Lumia950.WebHost.Core.Data
{
	public interface IVisitorsDbContext
	{
		DbSet<Visit> Visitors { get; set; }
	}
}
